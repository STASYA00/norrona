using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Serialization;

using norrona;

string assetsPath = "./../../../assets/";
string jsonname = "norrona.json";

var f = File.ReadAllText(String.Format("{0}{1}", assetsPath, jsonname));

var result = JsonSerializer.Deserialize<NorronaJson>(f);

Console.WriteLine(result.CurrentContent.DisplayName);
result.Products.ForEach(p =>  {
    Console.WriteLine(p.ToString());
    p.OutletVariants.ForEach(x => Console.WriteLine(x.ToString()));
} );

//result.CurrentContent.DisplayName
//    .Select(x => x.Value)
//    .ToList()
//    .ForEach(x => Console.WriteLine(x));
