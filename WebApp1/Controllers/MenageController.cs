using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.Diagnostics.Metrics;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class MenageController : Controller
    {
        public EmeraldAccount account = new EmeraldAccount() 
        { Ballance = 10000 };

        public static List<Product> products = new List<Product> {
            new Product(1,"Cat Robot"),
            new Product(2,"Dog Robot"),
            new Product(3,"Monkey Robot"),
            new Product(4,"Donkey Robot"),
            new Product(5,"Goat Robot"),
            };

        public IActionResult Index(){
            UpdateSaldo();
            return View(products);
        }


        [HttpPost]
        public IActionResult AddCampany(Campany campany)
        {
            if (ModelState.IsValid)
            {
                List<Campany> companiesList = FindCompaniesList(campany.Product_Id);
                campany.Id = companiesList.Count() + 1;
                companiesList.Add(campany);
                UpdateSaldo();
                return View("Index", products);
            }
            else
            {
                ViewBag.P_Id = campany.Product_Id;
                return View(campany);
            }
   
        }

        [HttpPost]
        public IActionResult EditCampany(Campany campany){
            if (ModelState.IsValid)
            {
                List<Campany> companiesList = FindCompaniesList(campany.Product_Id);
                Campany OldCampany = companiesList.Single(campany=>campany.Id == campany.Id);
                companiesList.Remove(OldCampany);
                companiesList.Add(campany);
                UpdateSaldo();
                return View("Index", products);
            }
            else
                return View(campany);
        }

        [HttpGet]
        public IActionResult AddCampany(int P_Id)
        {
            ViewBag.P_Id = P_Id;
            return View("AddCampany");
        }

        [HttpGet]
        public IActionResult EditCampany(int P_Id, int C_Id)
            => View(CampanyFromList(P_Id, C_Id)); 


        [HttpGet]
        public IActionResult DeleteCampany(int P_Id, int C_Id) {
            Campany campany = CampanyFromList(P_Id, C_Id);
            FindCompaniesList(P_Id).Remove(campany);
            UpdateSaldo();
            return View("Index", products); 
        }


        double CalculateCosts()
        {
            double Costs = 0;
            foreach (Product product in products)
                foreach (Campany campany in product.companies_List)
                    Costs += campany.Campaign_fund;
            return Costs;
        }

        /// <summary>
        /// Symulate new saldo 
        /// </summary>
        void UpdateSaldo()
            => ViewBag.Saldo = " " + (account.Ballance - CalculateCosts());

        List<Campany> FindCompaniesList(int P_Id) 
            => products.Single(p => p.Id == P_Id).companies_List;

        Campany CampanyFromList(int P_Id, int C_Id)
            => FindCompaniesList(P_Id).Single(campany => campany.Id == campany.Id);


    }
}
