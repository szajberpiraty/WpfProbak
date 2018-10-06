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

namespace WpfProbak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int szamlalo = 0;
        private int[] szamok = new int[5];
        private int[] nyeroszamok = new int[5];
        private int talalat;
        Random nyeroszam = new Random();

        public MainWindow()
        {
            InitializeComponent();
            sokgomb();
            //gombBejaras();
            buttonSorsolas.IsEnabled = false;
            buttonNewGame.IsEnabled = false;



        }

        public void NewGame()
        {
            buttonSorsolas.IsEnabled = false;
            szamlalo = 0;
            talalat = 0;
            szamok = new int[5];
            nyeroszamok = new int[5];
            balpan.Children.Clear();
            sokgomb();
            buttonNewGame.IsEnabled = false;

        }

        private void g1_Click(object sender, RoutedEventArgs e)
        {
            var butt = new Button();
            //butt.Content = $"Klikkgomb"+2;
            butt.Content = "Klikkgomb" + 2;
            butt.Name = "buttgomb";
            gpan.Children.Add(butt);

        }
        private void sokgomb()
        {
            for (int i = 0; i < 90; i++)
            {
                var butt = new Button();
                butt.Content = (i + 1).ToString();


                string gname = "buttgomb" + (i + 1);
                butt.Name = gname;

                butt.Padding = new Thickness(5);
                butt.Margin = new Thickness(5);
                butt.MinWidth = 30;

                butt.Click += d_butt_click;
                balpan.Children.Add(butt);
            }
        }
        private void gombBejaras()
        {
            //balpan.Children;
            //        	foreach (Button ch in balpan.Children) {
            //        		
            //        		allapot.Text+=ch.Content;
            //        		
            //        	}
            Button hohh = (Button)balpan.Children[1];
            //allapot.Text=(String)hohh.Content;
        }

        private void sorsolas()
        {
            for (int i = 0; i < 5; i++)
            {
                var textb_nyeroszam = new TextBox();
                nyeroszamok[i] = nyeroszam.Next(1, 91);

                textb_nyeroszam.Text = nyeroszamok[i].ToString();
                gpan.Children.Add(textb_nyeroszam);

            }
            var sorsolasEredmeny = new TextBox();
            sorsolasEredmeny.Text = "Találat:" + Eredmeny().ToString();
            gpan.Children.Add(sorsolasEredmeny);
        }

        private int Eredmeny()
        {
            for (int i = 0; i < szamok.Length; i++)
            {
                for (int j = 0; j < nyeroszamok.Length; j++)
                {
                    if (szamok[i] == nyeroszamok[i])
                    {
                        talalat++;
                    }
                }
            }

            return talalat;
        }

        private void d_butt_click(object sender, RoutedEventArgs e)
        {
            Button sg = (Button)sender;

            if ((szamlalo + 1) == 5)
            {

                buttonSorsolas.IsEnabled = true;
            }


            if (szamlalo < 5)
            {

                //sg.Foreground= new SolidColorBrush(Colors.Red);
                //sg.Background = new SolidColorBrush(Colors.Gold);
                sg.Foreground = Brushes.Red;
                sg.Background = Brushes.Gold;
                szamok[szamlalo] = Convert.ToInt32(sg.Content);
            }
            else
            {
                //allapot.Foreground = new SolidColorBrush(Colors.Red);
                allapot.Foreground = Brushes.Coral;



            }
            allapot.Text = (szamlalo + 1).ToString();
            szamlalo++;

            //allapot.Text = (string)sg.Content;

        }
        void buttonSorsolas_Click(object sender, RoutedEventArgs e)
        {
            sorsolas();
            eredmenyKiemeles();
            buttonNewGame.IsEnabled = true;
        }

        void eredmenyKiemeles()
        {
            foreach (Button ch in balpan.Children)
            {

                if (Array.IndexOf(nyeroszamok, Convert.ToInt32(ch.Content)) > -1)
                {

                    ch.Foreground = Brushes.DarkBlue;
                    ch.Background = Brushes.Green;

                }
                //allapot.Text+=ch.Content;

            }
        }
        void buttonNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}
