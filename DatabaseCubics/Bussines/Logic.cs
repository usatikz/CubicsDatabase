
using System;
using System.Collections.Generic;
using DatabaseCubics.Data;

namespace DatabaseCubics.Bussines
{
    class Logic
    {
  
        Database database;

        public Logic(Database database)//передаем базу данных
        {
            this.database = database;
        }

       
        public int CountAll() { return database.List.Count;  }

        public void Update(int n, Cubic cubic)
        {
            database[n] = cubic;// как бы присваеваем новый кубик 
        }

        public void Add(Cubic cubic)
        {
            database.Add(cubic);
        }
    
        public void RemoveAt(int index)
        {
            database.RemoveAt(index);
        }

        public void Save(string filename)
        {
            DatabaseIO.Save(filename, database);
        }

        public void Load(string filename)
        {
            DatabaseIO.Load(filename, out database);
        }


        public int MainSolve(int rib)//Выбираем только красные деревянные кубики
        {
            int count = 0;
            foreach (Cubic cubic in database.List) // итератор в листе 
            {
                if (cubic.Color == Colors.Red && cubic.Material == Materials.Wood && cubic.Rib <= rib) count++;
            }
            return count;
        }
        public List<Cubic> GetAll()
        {
            List<Cubic> cub = new List<Cubic>();
            for (int i = 0; i < CountAll(); i++)
            {
                cub.Add(database[i]);}
            return cub;
        }

    public Cubic GetRecord(int n)
        { return database[n]; }

    }
}
