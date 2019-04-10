using System;
using System.Collections.Generic;
using System.Text;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model
{
    public abstract class SpellEnabled
    {
        public readonly Dictionary<ModifierType, List<Func<Entity, int>>> MiscMod;
        public readonly Dictionary<ModifierType, List<Func<Entity, int>>> TempMod;

        public SpellEnabled()
        {
            // modifiers
            MiscMod = new Dictionary<ModifierType, List<Func<Entity, int>>>();
            TempMod = new Dictionary<ModifierType, List<Func<Entity, int>>>();
            foreach (ModifierType modifierType in Enum.GetValues(typeof(ModifierType)))
            {
                TempMod[modifierType] = new List<Func<Entity, int>>() { (Entity) => 0 };
                MiscMod[modifierType] = new List<Func<Entity, int>>() { (Entity) => 0 };
            }
        }
    }
}
