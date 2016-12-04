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
using Курсова.Controlls;

namespace Курсова
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool authenticated = false;
        public MainWindow()
        {
            InitializeComponent();           
            MainThis.Children.Add(new BookPage1(this));
        }

        public  bool getAuth() { return authenticated; }
        public void setAuth(bool auth) { authenticated = auth; }
    }
}
