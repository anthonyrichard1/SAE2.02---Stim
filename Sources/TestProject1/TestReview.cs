using Model;

namespace Test
{
    public class TestReview
    {
        [Fact]
        public void Constructor()
        {
            Review rev = new("User 1", 3, "rev");
            Assert.NotNull(rev);
        }

        [Fact]
        public void Rate()
        {
            Review rev = new("User 1", -5.8f, "rev");
            Review rev2 = new("User 2", 5.8f, "rev2");
            Assert.Equal(0, rev.Rate);
            Assert.Equal(0, rev2.Rate);
        }

        [Fact]
        public void Text()
        {
            Review rev = new("User 1", 3, "");
            Review rev2 = new("User 2", 3, null);
            Assert.Equal("Default", rev.Text);
            Assert.Equal("Default", rev2.Text);
        }

        [Fact]
        public void AuthorName()
        {
            Review rev = new("User 1", 3, "text");
            Assert.NotNull(rev.AuthorName);
        }

        [Fact]
        public void Str()
        {
            Review rev = new("User 1", 3, "rev");
            Assert.Equal("User 1 : 3 : rev", rev.ToString());
        }

        [Fact]
        public void EditText()
        {
            Review rev = new("User 1", 3, "rev");
            rev.EditReview("");
            Assert.Equal("rev", rev.Text);
            rev.EditReview("newRev");
            Assert.Equal("newRev (Modifié)", rev.Text);
        }

        [Fact]
        public void EditRate()
        {
            Review rev = new("User 1", 3, "rev");
            rev.EditRate(-2);
            Assert.Equal(0, rev.Rate);
            rev.EditRate(18);
            Assert.Equal(0, rev.Rate);
            rev.EditRate(4.5f);
            Assert.Equal(4.5f, rev.Rate);
        }
    }
}
