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
    class ImageController
    {
        private PictureService pictureService;

        public ImageController()
        {
            pictureService = new PictureService();
            pictureService.connect();

            pictureService.open();
            MySqlCommand command = pictureService.getConnection().CreateCommand();
            pictureService.setCommand(command);
        }


        public void add(Picture page)
        {
            pictureService.add(page);
        }

        public void delete(int id)
        {
            pictureService.delete(id);
        }

        public Picture findOne(int id)
        {
            return pictureService.findOne(id);
        }

        public List<Picture> findAll()
        {
            return pictureService.findAll();
        }

        public void close()
        {
            pictureService.close();
        }
    }
}
