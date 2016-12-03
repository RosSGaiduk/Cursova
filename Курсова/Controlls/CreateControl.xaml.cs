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
    /// Логика взаимодействия для CreateControl.xaml
    /// </summary>
    public partial class CreateControl : UserControl
    {
        private MainWindow parent;
        private TextBox[] tBoxes = new TextBox[11];
        private Label[] labels = new Label[11];
        private ChemistryElementController chemistryController;
        private OrganicController organicController;
        private PageController pageController;
        private ImageController imageController;
        private ViewController viewController;

        public CreateControl(MainWindow wind)
        {

            InitializeComponent();
            parent = wind;

            viewController = new ViewController(parent);

            comboBox.Items.Add("Хімічний елемент");
            comboBox.Items.Add("Органічний елемент");
            comboBox.Items.Add("Сторінка");
            comboBox.Items.Add("Картинка");

            tBoxes[0] = textBox1; tBoxes[1] = textBox2; tBoxes[2] = textBox3;
            tBoxes[3] = textBox4; tBoxes[4] = textBox5; tBoxes[5] = textBox6;
            tBoxes[6] = textBox7; tBoxes[7] = textBox8; tBoxes[8] = textBox9;
            tBoxes[9] = textBox10; tBoxes[10] = textBox11;


            labels[0] = label1; labels[1] = label2; labels[2] = label3;
            labels[3] = label4; labels[4] = label5; labels[5] = label6;
            labels[6] = label7; labels[7] = label8; labels[8] = label9;
            labels[9] = label10; labels[10] = label11;

        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        for (int i = 0; i < tBoxes.Length; i++)
                        {
                            tBoxes[i].IsEnabled = true;
                            labels[i].IsEnabled = true;
                        }

                        labels[0].Content = "Full name"; labels[1].Content = "Table name"; labels[2].Content = "Description";
                        labels[3].Content = "Group(int)"; labels[4].Content = "Valence"; labels[5].Content = "Period(int)";
                        labels[6].Content = "Atomic weight(double)"; labels[7].Content = "Orbital(char)"; labels[8].Content = "Graphic model";
                        labels[9].Content = "Formula"; labels[10].Content = "Natural name";
                    }
                    break;

                case 1:
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            tBoxes[i].IsEnabled = true;
                            labels[i].IsEnabled = true;
                        }
                        for (int i = 4; i < tBoxes.Length; i++)
                        {
                            tBoxes[i].IsEnabled = false;
                            labels[i].IsEnabled = false;
                        }

                        labels[0].Content = "Description"; labels[1].Content = "Full name"; labels[2].Content = "Formula";
                        labels[3].Content = "Graphic model";
                    }
                    break;

                case 2:
                    {
                        tBoxes[1].IsEnabled = true;
                        for (int i = 0; i < 2; i++)
                        {
                            tBoxes[i].IsEnabled = true;
                            labels[i].IsEnabled = true;
                        }

                        for (int i = 2; i < tBoxes.Length; i++)
                        {
                            tBoxes[i].IsEnabled = false; labels[i].IsEnabled = false;
                        }


                        labels[0].Content = "Number page(int)";
                        labels[1].Content = "Text";

                    }
                    break;
                case 3:
                    {
                        tBoxes[0].IsEnabled = true;
                        labels[0].IsEnabled = true;
                        for (int i = 1; i < tBoxes.Length; i++)
                        {
                            tBoxes[i].IsEnabled = false; labels[i].IsEnabled = false;
                        }

                        labels[0].Content = "Url";
                    }
                    break;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                string forChar = tBoxes[7].Text;
                char[] c = forChar.ToCharArray();
                try
                {
                    chemistryController = new ChemistryElementController();
                    ChemistryElement element = new ChemistryElement(tBoxes[0].Text, tBoxes[1].Text, tBoxes[2].Text,
                        int.Parse(tBoxes[3].Text), tBoxes[4].Text, int.Parse(tBoxes[5].Text),
                        double.Parse(tBoxes[6].Text), c[0], tBoxes[8].Text, tBoxes[9].Text, tBoxes[10].Text
                        );
                    chemistryController.add(element);
                    MessageBox.Show("Successfully added " + element);
                    for (int i = 0; i < tBoxes.Length; i++)
                        tBoxes[i].Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed, something is wrong");
                }
                chemistryController.close();

            }
            else if (comboBox.SelectedIndex == 1)
            {
                try
                {
                    organicController = new OrganicController();
                    OrganicElement element = new OrganicElement(tBoxes[0].Text, tBoxes[1].Text, tBoxes[2].Text,
                        tBoxes[3].Text);
                    organicController.add(element);
                    MessageBox.Show("Successfully added " + element);
                    for (int i = 0; i < tBoxes.Length; i++)
                        tBoxes[i].Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed, something is wrong");
                }
                organicController.close();
            }
            else if (comboBox.SelectedIndex == 2)
            {
                try
                {
                    pageController = new PageController();
                    PageWithTextAndImage element = new PageWithTextAndImage(int.Parse(tBoxes[0].Text), tBoxes[1].Text);
                    pageController.add(element);
                    MessageBox.Show("Successfully added " + element);
                    for (int i = 0; i < tBoxes.Length; i++)
                        tBoxes[i].Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed, something is wrong");
                }
                pageController.close();
            }
            else if (comboBox.SelectedIndex == 3)
            {
                try
                {
                    imageController = new ImageController();
                    Picture picture = new Picture(tBoxes[0].Text);
                    imageController.add(picture);
                    MessageBox.Show("Successfully added " + picture);
                    for (int i = 0; i < tBoxes.Length; i++)
                        tBoxes[i].Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed, something is wrong");
                }
                imageController.close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Close();
            //mainWindow.MainThis.Children.Clear();
            //mainWindow.MainThis.Children.Add(new UserControl2());
            //mainWindow.Show();
            //parent.Close();
            //parent.MainThis.Children.Clear();
            //parent.MainThis.Children.Add(new DeleteControl(parent));
            viewController.goTo("deletePage");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            viewController.goTo("showAll");
        }
    }
}
