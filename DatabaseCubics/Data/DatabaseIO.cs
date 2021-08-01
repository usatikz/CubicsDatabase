using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace DatabaseCubics.Data
{
    static class DatabaseIO
    {

        static public void Save(string filename, Database database)
        {
            FileStream fileStream = null;//создаем файловый поток
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Database));//обьект сериализатор, ему передаем обьект бд(разбирает на публичные свойст-ва )
                fileStream= new FileStream(filename, FileMode.Create);//обьект файлстрим связвыем с файлом на диске(говорим что надо его создать)
                serializer.Serialize(fileStream, database);//сериализуем в сам файлстрим
                fileStream.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
              
                if (fileStream != null) fileStream.Close();
            }
        }
        
        static public void Load(string filename, out Database database)//десериализация
        {            
            FileStream fileStream = null;
            database = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Database));
                fileStream= new FileStream(filename, FileMode.Open);
                database = (Database)serializer.Deserialize(fileStream);
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }
        }

    }
}
