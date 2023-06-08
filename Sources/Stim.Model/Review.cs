using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Review :INotifyPropertyChanged
    {
        [DataMember]
        public double Rate
        {
            get => rate;
            private set
            {
                if (value < 0 || value > 5) rate = 0;
                else rate = value;
                NotifyPropertyChanged();
            }
        }
        private double rate;

        [DataMember]
        public string? Text
        {
            get => text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) text = "Default";
                else text = value;
                NotifyPropertyChanged();
            }
        }
        private string? text;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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
        public void EditRate(double newval)
        {
            Rate= newval;
        }
    }
}
