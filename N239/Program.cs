// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

// hent json
string json = System.IO.File.ReadAllText(@"..\..\..\data.json");
// deserialiser
List<Person> lst = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(json);

// vis
foreach (var person in lst)
{
    Console.WriteLine($"{person.Id} {person.Navn} {person.ErDansk} {person.Dato}");
}

// serialiser til xml
System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(List<Person>));
System.IO.TextWriter writer = new System.IO.StreamWriter(@"data.xml");
x.Serialize(writer, lst);
Console.WriteLine(
    "Data has been serialized to data.xml");
writer.Close();

// serialiser til csv using csvhelper
using (var writer2 = new StreamWriter("data.csv"))
using (var csv = new CsvHelper.CsvWriter(writer2, System.Globalization.CultureInfo.InvariantCulture))
{
    csv.WriteRecords(lst);
}
Console.WriteLine(
    "Data has been serialized to data.csv");


// Wait for user input before closing the console window
Console.ReadKey();

public class Person
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Efternavn { get; set; }
    public bool ErDansk { get; set; }
    public DateTime Dato { get; set; }
}