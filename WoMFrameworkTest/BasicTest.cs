using System;
using WoMFramework.Game.Enums;
using WoMFramework.Game.Model;
using Xunit;

namespace WoMFramework.Game.Test
{
    public class BasicTest
    {
        [Fact]
        public void AbilityTest()
        {
            Character hero = new Character()
            {
                BaseStrength = 18,
                BaseDexterity = 16,
                BaseConstitution = 12,
                BaseInteligence = 16,
                BaseWisdom = 16,
                BaseCharisma = 10 
            };

            Assert.Equal(18, hero.BaseStrength);
            Assert.Equal(18, hero.Strength);
            Assert.Equal(4, hero.StrengthMod);

            hero.LevelClass(ClassType.Inquisitor);
        }

        [Fact]
        public void ClassLevelTest()
        {
            Character hero = new Character()
            {
                BaseStrength = 10,
                BaseDexterity = 10,
                BaseConstitution = 10,
                BaseInteligence = 10,
                BaseWisdom = 10,
                BaseCharisma = 10
            };

            Assert.Equal(0, hero.Fortitude);
            Assert.Equal(0, hero.FortitudeBaseSave);
            Assert.Equal(0, hero.ConstitutionMod);

            Assert.Equal(0, hero.BaseAttackBonus[0]);

            Assert.Equal(0, hero.GetClassLevel(ClassType.Inquisitor));

            hero.LevelClass(ClassType.Inquisitor);

            Assert.Equal(1, hero.GetClassLevel(ClassType.Inquisitor));

            Assert.Equal(2, hero.Fortitude);
            Assert.Equal(2, hero.FortitudeBaseSave);
            Assert.Equal(0, hero.ConstitutionMod);

            Assert.Equal(0, hero.BaseAttackBonus[0]);

            hero.LevelUp();

            hero.LevelClass(Enums.ClassType.Inquisitor);

            Assert.Equal(1, hero.BaseAttackBonus[0]);

        }

        [Fact]
        public void EquipeWeaponTest()
        {
            Character hero = new Character()
            {
                BaseStrength = 10,
                BaseDexterity = 10,
                BaseConstitution = 10,
                BaseInteligence = 10,
                BaseWisdom = 10,
                BaseCharisma = 10,
                SizeType = SizeType.Medium
            };


            var weapon = Weapons.DwarvenLonghammer(hero.SizeType);

            Assert.Empty(hero.Inventory);

            hero.AddToInventory(weapon);

            Assert.Single(hero.Inventory);

            Assert.True(hero.CanEquipeWeapon(SlotType.Weapon, weapon, 0, out WeaponSlot slot));

            hero.EquipeWeapon(weapon);


        }

        [Fact]
        public void EquipeMagicItemTest()
        {
            Character hero = new Character()
            {
                BaseStrength = 10,
                BaseDexterity = 10,
                BaseConstitution = 10,
                BaseInteligence = 10,
                BaseWisdom = 10,
                BaseCharisma = 10,
                SizeType = SizeType.Medium
            };

            var ring = MagicItems.RingOfTheBear();

            Assert.Empty(hero.Inventory);

            hero.AddToInventory(ring);

            Assert.Single(hero.Inventory);

            Assert.True(hero.CanEquipeItem(SlotType.Ring, ring, out EquipmentSlot slot));

            Assert.Equal(0, hero.MiscStrength);

            hero.EquipeItem(ring);

            Assert.Equal(2, hero.MiscStrength);

            hero.UnEquipeItem(ring);

            Assert.Equal(0, hero.MiscStrength);

        }
    }
}
