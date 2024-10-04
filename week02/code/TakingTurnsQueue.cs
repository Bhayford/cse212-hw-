public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// The person should go to the back of the queue again unless their turns have run out.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            Person person = _people.Dequeue();
            if (person.Turns == 0 || person.Turns < 0)
            {
                // Infinite turns, put them back in the queue
                _people.Enqueue(person);
            }
            else if (person.Turns > 1)
            {
                // Decrement the turns and re-enqueue if they have more turns left
                person.Turns -= 1;
                _people.Enqueue(person);
            }

            // No need to re-enqueue if turns == 1 (last turn)
            return person;
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
