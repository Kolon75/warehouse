using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Pallet> pallet = new List<Pallet>();
            Random rand = new Random();
            bool NameMonth = true;

            //Создание рандомного количества паллет
            for (int i = 0; i < rand.Next(9, 15); i++)
            {
                pallet.Add(new Pallet(i));
                for (int j = 0; j < rand.Next(3, 5); j++)
                {
                    //Заполнение палет коробками
                    //Размеры коробок создаютя специально так чтобы не превышать размеры палет(опционально поставлено ограничение в атрибутах класса)
                    pallet[i].Boxes.Add(new Box(i, j, rand.Next(1, 7) * 100, rand.Next(1, 11) * 100, rand.Next(2, 5) * 100, rand.Next(2, 11) * 10,new DateTime(2024, rand.Next(1, 12), rand.Next(1, 30))));
                    //Перешёт атрибутов паллеты
                    pallet[i].Weight += pallet[i].Boxes[j].Weight;
                    pallet[i].Volume += pallet[i].Boxes[j].Volume;
                    if (pallet[i].Date > pallet[i].Boxes[j].Date || j == 0)
                    {
                        pallet[i].Date = pallet[i].Boxes[j].Date;
                    }             
                }

            }


            //Сортировка паллет по весу
            pallet.Sort((x, y) => x.Weight.CompareTo(y.Weight));
            //Групприровка и сортировка паллет по месяцам
            for (int j = 1; j < 13; j++)
            {
                for (int i = 0; i < pallet.Count; i++)
                {
                    if (pallet[i].Date.Month == j)
                    {
                        if (NameMonth)
                        {
                            Console.WriteLine($"\nПаллеты со сроком годности до {j} месяца 2024 года ");
                            NameMonth = false;
                        }
                        Console.WriteLine($"   Паллета №{i} с весом {pallet[i].Weight}");
                    }
                }
                NameMonth = true;
            }
            //Сортировка паллет по сроку годности
            pallet.Sort((x, y) => x.Date.CompareTo(y.Date));
            //Сортировка и вывод 3 последних палет по весу
            pallet.Sort(pallet.Count-3, 3, new Pallet());
            Console.WriteLine($"\n3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.\n");
            for (int i = pallet.Count - 3; i < pallet.Count; i++)
            {
                Console.WriteLine($"Палета №{pallet[i].IdPallet + 1} со сроком годности {pallet[i].Date.ToShortDateString()} и с обьемом {pallet[i].Volume} \n");
                
            }
            Console.ReadKey();
        }
    }
}
