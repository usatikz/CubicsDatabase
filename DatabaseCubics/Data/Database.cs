using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DatabaseCubics.Data
{
    
     public class Database
    {  
        List<Cubic> list;

        public List<Cubic> List
        {
            get { return list; }
            set { list = value; }
        }
     
        public Database()
        {
            list = new List<Cubic>();
        }

        public void RemoveAt(int index)// реализация удаления 
        {
            list.RemoveAt(index);
        }

        public void Add(Cubic cubic)
        {
            list.Add(cubic);
        }

        //Индексатор(первичный ключ)
        public Cubic this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }



            public override string ToString()
        {
            string s = String.Format("{0,10}{1,10}{2,10}{3,10}\n", "N", "Color", "Material", "Length");
            int index = 0;
            foreach (Cubic cubic in list)
            {
                s += String.Format("{0,10}{1,10}{2,10}{3,10}\n", index++, cubic.Color, cubic.Material, cubic.Rib);
            }
            return s;
        }
    }

 
}
