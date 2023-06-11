using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    /// <summary>
    /// Représente un jeu.
    /// </summary>
    [DataContract]
    public sealed class Game : INotifyPropertyChanged, IEquatable<Game>
    {
        [DataMember]
        /// <summary>
        /// Obtient ou définit le nom du jeu.
        /// </summary>
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) name = "Default";
                else name = value;
                NotifyPropertyChanged();
            }
        }
        private string name = default!;

        [DataMember]
        /// <summary>
        /// Obtient ou définit la description du jeu.
        /// </summary>
        public string Description
        {
            get => description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) description = "Defaut";
                else description = value;
                NotifyPropertyChanged();
            }
        }
        private string description = default!;

        [DataMember]
        /// <summary>
        /// Obtient ou définit l'année de sortie du jeu.
        /// </summary>
        public int Year
        {
            get => year;
            private set
            {
                if (value < 1957 || value > 2023) year = 2023;
                else year = value;
                NotifyPropertyChanged();
            }
        }
        private int year = default!;

        [DataMember]
        /// <summary>
        /// Obtient ou définit la couverture du jeu.
        /// </summary>
        public string Cover
        {
            get => cover;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) cover = "no_cover.png";
                else cover = value;
                NotifyPropertyChanged();
            }
        }
        private string cover = default!;

        /// <summary>
        /// Obtient les étiquettes du jeu.
        /// </summary>
        public ReadOnlyCollection<string> Tags
        {
            get => tags.AsReadOnly();
            private set
            {
                if (value == null || value.Count > 3) tags = new List<string>();
                else tags = value.ToList();
                NotifyPropertyChanged();
            }
        }
        [DataMember]
        private List<string> tags;

        /// <summary>
        /// Obtient les avis sur le jeu.
        /// </summary>
        public ReadOnlyCollection<Review> Reviews => reviews.AsReadOnly();

        [DataMember]
        private readonly List<Review> reviews;

        /// <summary>
        /// Obtient la note moyenne du jeu.
        /// </summary>
        public double Average => Reviews.Any() ? Math.Round(Reviews.Select(review => review.Rate).Average(), 1) : 0;

        [DataMember]
        /// <summary>
        /// Obtient ou définit le lien du jeu.
        /// </summary>
        public string Lien
        {
            get => lien;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) lien = "Pas de lien";
                else lien = value;
                NotifyPropertyChanged();
            }
        }
        private string lien = default!;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Game"/> avec les valeurs spécifiées.
        /// </summary>
        /// <param name="name">Le nom du jeu.</param>
        /// <param name="description">La description du jeu.</param>
        /// <param name="year">L'année de sortie du jeu.</param>
        /// <param name="c_tags">Les étiquettes du jeu.</param>
        /// <param name="cover">La couverture du jeu.</param>
        /// <param name="c_lien">Le lien du jeu.</param>
        public Game(string name, string description, int year, List<string> c_tags, string cover, string c_lien)
        {
            if (string.IsNullOrWhiteSpace(name)) Name = "Default";
            else Name = name;
            if (string.IsNullOrWhiteSpace(description)) Description = "Pas de description";
            else Description = description;
            Year = year;
            if (c_tags is not null) tags = new List<string>(c_tags);
            else tags = new List<string>();
            if (string.IsNullOrWhiteSpace(cover)) Cover = "no_cover.png";
            else Cover = cover;
            if (string.IsNullOrWhiteSpace(c_lien)) Lien = "Pas de lien";
            else Lien = c_lien;
            reviews = new List<Review>();
        }

        /// <summary>
        /// Événement déclenché lorsque la valeur d'une propriété change.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Retourne le code de hachage pour l'objet.
        /// </summary>
        /// <returns>Le code de hachage calculé.</returns>
        public override int GetHashCode()
        {
            if (string.IsNullOrWhiteSpace(Name)) return 0;
            return Name.GetHashCode();
        }

        /// <summary>
        /// Détermine si l'objet spécifié est égal à l'objet actuel.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'objet actuel.</param>
        /// <returns>True si les objets sont égaux, sinon False.</returns>
        public override bool Equals(object? obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return this.Equals(obj as Game);
        }

        /// <summary>
        /// Détermine si l'objet spécifié est égal à l'objet actuel.
        /// </summary>
        /// <param name="other">L'objet à comparer avec l'objet actuel.</param>
        /// <returns>True si les objets sont égaux, sinon False.</returns>
        public bool Equals(Game? other)
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            return other != null && Name.Equals(other.Name);
        }

        /// <summary>
        /// Retourne une chaîne qui représente l'objet courant.
        /// </summary>
        /// <returns>Une chaîne qui représente l'objet courant.</returns>
        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"{Name} : {Description} : {Year} : {Cover} : {lien}\n");

            foreach (Review review in Reviews)
            {
                builder.Append($"{review}\n");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Ajoute un avis sur le jeu.
        /// </summary>
        /// <param name="review">L'avis à ajouter.</param>
        public void AddReview(Review review)
        {
            reviews.Add(review);
            UpdateReviews();
        }

        /// <summary>
        /// Supprime un avis du jeu.
        /// </summary>
        /// <param name="review">L'avis à supprimer.</param>
        public void RemoveReview(Review review)
        {
            reviews.Remove(review);
            UpdateReviews();
        }

        /// <summary>
        /// Met à jour la liste des avis et la note moyenne.
        /// </summary>
        public void UpdateReviews()
        {
            NotifyPropertyChanged(nameof(Reviews));
            NotifyPropertyChanged(nameof(Average));
        }

        /// <summary>
        /// Modifie la description du jeu.
        /// </summary>
        /// <param name="newdesc">La nouvelle description.</param>
        public void DescChange(string newdesc)
        {
            description = newdesc;
        }

        /// <summary>
        /// Modifie les étiquettes du jeu.
        /// </summary>
        /// <param name="newtag">La nouvelle liste d'étiquettes.</param>
        public void TagChange(List<string> newtag)
        {
            if (newtag != null && newtag.Count <= 3) tags = new List<string>(newtag);
        }

        /// <summary>
        /// Modifie le nom du jeu.
        /// </summary>
        /// <param name="newname">Le nouveau nom.</param>
        public void NameChange(string newname)
        {
            name = newname;
        }

        /// <summary>
        /// Modifie l'année de sortie du jeu.
        /// </summary>
        /// <param name="newyear">La nouvelle année.</param>
        public void YearChange(int newyear)
        {
            year = newyear;
        }
    }
}