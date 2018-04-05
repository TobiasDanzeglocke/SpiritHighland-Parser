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
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpiritHighland_Parser {
    public class Unit {
        int count;
        string name;
        bool senior;
        int trans;
        int elite;
        Unit_Dicitonary dictionary;
        availableShield shield;
        public enum availableShield { m, p, none };

        public int Count {
            get {
                return count;
            }

            set {
                count = value;
            }
        }

        public string Name {
            get {
                return name;
            }

            set {
                name = value;
            }
        }

        public bool Senior {
            get {
                return senior;
            }

            set {
                senior = value;
            }
        }

        public int Trans {
            get {
                return trans;
            }

            set {
                trans = value;
            }
        }

        public int Elite {
            get {
                return elite;
            }

            set {
                elite = value;
            }
        }

        public availableShield Shield {
            get {
                return shield;
            }

            set {
                shield = value;
            }
        }

        private string CleanSonderzeichen(string input) {
            input = input.Replace("\\'fc", "ü");
            input = input.Replace("\\'e4", "ä");
            input = input.Replace("\\'f6", "ö");
            input = input.Replace("\\'df", "ß");
            return input;
        }

        public Unit(string input) {
            input = CleanSonderzeichen(input);

            dictionary = new Unit_Dicitonary();
            Senior = false;
            Trans = 0;

            List<string> tempList = RemoveEmptyStringList(input.Split(' ').ToList());

            for (int i = 0; i < tempList.Count(); i++) {
                Regex regex = new Regex("[0-9]");
                string temp = "";

                if (Count == 0) {
                    if (regex.IsMatch(tempList[i])) {
                        if (tempList[i].EndsWith("x")) {
                            temp = tempList[i].Remove(tempList[i].Length - 1, 1);
                            Count = int.Parse(temp);
                        }
                    }
                }

                if (!Senior) {
                    if (tempList[i].Contains("Entwickelte") || tempList[i].Contains("höhere") || tempList[i].Contains("Senior")) {
                        Senior = true;
                    }
                }

                if (Name == null) {
                    if (tempList[i].Contains("\\par")) {
                        tempList[i] = tempList[i].Remove(tempList[i].Length - 4, 4);
                    }
                    if (!CheckName(tempList[i])) {
                        if (i < tempList.Count() - 1) {
                            if (!CheckName(tempList[i] + " " + tempList[i + 1])) {
                                if (i < tempList.Count() - 2) {
                                    if (!CheckName(tempList[i] + " " + tempList[i + 1] + " " + tempList[i + 2])) {
                                        if (i < tempList.Count() - 3) {
                                            if (!CheckName(tempList[i] + " " + tempList[i + 1] + " " + tempList[i + 2] + " " + tempList[i + 3])) {
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (Trans == 0) {
                    regex = new Regex("T[1-3]");
                    temp = "";
                    if (regex.IsMatch(tempList[i])) {
                        temp = tempList[i].Remove(0, 1);
                        if (!int.TryParse(temp, out trans)) {
                        }
                    }
                }

                if (Elite == 0) {
                    if (tempList[i].Contains("Elite")) {
                        if (i < tempList[i].Count()) {
                            if (tempList[i].Contains("+")) {
                                foreach (var item in tempList[i]) {
                                    if (item == '+') {
                                        Elite++;
                                    }
                                }
                            } else {
                                foreach (var item in tempList[i + 1]) {
                                    if (item == '+') {
                                        Elite++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (input.Contains("physische")) {
                shield = availableShield.p;
            } else if (input.Contains("magische")) {
                shield = availableShield.m;
            } else {
                shield = availableShield.none;
            }
        }

        private bool CheckName(string item) {
            string temp = dictionary.Translate(item);

            if (temp == null) {
                return false;
            } else {
                Name = temp;
                return true;
            }
        }

        private List<string> RemoveEmptyStringList(List<string> input) {
            input.RemoveAll(PredicateIsEmpty);
            return input;
        }

        private bool PredicateIsEmpty(string s) {
            return s == "";
        }
    }
}
