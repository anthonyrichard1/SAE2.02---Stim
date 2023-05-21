using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Review
    {
        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public string AuthorName
        {
            get { return authorName; }
            private set { authorName = value; }
        }
        private string authorName;

        public Review(/*string username,*/ float rate, string text)
        {
            //AuthorName = username;
            AuthorName = authorName;
            Rate = rate;
            Text = text;
        }

        public Review() { }

        public override string ToString()
        {
            return $"{AuthorName} : {Rate} : {Text}\n";
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
