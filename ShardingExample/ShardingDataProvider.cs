using System.Collections.Generic;
using System.Linq;

namespace ShardingExample
{
    public sealed class ShardingDataProvider
    {
        private readonly IList<Node> _nodes;

        public ShardingDataProvider(IList<Node> nodes)
            => _nodes = nodes;

        public IList<Node> GetSortedNodes()
        {
            return _nodes
                .OrderBy(n => n.PartitionValue)
                .ToArray();
        }

        public void AddNode(Node node)
            => _nodes.Add(node);
    }
}
