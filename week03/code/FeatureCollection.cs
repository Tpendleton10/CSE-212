using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

public class Properties
{
    // Example: "10 km NW of XYZ"
    [JsonPropertyName("place")]
    public string Place { get; set; }

    // Example: 2.9, 4.5, etc.
    [JsonPropertyName("mag")]
    public double? Magnitude { get; set; }
}
