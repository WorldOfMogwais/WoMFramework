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
            Learnables.AddRange(ClassLearnables()[0]);

            ClassBasicSkills = new List<SkillType> {
                SkillType.Bluff,
                SkillType.Climb,
                SkillType.Craft,
                SkillType.Diplomacy,
                SkillType.Disguise,
                SkillType.Heal,
                SkillType.Intimidate,
                SkillType.KnowledgeArcana,
                SkillType.KnowledgeDungeoneering,
                SkillType.KnowledgeNature,
                SkillType.KnowledgePlanes,
                SkillType.KnowledgeReligion,
                SkillType.Perception,
                SkillType.Profession,
                SkillType.Ride,
                SkillType.SenseMotive,
                SkillType.Spellcraft,
                SkillType.Stealth,
                SkillType.Survival,
                SkillType.Swim,
            };
        }

        public override int CasterMod(Entity entity) => entity.WisdomMod;


        public override Dictionary<int, List<ILearnable>> ClassLearnables()
        {
            return new Dictionary<int, List<ILearnable>>()
            {
                {  0 , new List<ILearnable>() { } },
                {  1 , new List<ILearnable>() { } },
                {  2 , new List<ILearnable>() { CunningInitiative() } },
            };
        }

        public override void ClassLevelUp()
        {
            base.ClassLevelUp();

            FortitudeBaseSave = (int)(2 + (double)ClassLevel / 2);
            ReflexBaseSave = (int)(0 + (double)ClassLevel / 3);
            WillBaseSave = (int)(2 + (double)ClassLevel / 2);

            ClassAttackBonus = (ClassLevel - 1) - (int)((double)(ClassLevel - 1) / 4);

            if (ClassLearnables().TryGetValue(ClassLevel, out List<ILearnable> list))
            {
                Learnables.AddRange(list);
            }
        }

        public Feat CunningInitiative()
        {
            var feat = new Feat(12001, "Cunning Initiative")
            {
                Description = "At 2nd level, an inquisitor adds her Wisdom modifier on initiative checks, in addition to her Dexterity modifier.",
                Requirements = new List<Requirement>() { },
                Modifiers = new List<Modifier>() { new SimpleModifier(ModifierType.Initiative, (Entity e) => e.WisdomMod) },
                CombatActions = new List<CombatAction>() { },
                IsActive = false
            };
            return feat;
        }
    }
}