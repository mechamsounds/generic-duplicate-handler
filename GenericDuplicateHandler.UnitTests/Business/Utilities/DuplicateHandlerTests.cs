using GenericDuplicateHandler.Business.Models;
using GenericDuplicateHandler.Business.Utilities;

namespace GenericDuplicateHandler.UnitTests.Business.Utilities
{
    [TestFixture]
    internal class DuplicateHandlerTests
    {
        [Test]
        public void RemoveDuplicatesStrings()
        {
            var handler = new DuplicateHandler<string>();
            var newListString = new List<string>
            {
                 "Hello",
                 "World",
                 "Hello",
                 "Hello"
            };

            var result = handler.RemoveDuplicates(newListString).ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo("Hello"));
            Assert.That(result[1], Is.EqualTo("World"));
        }

        [Test]
        public void RemoveDuplicateInts()
        {
            var handler = new DuplicateHandler<int>();
            var newListInt = new List<int>
            {
                 1,2,3,4,5,1,2,3,3
            };
            var result = handler.RemoveDuplicates(newListInt).ToList();

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(3));
            Assert.That(result[3], Is.EqualTo(4));
            Assert.That(result[4], Is.EqualTo(5));
        }

        [Test]
        public void RemoveDuplicatesObjects()
        {
            var handler = new DuplicateHandler<Page>();
            var newListObj = new List<Page>();
            var newPage = new Page
            {
                Id = 1,
                FileName = "TestFile.txt",
                DocumentType = "TestDocType",
                ImportDate = DateTime.Now,
                PageNumber = 1
            };

            newListObj.Add(newPage);
            newListObj.Add(newPage);
            newListObj.Add(newPage);

            var result = handler.RemoveDuplicates(newListObj).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(newPage));
        }

        [Test]
        public void RemoveDuplicatesEmptyList()
        {
            var handler = new DuplicateHandler<string>();
            var newEmptyList = new List<string>();
            Assert.DoesNotThrow(() => handler.RemoveDuplicates(newEmptyList));
        }

        [Test]
        public void RemoveDuplicatesDoesNotModifyOriginal()
        {
            var handler = new DuplicateHandler<string>();
            var newListString = new List<string>
            {
                 "Hello",
                 "World",
                 "Hello",
            };

            handler.RemoveDuplicates(newListString).ToList();

            Assert.That(newListString.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveDuplicatesNoLinqStrings()
        {
            var handler = new DuplicateHandler<string>();
            var newListString = new List<string>
            {
                 "Hello",
                 "World",
                 "Hello",
                 "Hello"
            };

            var result = handler.RemoveDuplicatesNoLinq(newListString).ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo("Hello"));
            Assert.That(result[1], Is.EqualTo("World"));
        }

        [Test]
        public void RemoveDuplicateNoLinqInts()
        {
            var handler = new DuplicateHandler<int>();
            var newListInt = new List<int>
            {
                 1,2,3,4,5,1,2,3,3
            };
            var result = handler.RemoveDuplicatesNoLinq(newListInt).ToList();

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(3));
            Assert.That(result[3], Is.EqualTo(4));
            Assert.That(result[4], Is.EqualTo(5));
        }

        [Test]
        public void RemoveDuplicatesNoLinqObjects()
        {
            var handler = new DuplicateHandler<Page>();
            var newListObj = new List<Page>();
            var newPage = new Page
            {
                Id = 1,
                FileName = "TestFile.txt",
                DocumentType = "TestDocType",
                ImportDate = DateTime.Now,
                PageNumber = 1
            };

            newListObj.Add(newPage);
            newListObj.Add(newPage);
            newListObj.Add(newPage);

            var result = handler.RemoveDuplicatesNoLinq(newListObj).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(newPage));
        }

    }
}
