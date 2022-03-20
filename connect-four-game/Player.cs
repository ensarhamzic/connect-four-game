
namespace connect_four_game
{
    internal class Player
    {
        int score;
        string name;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Player()
        {
            score = 0;
            name = "Player";
        }

        public Player(string name)
        {
            this.name = name;
        }
    }
}
