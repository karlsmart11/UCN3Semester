using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarmaWeb.ProductServiceRef;

namespace KarmaWeb.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// Client reference for the Product service.
        /// </summary>
        private readonly ProductServicesClient _pClient = new ProductServicesClient();  

        // GET: Order
        public ActionResult Index()
        {
            return View(_pClient.GetAllProducts());
        }

        //public ActionResult Select(string id)
        //{
        //    return RedirectToAction("Index", _pClient.GetProductById(id));
        //}

        #region Boilerplate MVC controller

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
