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
    /// Логика взаимодействия для BookPage1.xaml
    /// </summary>
    public partial class BookPage1 : UserControl
    {
        private MainWindow parent;
        private TextBox[] tBoxes = new TextBox[11];
        private Label[] labels = new Label[11];
        private ChemistryElementController chemistryController;
        private OrganicController organicController;
        private PageController pageController;
        private ImageController imageController;
        private ViewController viewController;
        public BookPage1(MainWindow wind)
        {
            InitializeComponent();
            parent = wind;
            chemistryController = new ChemistryElementController();
            List<ChemistryElement> elements = chemistryController.findAll();
            chemistryController.close();
            generateMendeleev(elements);
        }


        private void formTable(List<ChemistryElement>elements)
        {
            try
            {
               Button button = new Button();
                button.Content = elements[0].TableTame + "     " + 1 + "\n"+elements[0].FullName+" "+elements[0].AtomicWeight;
                chemistryTable.Children.Add(button);
                Grid.SetRow(button, 0);
                Grid.SetColumn(button, 0);

                Button button1 = new Button();
                button1.Content = elements[1].TableTame + "     " + 2 + "\n" + elements[1].FullName + " " + elements[1].AtomicWeight;
                chemistryTable.Children.Add(button1);
                Grid.SetRow(button1, 0);
                Grid.SetColumn(button1, 10);
            } catch (Exception ex)
            {

            }

            for (int i = 2; i < elements.Count; i++)
            {
                Button button = new Button();
                button.Content = elements[i].TableTame + "     "+(i+1)+"\n" + elements[i].FullName + " " + elements[i].AtomicWeight;
                chemistryTable.Children.Add(button);
                int row = (i - 2) / chemistryTable.ColumnDefinitions.Count + 1;
                Grid.SetRow(button, row);
                int column = i % (chemistryTable.ColumnDefinitions.Count);
                if (i % (chemistryTable.ColumnDefinitions.Count) - 2 >= 0)
                {
                    Grid.SetColumn(button, column - 2);
                }
                else{
                    Grid.SetColumn(button, column+ chemistryTable.ColumnDefinitions.Count-2);
                }
            }
        }
        
        private void generateMendeleev(List<ChemistryElement> elements)
        {
           
            int startWhere10Columns = 18;
            int[] where8ColumnsCheck = { 2, 10, 28, 46, 64, 78, 85 };
            int rowWhere10Columns = 3;
            int rowWhere8Columns = 1;
            int i = 2; //index of List
            int index = 0;

            while (i < elements.Count)
            {
                Button button = new Button();
                button.Content = elements[i].TableTame + "     " + (i + 1) + "\n" + elements[i].FullName + " " + elements[i].AtomicWeight;
                chemistryTable.Children.Add(button);

                if (i == where8ColumnsCheck[index])
                {
                    int col = 0;
                    for (int j = i; j <= i + 7; j++)
                    {
                        Button buttonNew = new Button();
                        buttonNew.Content = elements[j].TableTame + "     " + (j + 1) + "\n" + elements[j].FullName + " " + elements[j].AtomicWeight;
                        switch (elements[j].Orbital)
                        {
                            case 's': buttonNew.Background = Brushes.Pink; break;
                            case 'p': buttonNew.Background = Brushes.LightYellow; break;
                            case 'd': buttonNew.Background = Brushes.LightBlue; break;
                        }
                        chemistryTable.Children.Add(buttonNew);
                        Grid.SetRow(buttonNew, rowWhere8Columns);
                        Grid.SetColumn(buttonNew, col);
                        col++;
                    }
                    rowWhere8Columns++;
                    i += 8; index++;
                }
                else if (i == startWhere10Columns)
                {
                    int col = 0;
                    for (int j = i; j <= i + 9; j++)
                    {
                        Button buttonNew = new Button();
                        buttonNew.Content = elements[j].TableTame + "     " + (j + 1) + "\n" + elements[j].FullName + " " + elements[j].AtomicWeight;
                        switch (elements[j].Orbital)
                        {
                            case 's': buttonNew.Background = Brushes.Pink; break;
                            case 'p': buttonNew.Background = Brushes.LightYellow; break;
                            case 'd': buttonNew.Background = Brushes.LightBlue; break;
                        }

                        chemistryTable.Children.Add(buttonNew);
                        Grid.SetRow(buttonNew, rowWhere10Columns);
                        Grid.SetColumn(buttonNew, col);
                        col++;
                    }
                    startWhere10Columns += 18; rowWhere10Columns += 2; i += 10; rowWhere8Columns = rowWhere10Columns - 1;
                }
                else
                {
                    chemistryTable.Children.Clear();
                    formTable(elements);
                    break;
                }
            }

            try
            {
                Button button = new Button();
                button.Content = elements[0].TableTame + "     " + 1 + "\n" + elements[0].FullName + " " + elements[0].AtomicWeight;
                button.Background = Brushes.Pink; 
                chemistryTable.Children.Add(button);
                Grid.SetRow(button, 0);
                Grid.SetColumn(button, 0);

                Button button1 = new Button();
                button1.Content = elements[1].TableTame + "     " + 2 + "\n" + elements[1].FullName + " " + elements[1].AtomicWeight;
                button1.Background = Brushes.Pink;
                chemistryTable.Children.Add(button1);
                Grid.SetRow(button1, 0);
                Grid.SetColumn(button1, 10);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
