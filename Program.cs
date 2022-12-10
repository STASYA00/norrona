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

var res = result.Products
    .Where(x => x.Concept
        .ToLower()
        .Equals("lofoten"))
        .ToList()
        .Count()
        ;
Console.WriteLine(res);

//Products.OutletVariants.SizeVariations.Inventory

List<string> chosenConcepts = new List<string>() { "lofoten" };
List<string> chosenSizes=new List<string>() { "m" };
List<string> chosenColors=new List<string>() { "red" };
List<string> chosenCategories=new List<string>() { "jackets" };
int Discount = 30;
int ProductQuantity = 2;

var super_x = result.Products
    .Where(x => (chosenConcepts.Contains(x.Concept.ToLower()) &&
                (chosenCategories.Contains(x.Category.ToLower())) &&
                (x.OutletVariants.Select(x => (chosenColors.Contains(x.BaseColor.ToLower())) &&
                                            (x.Price.DiscountPercentage > Discount) &&
                                            (x.SizeVariations.Select(x => (x.Inventory > ProductQuantity) &&
                                                                        (chosenSizes.Contains(x.Size.ToLower()))
                                                                        ).Count() > 0)
                                            ).Count() > 0)));

super_x.ToList().ForEach(x => Console.WriteLine(x.ToString()));
var a = 3;
//result.CurrentContent.DisplayName
//    .Select(x => x.Value)
//    .ToList()
//    .ForEach(x => Console.WriteLine(x));
