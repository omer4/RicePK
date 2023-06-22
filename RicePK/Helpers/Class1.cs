using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace RicePK.Helpers
{
    
       

    public static class DropDownHelper
    {
        public static System.Web.Mvc.SelectList GetDropDownSelectList(List<DTO.DropDownVM> dropDownVMs, object SelectedValue = null)
        {
            return new System.Web.Mvc.SelectList(dropDownVMs.OrderBy(x=>x.Text), "Value", "Text", SelectedValue);
        }
        public static System.Web.Mvc.SelectList GetDropDownSelectListMonths(object SelectedValue = null)
        {
            List<DTO.DropDownVM> months = new List<DTO.DropDownVM>();
            for(int i = 1; i <= 12; i++)
            {
                months.Add(new DTO.DropDownVM { Text=new DateTime(DateTime.Now.Year,i,1).ToString("MMMM"),Value=i.ToString() });
            }
            return new System.Web.Mvc.SelectList(months, "Value", "Text", SelectedValue);
        }
       
    }
}
