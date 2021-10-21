using System;
using System.Collections.Generic;

namespace sigma_8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ParenthesisDepthResolver resolver = new ParenthesisDepthResolver();
            IEnumerable<string> sentences = resolver.GetSentenceWithMaxParenthesisDepth();

            
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}
