using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

namespace Курсова.Services
{
    class OrganicService:ServiceAbstract
    {
        public void add(OrganicElement organicElement)
        {
            command.CommandText = "INSERT INTO OrganicElement " +
               "(Description,FullName,Formula,GraphicModel) VALUES(?descr,?fname,?frml,?graphModel)";
            command.Prepare();
            command.Parameters.AddWithValue("?descr", organicElement.Description);
            command.Parameters.AddWithValue("?fname", organicElement.FullName);
            command.Parameters.AddWithValue("?frml", organicElement.Formula);
            command.Parameters.AddWithValue("?graphModel", organicElement.GraphicModel);
            command.ExecuteNonQuery();
        }

        public void delete(int id)
        {
            command.CommandText = "Delete from OrganicElement where id = ?id1";
            command.Prepare();
            command.Parameters.AddWithValue("?id1", id);
            command.ExecuteNonQuery();
        }

        public OrganicElement findOne(int id)
        {
            command.CommandText = "Select * from OrganicElement where id = ?id";
            command.Prepare();
            command.Parameters.AddWithValue("?id", id);
            reader = command.ExecuteReader();
            reader.Read();
            OrganicElement organicElement;

            try
            {
                organicElement = new OrganicElement(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                return null;
            }

            return organicElement;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<OrganicElement> findAll()
        {
            List<OrganicElement> organicElements = new List<OrganicElement>();
            command.CommandText = "Select * from OrganicElement";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                organicElements.Add(new OrganicElement(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));        
            }
            reader.Close();
            return organicElements;
        }
    }
}
