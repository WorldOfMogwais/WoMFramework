using System;

namespace WoMFramework.Game.Enums
{
    public enum GenderType
    {
        Male,
        Female
    }

    public enum SizeType
    {
        Fine = 0,
        Diminutive = 1,
        Tiny = 2,
        Small = 3,
        Medium = 4,
        Large = 5,
        Huge = 6,
        Gargantuan = 7,
        Colossal = 8
    }

    public static class SizeTypeFunction
    {

        public static int Modifier(this SizeType sizeType)
        {
            switch (sizeType)
            {
                case SizeType.Colossal:
                    return -8;
                case SizeType.Gargantuan:
                    return -4;
                case SizeType.Huge:
                    return -2;
                case SizeType.Large:
                    return -1;
                case SizeType.Medium:
                    return 0;
                case SizeType.Small:
                    return 1;
                case SizeType.Tiny:
                    return 2;
                case SizeType.Diminutive:
                    return 4;
                case SizeType.Fine:
                    return 8;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sizeType), sizeType, null);
            }
        }
    }


    public enum ClassType
    {
        None,
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Wizard,
        Inquisitor
    }

    public enum AlignmentType
    {
        LawfulGood,
        NeutralGood,
        ChaoticGood,
        LawfulNeutral,
        TrueNeutral,
        ChaoticNeutral,
        LawfulEvil,
        NeutralEvil,
        ChaoticEvil
    }

    public enum Faction
    {
        None,
        Hero,
        Monster,
        NPC
    }

    public enum SkillType
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
    }

    public enum SkillSubType
    {
        None,
        Arcana,
        Dungeoneering,
        Engineering,
        Geography,
        History,
        Local,
        Nature,
        Nobility,
        Planes,
        Religion,
        Traps,
        Dance,
        Alchemy,
        Act,
        Farmer,
        Stonemasonry,
        Blacksmithing,
        Comedy,
        Oratory,
        Sailor,
        Sing,
        Weaponsmithing,
        String,
        Sculpture,
        Wind,
        Jewelry,
        Any,
        AnyOne,
        AnyTwo,
        AnyThree,
        Miner,
        Cloth,
        Metalworking,
        Scribe,
        Percussion,
        Soothsayer,
        Carpentry,
        Bows,
        Armor,
        Cook,
        CrystalCarving,
        Fisherman,
        Gemcutting,
        Herbalism,
        Leather,
        Librarian,
        Limericks,
        Miller,
        Merchant,
        Poisonmaking,
        Scientist,
        Soldier,
        MusicalInstruments,
        Storytelling,
        Song,
        Wood,
        Peddler,
        Weaving,
        Rope
    }

    public enum HealthState
    {
        Healthy = 1,
        Injured = 0,
        Disabled = -1,
        Dying = -2,
        Dead = -3
    }

    public enum LanguageType
    {
        Common,
        Draconic,
        Dwarven,
        Elven,
        Giant,
        Gnome,
        Halfling,
        None,
        Abyssal,
        Aquan,
        Sylvan,
        Infernal,
        Terran,
        Auran,
        Aklo,
        Ignan,
        Goblin,
        Other
    }

    public enum SlotType
    {
        None,
        Head,
        Shoulders,
        Neck,
        Chest,
        Armor,
        Belt,
        Wrists,
        Hands,
        Ring,
        Feet,
        Weapon
    }

    public enum AbilityType
    {
        Strength,
        Dexterity,
        Constitution,
        Inteligence,
        Wisdom,
        Charisma
    }

    public enum ModifierType
    {
        Strength,
        Dexterity,
        Constitution,
        Inteligence,
        Wisdom,
        Charisma,

        Speed,
        Initiative,
        Fortitude,
        Reflex,
        Will,
        AttackBonus,
        ArmorClass,
        CMB,
        CMD,

        Acrobatics,
        Appraise,
        Balance,
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
        Knowledge,
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
        UseMagicDevice,
    }

    public enum LootState
    {
        None,
        Looted,
        Unlooted,
        Special

    }

}
