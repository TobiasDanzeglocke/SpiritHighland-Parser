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

namespace SpiritHighland_Parser {
    public class Unit_Dicitonary {
        Dictionary<string, string> translation = new Dictionary<string, string>();

        public Unit_Dicitonary() {
            createDictionary();
        }

        public void createDictionary() {
            translation.Add("infanterie", "infantry");
            translation.Add("entwickelter infanterie", "infantry");
            translation.Add("schwere infanterie", "heavy infantry");
            translation.Add("entwickelte schwere infantrie", "heavy infantry");
            translation.Add("feuervogel", "fire bird");
            translation.Add("entwickelter feuervogel", "fire bird");
            translation.Add("musketier", "musketeer");
            translation.Add("entwickelter musketier", "musketeer");
            translation.Add("hammerritter", "hammer knight");
            translation.Add("hammer ritter", "hammer knight");
            translation.Add("entwickelter hammer ritter", "hammer knight");
            translation.Add("kavallerie ritter", "cavalry knight");
            translation.Add("entwickelter kavallerie ritter", "cavalry knight");
            translation.Add("golem", "golem");
            translation.Add("entwickelter golem", "golem");
            translation.Add("flammenzauberin", "fire mage");
            translation.Add("flammenmagier", "fire mage");
            translation.Add("feuermagier", "fire mage");
            translation.Add("entwickelter feuermagier", "fire mage");
            translation.Add("kannonier", "gunner");
            translation.Add("entwickelter kannonier", "gunner");
            translation.Add("priester", "priest");
            translation.Add("entwickelter priester", "priest");
            translation.Add("aladdin", "aladdin");
            translation.Add("entwickelter aladdin", "aladdin");
            translation.Add("greifenreiter", "griffin rider");
            translation.Add("greifen reiter", "griffin rider");
            translation.Add("entwickelter greifen reiter", "griffin rider");
            translation.Add("heißblütiger xuanzang", "hot-blooded xuanzang");
            translation.Add("höherer heißblütiger xuanzang", "hot-blooded xuanzang");
            translation.Add("pilot", "pilot");
            translation.Add("höherer pilot", "pilot");
            translation.Add("steampunk", "steampunk");
            translation.Add("senior-steampunk", "steampunk");
            translation.Add("walkyre", "valkyrie");
            translation.Add("walküre", "valkyrie");
            translation.Add("senior-walküre", "valkyrie");
            translation.Add("senior-walkyre", "valkyrie");
            translation.Add("flammengeist", "flame spirit");
            translation.Add("höherer flammengeist", "flame spirit");
            translation.Add("kleriker", "cleric");
            translation.Add("höherer kleriker", "cleric");
            translation.Add("geflügelter ritter", "winged knight");
            translation.Add("höherer geflügelter ritter", "winged knight");
            translation.Add("elfenbogenschütze", "elf archer");
            translation.Add("elfen bogenschütze", "elf archer");
            translation.Add("entwickelter elfen bogenschütze", "elf archer");
            translation.Add("elfen krieger", "elf warrior");
            translation.Add("elfenkrieger", "elf warrior");
            translation.Add("entwickelter elfenkrieger", "elf warrior");
            translation.Add("giftbogenschütze", "poison archer");
            translation.Add("gift bogenschütze", "poison archer");
            translation.Add("entwickelter giftbogenschütze", "poison archer");
            translation.Add("hochelfenbogenschütze", "high elf archer");
            translation.Add("hochelfen bogenschütze", "high elf archer");
            translation.Add("entwickelter hochelfen bogenschützetranslation.Add(", "high elf archer");
            translation.Add("grüner adler", "green eagle");
            translation.Add("entwickelter grüner adler", "green eagle");
            translation.Add("windmagier", "wind mage");
            translation.Add("entwickelter windmagier", "wind mage");
            translation.Add("ent", "ent");
            translation.Add("entwickelter ent", "ent");
            translation.Add("wolfkrieger", "wolf warrior");
            translation.Add("wolfskrieger", "wolf warrior");
            translation.Add("entwickelter wolfskrieger", "wolf warrior");
            translation.Add("einhornritter", "unicorn knight");
            translation.Add("einhorn ritter", "unicorn knight");
            translation.Add("entwickelter einhorn ritter", "unicorn knight");
            translation.Add("fee", "fairy");
            translation.Add("entwickelte fee", "fairy");
            translation.Add("wächter des waldes", "forest guardian");
            translation.Add("entwickelter wächter des waldes", "forest guardian");
            translation.Add("druide", "druid");
            translation.Add("entwickelter druide", "druid");
            translation.Add("hoyden goku", "hoyden goku");
            translation.Add("höherer hoyden goku", "hoyden goku");
            translation.Add("alchemist", "alchemist");
            translation.Add("höherer alchemist", "alchemist");
            translation.Add("sylphide", "sylphid");
            translation.Add("senior-sylphide", "sylphid");
            translation.Add("schwerttänzerin", "sword dancer");
            translation.Add("senior-schwerttänzerin", "sword dancer");
            translation.Add("hippogriff", "hippogriff");
            translation.Add("höherer hippogriff", "hippogriff");
            translation.Add("elementarmagier", "elementalist");
            translation.Add("höherer elementarmagier", "elementalist");
            translation.Add("windläufer", "windwalker");
            translation.Add("höherer windläufer", "windwalker");
            translation.Add("skelett", "skeleton unit");
            translation.Add("entwickeltes skelett", "skeleton unit");
            translation.Add("hexenmeister", "warlock");
            translation.Add("entwickelter hexenmeister", "warlock");
            translation.Add("geist", "ghost");
            translation.Add("entwickelter geist", "ghost");
            translation.Add("skelettkrieger", "skeleton warrior");
            translation.Add("entwickelter skelettkrieger", "skeleton warrior");
            translation.Add("großer hammer krieger", "great hammer unit");
            translation.Add("großer hammerkrieger", "great hammer unit");
            translation.Add("große hammerkrieger", "great hammer unit");
            translation.Add("entwickelter großer hammerkrieger", "great hammer unit");
            translation.Add("schwarzmagie zauberer", "black magic wizard");
            translation.Add("dunkler zauberer", "black magic wizard");
            translation.Add("entwickelter schwarzmagie zauberertranslation.Add(", "black magic wizard");
            translation.Add("hände des todes", "hands of death");
            translation.Add("entwickelte hände des todes", "hands of death");
            translation.Add("skelett bomber", "bomb unit");
            translation.Add("entwickelter skelett bomber", "bomb unit");
            translation.Add("todesritter", "death knight");
            translation.Add("entwickelter todesritter", "death knight");
            translation.Add("dunkler bogenschütze", "dark archer");
            translation.Add("entwickelter dunkler bogenschütze", "dark archer");
            translation.Add("ninja des todes", "dark ninja");
            translation.Add("ninja der dunkelheit", "dark ninja");
            translation.Add("ninja der dunkeltheit", "dark ninja");
            translation.Add("entwickelter ninja der dunkelheit", "dark ninja");
            translation.Add("succubus", "succubus");
            translation.Add("sukkubus", "succubus");
            translation.Add("entwickelter sukkubus", "succubus");
            translation.Add("dunkler admiral", "dark admiral");
            translation.Add("höherer dunkler admiral", "dark admiral");
            translation.Add("höherer admiral", "dark admiral");
            translation.Add("lich", "lich");
            translation.Add("höherer lich", "lich");
            translation.Add("medusa", "medusa");
            translation.Add("senior-medusa", "medusa");
            translation.Add("inkubus", "incubus");
            translation.Add("senior-inkubus", "incubus");
            translation.Add("dunkler geist", "dark spirit");
            translation.Add("höherer dunkler geist", "dark spirit");
            translation.Add("dunkle elfe", "dark elf");
            translation.Add("höhere dunkle elfe", "dark elf");
            translation.Add("abgrundmagier", "abyss mage");
            translation.Add("höherer abgrundmagier", "abyss mage");
            translation.Add("ork kämpfer", "orc fighter");
            translation.Add("entwickelter ork kämpfer", "orc fighter");
            translation.Add("ork jäger", "orc hunter");
            translation.Add("orkjäger", "orc hunter");
            translation.Add("entwickelter ork jäger", "orc hunter");
            translation.Add("frostmagier", "frost mage");
            translation.Add("entwickelter frostmagier", "frost mage");
            translation.Add("ork flieger", "orc wing");
            translation.Add("entwickelter ork flieger", "orc wing");
            translation.Add("orkflieger", "orc wing");
            translation.Add("ork hammereinheit", "orc hammer unit");
            translation.Add("entwickelte ork hammereinheit", "orc hammer unit");
            translation.Add("ork axteinheit", "orc ax unit");
            translation.Add("entwickelte ork axteinheit", "orc ax unit");
            translation.Add("bigfoot", "big foot");
            translation.Add("entwickelter bigfoot", "big foot");
            translation.Add("eismagier", "ice wizard");
            translation.Add("eiszauberer", "ice wizard");
            translation.Add("entwickelter eiszauberer", "ice wizard");
            translation.Add("wolfsreiter", "wolf rider");
            translation.Add("entwickelter wolfsreiter", "wolf rider");
            translation.Add("kampf trommler", "battle drummer");
            translation.Add("entwickelter kampf trommler", "battle drummer");
            translation.Add("zauberer", "sorcerer");
            translation.Add("entwickelter zauberer", "sorcerer");
            translation.Add("raptorreiter", "raptor rider");
            translation.Add("höherer raptorreiter", "raptor rider");
            translation.Add("lindwurmreiter", "wyvern rider");
            translation.Add("höherer lindwurmreiter", "wyvern rider");
            translation.Add("naga", "naga");
            translation.Add("senior-naga", "naga");
            translation.Add("eisgeist", "ice spirit");
            translation.Add("senior-eisgeist", "ice spirit");
            translation.Add("klingenmeister", "blade master");
            translation.Add("höherer klingenmeister", "blade master");
            translation.Add("frostdämon", "frost demon");
            translation.Add("höherer frostdämon", "frost demon");
            translation.Add("sirene", "siren");
            translation.Add("höherer sirene", "siren");
        }

        public string Translate(string input) {
            string temp = input.ToLower();
            string output;
            if (translation.TryGetValue(input.ToLower(), out output)) {
                return output;
            } else {
                return null;
            }
        }
    }
}
