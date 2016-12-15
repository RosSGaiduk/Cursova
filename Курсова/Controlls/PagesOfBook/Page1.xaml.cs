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

namespace Курсова.Controlls.PagesOfBook
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : UserControl
    {
        private MainWindow parent;
        private TextBox[] tBoxes = new TextBox[11];
        private Label[] labels = new Label[11];
        private ChemistryElementController chemistryController;
        private ViewController viewController;
        private PageController pageController;
        private ImageController imageController;
        private int pageNumber;
        private int maxPageNumber;
        public Page1(MainWindow wind,int pageNumber)
        {
            InitializeComponent();
            parent = wind;

            this.pageNumber = pageNumber;

            viewController = new ViewController(parent);
            pageController = new PageController();
            imageController = new ImageController();

            PageWithTextAndImage page = pageController.findOneByPage(pageNumber);
            addRichTextBox(page);
            pageController.close();



            switch (pageNumber)
            {
                case 2:
                    {
                        label.Content = "Вступ";
                    }  break;

                case 3:
                    {
                        label.Content = "Органічна хімія";
                    } break;

                default:
                    {
                        label.Content = "Атом";
                    } break;
            }

            label1.Content = pageNumber + " сторінка";

            pageController = new PageController();  
            page.Pictures = pageController.findAllPicturesByIdPage(page.Id);
            int marginLeft = 800;
            int marginTop = -400;
            int index = 0;
            foreach (Picture p in page.Pictures)
            {
                if (index % 2 == 0)
                {
                    addImage(p.UrlOfImage, -800, marginTop);
                    marginTop += 500;
                } else
                {
                    addImage(p.UrlOfImage, marginLeft, marginTop);
                    marginTop += 500;
                }

                index ++;
            }
            pageController.close();


            pageController = new PageController();
            maxPageNumber = pageController.findMaxPage();
            pageController.close();

        }

        private void addImage(string url, int marginLeft,int marginTop)
        {

            Image myImage3 = new Image();
            myImage3.Width = 256; myImage3.Height = 256;
            Thickness marginImg = myImage3.Margin;
            marginImg.Left = marginLeft;
            marginImg.Top = marginTop;
            myImage3.Margin = marginImg;
            myImage3.Stretch = Stretch.Uniform;
            myImage3.Source = new BitmapImage(new Uri(url, UriKind.Relative));        
            gridForPage1.Children.Add(myImage3);

        }
        private void addRichTextBox(PageWithTextAndImage p)
        {
            RichTextBox richBox = new RichTextBox();

            Thickness margin = richBox.Margin;
            richBox.Width = 500; richBox.Height = 500;
            richBox.IsReadOnly = true;
            richBox.Margin = margin;
            richBox.Document.Blocks.Add(new Paragraph(new Run(p.TextInPage)));
            gridForPage1.Children.Add(richBox);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber < maxPageNumber)
                viewController.nextPage(pageNumber + 1);
            else viewController.goTo("book");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber>2)
                viewController.nextPage(pageNumber - 1);
            else viewController.goTo("book");
        }
    }
}
