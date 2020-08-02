using Packt.Shared;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace Exercise02
{
  class Program
  {
    static void Main(string[] args)
    {
      // create a file path to write to
      string path = Combine(CurrentDirectory, "shapes.xml");

      // create a list of Shape objects to serialize
      var listOfShapes = new List<Shape>
      {
          new Circle { Colour = "Red", Radius = 2.5 },
          new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
          new Circle { Colour = "Green", Radius = 8 },
          new Circle { Colour = "Purple", Radius = 12.3 },
          new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0  }
      };

      // create an object that knows how to serialize and deserialize 
      // a list of Shape objects
      var serializerXml = new XmlSerializer(typeof(List<Shape>));

      WriteLine("Saving shapes to XML file:");

      FileStream fileXml = File.Create(path);

      serializerXml.Serialize(fileXml, listOfShapes);

      fileXml.Dispose();

      WriteLine("Loading shapes from XML file:");

      fileXml = File.Open(path, FileMode.Open);

      List<Shape> loadedShapesXml = 
        serializerXml.Deserialize(fileXml) as List<Shape>;

      fileXml.Dispose();

      foreach (Shape item in loadedShapesXml)
      {
        WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of {item.Area:N2}");
      }
    }
  }
}
