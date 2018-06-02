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

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
        int count = 0;
        string x = "X";
        string o = "O";
        bool isWinner = false;
        List<Button> matrix = new List<Button>();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!matrix.Contains(((Button)sender)) && isWinner == false)
            {
                matrix.Add(((Button)sender));
                if (count % 2 == 0)
                {
                    ((Button)sender).Content = x;
                    count++;
                    CheckForWin();
                    if (isWinner)
                    {
                        return;
                    }
                }
                else
                {
                    ((Button)sender).Content = o;
                    count++;
                    CheckForWin();
                    if (isWinner)
                    {
                        return;
                    }
                }
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            first.Content = "";
            second.Content = "";
            third.Content = "";
            fourt.Content = "";
            fifth.Content = "";
            sixth.Content = "";
            seventh.Content = "";
            eight.Content = "";
            ninth.Content = "";

            first.Background = Brushes.Silver;
            second.Background = Brushes.Silver;
            third.Background = Brushes.Silver;
            fourt.Background = Brushes.Silver;
            fifth.Background = Brushes.Silver;
            sixth.Background = Brushes.Silver;
            seventh.Background = Brushes.Silver;
            eight.Background = Brushes.Silver;
            ninth.Background = Brushes.Silver;
            isWinner = false;
            matrix.Clear();
        }

        private void CheckForWin()
        {
            string topLeft = first.Content.ToString();
            string topCenter = second.Content.ToString();
            string topRight = third.Content.ToString();
            string left = fourt.Content.ToString();
            string center = fifth.Content.ToString();
            string right = sixth.Content.ToString();
            string bottomLeft = seventh.Content.ToString();
            string bottomCenter = eight.Content.ToString();
            string bottomRight = ninth.Content.ToString();
            //Diagonals
            if (topLeft == center && center == bottomRight && center!="")
            {
                first.Background = Brushes.Gold;
                fifth.Background = Brushes.Gold;
                ninth.Background = Brushes.Gold;
                isWinner = true;
            }
            if (topRight == center && center == bottomLeft && center != "")
            {
                third.Background = Brushes.Gold;
                fifth.Background = Brushes.Gold;
                seventh.Background = Brushes.Gold;
                isWinner = true;
            }
            //Vertical
            if (topCenter == center && center == bottomCenter && center != "")
            {
                second.Background = Brushes.Gold;
                fifth.Background = Brushes.Gold;
                eight.Background = Brushes.Gold;
                isWinner = true;
            }          
            if (topLeft == left && left == bottomLeft && left != "")
            {
                first.Background = Brushes.Gold;
                fourt.Background = Brushes.Gold;
                seventh.Background = Brushes.Gold;
                isWinner = true;
            }
            if (topRight == right && right == bottomRight && right != "")
            {
                third.Background = Brushes.Gold;
                sixth.Background = Brushes.Gold;
                ninth.Background = Brushes.Gold;
                isWinner = true;
            }
            //Horizontal
            if (topLeft == topCenter && topCenter == topRight && topCenter != "")
            {
                first.Background = Brushes.Gold;
                second.Background = Brushes.Gold;
                third.Background = Brushes.Gold;
                isWinner = true;
            }
            if (left == center && center == right && center != "")
            {
                fourt.Background = Brushes.Gold;
                fifth.Background = Brushes.Gold;
                sixth.Background = Brushes.Gold;
                isWinner = true;
            }
            if (bottomLeft == bottomCenter && bottomCenter == bottomRight && bottomCenter != "")
            {
                seventh.Background = Brushes.Gold;
                eight.Background = Brushes.Gold;
                ninth.Background = Brushes.Gold;
                isWinner = true;
            }
        }
    }
}
