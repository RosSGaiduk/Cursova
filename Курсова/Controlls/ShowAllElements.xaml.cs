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
        private OrganicController organicController;
        private PageController pageController;
        private ImageController imageController;
        private ViewController viewController;
        public ShowAllElements(MainWindow wind)
        {
            InitializeComponent();
            parent = wind;
            viewController = new ViewController(parent);


            chemistryController = new ChemistryElementController();
            List<ChemistryElement> elements = chemistryController.findAll();
            for (int i = 0; i < elements.Count; i++)
            {
                string str = "/MyImages/Графічні моделі/Гідроген.png";
                //MessageBox.Show(""+(elements[i].GraphicModel == str));
                addImage(elements[i].GraphicModel,i);
                addRichTextBox(elements[i],i);
                //addRichTextBox(elements[i]);
                //addButton(elements[i].Id);
            }
            MessageBox.Show(allElements.RowDefinitions.Count+"");
        }


        private void addImage(string url,int i)
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
            
            Grid.SetRow(myImage3,i/4 + 1); 
            Grid.SetColumn(myImage3, (i % 4)*2);
            
         
            allElements.Children.Add(myImage3);
            

            //stPnel.Children.Add(myImage3);

        }

        private void addRichTextBox(ChemistryElement element,int index)
        {
            RichTextBox richBox = new RichTextBox();

            Thickness margin = richBox.Margin;
            richBox.Width = 160; richBox.Height = 256;
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

       
    }

 
}
