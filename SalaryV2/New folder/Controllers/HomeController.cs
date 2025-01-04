using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaryV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top(1000)* FROM ray.EmpPayWagAndEmpInfoByDateV where NationCode='4322889573'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        //Create a new DataTable.
                        DataTable dtCustomers = new DataTable("ray.EmpPayWagAndEmpInfoByDateV");

                        //Load DataReader into the DataTable.
                        dtCustomers.Load(sdr);
                        List<SalaryV2.Models.EmpPayWagAndEmpInfoByDateV> employees = new List<SalaryV2.Models.EmpPayWagAndEmpInfoByDateV>();

                        foreach (DataRow row in dtCustomers.Rows)
                        {
                            employees.Add(new Models.EmpPayWagAndEmpInfoByDateV
                            {
                                 NationCode= row["NationCode"].ToString(),
                                 TelMobil= row["TelMobil"].ToString(),
                                  Acnt= row["Acnt"].ToString(),
                                  Acnt2 = row["Acnt2"].ToString(),
                                Year = Convert.ToSByte(row["Year"]),
                                //Mnt = Convert.ToByte(row["Mnt"]),
                                PayVal =Convert.ToDecimal( row["PayVal"]),
                              
                            });
                        }
                        var jj = employees.ToList();
                    }
                    
                    con.Close();

                }
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}