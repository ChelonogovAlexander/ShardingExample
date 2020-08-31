namespace ShardingExample
{
    public sealed class BoxItem
    {
        public BoxItem(int boxId, int itemId)
        {
            BoxId = boxId;
            ItemId = itemId;
        }

        public int BoxId { get; }

        public int ItemId { get; }
    }
}
