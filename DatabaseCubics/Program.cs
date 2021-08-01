using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCubics.Data;
using DatabaseCubics.User;

namespace DatabaseCubics
{
    class Program
    {
        static void Main(string[] args)
        {
            UserLogic userLogic = new UserLogic();
            userLogic.Run();
        }
    }
}
