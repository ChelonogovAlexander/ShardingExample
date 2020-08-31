using System.Linq;

namespace ShardingExample
{
    public sealed class ShardingService
    {
        private const int ServerCapacity = 32;
        private readonly ShardingDataProvider _shardingDataProvider;

        public ShardingService(ShardingDataProvider shardingDataProvider)
            => _shardingDataProvider = shardingDataProvider;

        public Node GetShardingNode(BoxItem boxItem)
        {
            var hash = boxItem.BoxId % ServerCapacity;
            var sortedNodes = _shardingDataProvider.GetSortedNodes();
            var shardingNode = sortedNodes
                .FirstOrDefault(n => n.PartitionValue >= hash)
                ?? sortedNodes.FirstOrDefault();

            return shardingNode;
        }
    }
}
