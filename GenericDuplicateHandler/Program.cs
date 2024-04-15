using GenericDuplicateHandler.Business.Models;
using GenericDuplicateHandler.Business.Utilities;

internal class Program
{
    private static void Main(string[] args)
    {
        var handler = new DuplicateHandler<string>();
        var newListString = new List<string>
         {
             "Hello",
             "World",
             "Hello",
             "Hello"
         };
        Console.WriteLine(string.Join(",", handler.RemoveDuplicates(newListString)));

        var handler1 = new DuplicateHandler<int>();
        var newListInt = new List<int>
         {
             1,2,3,4,5,1,2,3,3
         };
        Console.WriteLine(string.Join(",", handler1.RemoveDuplicates(newListInt)));

        var handler2 = new DuplicateHandler<Page>();
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
        Console.WriteLine(string.Join(",", handler2.RemoveDuplicates(newListObj)));
    }
}