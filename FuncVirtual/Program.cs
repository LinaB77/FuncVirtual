using System;

namespace FuncVirtual  //Иллюстрация механизма виртуальных функций
{
    class Point
    {
        string name = "Слой Point";
        public void Show0()
        {
            Console.WriteLine(name);
        }

        public virtual void Show()
        {
            Console.WriteLine(name);
        }
    }

    class Circle : Point
    {
        string name = "Слой Circle";
        new public void Show0()
        {
            Console.WriteLine(name);
        }

        public override void Show()
        {
            Console.WriteLine(name);
        }
    }

    class Cylinder : Circle
    {
        string name = "Слой Cylinder";
        new public void Show0()
        {
            Console.WriteLine(name);
        }

        public override void Show()
        {
            Console.WriteLine(name);
        }
    }

    // Вызывающая сторона
    class MyClass
    {
        public MyClass()
        {
            // Создаем объекты для всех типов 
            // иерархической цепочки наследования
            // и адресуем их базовой ссылкой
            Point[] point = {
                new Point(),
                new Circle(),
                new Cylinder()
            };

            // Распечатываем
            Console.WriteLine("Адресация к невиртуальной функции");
            for (int i = 0; i < point.Length; i++)
            {
                point[i].Show0();
            }

            Console.WriteLine("\nАдресация к виртуальной функции");
            for (int i = 0; i < point.Length; i++)
                point[i].Show();

            Console.WriteLine("\nТо же самое, только вручную");
            point[0].Show0();
            ((Circle)point[1]).Show0();
            ((Cylinder)point[2]).Show0();
        }
    }

    // Запуск
    class Program
    {
        static void Main()
        {
            // Настройка консоли
            Console.Title = "Механизм виртуальных функций";
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.WindowWidth = 60;
            Console.WindowHeight = 10;

            new MyClass();// Чтобы сработал конструктор

            Console.ReadLine();
        }
    }
}