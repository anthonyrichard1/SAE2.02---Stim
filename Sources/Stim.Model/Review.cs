using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Review
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

        public string AuthorName
        {
            get { return authorName; }
            private set { authorName = value; }
        }
        private string authorName;

        public Review(float rate, string text)
        {
            AuthorName = authorName;
            Rate = rate;
            Text = text;
        }

        public void EditReview(string text)
        {
            Text = text+" (Modifié)";
        }
        public void EditRate(int newval)
        {
            rate= newval;
        }
    }
}
