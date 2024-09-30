public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority. 
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(object value, int priority)
    {
        var item = new PriorityItem(value, priority);
        _queue.Add(item);
    }

    /// <summary>
    /// Return the highest priority item from the queue. 
    /// If multiple items have the same highest priority, return the first one.
    /// </summary>
    public object Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No items in the queue.");
        }

        var highestPriorityItem = _queue.OrderByDescending(i => i.Priority).First();
        _queue.Remove(highestPriorityItem);
        return highestPriorityItem.Value;
    }

    public int Length => _queue.Count;

    public bool IsEmpty() => _queue.Count == 0;

    public override string ToString() => string.Join(", ", _queue.Select(i => $"{i.Value} (Priority: {i.Priority})"));

    private class PriorityItem
    {
        public object Value { get; }
        public int Priority { get; }

        public PriorityItem(object value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }
}
