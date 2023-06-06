using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Review
    {
        [DataMember]
        public double Rate
        {
            get => rate;
            private set
            {
                if (value < 0 || value > 5) return;
                rate = value;
            }
        }
        private double rate;

        [DataMember]
        public string? Text
        {
            get => text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                text = value;
            }
        }
        private string? text;

        [DataMember]
        public string AuthorName { get; set; }

        public Review(string username, double rate, string text)
        {
            AuthorName = username;
            Rate = rate;
            Text = text;
        }

        public override string ToString()
        {
            return $"{AuthorName} : {Rate} : {Text}";
        }

        public void EditReview(string text)
        {
            if (!string.IsNullOrWhiteSpace(text)) Text = text+" (Modifié)";
        }
        public void EditRate(float newval)
        {
            Rate= newval;
        }
    }
}
