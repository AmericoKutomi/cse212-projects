using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 1 - Run test cases and record any defects the test code finds in the comment above the test method.
// DO NOT MODIFY THE CODE IN THE TESTS in this file, just the comments above the tests. 
// Fix the code being tested to match requirements and make all tests pass. 

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        // Arrange
        // Create three Person to be added
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        // Final result expected
        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        // Act
        // Start the class
        var players = new TakingTurnsQueue();
        // Add the players
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        // Assert

        // players loop
        int i = 0;
        while (players.Length > 0)
        {
            // Test whether the queue has the same length
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            // Test to compare the Person and the Player
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns.  Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        // Arrange
        // Create four Person
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);
        // Final result expected
        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, george, sue, tim, george, tim, george];

        // Act
        // Start the class
        var players = new TakingTurnsQueue();
        // Players are added except George
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        // Assert
        int i = 0;
        // Test to compare each Person
        for (; i < 5; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Act
        // Add "George" as a Player
        players.AddPerson("George", 3);

        // Assert
        // Players loop
        while (players.Length > 0)
        {

            if (i >= expectedResult.Length)
            {
                // The queue should be empty
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            // Test each Person in the queue
            Assert.AreEqual(expectedResult[i].Name, person.Name);

            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_ForeverZero()
    {
        // Arrange
        // Tim wil be forever in the queue
        var timTurns = 0;

        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);
        // Final result expected
        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        // Act
        // Create the queue
        var players = new TakingTurnsQueue();
        // Add Person to queue
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        // Assert
        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            // Each person is compared to the expected result
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        // The next Person should be Tim, who has infinite turns
        // Compare timTurns with the infinitePerson's (who is Tim) turns
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        // Arrange

        // Tim wil be forever in the queue: turns is equal to or less than 0
        var timTurns = -3;
        // Add Person
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);
        // Expected result
        Person[] expectedResult = [tim, sue, tim, sue, tim, sue, tim, tim, tim, tim];

        // Act
        // Create the queue
        var players = new TakingTurnsQueue();
        // Add players to the queue
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        // Assert
        // Loop for the queue
        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            // Check if the queue Person are the expected
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        // The next Person should be Tim, who has infinite turns
        // Compare timTurns with the infinitePerson's (who is Tim) turns
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: 
    public void TestTakingTurnsQueue_Empty()
    {
        // Act
        // Create the queue with no Person
        var players = new TakingTurnsQueue();

        // Assert
        try
        {
            // Try to get a Player who does not exist
            players.GetNextPerson();
            // Next statement shouldn't be executed due to the Exception
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            // The assert will confirm that the queue is empty
            Assert.AreEqual("No one in the queue.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            // Uneexpected exception ocurred
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}