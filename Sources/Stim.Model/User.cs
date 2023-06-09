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
        public string UserImage
        {
            get => userImage;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value)) userImage = value;
                else userImage = "no_cover.png";
                NotifyPropertyChanged();
            }
        }
        private string userImage = default!;
        [DataMember]
        public string? Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) username = "Default";
                else username = value;
                NotifyPropertyChanged();
            }
        }
        private string username=default!;
        [DataMember]
        public string Biographie 
        {
            get => biographie; 
            set
            {
                if (string.IsNullOrWhiteSpace(value)) biographie = "Pas de biographie";
                else biographie = value;
                NotifyPropertyChanged();
            }
        }
        private string biographie = default!;
        [DataMember]
        public string Email
        {
            get => email;
            set
            {
                Regex rg_email = new Regex("^([a-zA-Z0-9_-]+[.])*[a-zA-Z0-9_-]+@([a-zA-Z0-9_-]+[.])+[a-zA-Z0-9_-]{2,4}$");
                if (!(string.IsNullOrWhiteSpace(value)) && rg_email.IsMatch(value))
                {
                    email = value;
                    NotifyPropertyChanged();
                }
                else email = "Default";
            }
        }
        private string email = default!;
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
        private string password = default!;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ReadOnlyCollection<Game> Followed_Games => followed_Games.AsReadOnly();

        [DataMember]
        private readonly List<Game> followed_Games;

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
            if (password == null) throw new ArgumentNullException(nameof(password));
            else Password = password;
            followed_Games = new List<Game>();
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool Equals(User? other)
        {
            if (string.IsNullOrWhiteSpace(Username)) return false;
            return other != null && Username.Equals(other.Username);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return this.Equals((User)obj);
        }

        public override int GetHashCode()
        { 
            if (Username!=null) return Username.GetHashCode();
            return 0;
        }

        public void AddReview(Game game, double rate, string text)
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
            followed_Games.Add(game);
            NotifyPropertyChanged(nameof(Followed_Games));
        }
        public void RemoveAGame(Game game)
        {
            if (!Followed_Games.Contains(game)) return;
            followed_Games.Remove(game);
            NotifyPropertyChanged(nameof(Followed_Games));
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
