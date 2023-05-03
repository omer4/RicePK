using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RicePK.Models
{
    public class ProductModel
    {
        DataRicePKEntities db = new DataRicePKEntities();
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }

        public List<SelectListItem> GetProductCategoryList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var productCategoryList = db.tblProductCategories.ToList();
            foreach (var item in productCategoryList)
            {
                list.Add(new SelectListItem() { Text = item.ProductCategoryName.ToString(), Value = item.ProductCategoryId.ToString() });

            }

            return list;
        }
    }
}