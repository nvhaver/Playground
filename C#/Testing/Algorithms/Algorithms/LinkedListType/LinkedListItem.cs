namespace Algorithms.LinkedListType
{
    public class LinkedListItem<T>
    {
        public T data { get; set; }
        public LinkedListItem<T> next { get; set; }

        public LinkedListItem(T data)
        {
            this.data = data;
        }
    }
}
