using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_testing3
{
    using System;
    using System.Runtime.Intrinsics.X86;
    /*!
     * \brief Абстрактный базовый класс корпорации.
     *
     * Класс представляет собой шаблон для различных типов корпораций.
     * Содержит общие поля и абстрактный метод для расчета стоимости.
     * 
     * \image html dia.jpg 'Диаграмма классов'
     * 
     * \see StandartEnt, SpecialEnt, ComboEnt
     */
    abstract class Enterprise
    {
        protected string name;      ///< Название корпорации
        protected double add_room;  ///< Площадь дополнительных помещений (м^2)


        /*!
         * \brief Конструктор класса Enterprise.
         * 
         * \param name Название корпорации.
         * \param addRoom Площадь дополнительных помещений (м^2).
         */
        public Enterprise(string name, double addRoom)
        {
            this.name = name;
            this.add_room = addRoom;
        }

        /*!
        * \brief Рассчитывает суммарную стоимость всех зданий корпорации.
        * \return Стоимость всех зданий корпорации.
        * 
        * Абстрактный метод, который должен быть реализован 
        * в классах-наследниках
        * 
        * \return Суммарная стоимость всех зданий корпорации.
        */
        public abstract int SumBuild();
    }

    /*!
     * \brief Коорпорация с обычными зданиями
     * 
     * Класс-наследник Enterprise, содержащий два обычных здания.
     * 
     * \see Enterprise, Building
    */
    public class StandartEnt : Enterprise
    {
        protected Building b1;  ///< Первое здание корпорации
        protected Building b2;   ///< Второе здание корпорации

        /*!
         * \brief Конструктор класса StandartEnt.
         * 
         * Создает корпорацию с двумя стандартными зданиями. 
         * 
         * \param name Название корпорации.
         * \param addRoom Площадь дополнительных помещений (м^2).
         * \param s1 Площадь первого здания (м^2).
         * \param cost1 Стоимость за квадратный метр первого здания.
         * \param s2 Площадь второго здания (м^2).
         * \param cost2 Стоимость за квадратный метр второго здания.
         */
        public StandartEnt(string name, double addRoom, int s1, int cost1, int s2, int cost2)
            : base(name, addRoom)
        {
            b1 = new Building(cost1, s1);
            b2 = new Building(cost2, s2);
        }


        /*!
        * \brief Рассчитывает суммарную стоимость зданий корпорации.
        * 
        * Суммирует стоимость двух стандартных зданий, 
        * используя метод Building::Costed().
        * 
        * \return Стоимость всех зданий корпорации.
        * 
        * \see Building::Costed()
        */
        public override int SumBuild()// перегрузка абстрактной функции
        {
            return (int)(b1.Costed() + b2.Costed());
        }
    }

    /*!
     * \brief Корпорация со специальными зданиями.
     *
     * Класс-наследник Enterprise, содержащий два специальных здания
     * с учетом их типов при расчете стоимости.
     * 
     * \see Enterprise, SpecialBuilding
     */
    public class SpecialEnt : Enterprise
    {
        protected SpecialBuilding b1;  ///< Первое специальное здание
        protected SpecialBuilding b2; ///< Второе специальное здание

        /*!
         * \brief Конструктор класса SpecialEnt.
         * 
         * Создает корпорацию с двумя специальными зданиями.
         * 
         * \param name Название корпорации.
         * \param addRoom Площадь дополнительных помещений (м^2).
         * \param s1 Площадь первого здания (м^2).
         * \param cost1 Стоимость за квадратный метр первого здания.
         * \param type1 Тип первого здания.
         * \param s2 Площадь второго здания (м^2).
         * \param cost2 Стоимость за квадратный метр второго здания.
         * \param type2 Тип второго здания.
         */
        public SpecialEnt(string name, double addRoom, int s1, int cost1, int type1,
                           int s2, int cost2, int type2)
            : base(name, addRoom)
        {
            b1 = new SpecialBuilding(cost1, s1, type1);
            b2 = new SpecialBuilding(cost2, s2, type2);
        }


        /*!
         * \brief Рассчитывает суммарную стоимость зданий корпорации.
         * 
         * Суммирует стоимость двух специальных зданий,
         * используя методы SpecialBuilding::Costed() и SpecialBuilding::GetTypeBuilding().
         * 
         * \return Суммарная стоимость всех зданий корпорации.
         * 
         * \see SpecialBuilding::Costed(), SpecialBuilding::GetTypeBuilding()
         */
        public override int SumBuild()
        {
            return (int)(b1.Costed(b1.GetTypeBuilding()) +
                         b2.Costed(b2.GetTypeBuilding()));
        }
    }

    /*!
    * \brief Корпорация с комбинированными зданиями.
    *
    * Класс-наследник Enterprise, содержащий одно стандартное
    * и одно специальное здание.
    * 
    * \see Enterprise, Building, SpecialBuilding
    */
    public class ComboEnt : Enterprise
    {
        protected Building b1;///< обычное здание корпорации
        protected SpecialBuilding b2; ///< Специальное здание корпорации


        /*!
         * \brief Конструктор класса ComboEnt.
         * 
         * Создает предприятие с одним стандартным и одним специальным зданием.
         * 
         * \param name Название корпорации.
         * \param addRoom Площадь дополнительных помещений (м^2).
         * \param s1 Площадь первого здания (м^2).
         * \param cost1 Стоимость за квадратный метр первого здания.
         * \param s2 Площадь второго здания (м^2).
         * \param cost2 Стоимость за квадратный метр второго здания.
         * \param type2 Тип второго здания.
         */
        public ComboEnt(string name, double addRoom,
                          int s1, int cost1,
                          int s2, int cost2, int type2)
            : base(name, addRoom)
        {
            b1 = new Building(cost1, s1);
            b2 = new SpecialBuilding(cost2, s2, type2);
        }

        /*!
        * \brief Рассчитывает суммарную стоимость зданий корпорации.
        * 
        * Суммирует стоимость обычного здания (Building::Costed()) 
        * и специального здания с учетом его типа 
        * (SpecialBuilding::Costed(), SpecialBuilding::GetTypeBuilding()).
        * 
        * \return Суммарная стоимость всех зданий корпорации.
        * 
        * \see Building::Costed(), SpecialBuilding::Costed(), SpecialBuilding::GetTypeBuilding()
        */
        public override int SumBuild()// перегрузка абстрактной функции
        {
            return (int)(b1.Costed() + b2.Costed(b2.GetTypeBuilding()));
        }
    }

}
