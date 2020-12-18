using EmployeePayrollMVC.Models.Common;
using EmployeePayrollMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeRepository repo = new EmployeeRepository();
        [HttpGet]
        // GET: api/Employee
        public IHttpActionResult Get()
        {
            var result = repo.GetEmployees();
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Post: api/Employee
        public IHttpActionResult Post(RegisterRequestModel employee)
        {
            EmployeeRepository repo = new EmployeeRepository();
            var result = repo.RegisterEmployee(employee);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
