namespace Source.World
{
    public class PoolItem<T>
    {
        public T Item { get; set; }
        public bool IsFree { get; set; }

        public PoolItem(T item, bool isFree = true)
        {
            Item = item;
            IsFree = isFree;
        }
    }
}
