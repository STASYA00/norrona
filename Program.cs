using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;

using Norrona;

var config = new Config();
config.IsDebug = true;

var f = "";
var html = "";


if (config.IsDebug == false)
{
    using (WebClient wc = new WebClient())
    {
        f = wc.DownloadString(constants.JSONURL);
    }
    HttpClient client = new HttpClient();
    html = await client.GetStringAsync(constants.NORRONAURL);
}
else
{
    f = File.ReadAllText(String.Format("{0}{1}", constants.ASSETPATH, constants.JSONFILE));
    html = File.ReadAllText(String.Format("{0}{1}", constants.ASSETPATH, constants.HTMLFILE));
    var t = 0;
}

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
        .Count();

Console.WriteLine(res);

//Products.OutletVariants.SizeVariations.Inventory

List<string> chosenConcepts = result.Products.Select(x => x.Concept).Distinct().ToList();
List<string> chosenSizes=new List<string>() { "m" };
List<string> chosenColors=new List<string>() { "red" };
List<string> chosenCategories=new List<string>() { "jackets" };
int Discount = 30;
int ProductQuantity = 0;

var super_x = result.Products
    .Where(x => (chosenConcepts.Contains(x.Concept.ToLower()) &&
                (chosenCategories.Contains(x.Category.ToLower())) &&
                (x.OutletVariants.Select(x => (chosenColors.Contains(x.BaseColor.ToLower())) &&
                                            (x.Price.DiscountPercentage > Discount) &&
                                            (x.SizeVariations.Select(x => (x.Inventory == ProductQuantity) &&
                                                                        (chosenSizes.Contains(x.Size.ToLower()))
                                                                        ).Count() > 0)
                                            ).Count() > 0)));

super_x.ToList().ForEach(x => Console.WriteLine(x.ToString()));
var a = 3;
//result.CurrentContent.DisplayName
//    .Select(x => x.Value)
//    .ToList()
//    .ForEach(x => Console.WriteLine(x));

