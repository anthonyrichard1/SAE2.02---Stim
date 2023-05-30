using System.Text.RegularExpressions;

namespace Model
{
    public class User
    {
        public string? Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                username = value;
            }
        }
        private string? username;

        public string? Biographie 
        {
            get => biographie; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                biographie = value;
            }
        }
        private string? biographie;

        public string? Email
        {
            get => email;
            private set
            {
                Regex rg_email = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                if (!string.IsNullOrWhiteSpace(value) && rg_email.IsMatch(value))
                    email = value;
                return;
            }
        }
        private string? email;

        public string? Password
        {
            get => password;
            private set
            {
                Regex rg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,32}$");
                if (string.IsNullOrWhiteSpace(value) || !rg.IsMatch(value)) return;
                password = value;
            }
        }
        private string? password;

        //public int Role { get; }
        //private int role;
        public List<Game> Followed_Games 
        {
            get;
            private init;
        }

        public User(string username, string biographie, string email, string password)
        {
            if (username == null) Username = "Default";
            else Username = username;
            if (biographie == null) biographie = "Default";
            else Biographie = biographie;
            if (email == null) email = "Default";
            else Email = email;
            if (password == null) password = "Default";
            else Password = password;
            Followed_Games = new List<Game>();
            //Role = 0;
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
    }
}
