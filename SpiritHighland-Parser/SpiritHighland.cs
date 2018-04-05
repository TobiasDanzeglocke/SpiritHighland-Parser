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
using System.Linq;

namespace SpiritHighland_Parser {
    public class SpiritHighland {
        string firstLevel;
        string secondLevel;

        Forbidden forbidden;
        List<Unit> enemies;
        List<Unit> solutions;

        public SpiritHighland() {
            enemies = new List<Unit>();
            solutions = new List<Unit>();
        }

        public Forbidden Forbidden {
            get {
                return forbidden;
            }

            set {
                forbidden = value;
            }
        }

        public void AddLevel(string txtName) {
            string[] temp = txtName.Split('-');
            firstLevel = temp[0].Remove(0, 2);
            secondLevel = temp[1].Remove(temp[1].Length - 4, 4);
        }

        public string GetFirstLevel() {
            return firstLevel;
        }

        public string GetSecondLevel() {
            return secondLevel;
        }

        public void AddForbidden(string input) {
            forbidden = new Forbidden(input);
        }

        internal void PrintEnemies() {
            string temp = "      \"enemies\": [\n";

            foreach (var item in enemies) {
                temp += "         {\"count\": " + item.Count;
                temp += ", \"unit\": \"" + item.Name + "\"";
                temp += ", \"sr\": " + item.Senior.ToString().ToLower();
                temp += ", \"trans\": " + item.Trans;
                temp += ", \"elite\": " + item.Elite;
                temp += ", \"shield\": \"" + item.Shield + "\"},\n";
            }

            temp = temp.Remove(temp.Length - 2, 2);
            temp += "\n      ],";

            Console.WriteLine(temp);
        }

        internal void PrintSolutions() {
            string temp = "      \"solutions\": [\n         [\n";

            foreach (var item in solutions) {
                temp += "            {\"count\": " + item.Count;
                temp += ", \"unit\": \"" + item.Name + "\"";
                temp += ", \"sr\": " + item.Senior.ToString().ToLower();
                temp += ", \"trans\": " + item.Trans + "},\n";
            }

            if (solutions.Count == 0) {
                temp = temp.Remove(temp.Length - 5, 5);
                temp += "]";
            } else {
                temp = temp.Remove(temp.Length - 2, 1);
                temp += "         ]\n      ]";
            }

            Console.WriteLine(temp);
        }

        internal void PrintForbidden() {
            string temp = "      \"forbidden\": [";

            temp += forbidden.StufeStart;
            /*
            if (forbidden.StufeStart == forbidden.StufeEnd) {
                temp += forbidden.StufeStart;
            } else {
                temp += forbidden.StufeStart + "-" + forbidden.StufeEnd;
            }
            */

            foreach (var element in forbidden.NotAllowed) {
                temp += ", \"" + element + "\"";
            }
            temp += "],";

            Console.WriteLine(temp);
        }

        internal void AddEnemies(string input) {
            enemies.Add(new Unit(input));

            if (enemies.Last().Name == null) {
                enemies.RemoveAt(enemies.Count - 1);
            }
        }

        internal void AddSolutions(string input) {
            solutions.Add(new Unit(input));

            if (solutions.Last().Name == null) {
                solutions.RemoveAt(solutions.Count - 1);
            }
        }
    }
}