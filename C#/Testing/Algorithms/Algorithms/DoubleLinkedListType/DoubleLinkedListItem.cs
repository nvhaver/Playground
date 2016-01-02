namespace Algorithms.DoubleLinkedListType
{
    public class DoubleLinkedListItem<T>
    {
        public T data { get; set; }
        public DoubleLinkedListItem<T> next { get; set; }
        public DoubleLinkedListItem<T> previous { get; set; }

        public DoubleLinkedListItem(T data)
        {
            this.data = data;
        }
    }
}
