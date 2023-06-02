using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Model
{
    [DataContract]
    public class User : INotifyPropertyChanged , IEquatable<User>
    {
        [DataMember]
        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) value = "Default";
                username = value;
            }
        }
        private string username;
        [DataMember]
        public string Biographie 
        {
            get => biographie; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) value = "Default";
                biographie = value;
            }
        }
        private string biographie;
        [DataMember]
        public string Email
        {
            get => email;
            private set
            {
                Regex rg_email = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                if (!(string.IsNullOrWhiteSpace(value)) && rg_email.IsMatch(value))
                    email = value;
                else email = "Default";
            }
        }
        private string email;
        [DataMember]
        public string Password
        {
            get => password;
            private set
            {
                Regex rg = new Regex("^(?=.*[A-Za-z])(?=.*[0-9@$!%*#?&])[A-Za-z-0-9@$!%*#?&]{8,}$");
                if (string.IsNullOrWhiteSpace(value) || !rg.IsMatch(value)) throw new ArgumentNullException("password");
                else password = value;
            }
        }
        private string password;

        public event PropertyChangedEventHandler? PropertyChanged;

        [DataMember]
        public ObservableCollection<Game> Followed_Games 
        {
            get;
            private init;
        }
        [DataMember]
        public string UserImage 
        {   
            get => userImage;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value)) userImage = value;
                else userImage = "no_cover.png";
            }
        }
        private string userImage;

        public User(string userImage,string username, string biographie, string email, string password)
        {
            if (userImage == null) UserImage="no_cover.png";
            else UserImage = userImage;
            if (username == null) Username = "Default";
            else Username = username;
            if (biographie == null) Biographie = "Default";
            else Biographie = biographie;
            if (email == null) Email = "Default";
            else Email = email;
            if (password == null) throw new ArgumentNullException("password");
            else Password = password;
            Followed_Games = new ObservableCollection<Game>();
        }
        public bool Equals(User? other)
        {
            if (string.IsNullOrWhiteSpace(Username)) return false;
            return other != null && Username.Equals(other.Username);
        }
        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public void AddReview(Game game, float rate, string text)
        {
            game.AddReview(new Review(Username, rate, text));
        }
        public void RemoveSelfReview(Game game, float rate, string text)
        {
            for (int i = game.Reviews.Count - 1; i >= 0; i--)
            {
                Review review = game.Reviews[i];
                if (review.Rate == rate && review.Text == text && review.AuthorName == username)
                {
                    game.RemoveReview(review);
                }
            }
        }
        public void FollowAGame(Game game)
        {
            if (Followed_Games.Contains(game)) return;
            Followed_Games.Add(game);
        }
        public void RemoveAGame(Game game)
        {
            if (!Followed_Games.Contains(game)) return;
            Followed_Games.Remove(game);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }
    }
}
