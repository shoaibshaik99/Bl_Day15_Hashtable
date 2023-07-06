namespace Hastable
{
    class MyHashTable<K, V>
    {
        private readonly int size;
        private readonly LinkedList<MyMapNode<K, V>>[] items;

        public MyHashTable(int size)
        {
            this.size = size;
            items = new LinkedList<MyMapNode<K, V>>[size];
        }

        private int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public V? Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<MyMapNode<K, V>> linkedList = GetLinkedList(position);
            foreach (MyMapNode<K, V> myMapNode in linkedList)
            {
                if (myMapNode.Key.Equals(key))
                {
                    return myMapNode.Value;
                }
            }

            return default;
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<MyMapNode<K, V>> linkedList = GetLinkedList(position);

            bool keyExists = false;
            foreach (MyMapNode<K, V> node in linkedList)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value;
                    keyExists = true;
                    break;
                }
            }

            if (!keyExists)
            {
                MyMapNode<K, V> myMapNode = new MyMapNode<K, V>(key, value);
                items[position].AddLast(myMapNode);
            }
        }

        public void Display()
        {
            for (int i = 0; i < size; i++)
            {
                LinkedList<MyMapNode<K, V>> linkedList = items[i];
                if (linkedList != null)
                {
                    foreach (MyMapNode<K, V> node in linkedList)
                    {
                        Console.WriteLine("Frequency of word '{0}' is {1}", node.Key, node.Value);
                    }
                }
            }
        }

        private LinkedList<MyMapNode<K, V>> GetLinkedList(int position)
        {
            if (items[position] == null)
            {
                items[position] = new LinkedList<MyMapNode<K, V>>();
            }

            return items[position];
        }
    }

}