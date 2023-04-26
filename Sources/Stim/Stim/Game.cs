using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stim
{
    internal class Game
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Annee;
        public string[] Tags = new string[3];
        public List<Review> reviews;

        public Game(string name, string description, int annee, string[] tags)
        {
            Name = name;
            Description = description;
            Annee = annee;
            Tags = tags;
            reviews = new List<Review>();
        }

        public float GetAvgRate()
        {
            float sum = 0;

            foreach (Review review in reviews)
            {
                sum += review.Rate;
            }
            return sum/reviews.Count;
        }
    }
}
