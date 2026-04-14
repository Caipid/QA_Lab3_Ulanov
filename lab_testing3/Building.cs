using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary; // бинарная сериализация

namespace lab_testing3
{
    /*!
     * \brief Класс обычного здания.
     *
     * Базовый класс, представляющий обычное здание в составе предприятия.
     * Содержит информацию о площади и стоимости за квадратный метр.
     * 
     *  \see SpecialBuilding
     */
    public class Building
    {
        protected int s;       ///< площадь здания (м^2)
        protected double cost;  ///< стоимость за (м^2)

        /*!
         * \brief Рассчитывает стоимость здания
         * 
         * Вычисляет общую стоимость как произведение площади на стоимость за м².
         * 
         * \return Стоимость здания
         */
        public double Costed()
        {
            return s * cost;
        }

        /*!
         * \brief Конструктор класса Building.
         * 
         * Создает обычное здание
         * 
         * \param[in] cost стоимость за (м^2).
         * \param[in] ss площадь здания (м^2).
         */
        public Building(double cost, int ss)
        {
            this.s = ss;
            this.cost = cost;
        }
        /*!
         * \brief Конструктор по умолчанию класса Building.
         * 
         * Создает обычное здание с значениями по умолчанию:
         * s(площадь здания (м^2)) = 5.
         * cost(стоимость за (м^2)) = 4.
         */
        public Building()
        {
            s = 5;
            cost = 4;
        }

        /*!
         * \brief Считываение полей класса с консоли.
         * 
         * Производит переопредление значений полей класса,
         * на значения введные пользователем в консоли
         * 
         * \warning При некорректном вводе возникнет ошибка!
         */
        public void Read()
        {
            Console.Write("Введите площадь здания(м^2): ");
            s = int.Parse(Console.ReadLine());
            Console.Write("Введите стоимость за м^2 : ");
            cost = double.Parse(Console.ReadLine());
        }

        /*!
         * \brief Вывод информации о здании в консоль
         *
         *  Выводит:
         *  * Площадь здания (м^2)
         *  * Стоимость за (м^2)
         *  * Стоимость всего здания
         *
         * \see Costed()
         */
        public void Display()
        {
            Console.WriteLine($"Площадь здания(м^2): {s}");
            Console.WriteLine($"Стоимость за м^2 : {cost}");
            Console.WriteLine($"Стоимость всего здания: {Costed()}");
        }
    }


    /*!
     * \brief Класс-наследник Building
     *
     * Класс специального здания входящего в состав предприятия.
     * Класс имеет поле type влияющее на расчет стоимости.
     * 
     * \see Building
     */
    public class SpecialBuilding : Building
    {
        private int type;   ///< тип здания

        /*!
         * \brief Возвращает тип здания.
         * 
         * Функция класса SpecialBuilding для получения значения поля type
         * 
         * \return Тип здания
         */
        public int GetTypeBuilding()
        {
            return type;
        }

        /*!
         * \brief Рассчитывает стоимость здания с учетом типа.
         * 
         * Расчет стоимости производится c разным коэффицентом 
         * взависимости от типа специального здания
         * * 
         * Формула расчета стоимости:
         * \f[
         *     C = S \times P \times k(t)
         * \f]
         * где:
         * - \f$ C \f$ — общая стоимость здания
         * - \f$ S \f$ — площадь здания (м²)
         * - \f$ P \f$ — стоимость за м²
         * - \f$ k(t) \f$ — коэффициент типа здания:
         *   - \f$ k(0) = 0.3 \f$
         *   - \f$ k(1) = 1.0 \f$
         *   - \f$ k(2) = 0.5 \f$
         * 
         * \param[in] type Тип здания для расчета.
         * 
         * \return Стоимость здания
         */
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


        /*!
         * \brief Конструктор класса SpecialBuilding.
         * 
         * Создает специальное здание, передавая 
         * базовые параметры в родительский класс.
         * 
         * \param[in] cost Стоимость за квадратный метр (м^2).
         * \param[in] ss   Общая площадь здания (м^2).
         * \param[in] type Тип специального здания
         */
        public SpecialBuilding(double cost, int ss, int type)
        : base(cost, ss)
        {
            this.type = type;
        }
        /*!
         * \brief Конструктор по умолчанию класса SpecialBuilding.
         * 
         * Создает специальное здание с значениями по умолчанию:
         *  s(стоимость за (м^2)) = 5.
         *  cost(площадь здания (м^2)) = 4.
         *  type(тип здания) = 0.
         */
        public SpecialBuilding() : base(3, 5)
        {
            type = 0;
        }

        /*!
         * \brief Считываение полей класса с консоли.
         * 
         * Вызывает базовый метод Read()
         * Производит переопредление значений полей класса,
         * на значения введные пользователем в консоли
         * 
         * \warning При некорректном вводе возникнет ошибка!
         * 
         * \see Building::Read()
         */
        public void Read()
        {
            base.Read();
            Console.Write("Введите тип здания: ");
            type = int.Parse(Console.ReadLine());
        }


        /*!
         * \brief Выводит информацию о специальном здании в консоль.
         * 
          *  Выводит:
         *  * Площадь здания (м^2)
         *  * Стоимость за (м^2)
         *  * Стоимость всего здания
         *  * Тип здания
         * 
         * \param[in] type Тип здания для расчета стоимости.
         * 
         * \see Costed(int)
         */
        public void Display(int type)
        {
            Console.WriteLine($"Площадь здания(м^2): {s}");
            Console.WriteLine($"Стоимость за м^2 : {cost}");
            Console.WriteLine($"Стоимость всего здания: {Costed(type)}");
            Console.WriteLine($"Тип здания: {type}");
        }

    }
}
