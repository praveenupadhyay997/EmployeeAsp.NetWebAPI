using EmployeePayrollMVC.Models;
using EmployeePayrollMVC.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            //List<EmployeeViewModel> list = employeeRepository.GetEmployees();
            //return View(list);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63493/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Employee");
                //responseTask.Wait();

                var apiResponse = responseTask.Result;
                if (apiResponse.IsSuccessStatusCode)
                {
                    var list = apiResponse.Content.ReadAsAsync<IList<EmployeeViewModel>>().Result;
                    //var students = readTask.Result;

                    //foreach (var student in students)
                    //{
                    //    Console.WriteLine(student.Name);
                    //}
                    return View("Index", list);
                }
            }
            return View();

        }
    }
}