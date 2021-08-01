using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCubics.Data
{

    public class Cubic
    {
        //закрытые поля (доступ через свойства)
        Colors color;
        Materials material;
        int rib;

        public Colors Color
        {
            get { return color; }
            set { color = value; }
        }

        public Materials Material
        {
            get { return material; }
            set { material = value; }
        }

        public int Rib
        {
            get { return rib; }
            set {  rib = value; }
        }

        //конструктор для создания кубика 
        public Cubic(Colors _color, Materials _material, int _rib)
        {
            color = _color;
            material = _material;
            Rib = _rib;            
        }

        public Cubic()//конструктор по умолчанию нужен для сериализации
        {

        }

        public override string ToString()//строковое представление для кубика 
        {
            return String.Format("{0,10}{1,10}{2,10}", color, material, rib);
        }


    }
}
