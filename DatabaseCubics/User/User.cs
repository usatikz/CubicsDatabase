using System;
using DatabaseCubics.Data;
using DatabaseCubics.Bussines;

namespace DatabaseCubics.User
{
    class UserLogic
    {
        
        Logic logic = new Logic(new Database());

        public int Menu()
        {
                Console.WriteLine("\n1. Add record");
                Console.WriteLine("2. Delete record");
                Console.WriteLine("3. Show all records");
                Console.WriteLine("4. Show one record");
                Console.WriteLine("5. Update record");
                Console.WriteLine("6. Task solve");
                Console.WriteLine("7. Save database");
                Console.WriteLine("8. Load database");
                Console.WriteLine("0. Exit");
                ConsoleKeyInfo key = Console.ReadKey();
                int select = (int)Char.GetNumericValue(key.KeyChar);
            return select;            
        }

        public void Run()//показывает меню
        {
            int m;
            do
            {
                m = Menu();
                DoIt(m);
            }
            while (m != 0);
        }

        public void AddRecord()//добавление записи в бд
        {
             Cubic cubic = InputCubic(); 
                logic.Add(cubic);     
        }

        public void ShowAllRecords()//выводим все записи
        {
            Console.WriteLine();
            for (int i = 0; i < logic.CountAll(); i++)
            {
                Console.WriteLine(logic.GetAll()[i].Color + "    " + logic.GetAll()[i].Material + "   " + logic.GetAll()[i].Rib) ;
            }
        }

        public void ShowOneRecord()//показать одну запись
        {
            int n;
            if (InputBound("\nInput record number:", 0, logic.CountAll(), out n))
                Console.WriteLine(logic.GetRecord(n));
            else Console.WriteLine("No record !");

        }

        public Colors InputColor()//ввод цвета
        {
            Type type = typeof(Colors);//Используя рефлексию получаем тип данных и находим все значения перечислений
            int index = 0;
            Console.WriteLine();
            foreach (var color in type.GetEnumValues())
            {
                Console.WriteLine("{0}.{1}", index++, color);
            }
            bool flag;//проверка на правильный ввод данных для цвета
            int n;
            do
            {
                Console.WriteLine("\nInput color:");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (n >= index || n<0) flag = false;
                if (flag == false) Console.WriteLine("Invalid entry!");
            }
            while (flag == false);
            return (Data.Colors)n;
        }

        public Materials InputMaterial()//проверка на правильный ввод данных для материала
        {
            Type type = typeof(Materials);
            int index = 0;
            Console.WriteLine();
            foreach (var material in type.GetEnumValues())
            {
                Console.WriteLine("{0}.{1}", index++, material);
            }
            bool flag;
            int n;
            do
            {
                Console.WriteLine("\nInput material:");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (n >= index || n < 0) flag = false;

                if (flag == false) Console.WriteLine("Invalid entry!");
            }
            while (flag == false);
            return (Materials)n;
        }

        public int InputRib()
        {
            bool flag;
            int n;
            do
            {
                Console.WriteLine("\nInput length rib:");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (n <= 0 || n > 10000) flag = false;
                if (flag == false) Console.WriteLine("Entry rib length from 1 to 10000!");
            }
            while (flag == false);
            return n;
        }

        public bool InputBound(string message, int min,int max, out int n)//ограничение ввода данных 
        {
            bool flag;
            
            Console.WriteLine(message);
            flag = int.TryParse(Console.ReadLine(), out n);
            if (n < min || n >= max) flag = false;
            if (flag == false) Console.WriteLine("Invalid entry!");
            return flag;
        }

        public Cubic InputCubic() 
        {
            Colors color = InputColor();
            Materials material = InputMaterial();
            int rib = InputRib();
            return new Cubic(color, material, rib);// возвращаем  в качестве результата обьект кубик
        }

        public void UpdateRecord() 
        {
            int n;
            if (InputBound("\nInput record number",0,logic.CountAll(),out n))//ограничен из возможных
            {
                Cubic cubic = InputCubic();
                logic.Update(n, cubic);
            }
        }

        
       public void Save()//сохранение бд
        {
            string s = ".xml";
            Console.WriteLine("\nSave file\nInput filename:");
            string filename = Console.ReadLine();
            logic.Save(filename+s);
        }

        public void Load()// загрузить
        {
            string s = ".xml";
            Console.WriteLine("\nLoad file\nInput filename:");
            string filename = Console.ReadLine();
            logic.Load(filename+s);
        }

        public void DeleteRecord()//удаление записи
        {
            Console.WriteLine("\nDelete record");
            Console.WriteLine("All records:{0}", logic.CountAll());
            int n;
            if (InputBound("Input record number: ", 0, logic.CountAll(), out n) == true) logic.RemoveAt(n);//ограничение из возможных
            else Console.WriteLine("Delete nothing!");
        }

        public void TaskSolve()// решение задачи
        {
            int ribLength;
            ribLength=InputRib();
            Console.WriteLine("Count red wood cubics with length less or equal than {0} are {1}", ribLength, logic.MainSolve(ribLength));
        }
        public void DoIt(int m)//различные методы,которые вызываются при нажатии в меню
        {
            switch (m)
            {
                case 1:
                    AddRecord();
                    break;
                case 2:
                    DeleteRecord();
                    break;
                case 3:
                    ShowAllRecords();
                    break;
                case 4:
                    ShowOneRecord();
                    break;
                case 5:
                    UpdateRecord();
                    break;
                case 6:
                    TaskSolve();
                    break;
                case 7:
                    Save();
                    break;
                case 8:
                    Load();
                    break;
                default:
                    break;
            }
        }

    }
}
