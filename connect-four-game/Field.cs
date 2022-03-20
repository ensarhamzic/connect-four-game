

namespace connect_four_game
{
    internal class Field
    {
        public enum Val // Field can have just 3 states
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
            value = Val.VOID; // Field is empty at the beginning
        }
    }
}
