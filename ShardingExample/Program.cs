using System;
using System.Collections.Generic;
using System.Linq;

namespace ShardingExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var generator = new BoxItemsGenerator();
            var randomBoxItemsData = generator.GenerateRandomData(1000000, 1234).ToArray();
            var nodes = new List<Node>() {
                new Node("Machine A", 4),
                new Node("Machine B", 20),
                new Node("Machine C", 28) };

            var shardingDataProvider = new ShardingDataProvider(nodes);
            var shardingService = new ShardingService(shardingDataProvider);

            var shardsData = randomBoxItemsData
                .GroupBy(d => shardingService.GetShardingNode(d))
                .ToArray();

            foreach (var shard in shardsData)
            {
                Console.WriteLine($"Shard {shard.Key.Name} contain {shard.Count()} elements");
            }
        }
    }
}
