using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using Курсова.Services;

namespace Курсова.Controllers
{
    class PageController
    {
        private PageService pageService;

        public PageController()
        {
            pageService = new PageService();
            pageService.connect();

            pageService.open();
            MySqlCommand command = pageService.getConnection().CreateCommand();
            pageService.setCommand(command);
        }


        public void add(PageWithTextAndImage page)
        {
            pageService.add(page);
        }

        public void delete(int id)
        {
            pageService.delete(id);
        }

        public PageWithTextAndImage findOne(int id)
        {
            return pageService.findOne(id);
        }

        public List<PageWithTextAndImage> findAll()
        {
            return pageService.findAll();
        }

        public void close()
        {
            pageService.close();
        }

        public HashSet<Picture> findAllPicturesByIdPage(int idPage)
        {
            return pageService.findAllPicturesByIdPage(idPage);
        }
        public PageWithTextAndImage findOneByPage(int pageNumber)
        {
            return pageService.findOneByPage(pageNumber);
        }



    }
}
