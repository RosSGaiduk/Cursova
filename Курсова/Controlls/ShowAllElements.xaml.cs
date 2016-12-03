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


            addImage("/MyImages/Графічні моделі/Арсен.png");
            addRichTextBox();
            addImage("/MyImages/Графічні моделі/Актиній.png");
            addRichTextBox();
            addImage("/MyImages/Графічні моделі/Оксиген.png");
            addRichTextBox();

        }


        private void addImage(string url)
        {

            Image myImage3 = new Image();
            myImage3.Width = 160; myImage3.Height = 256;

            Thickness marginImg = myImage3.Margin;
            marginImg.Left = -300;
            marginImg.Top = 0;
            myImage3.Margin = marginImg;

            myImage3.Stretch = Stretch.Uniform;
            myImage3.Source = new BitmapImage(new Uri(url, UriKind.Relative));

            stPnel.Children.Add(myImage3);

        }

        private void addRichTextBox()
        {
            RichTextBox richBox = new RichTextBox();

            Thickness margin = richBox.Margin;
            richBox.Width = 200; richBox.Height = 200;
            margin.Left = 70;
            margin.Top = -200;
            richBox.Margin = margin;
            stPnel.Children.Add(richBox);
        }

    }

 
}
