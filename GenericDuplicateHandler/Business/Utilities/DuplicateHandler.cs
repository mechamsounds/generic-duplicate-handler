namespace GenericDuplicateHandler.Business.Utilities
{
    public class DuplicateHandler<T>
    {
        public ICollection<T> RemoveDuplicates(ICollection<T> source)
        {
            var distinctList = source.Distinct().ToList();
            source.Clear();
            foreach (var item in distinctList)
            {
                source.Add(item);
            }
            return source;
        }

        public ICollection<T> RemoveDuplicatesNoLinq(ICollection<T> source)
        {
            var existingItems = new HashSet<T>();
            var list = new List<T>(source);
            source.Clear();
            foreach (var item in list)
            {
                if (existingItems.Add(item))
                {
                    source.Add(item);
                };
            }
            return source;
        }
    }
}