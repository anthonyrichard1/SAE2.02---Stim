using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
{
    [DataContract]
    public sealed class User : INotifyPropertyChanged , IEquatable<User>
    {
        [DataMember]
        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) username = "Default";
                else
                {
                    username = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string username;
        [DataMember]
        public string Biographie 
        {
            get => biographie ?? "Pas de biographie"; 
            set
            {
                if (string.IsNullOrWhiteSpace(value)) biographie = "Pas de biographie";
                else
                {
                    biographie = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string biographie;
        [DataMember]
        public string Email
        {
            get => email;
            set
            {
                Regex rg_email = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                if (!(string.IsNullOrWhiteSpace(value)) && rg_email.IsMatch(value))
                {
                    email = value;
                    NotifyPropertyChanged();
                }
                else email = "Default";
            }
        }
        private string email;
        [DataMember]
        public string Password
        {
            get => password;
            set
            {
                Regex rg = new Regex("^(?=.*[A-Za-z])(?=.*[0-9@$!%*#?&])[A-Za-z-0-9@$!%*#?&]{8,}$");
                if (string.IsNullOrWhiteSpace(value) || !rg.IsMatch(value)) throw new ArgumentNullException(value);
                else
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string password;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [DataMember]
        public ObservableCollection<Game> Followed_Games 
        {
            get;
            private init;
        }
        [DataMember]
        public string? UserImage 
        {   
            get => userImage;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value)) userImage = value;
                else userImage = "no_cover.png";
            }
        }
        private string? userImage;

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
            if (Username!=null) return Username.GetHashCode();
            return 0;
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

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return this.Equals((User)obj);
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"{Username} : {Biographie} : {Email} : {Password}\n");
            foreach (Game game in Followed_Games) builder.Append($"{game.Name}\n");
            return builder.ToString();
        }

    }
}
