using System;
using System.Collections.Generic;
using System.Linq;

namespace ShardingExample
{
    public sealed class BoxItemsGenerator
    {
        private static readonly Random Random = new Random();

        public IEnumerable<BoxItem> GenerateRandomData(int itemsCount, int boxesCount)
        {
            var boxes = GenerateBoxes(boxesCount).ToArray();

            for (int i = 0; i < itemsCount; i++)
            {
                var boxIndex = Random.Next(0, boxesCount);
                var boxId = boxes[boxIndex];

                yield return new BoxItem(boxId, Random.Next());
            }
        }

        private IEnumerable<int> GenerateBoxes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return Random.Next();
            }
        }
    }
}
