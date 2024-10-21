using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    // Problem 1: Sum of squares
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        foreach (char letter in letters)
        {
            if (!word.Contains(letter))
            {
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    // Problem 3: Count ways to climb stairs
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();
        if (s < 0) return 0;
        if (s == 0) return 1;
        if (remember.ContainsKey(s)) return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // Problem 4: Wildcard binary patterns
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildcardIndex = pattern.IndexOf('*');
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }
        WildcardBinary(pattern.Substring(0, wildcardIndex) + '0' + pattern.Substring(wildcardIndex + 1), results);
        WildcardBinary(pattern.Substring(0, wildcardIndex) + '1' + pattern.Substring(wildcardIndex + 1), results);
    }

    // Problem 5: Solve the maze
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        currPath.Add((x, y));

        // Base case: if we have reached the end of the maze
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        // Recursive case: explore all possible directions
        if (maze.IsValidMove(currPath, x + 1, y)) // Move right
        {
            SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
        }
        if (maze.IsValidMove(currPath, x, y + 1)) // Move down
        {
            SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
        }
        if (maze.IsValidMove(currPath, x - 1, y)) // Move left
        {
            SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
        }
        if (maze.IsValidMove(currPath, x, y - 1)) // Move up
        {
            SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
        }
    }
}

// Extension method for tuple list
public static class MazeTupleListExtensionMethods
{
    public static string AsString(this List<ValueTuple<int, int>> list)
    {
        return "<List>{" + string.Join(", ", list) + "}";
    }
}
