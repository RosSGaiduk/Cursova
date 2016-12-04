﻿using System;
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

        public void checkUserGo(string urlPageWanted)
        {
            mainWind.MainThis.Children.Clear();
            if (!mainWind.getAuth())
            {
                mainWind.MainThis.Children.Add(new CheckingUser(mainWind, urlPageWanted));
            } else goTo(urlPageWanted);
        }

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
                case "book":
                    {
                        mainWind.MainThis.Children.Clear();
                        mainWind.MainThis.Children.Add(new BookPage1(mainWind));
                    } break;
            }
        }


    }
}
