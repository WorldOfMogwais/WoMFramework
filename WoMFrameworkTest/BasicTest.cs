using System;
using System.Linq;
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

            Assert.False(hero.BasicSkills.Find(p => p.SkillType == SkillType.Intimidate).IsClassSkill);

            hero.LevelClass(ClassType.Inquisitor);

            Assert.True(hero.BasicSkills.Find(p => p.SkillType == SkillType.Intimidate).IsClassSkill);

            Assert.Equal(1, hero.GetClassLevel(ClassType.Inquisitor));

            Assert.Equal(2, hero.Fortitude);
            Assert.Equal(2, hero.FortitudeBaseSave);
            Assert.Equal(0, hero.ConstitutionMod);

            Assert.Equal(0, hero.BaseAttackBonus[0]);

            hero.LevelUp();

            hero.LevelClass(ClassType.Inquisitor);

            Assert.Equal(1, hero.BaseAttackBonus[0]);

        }

        [Fact]
        public void ClassLearnablesTest()
        {
            Character hero = new Character()
            {
                BaseStrength = 10,
                BaseDexterity = 10,
                BaseConstitution = 10,
                BaseInteligence = 10,
                BaseWisdom = 12,
                BaseCharisma = 10
            };

            hero.LevelClass(ClassType.Inquisitor);
            hero.LevelUp();

            Assert.Equal(0, hero.MiscInitiative);

            Assert.Empty(hero.Feats);

            hero.LevelClass(ClassType.Inquisitor);

            Assert.Equal(2, hero.GetClassLevel(ClassType.Inquisitor));

            Assert.Single(hero.Feats);

            Assert.Equal("Cunning Initiative", hero.Feats[0].Name);

            Assert.Equal(1, hero.MiscMod(hero, ModifierType.Initiative));

            Assert.Equal(1, hero.MiscInitiative);

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
        public void EquipeMagicItemTest1()
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

            var belt = MagicItems.BeltOfGiantStrength();

            Assert.Empty(hero.Inventory);

            hero.AddToInventory(belt);

            Assert.Single(hero.Inventory);

            Assert.True(hero.CanEquipeItem(SlotType.Belt, belt, out EquipmentSlot slot));

            Assert.Equal(0, hero.MiscStrength);

            hero.EquipeItem(belt);

            Assert.Equal(2, hero.MiscStrength);

            hero.UnEquipeItem(belt);

            Assert.Equal(0, hero.MiscStrength);

        }

        [Fact]
        public void EquipeMagicItemTest2()
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

            var ring = MagicItems.RingOfAcrobatics();

            Assert.Empty(hero.Inventory);

            hero.AddToInventory(ring);

            Assert.Single(hero.Inventory);

            Assert.True(hero.CanEquipeItem(SlotType.Ring, ring, out EquipmentSlot slot));

            Assert.Equal(0, hero.BasicSkillInfo(SkillType.Acrobatics)[2]);

            hero.EquipeItem(ring);

            Assert.Equal(1, hero.BasicSkillInfo(SkillType.Acrobatics)[2]);

            hero.UnEquipeItem(ring);

            Assert.Equal(0, hero.MiscStrength);

        }

        [Fact]
        public void UnitySampleTest()
        {
            Character hero = new Character()
            {
                Name = "Kazmuk",

                BaseStrength = 16,
                BaseDexterity = 16,
                BaseConstitution = 12,
                BaseInteligence = 16,
                BaseWisdom = 16,
                BaseCharisma = 10,

                SizeType = SizeType.Medium,
                BaseSpeed = 30
            };

            var weapon = Weapons.DwarvenLonghammer(hero.SizeType);
            hero.AddToInventory(weapon);
            hero.EquipeWeapon(weapon);

            var belt = MagicItems.BeltOfGiantStrength();
            hero.AddToInventory(belt);
            hero.EquipeItem(belt);

            Assert.Equal(0, hero.MiscInitiative);

            hero.LevelClass(ClassType.Inquisitor);
            hero.LevelUp();

            hero.LevelClass(ClassType.Inquisitor);

            Assert.Equal(3, hero.MiscInitiative);

        }

        [Fact]
        public void BasicSkillTest()
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

            hero.LevelClass(ClassType.Inquisitor);

            foreach (SkillType skillType in Enum.GetValues(typeof(SkillType)).OfType<SkillType>().ToList())
            {
                int[] basicSkillInfo = hero.BasicSkillInfo(skillType);
                Assert.Equal(0, basicSkillInfo[0]);
                Assert.Equal(0, basicSkillInfo[1]);
                Assert.Equal(0, basicSkillInfo[2]);
            }

        }
    }
}
