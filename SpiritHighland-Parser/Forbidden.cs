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

namespace SpiritHighland_Parser {
    public class Forbidden {
        private int stufeStart;
        private int stufeEnd;
        List<forbidden> notAllowed;

        public List<forbidden> NotAllowed {
            get {
                return notAllowed;
            }

            set {
                notAllowed = value;
            }
        }

        public int StufeStart {
            get {
                return stufeStart;
            }

            set {
                stufeStart = value;
            }
        }

        public int StufeEnd {
            get {
                return stufeEnd;
            }

            set {
                stufeEnd = value;
            }
        }

        public enum forbidden { flying, melee, range, orc, elf, human, undead, female, neutral };

        public Forbidden(string input) {
            NotAllowed = new List<forbidden>();

            List<string> tempList = RemoveEmptyStringList(input.Split(' ').ToList());

            foreach (var item in tempList) {
                int tempInt;

                if (StufeEnd < 1) {
                    if (item.Contains("-")) {
                        List<string> tempList2 = RemoveEmptyStringList(item.Split('-').ToList());

                        foreach (var element in tempList2) {
                            if (int.TryParse(element, out tempInt)) {
                                if (StufeStart < 1) {
                                    StufeStart = tempInt;
                                } else {
                                    StufeEnd = tempInt;
                                }
                            }
                        }
                    } else {
                        if (int.TryParse(item, out tempInt)) {
                            if (StufeStart < 1) {
                                StufeStart = tempInt;
                            } else {
                                StufeEnd = tempInt;
                            }
                        }
                    }
                }

                if (item.ToLower().Contains("fliegende")) {
                    NotAllowed.Add(forbidden.flying);
                } else if (item.ToLower().Contains("untote")) {
                    NotAllowed.Add(forbidden.undead);
                } else if (item.ToLower().Contains("orkische")) {
                    NotAllowed.Add(forbidden.orc);
                } else if (item.ToLower().Contains("menschlich")) {
                    NotAllowed.Add(forbidden.human);
                } else if (item.ToLower().Contains("weiblich")) {
                    NotAllowed.Add(forbidden.female);
                } else if (item.ToLower().Contains("nahkampf")) {
                    NotAllowed.Add(forbidden.melee);
                } else if (item.ToLower().Contains("elfische")) {
                    NotAllowed.Add(forbidden.elf);
                } else if (item.ToLower().Contains("neutral")) {
                    NotAllowed.Add(forbidden.neutral);
                } else if (item.ToLower().Contains("fernkampf")) {
                    NotAllowed.Add(forbidden.range);
                }
            }
        }

        internal List<string> RemoveEmptyStringList(List<string> input) {
            input.RemoveAll(PredicateIsEmpty);
            return input;
        }

        internal bool PredicateIsEmpty(string s) {
            return s == "";
        }
    }
}
