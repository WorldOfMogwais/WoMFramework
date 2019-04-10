using System.Collections.Generic;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model.Classes
{
    public class Barbarian : EntityClass
    {
        public Barbarian() : base(ClassType.Barbarian, false)
        {
            HitPointDiceRollEvent = new[] { 1, 12 };
            WealthDiceRollEvent = new[] { 3, 6, 0, 1 };
            Description = "For some, there is only rage. In the ways of their people, in the fury of their passion, " +
                "in the howl of battle, conflict is all these brutal souls know. Savages, hired muscle, masters of " +
                "vicious martial techniques, they are not soldiers or professional warriors—they are the battle possessed, " +
                "creatures of slaughter and spirits of war. Known as barbarians, these warmongers know little of training, " +
                "preparation, or the rules of warfare; for them, only the moment exists, with the foes that stand before " +
                "them and the knowledge that the next moment might hold their death. They possess a sixth sense in regard " +
                "to danger and the endurance to weather all that might entail. These brutal warriors might rise from all " +
                "walks of life, both civilized and savage, though whole societies embracing such philosophies roam the wild " +
                "places of the world. Within barbarians storms the primal spirit of battle, and woe to those who face their rage.";
            Role = "Barbarians excel in combat, possessing the martial prowess and fortitude to take on foes seemingly far " +
                "superior to themselves. With rage granting them boldness and daring beyond that of most other warriors, " +
                "barbarians charge furiously into battle and ruin all who would stand in their way.";
            //Alignment: Any nonlawful.
            Learnables.AddRange(ClassSpells()[0]);
        }

        public override int CasterMod(Entity entity) => int.MinValue;

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
            WillBaseSave = (int)(0 + (double)ClassLevel / 3);

            ClassAttackBonus = ClassLevel;
        }
    }
}
