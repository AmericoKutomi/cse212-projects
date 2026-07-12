using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with 
    //   the highest priority and return its value.
    // Expected Result: The high priority item should come first
    // Defect(s) Found: The high priority item doesn't come
    public void TestPriorityQueue_1()
    {
        // arrange
        var priorityQueue = new PriorityQueue();

        // act
        var abc = new PriorityItem("abc", 1);
        var def = new PriorityItem("def", 3);  // this is the highest
        var ghi = new PriorityItem("ghi", 2);

        priorityQueue.Enqueue(abc.Value, abc.Priority);
        priorityQueue.Enqueue(def.Value, def.Priority);
        priorityQueue.Enqueue(ghi.Value, ghi.Priority);

        // assert
        Assert.AreEqual(def.Value, priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown. 
    //   This exception should be an InvalidOperationException with a message of 
    //   "The queue is empty."
    // Expected Result: Exception shall be thrown.
    // Defect(s) Found: The empty queue is not considered
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        }
        );
    }

    // Add more test cases as needed below.
}