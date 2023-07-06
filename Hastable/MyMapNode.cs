namespace Hastable
{
    class MyMapNode<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public MyMapNode<K, V>? Next { get; set; }

        public MyMapNode(K key, V value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }
}