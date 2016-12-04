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
using Курсова.Controllers;

namespace Курсова.Controlls
{
    /// <summary>
    /// Логика взаимодействия для CheckingUser.xaml
    /// </summary>
    public partial class CheckingUser : UserControl
    {
        private MainWindow parent;
        private ViewController viewController;
        private String goTo;
        public CheckingUser(MainWindow mainWin, String pageWant)
        {
            InitializeComponent();
            parent = mainWin;
            goTo = pageWant;
            viewController = new ViewController(parent);
            textBox1.Text = ""; textBox2.Text = "";
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "password")
            {
                parent.setAuth(true);
                viewController.goTo(goTo);
            } else
            {
                MessageBox.Show("User name or password was incorrect");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
