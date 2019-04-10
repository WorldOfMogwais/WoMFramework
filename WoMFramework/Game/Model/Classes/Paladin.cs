using System.Collections.Generic;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model.Classes
{
    public class Paladin : EntityClass
    {
        public Paladin() : base(ClassType.Paladin, true)
        {
            HitPointDiceRollEvent = new[] { 1, 10 };
            WealthDiceRollEvent = new[] { 3, 6, 0, 1 };
            Description = "Through a select, worthy few shines the power of the divine. Called paladins, these noble souls dedicate their swords and lives to the battle against evil. Knights, crusaders, and law-bringers, paladins seek not just to spread divine justice but to embody the teachings of the virtuous deities they serve. In pursuit of their lofty goals, they adhere to ironclad laws of morality and discipline. As reward for their righteousness, these holy champions are blessed with boons to aid them in their quests: powers to banish evil, heal the innocent, and inspire the faithful. Although their convictions might lead them into conflict with the very souls they would save, paladins weather endless challenges of faith and dark temptations, risking their lives to do right and fighting to bring about a brighter future.";
            Role = "Paladins serve as beacons for their allies within the chaos of battle. While deadly opponents of evil, they can also empower goodly souls to aid in their crusades. Their magic and martial skills also make them well suited to defending others and blessing the fallen with the strength to continue fighting.";
            //Alignment: Any lawful good
            Learnables.AddRange(ClassSpells()[0]);
        }

        public override int CasterMod(Entity entity) => entity.CharismaMod;

        public override Dictionary<int, List<Spell>> ClassSpells()
        {
            return new Dictionary<int, List<Spell>>()
            {
                {  0 , new List<Spell>() { } },
                {  1 , new List<Spell>() { } },
                {  2 , new List<Spell>() { } },
                {  3 , new List<Spell>() { } },
                {  4 , new List<Spell>() { } },
                {  5 , new List<Spell>() { } },
                {  6 , new List<Spell>() { } },
                {  7 , new List<Spell>() { } },
                {  8 , new List<Spell>() { } },
                {  9 , new List<Spell>() { } },
                { 10 , new List<Spell>() { } },
                { 11 , new List<Spell>() { } },
                { 12 , new List<Spell>() { } },
                { 13 , new List<Spell>() { } },
                { 14 , new List<Spell>() { } },
                { 15 , new List<Spell>() { } },
                { 16 , new List<Spell>() { } },
                { 17 , new List<Spell>() { } },
                { 18 , new List<Spell>() { } },
                { 19 , new List<Spell>() { } },
                { 20 , new List<Spell>() { } }
            };
        }

        public override void ClassLevelUp()
        {
            base.ClassLevelUp();

            FortitudeBaseSave = (int)(2 + (double)ClassLevel / 2);
            ReflexBaseSave = (int)(0 + (double)ClassLevel / 3);
            WillBaseSave = (int)(2 + (double)ClassLevel / 2);

            ClassAttackBonus = ClassLevel;
        }
    }
}