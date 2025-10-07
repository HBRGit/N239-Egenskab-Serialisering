# N239 Egenskab (serialisering)
Opgave fra Bogen om C#

Skab en fil p� disken (feks c:\temp\data.json) med f�lgende indhold:

```json
[
  {
    "Id": 1,
    "Navn": "A",
    "ErDansk": true,
    "Dato": "1966-01-01T00:00:00"
  },
  {
    "Id": 2,
    "Navn": "B",
    "ErDansk": true,
    "Dato": "2003-01-01T00:00:00"
  },
  {
    "Id": 3,
    "Navn": "C",
    "ErDansk": true,
    "Dato": "1988-01-01T00:00:00"
  }
]
```
Det er en liste af personer med fire egenskaber.
Lav en klasse Person med de fire egenskaber. (skal hedde det samme som i filen), og herefter skabe en liste af personer ved hj�lp af JSON deserialisering. Du kan benytte den indbyggede System.Text.Json.Deserialize<> som f�lger:


```csharp
// hent json
string json = System.IO.File.ReadAllText(@"c:\temp\data.json");
// deserialiser
List<Person> lst = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(json);
```
Herefter skal du l�be listen igennem og udskrive Navn eller lign.

## Ekstra
Pr�v evt at udvide JSON filen med en ny egenskab p� hver person, og tilrette klassen s� den tager hensyn til det nye skema.

## Ekstra Ekstra:
Pr�v at tilf�je f�lgende kode til sidst i main (og s�rg for at klassen Person er public):

````csharp
System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(List<Person>));
System.IO.TextWriter writer = new System.IO.StreamWriter(@"c:\temp\data.xml");
x.Serialize(writer, lst);
````
Check om der er kommet en xml-fil p� disken med det rette indhold.

## Ekstra Ekstra Ekstra
Pr�v at tilf�je NuGet-pakken ServiceStack.Text og tilf�j f�lgende kode i bunden af main:

````csharp
// Bare for sjov - brug ServiceStack.Text (NuGet) til at gemme som CSV            
ServiceStack.Text.CsvConfig.ItemSeperatorString = ";";  // Dansk format
System.IO.File.WriteAllText(@"c:\temp\data.csv", ServiceStack.Text.CsvSerializer.SerializeToString(lst));
````
Check om der er kommet en csv-fil p� disken med det rette indhold.
