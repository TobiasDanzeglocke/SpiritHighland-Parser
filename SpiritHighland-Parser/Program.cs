/*
    Copyright 2018 Tobias Gomes Danzeglocke
    
    This file is part of SpiritHighland-Parser.

    SpiritHighland-Parser is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SpiritHighland-Parser is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SpiritHighland-Parser. If not, see <http://www.gnu.org/licenses/>.

    Diese Datei ist Teil von SpiritHighland-Parser.

    SpiritHighland-Parser ist Freie Software: Sie können es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz oder (nach Ihrer Wahl) jeder neueren
    veröffentlichten Version, weiter verteilen und/oder modifizieren.

    SpiritHighland-Parser wird in der Hoffnung, dass es nützlich sein wird, aber
    OHNE JEDE GEWÄHRLEISTUNG, bereitgestellt; sogar ohne die implizite
    Gewährleistung der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License für weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace SpiritHighland_Parser {
    public class Program {
        private static List<SpiritHighland> spiritHighlands = new List<SpiritHighland>();
        private static List<List<SpiritHighland>> alleHighlandsInGruppen = new List<List<SpiritHighland>>();

        public static void Main(string[] args) {
            List<StringBuilder> sb = ReadFromFile();
            GetDataFromInput(sb);
            SortSpiritHighlands();
            PrintAllSpiritHighlands();
            Console.Error.WriteLine("Done");
            Console.ReadLine();
        }

        private static void PrintAllSpiritHighlands() {
            int counterTopLevel = 0;

            foreach (var item in alleHighlandsInGruppen) {
                int counterDownLevel = 0;

                Console.WriteLine("\"" + alleHighlandsInGruppen.ElementAt(counterTopLevel).ElementAt(0).GetFirstLevel() + "\": {");

                foreach (var element in alleHighlandsInGruppen.ElementAt(counterTopLevel)) {
                    Console.WriteLine("   \"" + element.GetSecondLevel() + "\": {");

                    element.PrintForbidden();
                    element.PrintEnemies();
                    element.PrintSolutions();

                    int dings = alleHighlandsInGruppen.ElementAt(counterTopLevel).Count;

                    if (counterDownLevel < alleHighlandsInGruppen.ElementAt(counterTopLevel).Count - 1) {
                        Console.WriteLine("   },");
                    } else {
                        Console.WriteLine("   }");
                    }
                    counterDownLevel++;
                }

                if (counterTopLevel < alleHighlandsInGruppen.Count - 1) {
                    Console.WriteLine("},");
                } else {
                    Console.WriteLine("}");
                }
                counterTopLevel++;
            }
        }

        private static List<StringBuilder> ReadFromFile() {
            List<StringBuilder> sb = new List<StringBuilder>();

            foreach (string txtName in Directory.GetFiles(@"C:\Users\danzeglo\Documents\visual studio 2015\Projects\SpiritHighland-Parser\SpiritHighland-Parser\Daten", "*.rtf")) {
                using (StreamReader sr = new StreamReader(txtName)) {
                    StringBuilder temp_sb = new StringBuilder();
                    temp_sb.Append(txtName.Split('\\')[9]);
                    temp_sb.Append("\r\n");
                    temp_sb.Append(sr.ReadToEnd());
                    temp_sb.AppendLine();
                    sb.Add(temp_sb);
                }
            }

            return sb;
        }

        private static void SortSpiritHighlands() {

            spiritHighlands.Sort(delegate (SpiritHighland x, SpiritHighland y) {
                if (int.Parse(x.GetFirstLevel()) < int.Parse(y.GetFirstLevel())) {
                    return -1;
                } else if (int.Parse(x.GetFirstLevel()) > int.Parse(y.GetFirstLevel())) {
                    return 1;
                } else {
                    return 0;
                }
            });

            foreach (var element in spiritHighlands) {
                if (alleHighlandsInGruppen.Count < int.Parse(element.GetFirstLevel())) {
                    alleHighlandsInGruppen.Add(new List<SpiritHighland>());
                }
            }

            foreach (var element in spiritHighlands) {
                alleHighlandsInGruppen[int.Parse(element.GetFirstLevel()) - 1].Add(element);
            }

            foreach (var item in alleHighlandsInGruppen) {
                item.Sort(delegate (SpiritHighland x, SpiritHighland y) {
                    if (int.Parse(x.GetSecondLevel()) < int.Parse(y.GetSecondLevel())) {
                        return -1;
                    } else if (int.Parse(x.GetSecondLevel()) > int.Parse(y.GetSecondLevel())) {
                        return 1;
                    } else {
                        return 0;
                    }
                });
            }
        }

        private static void GetDataFromInput(List<StringBuilder> sb) {
            foreach (var file in sb) {
                List<string> stringList = Split(file.ToString()).ToList();

                string txtName = stringList[0];

                stringList.RemoveAt(0);

                stringList[0] = stringList[0].Split('{')[1];

                stringList.Remove("\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1031");
                stringList.Remove("{\\colortbl ;\\red0\\green0\\blue255;}");
                stringList.Remove("{\\*\\generator Riched20 6.3.9600}\\viewkind4\\uc1 ");
                stringList.Remove("}");
                stringList.Remove("\0");
                stringList.Remove("\\par");

                switch (stringList.Count) {
                    case 1:
                    case 7:
                        spiritHighlands.Add(StartProcedureOne(stringList, txtName));
                        break;
                    case 2:
                        spiritHighlands.Add(StartProcedureTwo(stringList, txtName));
                        break;
                    case 19:
                        spiritHighlands.Add(StartProcedureThree(stringList, txtName));
                        break;
                    case 4:
                        spiritHighlands.Add(StartProcedureFour(stringList, txtName));
                        break;
                    default:
                        Console.WriteLine("Doesn't work!!");
                        break;
                }
            }
        }

        private static string CleanSonderzeichen(string input) {
            input = input.Replace("\\'fc", "ü");
            input = input.Replace("\\'e4", "ä");
            input = input.Replace("\\'f6", "ö");
            input = input.Replace("\\'df", "ß");
            return input;
        }

        private static SpiritHighland StartProcedureFour(List<string> stringList, string txtName) {
            SpiritHighland thereCanOnlyBeOneHighlander = new SpiritHighland();
            bool startForbidden = false;
            bool startEnemy = false;
            bool startSolution = false;
            bool stopWorking = false;

            string forbidden = "";
            string temp = "";
            List<string> tempStringList = new List<string>();

            foreach (var item in stringList) {
                tempStringList.Add(CleanSonderzeichen(item));
            }

            foreach (var item in tempStringList) {

                List<string> tempList = item.Split('\\').ToList();

                foreach (var element in tempList) {
                    temp = element;
                    if (temp.Contains("Nicht erlaubt:") && !startSolution) {
                        startForbidden = true;
                    } else if (temp.Contains("Gegner") && !startSolution) {
                        startForbidden = false;
                        startEnemy = true;
                    } else if (temp.Contains("Mögliche")) {
                        startEnemy = false;
                        startSolution = true;
                    } else if (temp.Contains("Belohnung") && startSolution) {
                        stopWorking = true;
                        break;
                    }

                    if (startForbidden && !startEnemy) {
                        forbidden += temp + " ";
                    }

                    if (startEnemy && !startSolution) {
                        if (temp.Length > 0) {
                            thereCanOnlyBeOneHighlander.AddEnemies(temp);
                        }
                    }

                    if (startSolution) {
                        if (temp.Contains("par")) {
                            temp = temp.Remove(0, 3);
                        } else if (temp.Contains("line")) {
                            temp = temp.Remove(0, 4);
                        }
                        if (temp.Length > 0) {
                            thereCanOnlyBeOneHighlander.AddSolutions(temp);
                        }
                    }
                }

                if (stopWorking) {
                    break;
                }
            }

            thereCanOnlyBeOneHighlander.AddForbidden(forbidden);

            thereCanOnlyBeOneHighlander.AddLevel(txtName);

            return thereCanOnlyBeOneHighlander;
        }

        private static SpiritHighland StartProcedureThree(List<string> stringList, string txtName) {
            SpiritHighland thereCanOnlyBeOneHighlander = new SpiritHighland();
            bool startForbidden = false;
            bool startEnemy = false;
            bool startSolution = false;

            string forbidden = "";
            string temp = "";

            foreach (var item in stringList) {
                int counter = item.Count();
                temp = item.Remove(item.Count() - 4, 4);

                if (temp.Contains("Nicht erlaubt") && !startSolution) {
                    startForbidden = true;
                } else if (temp.Contains("Gegner") && !startSolution) {
                    startForbidden = false;
                    startEnemy = true;
                } else if (temp.Contains("M\\'f6gliche")) {
                    startEnemy = false;
                    startSolution = true;
                }

                if (startForbidden && !startEnemy) {
                    forbidden += temp + " ";
                }

                if (startEnemy && !startSolution) {
                    if (temp.Length > 0) {
                        thereCanOnlyBeOneHighlander.AddEnemies(temp);
                    }
                }

                if (startSolution) {
                    if (temp.Length > 0) {
                        temp = temp.Split('\\')[0];
                        thereCanOnlyBeOneHighlander.AddSolutions(temp);
                    }
                }
            }

            thereCanOnlyBeOneHighlander.AddForbidden(forbidden);

            thereCanOnlyBeOneHighlander.AddLevel(txtName);

            return thereCanOnlyBeOneHighlander;
        }

        private static SpiritHighland StartProcedureTwo(List<string> stringList, string txtName) {
            if (stringList[1].StartsWith("\\{\"thumbnail\"")) {
                stringList.RemoveAt(1);
                return StartProcedureOne(stringList, txtName);
            }

            string tempContentA = stringList[0];
            string tempContentB = stringList[1];
            List<string> stringToParse = new List<string>();
            SpiritHighland thereCanOnlyBeOneHighlander = new SpiritHighland();

            tempContentA = tempContentA.Remove(0, 40);
            string tempImage = tempContentB.Split('{')[4];
            tempContentA = tempContentA.Split('{')[0];
            tempContentB = tempContentB.Split('{')[0];
            stringToParse = tempContentA.Split(new[] { "\\line" }, StringSplitOptions.None).ToList();

            stringToParse = RemoveEmptyStringList(stringToParse);

            thereCanOnlyBeOneHighlander.AddForbidden(stringToParse[5]);

            int counter = 0;

            for (int i = 7; i < stringToParse.Count; i++) {
                if (stringToParse[i].Contains("**") || stringToParse[i].Contains("\\par")) {
                    counter = i;
                    break;
                }

                if (stringToParse[i].Length > 0) {
                    thereCanOnlyBeOneHighlander.AddEnemies(stringToParse[i]);
                }
            }

            if (tempContentB.Length != 0) {
                stringToParse = tempContentB.Split(new[] { "\\line" }, StringSplitOptions.None).ToList();

                stringToParse = RemoveEmptyStringList(stringToParse);
                for (int i = 1; i < stringToParse.Count - 1; i++) {
                    if (stringToParse[i].Length > 2) {
                        thereCanOnlyBeOneHighlander.AddSolutions(stringToParse[i]);
                    }
                }
            } else {
                for (int i = counter+1; i < stringToParse.Count; i++) {
                    if (stringToParse[i].Length > 0) {
                        thereCanOnlyBeOneHighlander.AddSolutions(stringToParse[i]);
                    }
                }
            }

            thereCanOnlyBeOneHighlander.AddLevel(txtName);

            return thereCanOnlyBeOneHighlander;
        }

        private static SpiritHighland StartProcedureOne(List<string> stringList, string txtName) {
            string tempContent = stringList[0];
            List<string> stringToParse = new List<string>();
            SpiritHighland thereCanOnlyBeOneHighlander = new SpiritHighland();

            tempContent = tempContent.Remove(0, 40);
            string tempImage = tempContent.Split('{')[4];
            tempContent = tempContent.Split('{')[0];
            stringToParse = tempContent.Split(new[] { "\\line" }, StringSplitOptions.None).ToList();

            stringToParse = RemoveEmptyStringList(stringToParse);

            thereCanOnlyBeOneHighlander.AddForbidden(stringToParse[5]);

            int counter = 7;

            for (int i = counter; i < stringToParse.Count; i++) {
                if (stringToParse[i].StartsWith(" **")) {
                    counter = i + 1;
                    break;
                }

                if (stringToParse[i].Length > 0) {
                    thereCanOnlyBeOneHighlander.AddEnemies(stringToParse[i]);
                }
            }

            for (int i = counter; i < stringToParse.Count - 1; i++) {
                string temporary = stringToParse[i];

                if (stringToParse[i].Contains("**")) {
                    counter = i;
                    break;
                }

                if (stringToParse[i].Length > 2) {
                    thereCanOnlyBeOneHighlander.AddSolutions(stringToParse[i]);
                }
            }

            thereCanOnlyBeOneHighlander.AddLevel(txtName);

            return thereCanOnlyBeOneHighlander;
        }

        private static List<string> RemoveEmptyStringList(List<string> input) {
            input.RemoveAll(PredicateIsEmpty);
            return input;
        }

        private static bool PredicateIsEmpty(string s) {
            return s == "";
        }

        public static string[] Split(string input) {
            string[] stringSeperator = new string[] { "\r\n" };

            string[] output_array = input.Split(stringSeperator, StringSplitOptions.RemoveEmptyEntries);

            return output_array;
        }
    }
}