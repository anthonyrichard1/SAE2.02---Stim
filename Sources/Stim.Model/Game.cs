using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game
    {
        public string Name
        {
            get { return name; }
            private set
            {
                if (value == "") return;
                name = value;
            }
        }
        private string name;

        public string Description
        {
            get { return description; }
            private set
            {
                if (value == "") return;
                description = value;
            }
        }
        private string description;

        public int Year
        {
            get { return year; }
            private set
            {
                if (value < 1957 || value >= 2023) return;
                year = value;
            }
        }
        private int year;

        public string[] Tags
        {
            get { return tags; }
            set
            {
                if (tags.Length != 3) return;
                tags = value;
            }
        }
        private string[] tags;

        public List<Review> Reviews { get; }

        public Game(string name, string description, int year, string[] tags)
        {
            Name = name;
            Description = description;
            Year = year;
            Tags = tags;
            Reviews = new List<Review>();
        }

        public float GetAvgRate()
        {
            float sum = 0;

            foreach (Review review in Reviews)
            {
                sum += review.Rate;
            }
            return sum / Reviews.Count;
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
        public void TagChange(string[] newtag)
        {
            tags=newtag;
        }
        public void NameChange(string newname)
        {
            name = newname;
        }
        public void yearChange(int newyear)
        {
            year = newyear;
        }
    }
}
