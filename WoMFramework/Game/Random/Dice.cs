using System.Collections.Generic;
using System.Linq;
using WoMFramework.Game.Enums;

namespace WoMFramework.Game.Random
{
    public class Dice
    {
        private System.Random random;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        public Dice()
        {
            random = new System.Random();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        public Dice(int seed)
        {
            random = new System.Random(seed);
        }

        public int Roll(int diceSides, int modifier)
        {
            return random.Next() % diceSides + 1 + modifier;
        }

        public int Roll(int diceSides)
        {
            return random.Next() % diceSides + 1;
        }

        public int Roll(DiceType diceType)
        {
            return (random.Next() % (int) diceType) + 1;
        }

        public int Roll(int[] rollEvent)
        {
            var rolls = new List<int>();
            for (var i = 0; i < rollEvent[0]; i++)
            {
                rolls.Add(Roll(rollEvent[1]));
            }

            // best off
            if (rollEvent.Length > 2 && rollEvent[2] > 0)
            {
                var purgeXlowRolls = rollEvent[0] - rollEvent[2];
                for (var j = 0; purgeXlowRolls > 0 && j < purgeXlowRolls; j++)
                {
                    rolls.Remove(rolls.Min());
                }
            }

            // sum up the rolls
            var result = rolls.Sum();

            // modifier
            if (rollEvent.Length > 3 && rollEvent[3] > 0)
            {
                result += rollEvent[3];
            }

            return result;
        }

    }
}
