﻿using System;
using System.Collections.Generic;
using System.Linq;
using WoMFramework.Game.Model.Actions;

namespace WoMFramework.Game.Model
{
    public enum SchoolType
    {
        None,
        Conjuration,
    }

    public enum SubSchoolType
    {
        None,
        Creation,
        Healing
    }

    public enum DescriptorType
    {
        None,
        Acid
    }

    public enum RangeType
    {
        None,
        Touch,
    }

    public enum AreaType
    {
        None
    }

    public enum EffectType
    {
        None
    }

    public enum TargetType
    {
        None,
        Entity,
        Weapon
    }

    public enum DurationType
    {
        None,
        Instant
    }

    public enum SavingThrowType
    {
        None,
        Will,
        Reflex,
        Fortitude
    }

    public class Spell : ILearnable
    {
        public int Id { get; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public SchoolType SchoolType { get; set; }

        public SubSchoolType SubSchoolType { get; set; }

        public DescriptorType[] DescriptorTypes { get; set; }

        public List<Requirement> Requirements { get; set; }

        public ActionType CastingTime { get; set; }

        public RangeType RangeType { get; set; }

        public AreaType AreaType { get; set; }

        public EffectType EffectType { get; set; }

        public TargetType TargetType { get; set; }

        public DurationType DurationType { get; set; }

        public SavingThrowType SavingThrowType { get; set; }

        public double SpellResistance { get; set; }

        public Action<Entity, SpellEnabled> SpellEffect { get; set; }

        public Spell(int id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
        }

        public bool CanExecuteSpell(Entity me, SpellEnabled target = null)
        {
            return true;
        }

        public virtual bool ExecuteSpell(Entity me, SpellEnabled target = null)
        {
            if (!CanExecuteSpell(me, target))
            {
                return false;
            }

            SpellEffect(me, target);
            return true;
        }

        public bool CanLearn(Entity entity)
        {
            // can't learn skill 2x times
            if (entity.Spells.Any(p => p.Id == Id))
            {
                return false;
            }

            return Requirements.All(p => p.Valid(entity));
        }

        public bool Learn(Entity entity)
        {
            if (!CanLearn(entity))
            {
                return false;
            }

            var spellCast = new SpellCast(entity, this, CastingTime);

            // add actions
            entity.CombatActions.Add(spellCast);

            // add spell
            entity.Spells.Add(this);

            return true;
        }

        public bool CanUnLearn(Entity entity)
        {
            throw new NotImplementedException();
        }

        public bool UnLearn(Entity entity)
        {
            throw new NotImplementedException();
        }

        internal bool CanCast(Entity owner, SpellEnabled target)
        {
            // TODO implement conditions

            return true;
        }
    }
}
