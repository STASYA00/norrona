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
            return String.Format("{0}", Name);
        }
    }
    public class ProductVariant
    {
        public ProductVariant() { }
        public string BaseColor { get; set; }
        public string ColorName { get; set; }

        public String ColorCode { get; set; }

        public List<ProductSize> SizeVariations { get; set; }

        override public string ToString()
        {
            return String.Format("\t{0}", ColorName);
        }
    }

    public class ProductSize
    {
        public ProductSize() { }
        public string Size { get; set; }
        public string Inventory { get; set; }

        override public string ToString()
        {
            return String.Format("\t{0}", Size);
        }
    }

}
