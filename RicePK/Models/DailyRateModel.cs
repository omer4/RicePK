using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RicePK.Models
{
    public class DailyRateModel
    {
        DataRicePKEntities db = new DataRicePKEntities();
        public long DailyRateId { get; set; }
        public DateTime DailyRateDate { get; set; }
        public long ProductId { get; set; }
        public long CityId { get; set; }
        public Nullable<decimal> Min { get; set; }
        public Nullable<decimal> Max { get; set; }
       public DateTime selectedDate  { get; set; }
    public DataTable dtAllRecords { get; set; }
        public enum gen_BagSizesFields
        {
            DailyRateId,
            DailyRateDate,
            ProductId,
            ProductName,
            CityId,
            CityName,
            Min,
            Max,
            Continous,
            BagSizesDescription,
            InActive,
            EntryDate,
            EntryTerminal,
            EntryBy,
            ModifiedDate,
            ModifiedTerminal,
            ModifiedBy,
            ModifiedType,
            TimeStamp,
            LogSource,
            WhereClause
        }
        public List<tblDailyRate> GetRates(DateTime date,long[] productid=null,long[] cityid = null)
        {

            var results = db.tblDailyRates.Where(x => DbFunctions.TruncateTime(x.DailyRateDate) == DbFunctions.TruncateTime(date)).ToList();
            if(productid != null)
            {
                results = results.Where(x => productid.Contains(x.ProductId)).ToList();
            }
            if(cityid != null)
            {
                results = results.Where(x => cityid.Contains(x.CityId)).ToList();
            }
            return results;
        }
        public DataTable SelectAll()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Helper.GetString();
                DataTable dt = new DataTable();
                //SqlCommand cmd = new SqlCommand("select *,CONVERT(DATE, DailyRatedate) AS DailyRatedate from tblDailyRate inner join tblProduct on  tblProduct.ProductId=tblDailyRate.ProductId inner join tblCity on tblCity.CityId=tblDailyRate.CityId",conn);
                SqlCommand cmd = new SqlCommand("select * from tblDailyRate inner join tblProduct on  tblProduct.ProductId=tblDailyRate.ProductId inner join tblCity on tblCity.CityId=tblDailyRate.CityId", conn);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<SelectListItem> GetProductList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var Product = db.tblProducts.ToList();
            foreach (var item in Product)
            {
                list.Add(new SelectListItem() { Text = item.ProductName.ToString(), Value = item.ProductId.ToString() });
            }
            return list;
        }
        public List<SelectListItem> GetCityList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var City = db.tblCities.ToList();
            foreach (var item in City)
            {
                list.Add(new SelectListItem() { Text = item.CityName.ToString(), Value = item.CityId.ToString() });
            }

            return list;
        }
    }
}