using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace SKNF
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество аргументов:");
            var num_args = Int32.Parse(Console.ReadLine());
            List<string> lst = new List<string>(); //вместо динамических массивов удобнее использовать List
            //в данном случае создаем List из строк
            Console.WriteLine("Заполните таблицу истинности:");
            for (int i = 0; i < Math.Pow(2, num_args); ++i)
            {
                var line = Convert.ToString(i, 2).PadLeft(num_args, '0');
                Console.Write(line + " :");
                lst.Add(Console.ReadLine());
            }
            Console.WriteLine(SKNF(lst, num_args)); // вызов функции и печать результата
        }

        static string SKNF(List<string> lst, int len)
        {
            //StringBuilder аналог класса String, но изменяемый.
            // классический стинг неизменяемый тип данных.
            //поэтому в строке str+="ss" не изменяется строка, а создается новая.
            StringBuilder sknf = new StringBuilder("");
            bool flag = true; //Признак начала строки
            for (int i = 0; i < lst.Count; i++) // бежим по переданному массиву результатов
            {
                if (lst[i] == "0") // если 0, формируем строку
                {
                    sknf.Append(flag ? "(" : "&&("); //если первая итерация, пишем "(", иначе "&&("
                    flag = false;
                    var line = Convert.ToString(i, 2).PadLeft(len, '0'); // число в бинарную строку

                    for (int j = 0; j < len; j++) //бежим по бинарной строке
                    {
                        sknf.Append(line[j] == '0' ? "x" + (j + 1) : "!x" + (j + 1)); // если '0', то "xn", иначе !"xn"
                        sknf.Append(j < len - 1 ? " || " : ")"); //если не последний х, то "||", иначе закрываем скобку
                    }
                }
            }
            return sknf.ToString(); //конвертируем в обычную строку и возвращаем
        }
    }
}
