using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var word in words)
        {
            // Create the reverse of the current word
            var reversed = new string(new char[] { word[1], word[0] });

            // Check if the reversed word exists in the set
            if (wordSet.Contains(reversed) && word != reversed)
            {
                result.Add($"{word} & {reversed}");
                // Remove both words to avoid duplicates in result
                wordSet.Remove(word);
                wordSet.Remove(reversed);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>A dictionary summarizing degrees and their counts</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3].Trim(); // Get the degree from the 4th column
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize the words by removing spaces and converting to lowercase
        var normalizedWord1 = word1.Replace(" ", "").ToLower();
        var normalizedWord2 = word2.Replace(" ", "").ToLower();

        // Use a dictionary to count occurrences of each character
        var charCount = new Dictionary<char, int>();

        foreach (var ch in normalizedWord1)
        {
            if (charCount.ContainsKey(ch))
                charCount[ch]++;
            else
                charCount[ch] = 1;
        }

        foreach (var ch in normalizedWord2)
        {
            if (charCount.ContainsKey(ch))
                charCount[ch]--;
            else
                return false;
        }

        // Check if all counts are zero
        foreach (var count in charCount.Values)
        {
            if (count != 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON data from the USGS consisting of earthquake data.
    /// </summary>
    public static string[] EarthquakeDailySummary()
{
    const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
    using var client = new HttpClient();
    using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
    using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);

    // Prepare the output array
    var earthquakeSummary = new List<string>();

    foreach (var feature in featureCollection.Features)
    {
        earthquakeSummary.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
    }

    return earthquakeSummary.ToArray(); // Convert List to Array and return
}

}

// Define your FeatureCollection and related classes here
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double Mag { get; set; }
}
