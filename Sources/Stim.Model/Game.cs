﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    [DataContract]
    public class Game : INotifyPropertyChanged, IEquatable<Game>
    {
        [DataMember]
        public string Name
        {
            get => name ?? "Default";
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) name="Default";
                else
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string name;

        [DataMember]
        public string Description
        {
            get => description ?? "Pas de description";
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                else
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string description;

        [DataMember]
        public int Year
        {
            get => year;
            private set
            {
                if (value < 1957 || value > 2023) return;
                else
                {
                    year = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int year;

        [DataMember]
        public string Cover
        {
            get => cover ?? "no_cover.png";
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) cover="no_cover.png";
                else
                {
                    cover = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string cover;

        [DataMember]
        public ObservableCollection<string> Tags
        {
            get => tags;
            private set
            {
                if (value == null || value.Count > 3) return;
                else
                {
                    tags = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private ObservableCollection<string> tags;

        [DataMember]
        public List<Review> Reviews { get; private init; }

        public double Average => AverageCalc();
        public double AverageCalc()
        {
            if (Reviews.Count > 0) return Math.Round((double)Reviews.Select(review => review.Rate).Average(), 1); 
            else return 0;
        }

        [DataMember]
        public string Lien { 
            get => lien ?? "Pas de lien";
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                else
                {
                    lien = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string lien;

        public Game(string name, string description, int year, List<string> c_tags, string cover, string c_lien)
        {
            if (string.IsNullOrWhiteSpace(name)) Name = "Default";
            else Name = name;
            if (string.IsNullOrWhiteSpace(description)) Description = "Pas de description";
            else Description = description;
            Year = year;
            if (c_tags is not null) tags = new ObservableCollection<string>(c_tags);
            else tags = new ObservableCollection<string>();
            if (string.IsNullOrWhiteSpace(cover)) Cover = "no_cover.png";
            else Cover = cover;
            if (string.IsNullOrWhiteSpace(c_lien)) Lien = "Pas de lien";
            else Lien = c_lien;
            Reviews = new List<Review>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrWhiteSpace(Name)) return 0;
            return Name.GetHashCode();  
        }

        public override bool Equals(object? obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return this.Equals(obj as Game);
        }

        public bool Equals(Game? other)
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            return other != null && Name.Equals(other.Name);
        }

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

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }
        public void RemoveReview(Review review)
        {
            Reviews.Remove(review);
        }
        public void DescChange(string newdesc)
        {
            description = newdesc;
        }
        public void TagChange(List<string> newtag)
        {
            if (newtag != null && newtag.Count<=3) tags = new ObservableCollection<string>(newtag);
        }
        public void NameChange(string newname)
        {
            name = newname;
        }
        public void YearChange(int newyear)
        {
            year = newyear;
        }
    }
}
