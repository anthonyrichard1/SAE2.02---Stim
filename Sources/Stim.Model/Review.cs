using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Représente un commentaire.
    /// </summary>
    [DataContract]
    public class Review : INotifyPropertyChanged
    {
        [DataMember]
        /// <summary>
        /// Obtient ou définit la note du commentaire.
        /// </summary>
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
        /// <summary>
        /// Obtient ou définit le texte du commentaire.
        /// </summary>
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

        /// <summary>
        /// Événement déclenché lorsque les propriétés de l'objet changent.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        [DataMember]
        /// <summary>
        /// Obtient ou définit le nom de l'auteur du commentaire.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Review"/> avec le nom de l'auteur, la note et le texte du commentaire.
        /// </summary>
        /// <param name="username">Le nom de l'auteur du commentaire.</param>
        /// <param name="rate">La note du commentaire.</param>
        /// <param name="text">Le texte du commentaire.</param>
        public Review(string username, double rate, string text)
        {
            AuthorName = username;
            Rate = rate;
            Text = text;
        }

        /// <summary>
        /// Retourne une représentation sous forme de chaîne de l'objet courant.
        /// </summary>
        /// <returns>La représentation sous forme de chaîne de l'objet courant.</returns>
        public override string ToString()
        {
            return $"{AuthorName} : {Rate} : {Text}";
        }

        /// <summary>
        /// Modifie le texte du commentaire.
        /// </summary>
        /// <param name="text">Le nouveau texte du commentaire.</param>
        public void EditReview(string text)
        {
            if (!string.IsNullOrWhiteSpace(text)) Text = text + " (Modifié)";
        }

        /// <summary>
        /// Modifie la note du commentaire.
        /// </summary>
        /// <param name="newval">La nouvelle valeur de la note.</param>
        public void EditRate(double newval)
        {
            if (newval >= 0 && newval <= 5) Rate = newval;
        }
    }
}