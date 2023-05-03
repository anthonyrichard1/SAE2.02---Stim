using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stim_Model
{
    internal class Review
    {
        public float Rate
        {
            get
            {
                return rate;
            }
            private set
            {
                if (value < 0 || value > 5) return;
                rate = value;
            }
        }
        private float rate;

        public string Text
        {
            get
            {
                return text;
            }
            private set
            {
                if (text == "") return;
                text = value;
            }
        }
        private string text;

        public Review(float rate, string text)
        {
            Rate = rate;
            Text = text;
        }

        public void EditReview(string text)
        {
            Text = text;
        }
    }
}
