using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Dequeue function shall return the item with 
    //   the highest priority. It is in the middle of the queue.
    // Expected Result: def (The high priority item should come)
    // Defect(s) Found: None.
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
    // Expected Result: Exception shall be thrown with message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_2()
    {
        // arrange
        var priorityQueue = new PriorityQueue();

        // act
        //  do nothing

        // assert
        InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: The item with the highest priority is at the beginning 
    //   of the list.
    // Expected Result: abc
    // Defect(s) Found: None.
    public void TestHighestPriorityAtBeginning()
    {
        // arrange
        var priorityQueue = new PriorityQueue();

        // act
        var abc = new PriorityItem("abc", 3);  // this is the highest
        var def = new PriorityItem("def", 2);
        var ghi = new PriorityItem("ghi", 2);

        priorityQueue.Enqueue(abc.Value, abc.Priority);
        priorityQueue.Enqueue(def.Value, def.Priority);
        priorityQueue.Enqueue(ghi.Value, ghi.Priority);

        // assert
        Assert.AreEqual(abc.Value, priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: The item with the highest priority is at the end 
    //   of the list.
    // Expected Result: ghi
    // Defect(s) Found: def; the last element didn't come
    public void TestHighestPriorityAtEnd()
    {
        // arrange
        var priorityQueue = new PriorityQueue();

        // act
        var abc = new PriorityItem("abc", 2);
        var def = new PriorityItem("def", 2);
        var ghi = new PriorityItem("ghi", 3);  // this is the highest

        priorityQueue.Enqueue(abc.Value, abc.Priority);
        priorityQueue.Enqueue(def.Value, def.Priority);
        priorityQueue.Enqueue(ghi.Value, ghi.Priority);

        // assert
        Assert.AreEqual(ghi.Value, priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: The queue has only one element 
    // Expected Result: abc
    // Defect(s) Found: None.
    public void TestHighestPriorityWithOne()
    {
        // arrange
        var priorityQueue = new PriorityQueue();

        // act
        var abc = new PriorityItem("abc", 2);  // this is the only one

        priorityQueue.Enqueue(abc.Value, abc.Priority);

        // assert
        Assert.AreEqual(abc.Value, priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue is called twice to test remove.
    //  The highest come first, then the second one.
    // Expected Result: def first, ghi next
    // Defect(s) Found: def first, def again. Remove is not working.
    public void TestHighestPriorityTwoDequeues()
    {
        // arrange
        var priorityQueue = new PriorityQueue();

        // act
        var abc = new PriorityItem("abc", 1);
        var def = new PriorityItem("def", 3);  // this is the highest
        var ghi = new PriorityItem("ghi", 2);  // this is the second

        priorityQueue.Enqueue(abc.Value, abc.Priority);
        priorityQueue.Enqueue(def.Value, def.Priority);
        priorityQueue.Enqueue(ghi.Value, ghi.Priority);

        // assert
        Assert.AreEqual(def.Value, priorityQueue.Dequeue());
        Assert.AreEqual(ghi.Value, priorityQueue.Dequeue());
    }

}