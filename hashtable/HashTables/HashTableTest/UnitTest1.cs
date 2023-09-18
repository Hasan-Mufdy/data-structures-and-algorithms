using HashTable;

namespace HashTableTest
{
    public class UnitTest1
    {
        [Fact]
        public void CheckKeyAndValue()
        {
            Hashtable<string, string> hashtable = new Hashtable<string, string>();

            hashtable.Set("name", "John");
            string result = hashtable.Get("name");

            Assert.Equal("John", result);
        }
        [Fact]
        public void CheckRetrievingValueByKey()
        {
            Hashtable<string, string> hashtable = new Hashtable<string, string>();
            hashtable.Set("name", "John");

            string result = hashtable.Get("name");

            Assert.Equal("John", result);
        }
        [Fact]
        public void CheckRetrievingUniqueKeys()
        {
            Hashtable<string, string> hashtable = new Hashtable<string, string>();
            hashtable.Set("name", "John");
            hashtable.Set("age", "30");

            var keys = hashtable.Keys();

            Assert.Contains("name", keys);
            Assert.Contains("age", keys);
            Assert.Equal(2, keys.Count());
        }
        [Fact]
        public void HandlingCollisionCheck()
        {
            Hashtable<string, string> hashtable = new Hashtable<string, string>(2);
            hashtable.Set("name", "John");
            hashtable.Set("mane", "Jane");

            string result = hashtable.Get("mane");

            Assert.Equal("Jane", result);
        }
        [Fact]
        public void CheckRetrievingValueFromBucketWithCollision()
        {
            Hashtable<string, string> hashtable = new Hashtable<string, string>(2);
            hashtable.Set("name", "John");
            hashtable.Set("mane", "Jane");

            string result1 = hashtable.Get("name");
            string result2 = hashtable.Get("mane");

            Assert.Equal("John", result1);
            Assert.Equal("Jane", result2);
        }
        [Fact]
        public void CheckHashingKeyToInRangeValue()
        {
            Hashtable<string, string> hashtable = new Hashtable<string, string>(100);

            int hashIndex = hashtable.HashIndex("name");

            Assert.InRange(hashIndex, 0, 99);
        }
        ///////////////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void FindFirstRepeatedWord_NullInput_ReturnsNull()
        {
            var hashtable = new Hashtable<string, string>();

            string result = hashtable.FindFirstRepeatedWord(null);

            Assert.Null(result);
        }

        [Fact]
        public void FindFirstRepeatedWord_EmptyInput_ReturnsNull()
        {
            var hashtable = new Hashtable<string, string>();

            string result = hashtable.FindFirstRepeatedWord("");

            Assert.Null(result);
        }

        [Fact]
        public void FindFirstRepeatedWord_NoRepeatedWords_ReturnsNull()
        {
            var hashtable = new Hashtable<string, string>();

            string result = hashtable.FindFirstRepeatedWord("No Repeated Words Here");

            Assert.Null(result);
        }

        [Fact]
        public void FindFirstRepeatedWord_FirstRepeatedWordIsFound()
        {
            var hashtable = new Hashtable<string, string>();

            string result = hashtable.FindFirstRepeatedWord("word1 word2 word1 jshfdkfjhs word3");

            Assert.Equal("word1", result);
        }

        [Fact]
        public void FindFirstRepeatedWord_RepeatedWordIsFound()
        {
            var hashtable = new Hashtable<string, string>();

            string result = hashtable.FindFirstRepeatedWord("hello jdksfjdh  sjdhfksj uewj hello");

            Assert.Equal("hello", result);
        }
    }
}