using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_four_game
{
    internal class Field
    {
        public enum Val
        {
            RED,
            YELLOW,
            VOID,
        };

        private Val value;

        public Val Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Field()
        {
            value = Val.VOID;
        }
    }
}
