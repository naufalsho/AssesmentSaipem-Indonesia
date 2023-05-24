using AssesmentSaipem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AssesmentSaipem.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<DataCompany> dataCompanies = new List<DataCompany>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = AssesmentSaipem.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            FetchData();
            return View(dataCompanies);
        }

        private void FetchData()
        {
            if(dataCompanies.Count > 0)
            {
                dataCompanies.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT [c1Code1], [c1Name], [c2Code2], [c2Name] FROM [DataCompany] WHERE [c1Name] = 'SAIPEM' ORDER BY [c2Code2] DESC;";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    dataCompanies.Add(new DataCompany()
                    {
                        c1Code1 = dr["c1Code1"].ToString(),
                        c1Name = dr["c1Name"].ToString(),
                        c2Code2 = dr["c2Code2"].ToString(),
                        c2Name = dr["c2Name"].ToString()
                    });
                }
                con.Close();
            }
                catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}