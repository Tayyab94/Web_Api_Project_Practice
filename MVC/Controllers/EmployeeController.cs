using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            HttpResponseMessage response = GlobalVeriable.webApiClient.GetAsync("Employee").Result;

            IEnumerable<Employee> empList = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;

            return View(empList);
        }


        [HttpGet]
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                HttpResponseMessage response = GlobalVeriable.webApiClient.GetAsync("Employee/" + id.ToString()).Result;

                return View(response.Content.ReadAsAsync<Employee>().Result);
            }
        }

        [HttpPost]

        public ActionResult AddorEdit(Employee emp)
        {
            if (emp.EmployeeId == 0)
            {
                HttpResponseMessage response = GlobalVeriable.webApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["msg"] = "Data Saved Successfuly.!";
            }
            else
            {
                HttpResponseMessage response = GlobalVeriable.webApiClient.PutAsJsonAsync("Employee/" + emp.EmployeeId, emp).Result;
                TempData["msg"] = "Data Updated Successfuly.!";

            }

            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVeriable.webApiClient.DeleteAsync("Employee/" +id.ToString()).Result;
            TempData["msg"] = "Data Deleted Successfuly.!";
            return RedirectToAction("Index");
        }
    }
}