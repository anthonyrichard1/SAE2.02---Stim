using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Représente un utilisateur.
    /// </summary>
    [DataContract]
    public sealed class User : INotifyPropertyChanged, IEquatable<User>
    {
        /// <summary>
        /// Obtient ou définit la photo de profil de l'utilisateur.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit le nom d'utilisateur.
        /// </summary>
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
        private string username = default!;

        /// <summary>
        /// Obtient ou définit la biographie de l'utilisateur.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit l'adresse e-mail de l'utilisateur.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit le mot de passe de l'utilisateur.
        /// </summary>
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

        /// <summary>
        /// Événement déclenché lorsqu'une propriété de l'utilisateur change.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Obtient la liste des jeux suivis par l'utilisateur.
        /// </summary>
        public ReadOnlyCollection<Game> Followed_Games => followed_Games.AsReadOnly();

        [DataMember]
        private readonly List<Game> followed_Games;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="User"/>.
        /// </summary>
        /// <param name="userImage">La photo de profil de l'utilisateur.</param>
        /// <param name="username">Le nom d'utilisateur.</param>
        /// <param name="biographie">La biographie de l'utilisateur.</param>
        /// <param name="email">L'adresse e-mail de l'utilisateur.</param>
        /// <param name="password">Le mot de passe de l'utilisateur.</param>
        public User(string userImage, string username, string biographie, string email, string password)
        {
            if (userImage == null) UserImage = "no_cover.png";
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

        /// <summary>
        /// Détermine si l'objet spécifié est égal à l'objet courant.
        /// </summary>
        /// <param name="other">L'objet à comparer avec l'objet courant.</param>
        /// <returns>true si l'objet spécifié est égal à l'objet courant ; sinon, false.</returns>
        public bool Equals(User? other)
        {
            if (string.IsNullOrWhiteSpace(Username)) return false;
            return other != null && Username.Equals(other.Username);
        }

        /// <summary>
        /// Détermine si l'objet spécifié est égal à l'objet courant.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'objet courant.</param>
        /// <returns>true si l'objet spécifié est égal à l'objet courant ; sinon, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return this.Equals((User)obj);
        }

        /// <summary>
        /// Retourne le code de hachage de l'objet.
        /// </summary>
        /// <returns>Code de hachage.</returns>
        public override int GetHashCode()
        {
            if (Username != null) return Username.GetHashCode();
            return 0;
        }

        /// <summary>
        /// Ajoute une critique d'utilisateur pour un jeu spécifié.
        /// </summary>
        /// <param name="game">Le jeu pour lequel ajouter la critique.</param>
        /// <param name="rate">La note de la critique.</param>
        /// <param name="text">Le texte de la critique.</param>
        public void AddReview(Game game, double rate, string text)
        {
            game.AddReview(new Review(Username, rate, text));
        }

        /// <summary>
        /// Supprime la critique de l'utilisateur pour un jeu spécifié.
        /// </summary>
        /// <param name="game">Le jeu pour lequel supprimer la critique.</param>
        /// <param name="rate">La note de la critique.</param>
        /// <param name="text">Le texte de la critique.</param>
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

        /// <summary>
        /// Suit un jeu spécifié.
        /// </summary>
        /// <param name="game">Le jeu à suivre.</param>
        public void FollowAGame(Game game)
        {
            if (Followed_Games.Contains(game)) return;
            followed_Games.Add(game);
            NotifyPropertyChanged(nameof(Followed_Games));
        }

        /// <summary>
        /// Ne suit plus un jeu spécifié.
        /// </summary>
        /// <param name="game">Le jeu à ne plus suivre.</param>
        public void RemoveAGame(Game game)
        {
            if (!Followed_Games.Contains(game)) return;
            followed_Games.Remove(game);
            NotifyPropertyChanged(nameof(Followed_Games));
        }

        /// <summary>
        /// Retourne une représentation sous forme de chaîne de l'objet.
        /// </summary>
        /// <returns>La représentation sous forme de chaîne de l'objet.</returns>
        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"{Username} : {Biographie} : {Email} : {Password}\n");
            foreach (Game game in Followed_Games) builder.Append($"{game.Name}\n");
            return builder.ToString();
        }
    }
}