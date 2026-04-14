using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_testing3
{
    using System;
    using System.Runtime.Intrinsics.X86;
    // Абстрактный класс
    abstract class Enterprise
    {
        protected string name;
        protected double add_room;

        public Enterprise(string name, double addRoom)
        {
            this.name = name;
            this.add_room = addRoom;
        }
        public abstract int SumBuild();
    }

    class Build : Enterprise
    {
        protected Building b1;
        protected Building b2;

        public Build(string name, double addRoom, int s1, int cost1, int s2, int cost2)
            : base(name, addRoom)
        {
            b1 = new Building(cost1, s1);
            b2 = new Building(cost2, s2);
        }

        public override int SumBuild()// перегрузка абстрактной функции
        {
            return (int)(b1.Costed() + b2.Costed());
        }
    }


    class SecondBuild : Enterprise
    {
        protected BuildingSec b1;
        protected BuildingSec b2;

        public SecondBuild(string name, double addRoom, int s1, int cost1, int type1,
                           int s2, int cost2, int type2)
            : base(name, addRoom)
        {
            b1 = new BuildingSec(cost1, s1, type1);
            b2 = new BuildingSec(cost2, s2, type2);
        }

        public override int SumBuild()
        {
            return (int)(b1.Costed(b1.GetTypeBuilding()) +
                         b2.Costed(b2.GetTypeBuilding()));
        }
    }


    class ComboBuild : Enterprise
    {
        protected Building b1;
        protected BuildingSec b2;

        public ComboBuild(string name, double addRoom,
                          int s1, int cost1,
                          int s2, int cost2, int type2)
            : base(name, addRoom)
        {
            b1 = new Building(cost1, s1);
            b2 = new BuildingSec(cost2, s2, type2);
        }

        public override int SumBuild()
        {
            return (int)(b1.Costed() + b2.Costed(b2.GetTypeBuilding()));
        }
    }

}
