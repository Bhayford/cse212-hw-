using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    public void TestPriorityQueue_EnqueueDequeue()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("Low Priority", 1);
        queue.Enqueue("Medium Priority", 5);
        queue.Enqueue("High Priority", 10);

        Assert.AreEqual(3, queue.Length, "Queue should contain 3 items.");

        Assert.AreEqual("High Priority", queue.Dequeue(), "Dequeue should return item with highest priority.");
        Assert.AreEqual("Medium Priority", queue.Dequeue(), "Next should return medium priority.");
        Assert.AreEqual("Low Priority", queue.Dequeue(), "Last should return low priority.");
    }

    [TestMethod]
    public void TestPriorityQueue_EmptyQueueDequeue()
    {
        var queue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message, "Exception message is incorrect.");
    }
}
