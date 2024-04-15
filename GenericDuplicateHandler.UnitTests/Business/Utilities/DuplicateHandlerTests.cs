using GenericDuplicateHandler.Business.Models;
using GenericDuplicateHandler.Business.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDuplicateHandler.UnitTests.Business.Utilities
{
    [TestFixture]
    internal class DuplicateHandlerTests
    {
        [Test]
        public void RemoveDuplicateStrings()
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

            Assert.That(result.Count,Is.EqualTo(2));
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
        }

        [Test]
        public void RemoveDuplicateObjects()
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
        public void RemoveDuplicateEmptyList()
        {
            var handler = new DuplicateHandler<string>();
            var newEmptyList = new List<string>();
            Assert.DoesNotThrow(() => handler.RemoveDuplicates(newEmptyList));
        }
    }
}
