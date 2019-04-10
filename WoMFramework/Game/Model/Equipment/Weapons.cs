using System;
using System.Collections.Generic;
using System.Text;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model
{
    public class Weapons
    {
        public static Weapon DwarvenLonghammer(SizeType sizeType)
        {
            var weapon = new Weapon(
                "Dwarven Longhammer",
                WeaponBaseType.Longhammer,
                WeaponSubType.None,
                WeaponProficiencyType.Exotic,
                WeaponEffortType.TwoHanded,
                new int[] { 2, 6, 0, 0 },
                WeaponAttackType.Primary,
                20,
                3,
                new WeaponDamageType[] { WeaponDamageType.Bludgeoning },
                0,
                sizeType,
                70.0,
                20.0,
                "These heavy-headed bludgeons are often carved or cast with monstrous " +
                "faces or drilled with tiny holes to create a menacing whistling as they " +
                "are swung through the air.");

            // add reach
            //weapon.Modifiers.Add();


            return weapon;
        }
    }
}
