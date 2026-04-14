using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary; // бинарная сериализация

namespace lab_testing3
{
    public class Building
    {
        protected int s;       // площадь
        protected double cost; // стоимость за м^2

        public double Costed()
        {
            return s * cost;
        }

        public Building(double cost, int ss)
        {
            this.s = ss;
            this.cost = cost;
        }

        public Building()
        {
            s = 5;
            cost = 4;
        }


        public void Read()
        {
            Console.Write("Введите площадь здания(м^2): ");
            s = int.Parse(Console.ReadLine());
            Console.Write("Введите стоимость за м^2 : ");
            cost = double.Parse(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine($"Площадь здания(м^2): {s}");
            Console.WriteLine($"Стоимость за м^2 : {cost}");
            Console.WriteLine($"Стоимость всего здания: {Costed()}");
        }
    }

    class BuildingSec : Building
    {
        private int type;

        public int GetTypeBuilding()
        {
            return type;
        }

        public double Costed(int type)
        {
            return type switch
            {
                1 => s * cost,
                2 => s * cost * 0.5,
                0 => s * cost * 0.3,
                _ => 0,
            };
        }

        public BuildingSec(double cost, int ss, int type)
        : base(cost, ss)
        {
            this.type = type;
        }

        public BuildingSec() : base(3, 5)
        {
            type = 0;
        }

        public void Read()
        {
            base.Read();
            Console.Write("Введите тип здания: ");
            type = int.Parse(Console.ReadLine());
        }

        public void Display(int type)
        {
            Console.WriteLine($"Площадь здания(м^2): {s}");
            Console.WriteLine($"Стоимость за м^2 : {cost}");
            Console.WriteLine($"Стоимость всего здания: {Costed(type)}");
            Console.WriteLine($"Тип здания: {type}");
        }

    }
}
