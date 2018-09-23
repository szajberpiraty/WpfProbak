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
        private int szamlalo;
        private int[] szamok = new int[5];

        public MainWindow()
        {
            InitializeComponent();
            sokgomb();
          
        }

        private void g1_Click(object sender, RoutedEventArgs e)
        {
            var butt = new Button();
            butt.Content = $"Klikkgomb"+2;
            butt.Name = "buttgomb";
            gpan.Children.Add(butt);
            
        }
        private void sokgomb()
        {
            for (int i = 0; i < 90; i++)
            {
                var butt = new Button();
                butt.Content = (i+1).ToString();

                
                string gname = $"buttgomb" + (i + 1);
                butt.Name = gname;
                butt.MinWidth = 20;
                butt.Click += d_butt_click;
                balpan.Children.Add(butt);
            }
        }
        private void d_butt_click(object sender, RoutedEventArgs e)
        {
            Button sg = (Button)sender;
            if (szamlalo<5)
            {
                szamok[szamlalo] = Convert.ToInt32(sg.Content);
                sg.Foreground= new SolidColorBrush(Colors.Red);
                sg.Background = new SolidColorBrush(Colors.Gold);
            }
            else
            {
                allapot.Foreground = new SolidColorBrush(Colors.Red);
            }
            szamlalo++;

            allapot.Text = (string)sg.Content;

        }
    }
}
