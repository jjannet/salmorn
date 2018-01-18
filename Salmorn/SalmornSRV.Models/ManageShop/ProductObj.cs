using SalmornSRV.Models.Log;
using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Models.ManageShop
{
    public class ProductObj
    {
        public Product product { get; set; }
        public FileUpload image { get; set; }
    }
}
