using JABIL_TEST.Migrations;
using JABIL_TEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JABIL_TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly MaterialsContext _context;

        public HomeController (MaterialsContext _dbconext)
        {
            _context = _dbconext;
        }

        public IActionResult Index()
        {
            var Lista = _context.Buildings.ToList();
            return View();
        }
        /**************************************/
        /* AGREGAR EDIFICIOS STORED PROCEDURE */
        /**************************************/
        public IActionResult Buildings_ADD()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Buildings_ADD(Building building)
        {
            // REVISAR QUE EL DATO NO EXISTA YA EN LA BASE DE DATOS
            bool ExistInDB = _context.Buildings.Where(x => x.Building1 == building.Building1).Any();

            if (!ModelState.IsValid && ExistInDB == false)
            {
                // EJECUTAR STORED PROCEDURE 
                _context.Database.ExecuteSqlRaw($"sp_Building_Insert {building.Building1}");
                return View();
            }
            return View();
        }
        /*******************************************************/
        /*       END AGREGAR BUILDINGS STORED PROCEDURE        */
        /*******************************************************/

        /**************************************/
        /* AGREGAR CUSTOMER STORED PROCEDURE  */
        /**************************************/
        public IActionResult Customers_ADD()
        {
            ViewData["Fkbuilding"] = new SelectList(_context.Buildings, "Pkbuilding", "Pkbuilding");
            return View();
        }

        [HttpPost]
        public IActionResult Customers_ADD(Customer customer)
        {
            // REVISAR QUE EL DATO NO EXISTA YA EN LA BASE DE DATOS
            bool ExistInDB = _context.Customers.Where(x => x.Customer1 == customer.Customer1).Any();

            if (!ModelState.IsValid && ExistInDB == false)
            {
                // EJECUTAR STORED PROCEDURE 
                _context.Database.ExecuteSqlRaw($"sp_Customer_Insert {customer.Prefix}, {customer.Customer1}, {customer.Fkbuilding}");
                return View();
            }

            return View();
        }
        /*******************************************************/
        /*       END AGREGAR CUSTOMERS STORED PROCEDURE        */
        /*******************************************************/

        /****************************************/
        /* AGREGAR PARTNUMBER STORED PROCEDURE  */
        /****************************************/
        public IActionResult PartNumbers_ADD()
        {
            ViewData["Fkcustomer"] = new SelectList(_context.Customers, "Pkcustomers", "Pkcustomers");
            
            return View();
        }

        [HttpPost]
        public IActionResult PartNumbers_ADD(PartNumber partNumber)
        {
            // REVISAR QUE EL DATO NO EXISTA YA EN LA BASE DE DATOS
            bool ExistInDB = _context.PartNumbers.Where(x => x.PartNumber1 == partNumber.PartNumber1).Any();

            if (!ModelState.IsValid && ExistInDB == false)
            {
                // EJECUTAR STORED PROCEDURE 
                _context.Database.ExecuteSqlRaw($"sp_PartNumber_Insert {partNumber.PartNumber1}, {partNumber.Fkcustomer}");
                return View();
            }
            return View();
        }
        /*******************************************************/
        /*       END AGREGAR PARTNUMBER STORED PROCEDURE        */
        /*******************************************************/


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