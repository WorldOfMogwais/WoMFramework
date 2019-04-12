using System;
using System.Collections.Generic;
using System.Linq;
using WoMFramework.Game.Enums;
using WoMFramework.Game.Model.Actions;
using WoMFramework.Game.Model.Classes;
using WoMFramework.Game.Model.Learnable;
using WoMFramework.Game.Random;

namespace WoMFramework.Game.Model
{
    public abstract partial class Entity
    {
        public int GetRequirementValue(RequirementType requirementType, object addValue = null)
        {
            switch (requirementType)
            {
                case RequirementType.Strength:
                    return Strength;
                case RequirementType.Dexterity:
                    return Dexterity;
                case RequirementType.Consititution:
                    return Constitution;
                case RequirementType.Intelligence:
                    return Inteligence;
                case RequirementType.Wisdom:
                    return Wisdom;
                case RequirementType.Charisma:
                    return Charisma;
                case RequirementType.Skill:
                    throw new NotImplementedException();
                case RequirementType.Level:
                    return CurrentLevel;
                case RequirementType.CasterLevel:
                    var casterClasses = Classes.Where(p => p.CanCast);
                    return casterClasses.Any() ? casterClasses.Max(p => p.ClassLevel) : 0;
                case RequirementType.FighterLevel:
                    var fighterClasses = Classes.Where(p => !p.CanCast);
                    return fighterClasses.Any() ? fighterClasses.Max(p => p.ClassLevel) : 0;
                case RequirementType.BaseAttack:
                    return BaseAttackBonus[0];
                default:
                    throw new ArgumentOutOfRangeException(nameof(requirementType), requirementType, null);
            }
        }
    }

    public abstract partial class Entity : SpellEnabled
    {
        public string Name { get; set; }

        public int Gender { get; set; }
        public string GenderStr => ((GenderType)Gender).ToString();

        public SizeType SizeType { get; set; }

        #region abilities

        public int Strength => BaseStrength + MiscStrength + TempStrength;
        public int StrengthMod => Modifier(Strength);
        public int BaseStrength { get; set; }
        public int MiscStrength => MiscMod(this, ModifierType.Strength);
        public int TempStrength => TempMod(this, ModifierType.Strength);

        public int Dexterity => BaseDexterity + MiscDexterity + TempDexterity;
        public int DexterityMod => Modifier(Dexterity);
        public int BaseDexterity { get; set; }
        public int MiscDexterity => MiscMod(this, ModifierType.Dexterity);
        public int TempDexterity => TempMod(this, ModifierType.Dexterity);

        public int Constitution => BaseConstitution + MiscConstitution + TempConstitution;
        public int ConstitutionMod => Modifier(Constitution);
        public int BaseConstitution { get; set; }
        public int MiscConstitution => MiscMod(this, ModifierType.Constitution);
        public int TempConstitution => TempMod(this, ModifierType.Constitution);

        public int Inteligence => BaseInteligence + MiscInteligence + TempInteligence;
        public int InteligenceMod => Modifier(Inteligence);
        public int BaseInteligence { get; set; }
        public int MiscInteligence => MiscMod(this, ModifierType.Inteligence);
        public int TempInteligence => TempMod(this, ModifierType.Inteligence);

        public int Wisdom => BaseWisdom + MiscWisdom + TempWisdom;
        public int WisdomMod => Modifier(Wisdom);
        public int BaseWisdom { get; set; }
        public int MiscWisdom => MiscMod(this, ModifierType.Wisdom);
        public int TempWisdom => TempMod(this, ModifierType.Wisdom);

        public int Charisma => BaseCharisma + MiscCharisma + TempCharisma;
        public int CharismaMod => Modifier(Charisma);
        public int BaseCharisma { get; set; }
        public int MiscCharisma => MiscMod(this, ModifierType.Charisma);
        public int TempCharisma => TempMod(this, ModifierType.Charisma);

        private int Modifier(int ability) => (int)Math.Floor((ability - 10) / 2.0);

        private int GetAbility(ModifierType modifierType) {
            switch (modifierType)
            {
                case ModifierType.Strength:
                    return StrengthMod;
                case ModifierType.Dexterity:
                    return DexterityMod;
                case ModifierType.Constitution:
                    return ConstitutionMod;
                case ModifierType.Inteligence:
                    return InteligenceMod;
                case ModifierType.Wisdom:
                    return WisdomMod;
                case ModifierType.Charisma:
                    return CharismaMod;
                default:
                    throw new Exception();
            }
        }

        #endregion

        public int CurrentLevel { get; set; } = 1;

        // base speed
        public int BaseSpeed { get; set; }

        // calculate encumbarance and stuff like that ...
        public int Speed => BaseSpeed + MiscMod(this, ModifierType.Speed) + TempMod(this, ModifierType.Speed);

        public int NaturalArmor { get; set; }
        // armorclass = 10 + armor bonus + shield bonus + dex modifier + size modifier + natural armor + deflection + misc modifier
        public int ArmorClass => 10 + Equipment.ArmorBonus + Equipment.ShieldBonus + DexterityMod + SizeType.Modifier() + NaturalArmor + MiscArmorClass + TempArmorClass;
        public int MiscArmorClass => MiscMod(this, ModifierType.ArmorClass);
        public int TempArmorClass => TempMod(this, ModifierType.ArmorClass);

        // hitpoints
        public int HitPointDice { get; set; }
        public int[] HitPointDiceRollEvent { get; set; }
        public List<int> HitPointLevelRolls { get; }
        public int MaxHitPoints => HitPointDice + HitPointLevelRolls.Sum();

        // damage
        public int DamageTaken { get; set; }

        public int CurrentHitPoints => MaxHitPoints - DamageTaken;

        // initiative = dex modifier + misc modifier
        public int Initiative => DexterityMod + MiscInitiative + TempInitiative;
        public int MiscInitiative => MiscMod(this, ModifierType.Initiative);
        public int TempInitiative => TempMod(this, ModifierType.Initiative);

        #region saving throws

        //saving throw = basesave + abilitymod + misc modifier + magic modifier + temp modifier
        public int FortitudeBaseSave { get; set; }
        public int Fortitude => FortitudeBaseSave + ConstitutionMod + MiscFortitude + TempFortitude;
        public int MiscFortitude => MiscMod(this, ModifierType.Fortitude);
        public int TempFortitude => TempMod(this, ModifierType.Fortitude);

        public int ReflexBaseSave { get; set; }
        public int Reflex => ReflexBaseSave + DexterityMod + MiscReflex + TempReflex;
        public int MiscReflex => MiscMod(this, ModifierType.Reflex);
        public int TempReflex => TempMod(this, ModifierType.Reflex);

        public int WillBaseSave { get; set; }
        public int Will => WillBaseSave + WisdomMod + MiscWill + TempWill;
        public int MiscWill => MiscMod(this, ModifierType.Will);
        public int TempWill => TempMod(this, ModifierType.Will);

        #endregion

        // base attack bonus = class dependent value
        public int[] BaseAttackBonus { get; set; } = new int[] { 0 };

        // combat maneuver bonus
        public int Cmb => BaseAttackBonus[0] + StrengthMod + SizeType.Modifier() + MiscCmb;
        public int MiscCmb => MiscMod(this, ModifierType.CMB);

        // combat maneuver defense
        public int Cmd => 10 + BaseAttackBonus[0] + StrengthMod + DexterityMod + SizeType.Modifier() + MiscCmd;
        public int MiscCmd => MiscMod(this, ModifierType.CMD);

        // attackbonus = base attack bonus + strength modifier + size modifier
        public int AttackBonus(int attackIndex) => BaseAttackBonus[attackIndex] + StrengthMod + SizeType.Modifier() + MiscMod(this, ModifierType.AttackBonus) + TempMod(this, ModifierType.AttackBonus);

        // attack roll
        public int[] AttackRolls(int attackIndex, int criticalMinRoll = 21)
        {
            var rolls = new List<int>();
            for (var i = 0; i < 3; i++)
            {
                var lastRoll = Dice.Roll(DiceType.D20);
                rolls.Add(lastRoll + AttackBonus(attackIndex));
                if (lastRoll < criticalMinRoll)
                    break;
            }
            return rolls.ToArray();
        }

        // initiative roll
        public int InitiativeRoll => Dice.Roll(DiceType.D20) + Initiative;

        // damage
        public int DamageRoll(Weapon weapon, Dice dice)
        {
            var damage = dice.Roll(WeaponDamage(weapon));
            return damage < 1 ? 1 : damage;
        }
        public int[] WeaponDamage(Weapon weapon) => new int[] { weapon.DamageRoll[0], weapon.DamageRoll[1], 0, weapon.DamageRoll[3] + WeaponStrengthMod(weapon) };
        public int WeaponStrengthMod(Weapon weapon) => (weapon.WeaponEffortType == WeaponEffortType.TwoHanded ? (int)Math.Floor(1.5 * StrengthMod) : StrengthMod);

        // injury and death
        public HealthState HealthState
        {
            get
            {
                if (CurrentHitPoints == MaxHitPoints)
                {
                    return HealthState.Healthy;
                }
                if (CurrentHitPoints > 0)
                {
                    return HealthState.Injured;
                }
                if (CurrentHitPoints == 0)
                {
                    return HealthState.Disabled;
                }
                if (CurrentHitPoints > -10)
                {
                    return HealthState.Dying;
                }

                return HealthState.Dead;
            }
        }

        // equipment
        public Equipment Equipment { get; }

        // wealth
        public int Gold { get; set; }

        // dice
        public virtual Dice Dice { get; set; }

        //public Classes.Classes CurrentClass => Classes.Count > 0 ? Classes[0] : null;
        public List<EntityClass> Classes { get; }
        public int GetClassLevel(ClassType classType)
        {
            var classes = Classes.FirstOrDefault(p => p.ClassType == classType);
            return classes?.ClassLevel ?? 0;
        }

        public EnvironmentType[] EnvironmentTypes { get; set; }

        public List<Skill> BasicSkills { get; set; }

        public int BasicSkill(SkillType skillType)
        {
            var array = BasicSkillInfo(skillType);
            return array.Sum();
        }

        public int[] BasicSkillInfo(SkillType skillType) {
            var skill = BasicSkills.Where(p => p.SkillType == skillType).First();
            return new int[] { GetAbility(skill.KeyAbility), skill.Ranks, MiscMod(this, (ModifierType)Enum.Parse(typeof(ModifierType), skillType.ToString()))};
        }

        public List<Feat> Feats { get; set; }

        public List<Spell> Spells { get; set; }

        public List<BaseItem> Inventory { get; }

        public List<CombatAction> CombatActions { get; set; }

        public int CurrentInitiative { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Entity()
        {
            // initialize
            HitPointLevelRolls = new List<int>();
            Equipment = new Equipment();
            Gold = 0;
            Classes = new List<EntityClass>();

            // add basic actions
            CombatActions = new List<CombatAction>();

            // add all basic skills
            BasicSkills = Skills.GetAll();

            // initialize skills list
            Feats = new List<Feat>();

            // initialize spells list
            Spells = new List<Spell>();

            // initialize inventory
            Inventory = new List<BaseItem>();

            // set Dice
            Dice = new Dice();

        }

        public void LevelUp()
        {
            CurrentLevel += 1;
        }

        protected bool CanLevelClass()
        {
            return CurrentLevel > Classes.Sum(p => p.ClassLevel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classType"></param>
        protected void LevelClass(ClassType classType, int hitPointLevelRoll = 0, bool doWealth = false)
        {
            if (!CanLevelClass())
            {
                return;
            }

            var classes = Classes.FirstOrDefault(p => p.ClassType == classType);
            if (Classes.Count == 0 || classes == null)
            {
                Classes.Insert(0, EntityClass.GetClasses(classType));
            }
            else if (Classes.Remove(classes))
            {
                Classes.Insert(0, classes);
            }

            var classesLevels = Classes.Sum(p => p.ClassLevel);

            // do the class level up
            Classes[0].ClassLevelUp();

            // level class now
            BaseAttackBonus = CalculateBaseAttackBonus(Classes.Sum(p => p.ClassAttackBonus));

            FortitudeBaseSave = Classes.Sum(p => p.FortitudeBaseSave);
            ReflexBaseSave = Classes.Sum(p => p.ReflexBaseSave);
            WillBaseSave = Classes.Sum(p => p.WillBaseSave);

            // hit point roll
            if (hitPointLevelRoll == 0)
            {
                HitPointDiceRollEvent = Classes[0].HitPointDiceRollEvent;
                hitPointLevelRoll = Dice.Roll(HitPointDiceRollEvent);
            }
            HitPointLevelRolls.Add(hitPointLevelRoll);


            // learn new class learnables
            Classes[0].Learnables.ForEach(q => Learn(q));

            // learn new class basic skills
            if (Classes[0].ClassLevel == 1)
            {
                foreach(Skill skill in BasicSkills)
                {
                    if (Classes[0].ClassBasicSkills.Contains(skill.SkillType))
                    {
                        skill.IsClassSkill = true;
                    }
                }
            }

            // initial class level
            if (doWealth && classesLevels == 0)
            {
                AddGold(Dice.Roll(Classes[0].WealthDiceRollEvent));
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lernable"></param>
        /// <returns></returns>
        public bool Learn(ILearnable lernable)
        {
            if (!lernable.CanLearn(this))
            {
                return false;
            }

            return lernable.Learn(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attackBonus"></param>
        /// <returns></returns>
        private int[] CalculateBaseAttackBonus(int attackBonus)
        {
            var currentBaseAttackBonus = attackBonus;

            var baseAttackBonusList = new List<int> { currentBaseAttackBonus };

            for (var i = currentBaseAttackBonus - 5; i > 0; i = i - 5)
            {
                baseAttackBonusList.Add(i);
            }
            return baseAttackBonusList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseItem"></param>
        /// <returns></returns>
        public bool AddToInventory(BaseItem baseItem)
        {
            // TODO check if we are not encumbered!

            Inventory.Add(baseItem);

            baseItem.ChangeOwner(this);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseItem"></param>
        /// <returns></returns>
        public bool RemoveFromInventory(BaseItem baseItem)
        {
            if (!Inventory.Contains(baseItem))
            {
                return false;
            }

            Inventory.Remove(baseItem);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotType"></param>
        /// <param name="baseItem"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public bool CanEquipeItem(SlotType slotType, BaseItem baseItem, out EquipmentSlot slot, int slotIndex = 0)
        {
            slot = Equipment.Slots.Where(p => p.SlotType == slotType).ElementAtOrDefault(slotIndex);

            return Inventory.Contains(baseItem)
                   && baseItem.SlotType == slotType
                   && slot != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotType"></param>
        /// <param name="baseItem"></param>
        /// <returns></returns>
        public bool EquipeItem(BaseItem baseItem, int slotIndex = 0)
        {
            if (!CanEquipeItem(baseItem.SlotType, baseItem, out var slot, slotIndex))
            {
                return false;
            }

            UnEquipeSlot(slot);

            slot.BasicItem = baseItem;

            // learn new item
            baseItem.Learn(this);

            return true;
        }

        public bool CanUnEquipeItem(BaseItem baseItem, out EquipmentSlot slot)
        {
            slot = Equipment.Slots.FirstOrDefault(s => s.BasicItem != null && s.BasicItem.Equals(baseItem));

            if (slot == null)
                return false;

            return true;
        }

        public bool UnEquipeItem(BaseItem baseItem)
        {
            if (!CanUnEquipeItem(baseItem, out EquipmentSlot slot))
            {
                return false;
            }

            UnEquipeSlot(slot);

            return true;
        }

        private bool UnEquipeSlot(EquipmentSlot slot)
        {
            // removed old item
            if (slot.BasicItem != null)
            {
                var oldItem = slot.BasicItem;
                slot.BasicItem = null;

                if (!AddToInventory(oldItem))
                {
                    return false;
                }

                // unlearn old item
                oldItem.UnLearn(this);
            }

            return true;
        }

        public bool CanEquipeWeapon(SlotType slotType, Weapon weapon, int slotIndex, out WeaponSlot slot)
        {
            slot = Equipment.GetWeaponSlot(slotIndex);

            return Inventory.Contains(weapon)
                   && weapon.SlotType == slotType
                   && slot != null;
        }

        public bool EquipeWeapon(Weapon baseItem, Weapon secondaryWeapon = null, int slotIndex = 0)
        {

            if (!CanEquipeWeapon(SlotType.Weapon, baseItem, slotIndex, out var slot))
            {
                return false;
            }

            // removed old item
            if (slot.PrimaryWeapon != null)
            {
                var oldItem = slot.PrimaryWeapon;
                slot.PrimaryWeapon = null;

                if (!AddToInventory(oldItem))
                {
                    return false;
                }

                // unlearn old item
                oldItem.UnLearn(this);
            }

            // add new item
            if (!RemoveFromInventory(baseItem))
            {
                return false;
            }

            slot.PrimaryWeapon = baseItem;

            // learn new item
            baseItem.Learn(this);

            // standard attack
            //CombatActions.Add(CombatAction.CreateWeaponAttack(this, baseItem, false));

            // full attack
            //CombatActions.Add(CombatAction.CreateWeaponAttack(this, baseItem, true));

            slot.PrimaryWeapon = baseItem;

            if (secondaryWeapon != null)
            {
                // TODO implement secondary weapon
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attackRolls"></param>
        /// <param name="armorClass"></param>
        /// <param name="criticalCount"></param>
        /// <returns></returns>
        private int AttackRoll(int[] attackRolls, int armorClass, out int criticalCount)
        {
            var attack = attackRolls[attackRolls.Length - 1];
            if (attack > armorClass)
            {
                criticalCount = attackRolls.Length - 1;
                return attack;
            }
            criticalCount = attackRolls.Length > 2 ? attackRolls.Length - 2 : 0;
            return attack;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gold"></param>
        public virtual void AddGold(int gold)
        {
            // nothing here ..
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="healAmount"></param>
        /// <param name="healType"></param>
        public void Heal(int healAmount, HealType healType)
        {
            if (DamageTaken <= 0 || healAmount <= 0)
            {
                return;
            }

            if (DamageTaken < healAmount)
            {
                healAmount = DamageTaken;
            }

            DamageTaken -= healAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damageAmount"></param>
        /// <param name="damageType"></param>
        public void Damage(int damageAmount, DamageType damageType)
        {
            // no damage return or same for dead entities
            if (damageAmount <= 0)
            {
                return;
            }

            DamageTaken += damageAmount;
        }

        #region AdventureEntity

        public bool TakeAction(EntityAction entityAction)
        {
            if (!entityAction.IsExecutable)
            {
                return false;
            }

            // weapon attack
            if (entityAction is WeaponAttack weaponAttack)
            {
                Attack(weaponAttack);
                return true;
            }

            // cast spell
            if (entityAction is SpellCast spellCast)
            {
                return Cast(spellCast);
            }

            return false;
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="spellCast"></param>
        /// <returns></returns>
        private bool Cast(SpellCast spellCast)
        {
            var spell = spellCast.Spell;
            var target = spellCast.Target as Entity;

            var concentrateRoll = 10;

            if (concentrateRoll > 1 && concentrateRoll > spell.Level)
            {
                //spell.SpellEffect(this, target);
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weaponAttack"></param>
        /// <returns></returns>
        private void Attack(WeaponAttack weaponAttack)
        {
            var attackTimes = weaponAttack.ActionType == ActionType.Full ? BaseAttackBonus.Length : 1;
            var weapon = weaponAttack.Weapon;
            var target = weaponAttack.Target as Entity;

            //Console.WriteLine($"{Name}: is acking {attackTimes} times");

            // all attacks are calculated
            for (var attackIndex = 0; attackIndex < attackTimes; attackIndex++)
            {
                // break when target is null or dead, no more attacks on dead monsters.
                if (target == null)
                {
                    break;
                }

                //Console.WriteLine($"{weapon.Name} CriticalMinRoll: {weapon.CriticalMinRoll}");
                var attackRolls = AttackRolls(attackIndex, weapon.CriticalMinRoll);
                var attack = AttackRoll(attackRolls, target.ArmorClass, out var criticalCounts);

                if (attack > target.ArmorClass || criticalCounts > 0)
                {
                    var damage = DamageRoll(weapon, Dice);
                    var criticalDamage = 0;
                    if (criticalCounts > 0)
                    {
                        for (var i = 0; i < weapon.CriticalMultiplier - 1; i++)
                        {
                            criticalDamage += DamageRoll(weapon, Dice);
                        }
                    }

                    target.Damage(damage + criticalDamage, DamageType.Weapon);
                }

            }
        }

    }
}
