using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDuplicateHandler.Business.Utilities
{
    public class DuplicateHandler<T>
    {
        public ICollection<T> RemoveDuplicates<T>(ICollection<T> source)
        {
            return source.Distinct().ToList();
        }
    }
}