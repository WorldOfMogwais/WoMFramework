using System.Collections.Generic;
using WoMFramework.Game.Enums;
using WoMFramework.Game.Model.Actions;

namespace WoMFramework.Game.Model.Classes
{
    public class Inquisitor : EntityClass
    {
        public Inquisitor() : base(ClassType.Inquisitor, true)
        {
            HitPointDiceRollEvent = new[] { 1, 8 };
            WealthDiceRollEvent = new[] { 4, 6, 0, 1 };
            Description = "Grim and determined, the inquisitor roots out enemies of the faith, using trickery and guile when righteousness and purity is not enough. Although inquisitors are dedicated to a deity, they are above many of the normal rules and conventions of the church. They answer to their deity and their own sense of justice alone, and are willing to take extreme measures to meet their goals.";
            Role = "Inquisitors tend to move from place to place, chasing down enemies and researching emerging threats. As a result, they often travel with others, if for no other reason than to mask their presence. Inquisitors work with members of their faith whenever possible, but even such allies are not above suspicion.";
            //Alignment: An inquisitor’s alignment must be within one step of her deity’s, along either the law/chaos axis or the good/evil axis.
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
            ReflexBaseSave = (int)(0 + (double)ClassLevel / 3);
            WillBaseSave = (int)(2 + (double)ClassLevel / 2);

            ClassAttackBonus = (ClassLevel - 1) - (int)((double)(ClassLevel - 1) / 4);
        }

        public Feat CunningInitiative()
        {
            var feat = new Feat(10001, "Cunning Initiative")
            {
                Description = "At 2nd level, an inquisitor adds her Wisdom modifier on initiative checks, in addition to her Dexterity modifier.",
                Requirements = new List<Requirement>() { },
                //Modifiers = new List<Modifier>() { new Modifier() { } },
                CombatActions = new List<CombatAction>() { },
                IsActive = false
            };
            return feat;
        }
    }
}