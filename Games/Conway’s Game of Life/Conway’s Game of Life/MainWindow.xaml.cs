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
using System.Windows.Threading;

namespace Conway_s_Game_of_Life
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            windowTable.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            windowTable.Arrange(new Rect(0.0, 0.0, windowTable.DesiredSize.Width, windowTable.DesiredSize.Height));

            for (int i = 0; i < numberOfCellsHight; i++)
            {
                for (int j = 0; j < numberOfCellsWide; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = windowTable.ActualWidth / numberOfCellsWide - 2.0;
                    rectangle.Height = windowTable.ActualHeight / numberOfCellsHight - 2.0;
                    rectangle.Fill = Brushes.Chocolate;
                    windowTable.Children.Add(rectangle);
                    Canvas.SetLeft(rectangle, j * windowTable.ActualWidth / numberOfCellsWide);
                    Canvas.SetTop(rectangle, i * windowTable.ActualHeight / numberOfCellsHight);
                    rectangle.MouseDown += R_MouseDown;
                    fields[i, j] = rectangle;
                }
            }

            timer.Interval = TimeSpan.FromMilliseconds(250);
            timer.Tick += Timer_Tick;
        }

        const int numberOfCellsWide = 50;
        const int numberOfCellsHight = 50;
        long generationCount = 0;

        Rectangle[,] fields = new Rectangle[numberOfCellsHight, numberOfCellsWide];
        DispatcherTimer timer = new DispatcherTimer();

        private void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill =
                (((Rectangle)sender).Fill == Brushes.Chocolate) ? Brushes.Black : Brushes.Chocolate;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NextStep();
        }

        private void ButtonPlayPause_Click(object sender, RoutedEventArgs e)
        {

            if (timer.IsEnabled)
            {
                timer.Stop();
                buttonPlayPause.Content = "Play";
            }
            else
            {
                timer.Start();

                buttonPlayPause.Content = "Pause";
            }

        }

        private void ButtonNextStep_Click(object sender, RoutedEventArgs e)
        {
            NextStep();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            int[,] matrixWithNeighboarCount = new int[numberOfCellsHight, numberOfCellsWide];
            for (int i = 0; i < numberOfCellsHight; i++)
            {
                for (int j = 0; j < numberOfCellsWide; j++)
                {
                    matrixWithNeighboarCount[i, j] = 0;
                }
            }

            for (int i = 0; i < numberOfCellsHight; i++)
            {
                for (int j = 0; j < numberOfCellsWide; j++)
                {
                    if (matrixWithNeighboarCount[i, j] == 3)
                    {
                        fields[i, j].Fill = Brushes.Black;
                    }
                    else if (matrixWithNeighboarCount[i, j] < 2 || matrixWithNeighboarCount[i, j] > 3)
                    {
                        fields[i, j].Fill = Brushes.Chocolate;
                    }
                }
            }
            generationCount = 0;
            int populationsCount = 0;
            generation.Text = "Generation: " + generationCount;
            populationCount.Text = "Population Count: " + populationsCount;
        }

        private void NextStep()
        {
            int[,] matrixWithNeighboarCount = new int[numberOfCellsHight, numberOfCellsWide];
            for (int i = 0; i < numberOfCellsHight; i++)
            {
                for (int j = 0; j < numberOfCellsWide; j++)
                {
                    int neighbours = GetAllNeighBours(i, j);
                    matrixWithNeighboarCount[i, j] = neighbours;
                }
            }

            for (int i = 0; i < numberOfCellsHight; i++)
            {
                for (int j = 0; j < numberOfCellsWide; j++)
                {
                    if (matrixWithNeighboarCount[i, j] == 3)
                    {
                        fields[i, j].Fill = Brushes.Black;
                    }
                    else if (matrixWithNeighboarCount[i, j] < 2 || matrixWithNeighboarCount[i, j] > 3)
                    {
                        fields[i, j].Fill = Brushes.Chocolate;
                    }
                }
            }
            int populationsCount = GetPopulationCount();
            generationCount++;
            generation.Text = "Generation: " + generationCount;
            populationCount.Text = "Population Count: " + populationsCount;

        }

        private int GetPopulationCount()
        {
            int count = 0;
            for (int i = 0; i < numberOfCellsHight; i++)
            {
                for (int j = 0; j < numberOfCellsWide; j++)
                {
                    if (fields[i, j].Fill == Brushes.Black)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int GetAllNeighBours(int i, int j)
        {
            int neightboars = 0;
            int leftBoarder = j - 1;
            if (leftBoarder < 0)
            {
                leftBoarder = numberOfCellsWide - 1;
            }
            int rightBoarder = j + 1;
            if (rightBoarder >= numberOfCellsWide)
            {
                rightBoarder = 0;
            }
            int topBoarder = i - 1;
            if (topBoarder < 0)
            {
                topBoarder = numberOfCellsHight - 1;
            }
            int bottomBoarder = i + 1;
            if (bottomBoarder >= numberOfCellsHight)
            {
                bottomBoarder = 0;
            }
            if (fields[topBoarder, leftBoarder].Fill == Brushes.Black)
            {
                neightboars++;
            }
            if (fields[topBoarder, j].Fill == Brushes.Black)
            {
                neightboars++;
            }
            if (fields[topBoarder, rightBoarder].Fill == Brushes.Black)
            {
                neightboars++;
            }

            if (fields[i, leftBoarder].Fill == Brushes.Black)
            {
                neightboars++;
            }
            if (fields[bottomBoarder, leftBoarder].Fill == Brushes.Black)
            {
                neightboars++;
            }
            if (fields[i, rightBoarder].Fill == Brushes.Black)
            {
                neightboars++;
            }
            if (fields[bottomBoarder, rightBoarder].Fill == Brushes.Black)
            {
                neightboars++;
            }
            if (fields[bottomBoarder, j].Fill == Brushes.Black)
            {
                neightboars++;
            }

            return neightboars;
        }

        private void ButtonRandom_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfCellsHight; i++)
            {
                for (int j = 0; j < numberOfCellsWide; j++)
                {
                    fields[i, j].Fill = (random.Next(0, 2) == 1) ? Brushes.Chocolate : Brushes.Black;
                }
            }
        }
    }
}
