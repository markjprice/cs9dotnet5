using System.Collections.Generic;
using System.IO;
using System.Xml;
using Packt.Shared;
using static System.Console;
using static System.IO.Path;
using static System.Environment;

namespace Exercise02
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteLine("You must enter a password to encrypt the sensitive data in the document.");
      WriteLine("You must enter the same passord to decrypt the document later.");
      Write("Password: ");
      string password = ReadLine();

      // define two example customers and
      // note they have the same password
      var customers = new List<Customer>
      {
        new Customer
        {
          Name = "Bob Smith",
          CreditCard = "1234-5678-9012-3456",
          Password = "Pa$$w0rd",
        },
        new Customer
        {
          Name = "Leslie Knope",
          CreditCard = "8002-5265-3400-2511",
          Password = "Pa$$w0rd",
        }
      };

      // define an XML file to write to
      string xmlFile = Combine(CurrentDirectory, 
        "..", "protected-customers.xml");

      var xmlWriter = XmlWriter.Create(xmlFile,
        new XmlWriterSettings { Indent = true });

      xmlWriter.WriteStartDocument();

      xmlWriter.WriteStartElement("customers");

      foreach (var customer in customers)
      {
        xmlWriter.WriteStartElement("customer");
        xmlWriter.WriteElementString("name", customer.Name);

        // to protect the credit card number we must encrypt it
        xmlWriter.WriteElementString("creditcard", 
          Protector.Encrypt(customer.CreditCard, password));
        
        // to protect the password we must salt and hash it
        // and we must store the random salt used
        var user = Protector.Register(customer.Name, customer.Password);
        xmlWriter.WriteElementString("password", user.SaltedHashedPassword);
        xmlWriter.WriteElementString("salt", user.Salt);

        xmlWriter.WriteEndElement();
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();

      WriteLine();
      WriteLine("Contents of the protected file:");
      WriteLine();
      WriteLine(File.ReadAllText(xmlFile));
    }
  }
}
