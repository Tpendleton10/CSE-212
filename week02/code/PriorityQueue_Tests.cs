using Microsoft.VisualStudio.TestTools.UnitTesting;

// Tests for the PriorityQueue class.
// Fix the bugs in PriorityQueue.cs so all tests pass.
// DO NOT MODIFY THE TEST CODE.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items and ensure the highest priority is returned.
    // Expected: "C" should dequeue first (priority 30)
    public void TestPriorityQueue_BasicHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 10);
        pq.Enqueue("B", 20);
        pq.Enqueue("C", 30);

        var result = pq.Dequeue();
        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Ensure items of equal priority return in FIFO order.
    // Expected: A then B (both priority 10)
    public void TestPriorityQueue_FIFOTie()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 10);
        pq.Enqueue("B", 10);

        var first = pq.Dequeue();
        var second = pq.Dequeue();

        Assert.AreEqual("A", first);
        Assert.AreEqual("B", second);
    }

    [TestMethod]
    // Scenario: Multiple mixed priorities, ensure order is correct.
    // Expected Dequeue order: Z (50), Y (40), A (10)
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 10);
        pq.Enqueue("Y", 40);
        pq.Enqueue("Z", 50);

        Assert.AreEqual("Z", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue repeatedly until empty.
    // Expected: queue empties in priority order without exception.
    public void TestPriorityQueue_DequeueAll()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Mid", 5);
        pq.Enqueue("High", 10);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Mid", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected: InvalidOperationException with correct message.
    public void TestPriorityQueue_EmptyDequeueError()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                ex.GetType(), ex.Message)
            );
        }
    }
}
