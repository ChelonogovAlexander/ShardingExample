namespace ShardingExample
{
    public sealed class Node
    {
        public Node(string name, int partitionValue)
        {
            Name = name;
            PartitionValue = partitionValue;
        }

        public string Name { get; }

        public int PartitionValue { get; }
    }
}
