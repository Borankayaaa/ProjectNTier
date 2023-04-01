using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.WinFormUI.WiewModels
{
    public class ProductVM
    {
        public  int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }


        public string CategoryName { get; set; }
        public int? CategoryID { get; set; }

        public override string ToString()
        {
            return $"{ProductName}, Price => {UnitPrice:C2}, Category=> {CategoryName}";
        }




    }
}
