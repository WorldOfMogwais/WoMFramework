using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoMFramework.Game.Enums;
using WoMFramework.Game.Model;

namespace WoMFramework.Game
{
    public class Character : Entity
    {
        public Character()
        {
            // create slot types
            Equipment.CreateEquipmentSlots(new[] {
                SlotType.Head, SlotType.Shoulders, SlotType.Neck,
                SlotType.Chest,SlotType.Armor, SlotType.Belt,SlotType.Wrists,
                SlotType.Hands,SlotType.Ring,SlotType.Ring,SlotType.Feet});

            // add weaponslot
            Equipment.WeaponSlots.Add(new WeaponSlot());
        }

        public void LevelClass(ClassType classType)
        {
            base.LevelClass(classType);
        }
    }
}
