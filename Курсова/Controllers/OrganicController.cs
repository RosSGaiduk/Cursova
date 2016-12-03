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
    class OrganicController
    {
        private OrganicService organicService;

        public OrganicController()
        {
            organicService = new OrganicService();
            organicService.connect();

            organicService.open();
            MySqlCommand command = organicService.getConnection().CreateCommand();
            organicService.setCommand(command);  
        }


        public void add(OrganicElement element){
            organicService.add(element);
        }

        public void delete(int id)
        {
            organicService.delete(id);
        }

        public OrganicElement finOne(int id)
        {
            return organicService.findOne(id);
        }

        public List<OrganicElement> findAll()
        {
            return organicService.findAll();
        }

        public void close()
        {
            organicService.close();
        }

    }
}
