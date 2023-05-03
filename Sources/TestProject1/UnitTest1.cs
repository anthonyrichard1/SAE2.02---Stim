using Model;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string[] tags = { "1", "2", "3" };
            Game game = new("Elden Ring", "C'est un jeu vraiment cool !", 2022, tags);
            Console.WriteLine("coucou");
        }
    }
}