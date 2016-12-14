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
    /// Логика взаимодействия для ShowAllElements.xaml
    /// </summary>
    /// 
    public partial class ShowAllElements : UserControl
    {
        private MainWindow parent;
        private TextBox[] tBoxes = new TextBox[11];
        private Label[] labels = new Label[11];
        private ChemistryElementController chemistryController;
        private ViewController viewController;
        public ShowAllElements(MainWindow wind)
        {
            InitializeComponent();
            parent = wind;
            viewController = new ViewController(parent);

            comboBox.Items.Add("Таблична назва");
            comboBox.Items.Add("Група");
            comboBox.Items.Add("Орбіталь");
            comboBox.Items.Add("*");

            chemistryController = new ChemistryElementController();
            List<ChemistryElement> elements = chemistryController.findAll();
            for (int i = 0; i < elements.Count; i++)
            {
                string str = "/MyImages/Графічні моделі/Гідроген.png";
                //MessageBox.Show(""+(elements[i].GraphicModel == str));
                addImage(elements[i].GraphicModel, i);
                addRichTextBox(elements[i], i);



                //addRichTextBox(elements[i]);
                //addButton(elements[i].Id);
            }
            //MessageBox.Show(allElements.RowDefinitions.Count+"");
        }


        private void addImage(string url, int i)
        {

            Image myImage3 = new Image();
            myImage3.Width = 160; myImage3.Height = 256;

            Thickness marginImg = myImage3.Margin;
            //marginImg.Left = -300;
            //marginImg.Top = 0;
            myImage3.Margin = marginImg;

            myImage3.Stretch = Stretch.Uniform;
            myImage3.Source = new BitmapImage(new Uri(url, UriKind.Relative));

            if (i % 4 == 0)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(256);
                allElements.RowDefinitions.Add(row);
            }

            Grid.SetRow(myImage3, i / 4 + 1);
            Grid.SetColumn(myImage3, (i % 4) * 2);


            allElements.Children.Add(myImage3);


            //stPnel.Children.Add(myImage3);

        }

        private void addRichTextBox(ChemistryElement element, int index)
        {
            RichTextBox richBox = new RichTextBox();

            Thickness margin = richBox.Margin;
            richBox.Width = 160; richBox.Height = 256;
            richBox.IsReadOnly = true;
            //margin.Left = -300;
            //margin.Top = 0;
            richBox.Margin = margin;
            //stPnel.Children.Add(richBox);
            richBox.Document.Blocks.Add(new Paragraph(new Run(element.ToString())));
            Grid.SetRow(richBox, index / 4 + 1);
            Grid.SetColumn(richBox, (index % 4) * 2 + 1);


            allElements.Children.Add(richBox);
        }

        private void addButton(int id)
        {
            Button button = new Button();
            button.Content = "Delete " + id;
            button.Width = 100; button.Height = 20;
            Thickness margin = button.Margin;
            margin.Top = 30;
            margin.Left = 150;
            button.Margin = margin;
            //stPnel.Children.Add(button);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //viewController.goTo("creatingPage");
            viewController.checkUserGo("creatingPage");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //viewController.goTo("deletePage");
            viewController.checkUserGo("deletePage");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            viewController.goTo("book");
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 3)
                textBox1.IsReadOnly = true;
            else textBox1.IsReadOnly = false;
            textBox1.Text = "";

        }

        private void clearScreen()
        {

            for (int i = 6; i < allElements.Children.Count; i++)
            {
                allElements.Children.RemoveAt(i);
                i--;
            }

            for (int i = 1; i < allElements.RowDefinitions.Count; i++)
            {
                allElements.RowDefinitions.RemoveAt(i);
                i--;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        chemistryController = new ChemistryElementController();
                        ChemistryElement chemistryElement = chemistryController.findByTableName(textBox1.Text);
                        chemistryController.close();

                        clearScreen();

                        try
                        {
                            addImage(chemistryElement.GraphicModel, 0);
                            addRichTextBox(chemistryElement, 0);
                        }
                        catch (NullReferenceException ex)
                        {
                        }
                        break;
                    }
                case 1:
                    try
                    {
                        int group = int.Parse(textBox1.Text);
                    } catch(Exception ex){
                        MessageBox.Show("Only integer value can be read from this text box!!!");
                        return;
                    }
                    {
                        clearScreen();
                        chemistryController = new ChemistryElementController();
                        List<ChemistryElement> chemistryElements = chemistryController.findAllByGroup(textBox1.Text);
                        
                        
                        for (int i = 0; i < chemistryElements.Count; i++){
                            addImage(chemistryElements[i].GraphicModel, i);
                            addRichTextBox(chemistryElements[i], i);
                        }
                        chemistryController.close();
                    } break;

                case 2:
                    {
                        if (textBox1.Text!="p" && textBox1.Text != "s" && textBox1.Text != "d")
                        {
                            MessageBox.Show("Orbitals can be only like 'p' or 's' or 'd'!!!");
                            return;
                        }
                        clearScreen();
                        chemistryController = new ChemistryElementController();
                        List<ChemistryElement> chemistryElements = chemistryController.findAllByOrbital(textBox1.Text);


                        for (int i = 0; i < chemistryElements.Count; i++)
                        {
                            addImage(chemistryElements[i].GraphicModel, i);
                            addRichTextBox(chemistryElements[i], i);
                        }
                        chemistryController.close();
                    } break;

                case 3:
                    {
                        clearScreen();
                        chemistryController = new ChemistryElementController();
                        List<ChemistryElement> elements = chemistryController.findAll();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            string str = "/MyImages/Графічні моделі/Гідроген.png";
                            addImage(elements[i].GraphicModel, i);
                            addRichTextBox(elements[i], i);
                        }
                        chemistryController.close();
                    } break;
            }
        }
    }
}
