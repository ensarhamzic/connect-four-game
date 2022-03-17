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
        public MainWindow()
        {
            InitializeComponent();
            table = new Table();
            DrawTable();
        }

        private void DrawTable()
        {
            StackPanel mainSP = new StackPanel();
            Grid.SetRow(mainSP, 1);
            mainSP.HorizontalAlignment = HorizontalAlignment.Center;
            mainSP.VerticalAlignment = VerticalAlignment.Center;
            for(int i = 0; i < table.Fields.GetLength(1); i++)
            {
                StackPanel fieldSP = new StackPanel();
                fieldSP.Orientation = Orientation.Horizontal;
                if(i != 0)
                {
                    fieldSP.Margin = new Thickness(0, 10, 0, 0);
                }
                for(int j = 0; j < table.Fields.GetLength(0); j++)
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
            Ellipse clickedEllipse = sender as Ellipse;
            MessageBox.Show(clickedEllipse.Name);
        }
    }
}
