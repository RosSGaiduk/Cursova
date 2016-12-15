using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

namespace Курсова.Services
{
    class PageService:ServiceAbstract
    {
        public void add(PageWithTextAndImage page)
        {
            command.CommandText = "INSERT INTO PageWithTextAndImage " +
               "(NumberOfPage,TextInPage) VALUES(?number,?text)";
            command.Prepare();
            command.Parameters.AddWithValue("?number", page.NumberOfPage);
            command.Parameters.AddWithValue("?text", page.TextInPage);
            command.ExecuteNonQuery();
        }

        public void delete(int id)
        {
            command.CommandText = "Delete from PageWithTextAndImage where id = ?id1";
            command.Prepare();
            command.Parameters.AddWithValue("?id1", id);
            command.ExecuteNonQuery();
        }

        public PageWithTextAndImage findOne(int id)
        {
            command.CommandText = "Select * from PageWithTextAndImage where id = ?id";
            command.Prepare();
            command.Parameters.AddWithValue("?id", id);
            reader = command.ExecuteReader();
            reader.Read();
            PageWithTextAndImage page;

            try
            {
                page = new PageWithTextAndImage(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                return null;
            }

            return page;
        }


        public int findMaxPage()
        {
            command.CommandText = "Select max(NumberOfPage) from PageWithTextAndImage where id>1";
            command.ExecuteNonQuery();
            reader = command.ExecuteReader();
            reader.Read();
            int max = int.Parse(reader[0].ToString());
            reader.Close();
            return max;
        }
        public PageWithTextAndImage findOneByPage(int pageNumber)
        {
            command.CommandText = "Select * from PageWithTextAndImage where NumberOfPage = ?page";
            command.Prepare();
            command.Parameters.AddWithValue("?page", pageNumber);
            reader = command.ExecuteReader();
            reader.Read();
            PageWithTextAndImage page;

            try
            {
                page = new PageWithTextAndImage(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                return null;
            }

            return page;
        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<PageWithTextAndImage> findAll()
        {
            List<PageWithTextAndImage> pages = new List<PageWithTextAndImage>();
            command.CommandText = "Select * from PageWithTextAndImage";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                pages.Add(new PageWithTextAndImage(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString()));
            }
            reader.Close();
            return pages;
        }

        public HashSet<Picture> findAllPicturesByIdPage(int idPage)
        {
            HashSet<Picture> pictures = new HashSet<Picture>();
            //select * from picture join picture_page on picture_page.id_page = 7 and picture.id = picture_page.id_picture;
            command.CommandText = "Select * from picture join picture_page on picture_page.id_page = ?idPage and picture.id = picture_page.id_picture";
            command.Prepare();
            command.Parameters.AddWithValue("?idPage", idPage);
            reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                
                pictures.Add(new Picture(reader[1].ToString()));
            }
            reader.Close();
            return pictures;
        }

    }
}
