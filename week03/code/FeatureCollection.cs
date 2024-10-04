using System.Collections.Generic;

public class FeatureCollections
{
    public string Type { get; set; } // Type of the collection, usually "FeatureCollection"
    public List<Feature> Features { get; set; } // List of features (earthquakes)
}

public class Features
{
    public string Type { get; set; } // Type of the feature, usually "Feature"
    public Properties Properties { get; set; } // Properties containing the earthquake info
    public Geometry Geometry { get; set; } // Geometry information (location)
    public string Id { get; set; } // Unique identifier for the feature
}

public class Propertiess
{
    public double Mag { get; set; } // Magnitude of the earthquake
    public string Place { get; set; } // Location of the earthquake
}

public class Geometry
{
    public string Type { get; set; } // Type of geometry, typically "Point"
    public List<double> Coordinates { get; set; } // Coordinates [longitude, latitude]
}
