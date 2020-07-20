using System;

namespace Possibility
{
    class Program
    {
        static void Main(string[] args)
        {
            int Try = 500000; // кол-во попыток
            int Hit = 0; // кол-во угадываний
            int HitIfChange = 0; // кол-во угадываний, если сменить выбор
            Random rand = new Random();

            for (int i = 0; i < Try; i++)
            {
                var chance = new bool[3];
                for (int j = 0; j < chance.Length; j++) chance[j] = false;
                chance[rand.Next(chance.Length)] = true; // выбор случайной "выигрышной" ячейки

                int favorite = rand.Next(chance.Length); // загадываем ячейку

                int SelectionOfHost = 0; // выбор ячейки ведущего
                for (int j = 0; j < chance.Length; j++)
                    if (!chance[j] && j != favorite) // пустая ячейка, которую не выбрал игрок
                    {
                        SelectionOfHost = j;
                        break;
                    }

                int favoriteIfChange = 0;
                for (int j = 0; j < chance.Length; j++) //меняем выбранную нами ячейку
                    if (j != favorite && j != SelectionOfHost) 
                        favoriteIfChange = j;

                if (chance[favoriteIfChange]) HitIfChange++;
                if (chance[favorite]) Hit++;
            }

            Console.WriteLine("Меняя выбор угадал {0}/{1} \t({2}%)", HitIfChange, Try, (HitIfChange / (float)Try * 100));
            Console.WriteLine("Не меняя выбор угадал {0}/{1} \t({2}%)", Hit, Try, (Hit / (float)Try * 100));
            Console.ReadLine();
        }
    }
}
