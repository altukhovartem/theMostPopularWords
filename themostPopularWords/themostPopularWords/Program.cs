using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace themostPopularWords
{
    class Program
    {
        static void Main(string[] args)
        {
              string mainStr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sodales consectetur purus at faucibus. Donec mi quam, tempor vel ipsum non, faucibus suscipit massa. Morbi lacinia velit blandit tincidunt efficitur. Vestibulum eget metus imperdiet sapien laoreet faucibus. Nunc eget vehicula mauris, ac auctor lorem. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer vel odio nec mi tempor dignissim.";
            //string mainStr = "Мама мыла-мыла-мыла раму!";

            foreach (var item in GetTheMostPopularWords(mainStr))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            IEnumerable<string> result = GetTheMostPopularWords(mainStr);
        }

        private static IEnumerable<string> GetTheMostPopularWords(string mainStr)
        {
            char[] separators = new char[] { ' ', '-', '_', '.', ',', '!'};
            var arratOfStr = mainStr.Split(separators).Select(x => x.ToLower()).Where(x => x.Length > 0);
            var collectionOfCollictions = arratOfStr.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key);

            var result = mainStr.Split(separators)
                .Select(x => x.ToLower())
                .Where(x => x.Length > 0)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key.ToString() + " " + x.Count());

            return result;
        }
    }
}


//Напишите программу, получающую текст, подсчитывающую в нем частоту появления слов, и в конце выводящую 10 наиболее часто встречающихся слов.
//Словом будем считать любую непрерывную последовательность символов, состоящую только из букв и цифр. 
//Например, в строке "Мама мыла раму 33 раза!" ровно пять слов: "Мама", "мыла", "раму", "33" и "раза". 
//Подсчет слов должен выполняться без учета регистра, т.е. "МАМА", "мама" и "Мама" — это одно и то же слово. 
//Выводите слова в нижнем регистре.Если в тексте меньше 10 уникальных слов, то выводите сколько есть. 
//Если в тексте некоторые слова имеют одинаковую частоту, т.е.их нельзя однозначно упорядочить только по частоте, 
//то дополнительно упорядочите слова с одинаковой частотой в лексикографическом порядке. 
//Задача имеет красивое решение через LINQ без циклов и условных операторов.Попробуйте придумать его.