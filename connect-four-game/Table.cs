using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_four_game
{
    internal class Table
    {
        private Field[,] fields = new Field[6,7]; // Standard table size for this game

        public Field[,] Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        public Table()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    fields[i,j] = new Field(); // Initialization
                }
            }
        }
    }
}
