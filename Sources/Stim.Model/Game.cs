﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    [DataContract]
    public class Game : INotifyPropertyChanged, IEquatable<Game>
    {
        [DataMember]
        public string? Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                name = value;
            }
        }
        private string? name;

        [DataMember]
        public string? Description
        {
            get => description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                description = value;
            }
        }
        private string? description;

        [DataMember]
        public int Year
        {
            get => year;
            private set
            {
                if (value < 1957 || value > 2023) return;
                year = value;
            }
        }
        private int year;

        [DataMember]
        public string? Cover
        {
            get => cover;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                cover = value;
            }
        }
        private string? cover;

        [DataMember]
        public ObservableCollection<string> Tags
        {
            get => tags;
            private set
            {
                if (value == null || value.Count > 3) return;
                tags = value;
            }
        }
        private ObservableCollection<string> tags;

        [DataMember]
        public List<Review> Reviews { get; private init; }

        [DataMember]
        public float Average { get; private set; }

        [DataMember]
        public string Lien { 
            get => lien;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                lien = value;
            }
        }
        private string lien;

        public Game(string name, string description, int year, List<string> c_tags, string cover, string c_lien)
        {
            if (string.IsNullOrWhiteSpace(name)) Name = "Default";
            else Name = name;
            if (string.IsNullOrWhiteSpace(description)) Description = "Default";
            else Description = description;
            Year = year;
            if (c_tags is not null) tags = new ObservableCollection<string>(c_tags);
            else tags = new ObservableCollection<string>();
            if (string.IsNullOrWhiteSpace(cover)) Cover = "Default";
            else Cover = cover;
            if (string.IsNullOrWhiteSpace(c_lien)) Lien = "Default";
            else Lien = c_lien;
            Reviews = new List<Review>();
            Average = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

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
            builder.Append($"{Name} : {Description} : {Year} : {Cover}\n");

            foreach (Review review in Reviews)
            {
                builder.Append($"{review}\n");
            }

            return builder.ToString();
        }

        public float GetAvgRate()
        {
            float sum = 0;
            foreach (Review review in Reviews)
            {
                sum += review.Rate;
            }
            return (float)(Math.Round((sum / Reviews.Count) * 2, MidpointRounding.AwayFromZero) / 2);
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
            Average = GetAvgRate();
        }
        public void RemoveReview(Review review)
        {
            Reviews.Remove(review);
            Average = GetAvgRate();
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
