using System;
using System.Collections.Generic;
using System.Text;

namespace WoMFramework.Game
{
    public class Helper
    {
        public static int Modifier(int ability) => (int)Math.Floor((ability - 10) / 2.0);
    }
}
