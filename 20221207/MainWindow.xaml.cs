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

namespace _20221207
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

        private void btn_hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            hozzaadas ablak=new hozzaadas();
            ablak.ShowDialog();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            update ablak=new update();
            ablak.ShowDialog();
        }
    }
}
