using System;
using System.Collections.Generic;
using System.Text;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model.Learnable
{
    public class Skill
    {
        public int Id { get; }

        public SkillType SkillType { get; set; }

        public string Description { get; set; }

        public ModifierType KeyAbility { get; set; }

        public bool Untrained { get; set; }

        public bool ArmorCheckPenalty { get; set; }

        public bool IsClassSkill { get; set; }

        public int Ranks { get; set; }

        public Skill(int id, SkillType skillType, string description, ModifierType keyAbility, bool untrained, bool armorCheckPenalty)
        {
            Id = id;
            SkillType = skillType;

            Description = description;
            KeyAbility = keyAbility;
            Untrained = untrained;
            ArmorCheckPenalty = armorCheckPenalty;
            IsClassSkill = false;
            Ranks = 0;
        }
    }

    public class Skills
    {
        public static Skill Acrobatics => new Skill(601, SkillType.Acrobatics, "You can keep your balance while traversing narrow or treacherous surfaces. You can also dive, flip, jump, and roll, avoiding attacks and confusing your opponents.", ModifierType.Dexterity, true, true);
        public static Skill Appraise => new Skill(602, SkillType.Appraise, "You can evaluate the monetary value of an object.", ModifierType.Inteligence, false, true);
        public static Skill Bluff => new Skill(603, SkillType.Bluff, "You know how to tell a lie.", ModifierType.Charisma, false, true);
        public static Skill Climb => new Skill(604, SkillType.Climb, "You are skilled at scaling vertical surfaces, from smooth city walls to rocky cliffs.", ModifierType.Strength, true, true);
        public static Skill Craft => new Skill(605, SkillType.Craft, "You are skilled in the creation of a specific group of items, such as armor or weapons.", ModifierType.Inteligence, false, true);
        public static Skill Diplomacy => new Skill(606, SkillType.Diplomacy, "You can use this skill to persuade others to agree with your arguments, to resolve differences, and to gather valuable information or rumors from people. This skill is also used to negotiate conflicts by using the proper etiquette and manners suitable to the problem.", ModifierType.Charisma, false, true);
        public static Skill DisableDevice => new Skill(607, SkillType.DisableDevice, "You are skilled at disarming traps and opening locks. In addition, this skill lets you sabotage simple mechanical devices, such as catapults, wagon wheels, and doors.", ModifierType.Dexterity, true, false);
        public static Skill Disguise => new Skill(608, SkillType.Disguise, "You are skilled at changing your appearance.", ModifierType.Charisma, false, true);
        public static Skill EscapeArtist => new Skill(609, SkillType.EscapeArtist, "xxx", ModifierType.Dexterity, true, true);
        public static Skill Fly => new Skill(610, SkillType.Fly, "You are skilled at flying, either through the use of wings or magic, and you can perform daring or complex maneuvers while airborne. Note that this skill does not give you the ability to fly.", ModifierType.Dexterity, true, true);
        public static Skill HandleAnimal => new Skill(611, SkillType.HandleAnimal, "You are trained at working with animals, and can teach them tricks, get them to follow your simple commands, or even domesticate them.", ModifierType.Charisma, false, false);
        public static Skill Heal => new Skill(612, SkillType.Heal, "You are skilled at tending to the ailments of others.", ModifierType.Wisdom, false, true);
        public static Skill Intimidate => new Skill(613, SkillType.Intimidate, "You can use this skill to frighten your opponents or to get them to act in a way that benefits you. This skill includes verbal threats and displays of prowess.", ModifierType.Charisma, false, true);
        public static Skill KnowledgeArcana => new Skill(614, SkillType.KnowledgeArcana, "You are educated in a field of study and can answer both simple and complex questions. Arcana (ancient mysteries, magic traditions, arcane symbols, constructs, dragons, magical beasts)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeDungeoneering => new Skill(615, SkillType.KnowledgeDungeoneering, "You are educated in a field of study and can answer both simple and complex questions. Dungeoneering (aberrations, caverns, oozes, spelunking)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeEngineering => new Skill(616, SkillType.KnowledgeEngineering, "You are educated in a field of study and can answer both simple and complex questions. Engineering (buildings, aqueducts, bridges, fortifications)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeGeography => new Skill(617, SkillType.KnowledgeGeography, "You are educated in a field of study and can answer both simple and complex questions. Geography (lands, terrain, climate, people)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeHistory => new Skill(618, SkillType.KnowledgeHistory, "You are educated in a field of study and can answer both simple and complex questions. History (wars, colonies, migrations, founding of cities)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeLocal => new Skill(619, SkillType.KnowledgeLocal, "You are educated in a field of study and can answer both simple and complex questions. Local (legends, personalities, inhabitants, laws, customs, traditions, humanoids)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeNature => new Skill(620, SkillType.KnowledgeNature, "You are educated in a field of study and can answer both simple and complex questions. Nature (animals, fey, monstrous humanoids, plants, seasons and cycles, weather, vermin)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeNobility => new Skill(621, SkillType.KnowledgeNobility, "You are educated in a field of study and can answer both simple and complex questions. Nobility (lineages, heraldry, personalities, royalty)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgePlanes => new Skill(622, SkillType.KnowledgePlanes, "You are educated in a field of study and can answer both simple and complex questions. Planes (the Inner Planes, the Outer Planes, the Astral Plane, the Ethereal Plane, outsiders, planar magic)", ModifierType.Inteligence, false, false);
        public static Skill KnowledgeReligion => new Skill(623, SkillType.KnowledgeReligion, "You are educated in a field of study and can answer both simple and complex questions. Religion (gods and goddesses, mythic history, ecclesiastic tradition, holy symbols, undead)", ModifierType.Inteligence, false, false);
        public static Skill Linguistics => new Skill(624, SkillType.Linguistics, "You are skilled at working with language, in both its spoken and written forms. You can speak multiple languages, and can decipher nearly any tongue given enough time. Your skill in writing allows you to create and detect forgeries as well.", ModifierType.Inteligence, false, false);
        public static Skill Perception => new Skill(625, SkillType.Perception, "Your senses allow you to notice fine details and alert you to danger. Perception covers all five senses, including sight, hearing, touch, taste, and smell.", ModifierType.Wisdom, false, true);
        public static Skill Perform => new Skill(626, SkillType.Perform, "You are skilled at one form of entertainment, from singing to acting to playing an instrument. Like Craft, Knowledge, and Profession, Perform is actually a number of separate skills. You could have several Perform skills, each with its own ranks.", ModifierType.Charisma, false, true);
        public static Skill Profession => new Skill(627, SkillType.Profession, "You are skilled at a specific job. Like Craft, Knowledge, and Perform, Profession is actually a number of separate skills.", ModifierType.Wisdom, false, false);
        public static Skill Ride => new Skill(628, SkillType.Ride, "You are skilled at riding mounts, usually a horse, but possibly something more exotic, like a griffon or pegasus. If you attempt to ride a creature that is ill suited as a mount, you take a –5 penalty on your Ride checks.", ModifierType.Dexterity, true, true);
        public static Skill SenseMotive => new Skill(629, SkillType.SenseMotive, "You are skilled at detecting falsehoods and true intentions.", ModifierType.Wisdom, false, true);
        public static Skill SleightOfHand => new Skill(630, SkillType.SleightOfHand, "Your training allows you to pick pockets, draw hidden weapons, and take a variety of actions without being noticed.", ModifierType.Dexterity, true, false);
        public static Skill Spellcraft => new Skill(631, SkillType.Spellcraft, "You are skilled at the art of casting spells, identifying magic items, crafting magic items, and identifying spells as they are being cast.", ModifierType.Inteligence, false, false);
        public static Skill Stealth => new Skill(632, SkillType.Stealth, "You are skilled at avoiding detection, allowing you to slip past foes or strike from an unseen position. This skill covers hiding and moving silently.", ModifierType.Dexterity, true, true);
        public static Skill Survival => new Skill(633, SkillType.Survival, "You are skilled at surviving in the wild and at navigating in the wilderness. You also excel at following trails and tracks left by others.", ModifierType.Wisdom, false, true);
        public static Skill Swim => new Skill(634, SkillType.Swim, "You know how to swim and can do so even in stormy water.", ModifierType.Strength, true, true);
        public static Skill UseMagicDevice => new Skill(635, SkillType.UseMagicDevice, "You are skilled at activating magic items, even if you are not otherwise trained in their use.", ModifierType.Charisma, false, false);

        public static List<Skill> GetAll() => new List<Skill>()
        {
            Acrobatics,
            Appraise,
            Bluff,
            Climb,
            Craft,
            Diplomacy,
            DisableDevice,
            Disguise,
            EscapeArtist,
            Fly,
            HandleAnimal,
            Heal,
            Intimidate,
            KnowledgeArcana,
            KnowledgeDungeoneering,
            KnowledgeEngineering,
            KnowledgeGeography,
            KnowledgeHistory,
            KnowledgeLocal,
            KnowledgeNature,
            KnowledgeNobility,
            KnowledgePlanes,
            KnowledgeReligion,
            Linguistics,
            Perception,
            Perform,
            Profession,
            Ride,
            SenseMotive,
            SleightOfHand,
            Spellcraft,
            Stealth,
            Survival,
            Swim,
            UseMagicDevice
        };

    }
}
