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
    /// Логика взаимодействия для DeleteControl.xaml
    /// </summary>
    
    public partial class DeleteControl : UserControl
    {
        private MainWindow parent;
        private ChemistryElementController chemistryController;
        private OrganicController organicController;
        private PageController pageController;
        private ImageController imageController;
        private ViewController viewController;
        private string block = "---------------------------------------------\n";

        public DeleteControl(MainWindow mainW)
        {
            InitializeComponent();
            parent = mainW;
            viewController = new ViewController(parent);
            comboBox1.Items.Add("Хімічний елемент");
            comboBox1.Items.Add("Органічний елемент");
            comboBox1.Items.Add("Сторінка");
            comboBox1.Items.Add("Картинка");

            comboBox2.Items.Add("All");
            comboBox2.SelectedIndex = 0;
            comboBox2.Items.Add("One");
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            int index = comboBox1.SelectedIndex;
            comboBox3.Items.Clear();
            richTextBox.Document.Blocks.Clear();
            comboBox2.SelectedIndex = 0;

            //В залежності від того, яку сутність з бд що ми обрали, такими id-шками має наповнитись combobox3
            switch (index)
            {
                case 0:
                    {
                        chemistryController = new ChemistryElementController();
                        List<ChemistryElement> elements = chemistryController.findAll();
                        
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (comboBox2.SelectedIndex == 0)                   
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + elements[i].ToString() + "\n" + block)));
                            comboBox3.Items.Add(elements[i].Id);
                        }
                        chemistryController.close();
                    } break;

                case 1:
                    {
                        organicController = new OrganicController();
                        List<OrganicElement> elements = organicController.findAll();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + elements[i].ToString() + "\n" + block)));
                            comboBox3.Items.Add(elements[i].Id);       
                        }
                        organicController.close();
                    } break;

                case 2:
                    {
                        pageController = new PageController();
                        List<PageWithTextAndImage> elements = pageController.findAll();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + elements[i].ToString() + "\n" + block)));
                            comboBox3.Items.Add(elements[i].Id);
                        }
                        pageController.close();
                    }
                    break;


                case 3:
                    {
                        imageController = new ImageController();
                        List<Picture> elements = imageController.findAll();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + elements[i].ToString() + "\n" + block)));
                            comboBox3.Items.Add(elements[i].Id);
                        }
                        imageController.close();
                    }
                    break;


            }

        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        richTextBox.Document.Blocks.Clear();
                        chemistryController = new ChemistryElementController();
                        if (comboBox2.SelectedIndex == 0)
                        {
                            List<ChemistryElement> elements = chemistryController.findAll();
                            foreach(ChemistryElement element in elements)
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block+element.ToString()+"\n"+block)));
                        } else
                        {
                            richTextBox.Document.Blocks.Clear();
                            try
                            {
                                if (comboBox3.SelectedValue.ToString() != "")
                                {
                                    int id = int.Parse(comboBox3.SelectedValue.ToString());
                            
                                    richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + chemistryController.findOne(id).ToString() + "\n" + block)));
                                }
                            } catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }
                        chemistryController.close();
                    } break;

                case 1:
                    {
                        richTextBox.Document.Blocks.Clear();
                        organicController = new OrganicController();
                        if (comboBox2.SelectedIndex == 0)
                        {
                            List<OrganicElement> elements = organicController.findAll();
                            foreach (OrganicElement element in elements){
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + element.ToString() + "\n" + block)));
                            }
                        } else
                        {
                            richTextBox.Document.Blocks.Clear();
                            try
                            {
                                if (comboBox3.SelectedValue.ToString() != "")
                                {
                                    int id = int.Parse(comboBox3.SelectedValue.ToString());
                                    richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + organicController.finOne(id).ToString() + "\n" + block)));
                                }
                            } catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }
                        organicController.close();
                    } break;

                case 2:
                    {
                        richTextBox.Document.Blocks.Clear();
                        pageController = new PageController();
                        if (comboBox2.SelectedIndex == 0)
                        {
                            List<PageWithTextAndImage> elements = pageController.findAll();
                            foreach (PageWithTextAndImage element in elements)
                            {
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + element.ToString() + "\n" + block)));
                            }
                        }
                        else
                        {
                            richTextBox.Document.Blocks.Clear();
                            try
                            {
                                if (comboBox3.SelectedValue.ToString() != "")
                                {
                                    int id = int.Parse(comboBox3.SelectedValue.ToString());
                                    richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + pageController.findOne(id).ToString() + "\n" + block)));
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }
                        pageController.close();
                    }
                    break;



                case 3:
                    {
                        richTextBox.Document.Blocks.Clear();
                        imageController = new ImageController();
                        if (comboBox2.SelectedIndex == 0)
                        {
                            List<Picture> elements = imageController.findAll();
                            foreach (Picture element in elements)
                            {
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + element.ToString() + "\n" + block)));
                            }
                        }
                        else
                        {
                            richTextBox.Document.Blocks.Clear();
                            try
                            {
                                if (comboBox3.SelectedValue.ToString() != "")
                                {
                                    int id = int.Parse(comboBox3.SelectedValue.ToString());
                                    richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + imageController.findOne(id).ToString() + "\n" + block)));
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }
                        imageController.close();
                    }
                    break;


            }
        }

        private void comboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            switch (index)
            {
                case 0:
                    {
                        if (comboBox2.SelectedValue.ToString() == "One")
                        {
                            try {
                                richTextBox.Document.Blocks.Clear();
                                chemistryController = new ChemistryElementController();
                                int id = int.Parse(comboBox3.SelectedValue.ToString());
                                string block = "---------------------------------------------\n";
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + chemistryController.findOne(id).ToString() + "\n" + block)));
                                chemistryController.close();
                            } catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }                 
                    } break;

                case 1:
                    {
                        if (comboBox2.SelectedValue.ToString() == "One")
                        {
                            try
                            {
                                richTextBox.Document.Blocks.Clear();
                                organicController = new OrganicController();
                                int id = int.Parse(comboBox3.SelectedValue.ToString());
                                string block = "---------------------------------------------\n";
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + organicController.finOne(id).ToString() + "\n" + block)));
                                organicController.close();
                            } catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }
                    } break;

                case 2:
                    {
                        if (comboBox2.SelectedValue.ToString() == "One")
                        {
                            try
                            {
                                richTextBox.Document.Blocks.Clear();
                                pageController = new PageController();
                                int id = int.Parse(comboBox3.SelectedValue.ToString());
                                string block = "---------------------------------------------\n";
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + pageController.findOne(id).ToString() + "\n" + block)));
                                pageController.close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }
                    }
                    break;

                case 3:
                    {
                        if (comboBox2.SelectedValue.ToString() == "One")
                        {
                            try
                            {
                                richTextBox.Document.Blocks.Clear();
                                imageController = new ImageController();
                                int id = int.Parse(comboBox3.SelectedValue.ToString());
                                string block = "---------------------------------------------\n";
                                richTextBox.Document.Blocks.Add(new Paragraph(new Run(block + imageController.findOne(id).ToString() + "\n" + block)));
                                imageController.close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Firstly select id of element!!!");
                            }
                        }
                    }
                    break;


            }
        }

        private void OnDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                 id = int.Parse(comboBox3.Text);

            } catch (Exception ex)
            {
                MessageBox.Show("Firstry select id of element");
                return;
            }
            try
            {
               
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            chemistryController = new ChemistryElementController();
                            chemistryController.delete(id);
                            chemistryController.close();
                        } break;

                    case 1:
                        {
                            organicController = new OrganicController();
                            organicController.delete(id);
                            organicController.close();
                        }
                        break;

                    case 2:
                        {
                            pageController = new PageController();
                            pageController.delete(id);
                            pageController.close();
                        }
                        break;

                    case 3:
                        {
                            imageController = new ImageController();
                            imageController.delete(id);
                            imageController.close();
                        }
                        break;

                }
                updateCombobox3(id.ToString());

            }         
           finally
            {
                richTextBox.Document.Blocks.Clear();
                MessageBox.Show("Successfully deleted from "+comboBox1.SelectedValue.ToString());
            }
        }
        
       private void updateCombobox3(string val)
        {
            for (int i = 0; i < comboBox3.Items.Count; i++)
                if (comboBox3.Items[i].ToString() == val)
                {
                    comboBox3.Items.RemoveAt(i);
                    break;
                }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //viewController.goTo("creatingPage");
            viewController.checkUserGo("creatingPage");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            viewController.goTo("showAll");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            viewController.goTo("book");
        }
    }
}
