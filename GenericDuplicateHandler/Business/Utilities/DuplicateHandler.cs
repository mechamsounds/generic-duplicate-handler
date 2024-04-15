namespace GenericDuplicateHandler.Business.Utilities
{
    public class DuplicateHandler<T>
    {
        public ICollection<T> RemoveDuplicates(ICollection<T> source)
        {
            return source.Distinct().ToList();
        }

        public ICollection<T> RemoveDuplicatesNoLinq(ICollection<T> source)
        {
            var existingItems = new HashSet<T>();
            foreach (var item in source)
            {
                existingItems.Add(item);
            }
            return existingItems.ToList();
        }
    }
}