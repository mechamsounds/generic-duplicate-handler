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

            var result = handler.RemoveDuplicates(newListString);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.ElementAt(0), Is.EqualTo("Hello"));
            Assert.That(result.ElementAt(1), Is.EqualTo("World"));
        }

        [Test]
        public void RemoveDuplicateInts()
        {
            var handler = new DuplicateHandler<int>();
            var newListInt = new List<int>
            {
                 1,2,3,4,5,1,2,3,3
            };
            var result = handler.RemoveDuplicates(newListInt);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.ElementAt(0), Is.EqualTo(1));
            Assert.That(result.ElementAt(1), Is.EqualTo(2));
            Assert.That(result.ElementAt(2), Is.EqualTo(3));
            Assert.That(result.ElementAt(3), Is.EqualTo(4));
            Assert.That(result.ElementAt(4), Is.EqualTo(5));
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

            var result = handler.RemoveDuplicates(newListObj);

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

            Assert.That(result, Is.TypeOf<List<string>>());
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

            Assert.That(result, Is.TypeOf<List<int>>());
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

            var result = handler.RemoveDuplicatesNoLinq(newListObj);

            Assert.That(result, Is.TypeOf<List<Page>>());
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(newPage));
        }

        [Test]
        public void RemoveDuplicatesNoLinqStringsLinkedList()
        {
            var handler = new DuplicateHandler<string>();
            var newListString = new LinkedList<string>();
            var current = newListString.AddFirst("Hello");
            current = newListString.AddAfter(current, "World");
            current = newListString.AddAfter(current, "Hello");
            newListString.AddAfter(current, "Hello");

            var result = handler.RemoveDuplicatesNoLinq(newListString);

            Assert.That(result, Is.TypeOf<LinkedList<string>>());
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.ElementAt(0), Is.EqualTo("Hello"));
            Assert.That(result.ElementAt(1), Is.EqualTo("World"));
        }

        [Test]
        public void RemoveDuplicateNoLinqIntsLinkedList()
        {
            var handler = new DuplicateHandler<int>();
            var newListInt = new LinkedList<int>();

            var current = newListInt.AddFirst(1);
            current = newListInt.AddAfter(current, 2);
            current = newListInt.AddAfter(current, 3);
            current = newListInt.AddAfter(current, 4);
            current = newListInt.AddAfter(current, 5);
            current = newListInt.AddAfter(current, 1);
            current = newListInt.AddAfter(current, 2);
            current = newListInt.AddAfter(current, 3);
            newListInt.AddAfter(current, 3);

            var result = handler.RemoveDuplicatesNoLinq(newListInt);

            Assert.That(result, Is.TypeOf<LinkedList<int>>());
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.ElementAt(0), Is.EqualTo(1));
            Assert.That(result.ElementAt(1), Is.EqualTo(2));
            Assert.That(result.ElementAt(2), Is.EqualTo(3));
            Assert.That(result.ElementAt(3), Is.EqualTo(4));
            Assert.That(result.ElementAt(4), Is.EqualTo(5));
        }

        [Test]
        public void RemoveDuplicatesNoLinqObjectsLinkedList()
        {
            var handler = new DuplicateHandler<Page>();
            var newListObj = new LinkedList<Page>();
            var newPage = new Page
            {
                Id = 1,
                FileName = "TestFile.txt",
                DocumentType = "TestDocType",
                ImportDate = DateTime.Now,
                PageNumber = 1
            };

            var current = newListObj.AddFirst(newPage);
            current = newListObj.AddAfter(current, newPage);
            newListObj.AddAfter(current, newPage);


            var result = handler.RemoveDuplicatesNoLinq(newListObj);

            Assert.That(result, Is.TypeOf<LinkedList<Page>>());
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(newPage));
        }
    }
}
