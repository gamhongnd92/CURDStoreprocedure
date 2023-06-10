using CURDStoreprocedure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDStoreprocedure.Controllers
{
    public class HomeController : Controller
    {
        Data_Access_Layer.db dbLayer = new Data_Access_Layer.db();
        public ActionResult ShowData()
        {
            DataSet dataSet = dbLayer.ShowData();
            ViewBag.emp = dataSet.Tables[0];
            return View();
        }

        public ActionResult AddRecord()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddRecord(FormCollection formCollection)
        {
            Employee emp = new Employee();
            emp.Name = formCollection["Name"];
            emp.Address = formCollection["Address"];
            emp.City = formCollection["City"];
            emp.Pin_Code = formCollection["Pin_Code"];
            emp.Designation = formCollection["Designation"];
            dbLayer.AddRecord(emp);
            TempData["msg"] = "Inserted";
            return View();
        }

        public ActionResult UpdateRecord(int id)
        {
            
            DataSet dataset = dbLayer.ShowRecordById(id);
            ViewBag.empRecord = dataset.Tables[0];

            return View();
        }

        [HttpPost]
        public ActionResult UpdateRecord(int id, FormCollection formCollection)
        {
            Employee emp = new Employee();
            emp.Emp_Id = id;
            emp.Name = formCollection["Name"];
            emp.Address = formCollection["Address"];
            emp.City = formCollection["City"];
            emp.Pin_Code = formCollection["Pin_Code"];
            emp.Designation = formCollection["Designation"];
            dbLayer.UpdateRecord(emp);
            TempData["msg"] = "Updated";
            return RedirectToAction("ShowData");
        }


        
        public ActionResult DeleteRecord(int id)
        {
            dbLayer.DeleteRecord(id);
            TempData["msg"] = "Delete";
            return RedirectToAction("ShowData");
        }
        
    }
}