using BasicCoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCoffeeShop
{
    public class DataStorage
    {
/*        public static string TextBoxValue { get; set; }
        public static string managerName {  get; set; }
        public static string baristaName { get; set;}*/
        public static Manager Manager { get; set; }
        public static Barista Barista { get; set;}
        public static Customer Customer { get; set; }
        public static Feedback Feedback { get; set; }
        public static Bill Bill { get; set; }
    }
}
