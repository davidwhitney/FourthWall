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

namespace FourthWall.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Browser.MouseUp += Browser_MouseUp;
            Browser.KeyDown += Browser_KeyDown;
            Browser.Navigate(App.Server.BaseUrl);
        }

        private void Browser_KeyDown(object sender, KeyEventArgs e)
        {
        }

        protected override void OnActivated(EventArgs e)
        {


        }

        private void Browser_MouseUp(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
