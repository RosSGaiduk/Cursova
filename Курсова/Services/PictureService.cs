using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

namespace Курсова.Services
{
    class PictureService:ServiceAbstract
    {
        public void add(Picture picture)
        {
            command.CommandText = "INSERT INTO Picture " +
               "(UrlOfImage) VALUES(?url)";
            command.Prepare();
            command.Parameters.AddWithValue("?url", picture.UrlOfImage);
            command.ExecuteNonQuery();
        }

        public void delete(int id)
        {
            command.CommandText = "Delete from Picture where id = ?id1";
            command.Prepare();
            command.Parameters.AddWithValue("?id1", id);
            command.ExecuteNonQuery();
        }

        public Picture findOne(int id)
        {
            command.CommandText = "Select * from Picture where id = ?id";
            command.Prepare();
            command.Parameters.AddWithValue("?id", id);
            reader = command.ExecuteReader();
            reader.Read();
            Picture picture;
            try
            {
                picture = new Picture(int.Parse(reader[0].ToString()), reader[1].ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                return null;
            }

            return picture;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Picture> findAll()
        {
            List<Picture> pictures = new List<Picture>();
            command.CommandText = "Select * from Picture";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                pictures.Add(new Picture(int.Parse(reader[0].ToString()), reader[1].ToString()));
            }
            reader.Close();
            return pictures;
        }
    }
}
