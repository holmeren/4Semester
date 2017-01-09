using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ReeksamenWeb.Migrations;
using ReeksamenWeb.Models;

namespace ReeksamenWeb.Controllers
{
    public class ExamController : Controller
    {
        private ExamContext db = new ExamContext();
        // POST: Exam
        public ActionResult Create(string objektString)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EksamensSet set = JsonConvert.DeserializeObject<EksamensSet>(objektString);

                    db.EksamensSets.Add(set);
                    
                    db.SaveChanges();

                    return null;
                }
                catch
                {
                    return HttpNotFound();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}