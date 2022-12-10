using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norrona
{
    public class NorronaJson
    {
        public NorronaJson() { }
        public int TotalMatching { get; set; }
        //public Dictionary<string, Product> Products { get; set; }

        public CurrentCollection CurrentContent { get; set; }

        public List<Product> Products { get; set; }
    }

    public class CurrentCollection
    {
        public CurrentCollection() { }

        public string DisplayName { get; set; }
        public bool Outlet { get; set; }
        public string Gender { get; set; }
    }
    public class Product
    {
        public Product() { }
        public string Name { get; set; }
        public string SimpleName { get; set; }
        public string Concept { get; set; }
        public string Gender { get; set; }
        public List<ProductVariant> OutletVariants { get; set; }
        public string Category { get; set; }

        override public string ToString()
        {
            return String.Format("{0, 5}:\t{1}\t{2}\n***\n", Category.ToUpper(), Name, 
                                 OutletVariants.Aggregate("", (acc, next)=>acc + next.ToString()));
        }
    }
    public class ProductVariant
    {
        public ProductVariant() { }
        public string BaseColor { get; set; }
        public string ColorName { get; set; }

        public String ColorCode { get; set; }

        public List<ProductSize> SizeVariations { get; set; }

        public Price Price { get; set; }
        override public string ToString()
        {
            return String.Format("{0}\tAMOUNT: {1}\n", ColorName, SizeVariations.Where(x=>x.Inventory>0).Aggregate("", (acc, next)=>acc + next.ToString()));
        }
    }

    public class ProductSize
    {
        public ProductSize() { }
        public string Size { get; set; }
        public int Inventory { get; set; }

        override public string ToString()
        {
            return String.Format("{0}: {1} ", Size, Inventory);
        }
    }

    public class Price
    {
        public Price() { }
        public double VariantAmount { get; set; }
        public string CurrencyCode { get; set; }
        public double FullPrice { get; set; }
        public int DiscountPercentage { get; set; }
        override public string ToString()
        {
            return String.Format("{0:F2} {1}", VariantAmount, CurrencyCode);
        }

    }

}
