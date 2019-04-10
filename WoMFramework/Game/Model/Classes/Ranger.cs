using System.Collections.Generic;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model.Classes
{
    public class Ranger : EntityClass
    {

        public Ranger() : base(ClassType.Ranger, true)
        {
            HitPointDiceRollEvent = new[] { 1, 10 };
            WealthDiceRollEvent = new[] { 3, 6, 0, 1 };
            Description = "For those who relish the thrill of the hunt, there are only predators and prey. Be they scouts, trackers, or bounty hunters, rangers share much in common: unique mastery of specialized weapons, skill at stalking even the most elusive game, and the expertise to defeat a wide range of quarries. Knowledgeable, patient, and skilled hunters, these rangers hound man, beast, and monster alike, gaining insight into the way of the predator, skill in varied environments, and ever more lethal martial prowess. While some track man-eating creatures to protect the frontier, others pursue more cunning game—even fugitives among their own people.";
            Role = "Rangers are deft skirmishers, either in melee or at range, capable of skillfully dancing in and out of battle. Their abilities allow them to deal significant harm to specific types of foes, but their skills are valuable against all manner of enemies.";
            //Alignment: Any
            Learnables.AddRange(ClassSpells()[0]);
        }

        public override int CasterMod(Entity entity) => entity.WisdomMod;

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
            ReflexBaseSave = (int)(2 + (double)ClassLevel / 2);
            WillBaseSave = (int)(0 + (double)ClassLevel / 3);

            ClassAttackBonus = ClassLevel;
        }
    }
}