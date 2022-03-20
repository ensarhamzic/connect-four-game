using System.Windows;

namespace connect_four_game
{
    public partial class NamesForm : Window
    {
        string player1Name = "Player";
        string player2Name = "Player";

        public string Player1Name
        {
            get { return player1Name; }
            set { player1Name = value; }
        }

        public string Player2Name
        {
            get { return player2Name; }
            set { player2Name = value; }
        }
        public NamesForm()
        {
            InitializeComponent();
        }

        private void SubmitNamesButton_Click(object sender, RoutedEventArgs e)
        {
            if(FPName.Text.Length > 10)
                player1Name = FPName.Text.Substring(0, 10);
            else if(FPName.Text != "")
                player1Name = FPName.Text;

            if (SPName.Text.Length > 10)
                player2Name = SPName.Text.Substring(0, 10);

            else if (SPName.Text != "")
                player2Name = SPName.Text;

            this.Close(); // Closes Window
        }
    }
}
