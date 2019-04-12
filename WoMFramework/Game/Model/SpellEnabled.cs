using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Model
{
    public abstract class SpellEnabled
    {
        private readonly Dictionary<ModifierType, List<Func<Entity, int>>> miscMod;
        private readonly Dictionary<ModifierType, List<Func<Entity, int>>> tempMod;

        public SpellEnabled()
        {
            miscMod = new Dictionary<ModifierType, List<Func<Entity, int>>>();
            tempMod = new Dictionary<ModifierType, List<Func<Entity, int>>>();
            foreach (ModifierType modifierType in Enum.GetValues(typeof(ModifierType)))
            {
                tempMod[modifierType] = new List<Func<Entity, int>>() { (Entity) => 0 };
                miscMod[modifierType] = new List<Func<Entity, int>>() { (Entity) => 0 };
            }
        }

        public int MiscMod(Entity e, ModifierType modifierType) => miscMod[modifierType].Sum(t => t.Invoke(e));
        public int TempMod(Entity e, ModifierType modifierType) => tempMod[modifierType].Sum(t => t.Invoke(e));

        public Dictionary<ModifierType, List<Func<Entity, int>>> MiscModDict()
        {
            return miscMod;
        }

        public Dictionary<ModifierType, List<Func<Entity, int>>> TempModDict()
        {
            return tempMod;
        }
    }
}
