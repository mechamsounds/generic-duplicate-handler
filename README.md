# Generic Duplicate Handler

The goal of this challenge is to implement a generic duplicate handler. The generic duplicate handler should take in
one parameter: the generic collection of type T. It should be able to remove duplicate objects from the input collection.

## Instructions

1. Generate a new **private** repo.
2. Write your solution to the requirements listed below to your generated repo.
3. Once your repo is ready for review, add `rowconstantino` and kevaltrivedied@gmail.com as collaborators for your repo.
4. Wait for our response.

## Requirements

1. The generic duplicate handler should be a class with at least one public method: RemoveDuplicates().
2. RemoveDuplicates method accepts ICollection of T objects and returns ICollection of T objects.
3. RemoveDuplicates() method should return an ICollection of distinct T objects from the input collection.
4. Instantiate the generic duplicate handler class for each type below and call RemoveDuplicates() method passing these inputs:
            
            Input1:
            var handler = new DuplicateHandler<string>();
            var newListString = new List<string>
            {
                "Hello",
                "World",
                "Hello",
                "Hello"
            };
            
            Output: {
                      "Hello",
                      "World"
                    }
                    
            Input2:
            var handler1 = new DuplicateHandler<int>();
            var newListInt = new List<int>
            {
                1,2,3,4,5,1,2,3,3
            };
            
            Output: {
                      1,2,3,4,5
                    }
                    
            Input3:
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
            
            Output: {
                      newPage
                    }
                    
5. Add a unit test.
