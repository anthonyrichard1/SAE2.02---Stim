using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stim
{
    internal class Review
    {
        public float Rate { get; set; }
        public string Text { get; set; }

        public Review(float rate, string text)
        {
            CheckRate(rate);
            Text = text;
        }

        public bool CheckRate(float rate)
        {
            if (rate < 0 || rate > 5) return false;
            Rate=rate;
            return true;
        }
    }
}
