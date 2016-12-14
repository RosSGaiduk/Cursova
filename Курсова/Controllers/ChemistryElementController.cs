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
    class ChemistryElementController
    {
        private ChemisrtyService chemistryService;

        public ChemistryElementController()
        {
            chemistryService = new ChemisrtyService();
            chemistryService.connect();

            chemistryService.open();
            MySqlCommand command = chemistryService.getConnection().CreateCommand();
            chemistryService.setCommand(command);
        }

        public ChemistryElement findByTableName(string tableName)
        {
            return chemistryService.findByTableName(tableName);
        }

        public void add(ChemistryElement chemistryElement){
            chemistryService.add(chemistryElement);
        }
        public void delete(int id){
            chemistryService.delete(id);
        }

        public ChemistryElement findOne(int id){
            return chemistryService.findOne(id);
        }

        public List<ChemistryElement> findAllByOrbital(string orbital)
        {
            return chemistryService.findAllByOrbital(orbital);
        }
        public List<ChemistryElement> findAllByGroup(string group)
        {
            return chemistryService.findAllByGroup(group);
        }

        public List<ChemistryElement> findAll()
        {
            return chemistryService.findAll();
        }

        public void close()
        {
            chemistryService.close();
        }
    }
}
