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
            int winner = 0;
            for(int i = 5; i >= 0; i--) // Horizontal win
            {
                if(winner != 0)
                    break;
                for(int j = 0; j < 4; j++)
                {
                    if(table.Fields[i,j].Value == Field.Val.RED && table.Fields[i, j+1].Value == Field.Val.RED && table.Fields[i, j+2].Value == Field.Val.RED && table.Fields[i, j+3].Value == Field.Val.RED)
                    {
                        winner = 1;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i}c{j+1}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i}c{j+2}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i}c{j+3}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    } else if(table.Fields[i, j].Value == Field.Val.YELLOW && table.Fields[i, j + 1].Value == Field.Val.YELLOW && table.Fields[i, j + 2].Value == Field.Val.YELLOW && table.Fields[i, j + 3].Value == Field.Val.YELLOW)
                    {
                        winner = 2;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i}c{j + 1}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i}c{j + 2}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i}c{j + 3}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    }
                }
            }

            for (int j = 0; j < 7; j++) // Vertical win
            {
                if (winner != 0)
                    break;
                for (int i = 5; i > 2; i--)
                {
                    if (table.Fields[i, j].Value == Field.Val.RED && table.Fields[i-1, j].Value == Field.Val.RED && table.Fields[i-2, j].Value == Field.Val.RED && table.Fields[i-3, j].Value == Field.Val.RED)
                    {
                        winner = 1;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i-1}c{j}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i-2}c{j}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i-3}c{j}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    }
                    else if (table.Fields[i, j].Value == Field.Val.YELLOW && table.Fields[i - 1, j].Value == Field.Val.YELLOW && table.Fields[i - 2, j].Value == Field.Val.YELLOW && table.Fields[i - 3, j].Value == Field.Val.YELLOW)
                    {
                        winner = 2;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i - 1}c{j}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i - 2}c{j}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i - 3}c{j}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    }
                }
            }

            for (int i = 5; i > 2; i--) // Down left - up right diagonal win
            {
                if (winner != 0)
                    break;
                for (int j = 0; j < 4; j++)
                {
                    if (table.Fields[i, j].Value == Field.Val.RED && table.Fields[i - 1, j + 1].Value == Field.Val.RED && table.Fields[i - 2, j + 2].Value == Field.Val.RED && table.Fields[i - 3, j + 3].Value == Field.Val.RED)
                    {
                        winner = 1;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i - 1}c{j + 1}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i - 2}c{j + 2}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i - 3}c{j + 3}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    }
                    else if (table.Fields[i, j].Value == Field.Val.YELLOW && table.Fields[i - 1, j + 1].Value == Field.Val.YELLOW && table.Fields[i - 2, j + 2].Value == Field.Val.YELLOW && table.Fields[i - 3, j + 3].Value == Field.Val.YELLOW)
                    {
                        winner = 2;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i - 1}c{j + 1}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i - 2}c{j + 2}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i - 3}c{j + 3}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    }
                }
            }

            for (int i = 5; i > 2; i--) // Up left - down right diagonal win
            {
                if (winner != 0)
                    break;
                for (int j = 6; j > 2; j--)
                {
                    if (table.Fields[i, j].Value == Field.Val.RED && table.Fields[i - 1, j - 1].Value == Field.Val.RED && table.Fields[i - 2, j - 2].Value == Field.Val.RED && table.Fields[i - 3, j - 3].Value == Field.Val.RED)
                    {
                        winner = 1;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i - 1}c{j - 1}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i - 2}c{j - 2}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i - 3}c{j - 3}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    }
                    else if (table.Fields[i, j].Value == Field.Val.YELLOW && table.Fields[i - 1, j - 1].Value == Field.Val.YELLOW && table.Fields[i - 2, j - 2].Value == Field.Val.YELLOW && table.Fields[i - 3, j - 3].Value == Field.Val.YELLOW)
                    {
                        winner = 2;
                        this.Dispatcher.Invoke(() =>
                        {
                            Ellipse el1 = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                            Ellipse el2 = GameGrid.FindName($"r{i - 1}c{j - 1}") as Ellipse;
                            Ellipse el3 = GameGrid.FindName($"r{i - 2}c{j - 2}") as Ellipse;
                            Ellipse el4 = GameGrid.FindName($"r{i - 3}c{j - 3}") as Ellipse;
                            el1.StrokeThickness = 15;
                            el2.StrokeThickness = 15;
                            el3.StrokeThickness = 15;
                            el4.StrokeThickness = 15;
                        });
                        break;
                    }
                }
            }


            if (winner != 0)
            {
                MessageBox.Show($"Winner is player {winner}");
                playerTurn = Turn.NONE;
            }
                

            // Winning logic
            // Increment score
            // Game end no winner message
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            playerTurn = Turn.FIRST;
            filled = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Ellipse el = GameGrid.FindName($"r{i}c{j}") as Ellipse;
                        el.Fill = Brushes.Transparent;
                        el.StrokeThickness = 2;
                    });
                    table.Fields[i, j] = new Field(); // Resetting
                }
            }
        }
    }
}
