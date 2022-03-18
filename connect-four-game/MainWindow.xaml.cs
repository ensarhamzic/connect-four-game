using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace connect_four_game
{

    public partial class MainWindow : Window
    {
        private Table table;
        private int filled;
        public enum Turn
        {
            NONE,
            FIRST,
            SECOND
        };
        private Turn playerTurn;
        public MainWindow()
        {
            InitializeComponent();
            table = new Table();
            playerTurn = Turn.NONE;
            DrawTable();
            filled = 0;
        }

        private void DrawTable()
        {
            StackPanel mainSP = new StackPanel();
            Grid.SetRow(mainSP, 1);
            mainSP.HorizontalAlignment = HorizontalAlignment.Center;
            mainSP.VerticalAlignment = VerticalAlignment.Center;
            for(int i = 0; i < 6; i++)
            {
                StackPanel fieldSP = new StackPanel();
                fieldSP.Orientation = Orientation.Horizontal;
                if(i != 0)
                {
                    fieldSP.Margin = new Thickness(0, 10, 0, 0);
                }
                for(int j = 0; j < 7; j++)
                {
                    Ellipse e = new Ellipse();
                    e.Name = $"r{i}c{j}";
                    GameGrid.RegisterName(e.Name, e);
                    e.Height = 100;
                    e.Width = 100;
                    if(j != 0)
                    {
                        e.Margin = new Thickness(10,0,0,0);
                    }
                    e.Fill = Brushes.Transparent;
                    e.Stroke = Brushes.Black;
                    e.StrokeThickness = 2;
                    e.MouseLeftButtonDown += Field_MouseLeftButtonDown;
                    fieldSP.Children.Add(e);
                }
                mainSP.Children.Add(fieldSP);
            }

            GameGrid.Children.Add(mainSP);
        }

        private void Field_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (playerTurn == Turn.NONE) return;
            Ellipse clickedEllipse = sender as Ellipse;
            int row = int.Parse(clickedEllipse.Name[clickedEllipse.Name.Length - 1].ToString());
            for (int i = 5; i >= 0; i--)
            {
                if(table.Fields[i, row].Value == Field.Val.VOID)
                {
                    if(playerTurn == Turn.FIRST)
                    {
                        table.Fields[i, row].Value = Field.Val.RED;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse ellipse = GameGrid.FindName($"r{i}c{row}") as Ellipse;
                            ellipse.Fill = Brushes.Red;
                        });
                        playerTurn = Turn.SECOND;
                    } else
                    {
                        table.Fields[i, row].Value = Field.Val.YELLOW;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse ellipse = GameGrid.FindName($"r{i}c{row}") as Ellipse;
                            ellipse.Fill = Brushes.Yellow;
                        });
                        playerTurn = Turn.FIRST;
                    }
                    filled++;
                    if(filled > 6)
                    {
                        HasWinner();
                    }
                    break;
                }
            }
        }

        private void HasWinner()
        {
            // Winning logic
            // Increment score
            // Game end no winner message
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            playerTurn = Turn.FIRST;
            filled = 0;
        }
    }
}
