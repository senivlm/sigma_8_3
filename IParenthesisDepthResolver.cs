using System;
using System.Collections.Generic;
using System.Text;

namespace sigma_8_3
{
    interface IParenthesisDepthResolver
    {
        public int GetMaxParenthesisDepth();
        public IEnumerable<string> GetSentenceWithMaxParenthesisDepth();
    }
}
