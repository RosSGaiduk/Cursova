using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using Курсова.Services;
using Курсова.Controlls;

namespace Курсова.Controllers
{
    class ViewController
    {
        private MainWindow mainWind;

        public ViewController() { }

        public ViewController(MainWindow mainW) { mainWind = mainW; }

        public void goTo(string page)
        {
            switch (page)
            {
                case "deletePage":
                    {
                        mainWind.MainThis.Children.Clear();
                        mainWind.MainThis.Children.Add(new DeleteControl(mainWind));
                    } break;

                case "creatingPage":
                    {
                        mainWind.MainThis.Children.Clear();
                        mainWind.MainThis.Children.Add(new CreateControl(mainWind));
                    }
                    break;
                case "showAll":
                    {
                        mainWind.MainThis.Children.Clear();
                        mainWind.MainThis.Children.Add(new ShowAllElements(mainWind));
                    }
                    break;
            }
        }


    }
}
