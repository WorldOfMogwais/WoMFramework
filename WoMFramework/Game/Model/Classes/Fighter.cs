﻿using System.Collections.Generic;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model.Classes
{
    public class Fighter : EntityClass
    {
        public Fighter() : base(ClassType.Fighter, false)
        {
            HitPointDiceRollEvent = new[] { 1, 10 };
            WealthDiceRollEvent = new[] { 3, 6, 0, 1 };
            Description = "Some take up arms for glory, wealth, or revenge. Others do battle to prove themselves, to protect others, or because they know nothing else. Still others learn the ways of weaponcraft to hone their bodies in battle and prove their mettle in the forge of war. Lords of the battlefield, fighters are a disparate lot, training with many weapons or just one, perfecting the uses of armor, learning the fighting techniques of exotic masters, and studying the art of combat, all to shape themselves into living weapons. Far more than mere thugs, these skilled warriors reveal the true deadliness of their weapons, turning hunks of metal into arms capable of taming kingdoms, slaughtering monsters, and rousing the hearts of armies. Soldiers, knights, hunters, and artists of war, fighters are unparalleled champions, and woe to those who dare stand against them.";
            Role = "Fighters excel at combat—defeating their enemies, controlling the flow of battle, and surviving such sorties themselves. While their specific weapons and methods grant them a wide variety of tactics, few can match fighters for sheer battle prowess.";
            //Alignment: Any 
            Learnables.AddRange(ClassLearnables()[0]);
        }

        public override int CasterMod(Entity entity) => int.MinValue;

        public override Dictionary<int, List<ILearnable>> ClassLearnables()
        {
            return new Dictionary<int, List<ILearnable>>()
            {
                {  0 , new List<ILearnable>() { } }
            };
        }

        public override void ClassLevelUp()
        {
            base.ClassLevelUp();

            FortitudeBaseSave = (int)(2 + (double)ClassLevel / 2);
            ReflexBaseSave = (int)(0 + (double)ClassLevel / 3);
            WillBaseSave = (int)(0 + (double)ClassLevel / 3);

            ClassAttackBonus = ClassLevel;

            if (ClassLearnables().TryGetValue(ClassLevel, out List<ILearnable> list))
            {
                Learnables.AddRange(list);
            }
        }
    }
}