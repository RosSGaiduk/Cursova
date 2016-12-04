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
    /// Логика взаимодействия для CheckedElement.xaml
    /// </summary>
    public partial class CheckedElement : UserControl
    {
        private MainWindow parent;
        private ViewController viewController;
        private ChemistryElementController chemistryController;
        private CheckedElement chemistryElement;

        public CheckedElement(MainWindow mainWind,ChemistryElement chemElem)
        {
            InitializeComponent();
            parent = mainWind;
            viewController = new ViewController(parent);
            addImage(chemElem.GraphicModel);
            addRichTextBox(chemElem);
        }

        

        private void addImage(string url)
        {

            Image myImage3 = new Image();
            myImage3.Width = 320; myImage3.Height = 512;

            Thickness marginImg = myImage3.Margin;
            marginImg.Left = -660;
            marginImg.Top = -50;
            myImage3.Margin = marginImg;

            myImage3.Stretch = Stretch.Uniform;
            myImage3.Source = new BitmapImage(new Uri(url, UriKind.Relative));

            stPnel.Children.Add(myImage3);

        }

        private void addRichTextBox(ChemistryElement element)
        {
            RichTextBox richBox = new RichTextBox();

            Thickness margin = richBox.Margin;
            richBox.Width = 500; richBox.Height = 500;
            margin.Left = 170;
            margin.Top = -420;
            richBox.FontSize = 24;
            richBox.Margin = margin;
            richBox.IsReadOnly = true;
            stPnel.Children.Add(richBox);
            richBox.Document.Blocks.Add(new Paragraph(new Run(element.ToString())));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            viewController.goTo("book");
        }
    }
}
