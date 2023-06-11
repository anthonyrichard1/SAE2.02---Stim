using Model;

namespace Test
{
    public class TestReview
    {
        public static IEnumerable<object[]> ReviewData
            => new List<object[]>
            {
                new object[] {new Review("User 1", 3, "rev")},
                new object[] {new Review("User 1", -5.8f, "rev")},
                new object[] {new Review("User 2", +5.8f, "rev") }
            };

        [Theory]
        [MemberData(nameof(ReviewData))]
        public void Constructor(Review rev)
        {
            Assert.NotNull(rev);
        }

        [Theory]
        [MemberData(nameof(ReviewData))]
        public void Rate(Review rev)
        {
            Assert.True(rev.Rate >= 0);
            Assert.True(rev.Rate <= 5);
        }

        [Theory]
        [MemberData(nameof(ReviewData))]
        public void Text(Review rev)
        {
            Assert.NotNull(rev.Text);
            Assert.NotEqual("", rev.Text);
        }

        [Theory]
        [MemberData(nameof(ReviewData))]
        public void AuthorName(Review rev)
        {
            Assert.NotNull(rev.AuthorName);
            Assert.NotEqual("", rev.AuthorName);
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
            Assert.Equal(3, rev.Rate);
            rev.EditRate(18);
            Assert.Equal(3, rev.Rate);
            rev.EditRate(4.5f);
            Assert.Equal(4.5f, rev.Rate);
        }
    }
}
