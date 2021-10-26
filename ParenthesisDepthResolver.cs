using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace sigma_8_3
{
    class ParenthesisDepthResolver : IParenthesisDepthResolver
    {Умова задачі передбачає, що у стрічці файлу може бути кілька речень, а також речення може бути в кількох стрічках. Ця задача значно складніша, ніж та, яку Ви реалізовували
        private List<string> _sentences = new List<string>();
        private List<int> _parenthesisCounters = new List<int>();

        public ParenthesisDepthResolver(string filename = "data.txt")
        {
            ReadDataFromFile(filename);
            _sentences = _sentences.OrderBy(s => s.Length).ToList();
            //Посортувати всі речення за довжиною, використавши лямбда-вираз.

            CountParenthesis();
        }

        private void CountParenthesis()
        {
            foreach (string sentence in _sentences)
            {
                int openingParenthesisCounter = sentence.Count(ch => ch == '(');
                int closingParenthesisCounter = sentence.Count(ch => ch == ')');
                if (openingParenthesisCounter != closingParenthesisCounter)
                    throw new FormatException("Invalid parenthesis");
                // Слідкуємо, щоб у кожному реченні було порівну відкриваючих та закриваючих дужок

                _parenthesisCounters.Add(openingParenthesisCounter);
            }
        }

        public int GetMaxParenthesisDepth()
        {
            return _parenthesisCounters.Max();
        }

        public IEnumerable<string> GetSentenceWithMaxParenthesisDepth()
        {
            return _sentences.Where(sentence=> sentence.Count(ch => ch == '(') == GetMaxParenthesisDepth());
        }

        public void ReadDataFromFile(string filename)
        {
            try
            {
                using(StreamReader sr = new StreamReader(filename))
                {
                    _sentences = sr.ReadToEnd().Split(".").ToList();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                Environment.Exit(-1);
            }
        }
    }
}
