using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KarmaWeb.OrderServiceRef;
using KarmaWeb.ProductServiceRef;

namespace KarmaWeb.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// Client reference for the Product service.
        /// </summary>
        private readonly ProductServicesClient _pClient = new ProductServicesClient();
        private readonly OrderServiceClient _oClient = new OrderServiceClient();

        // GET: Order
        public ActionResult Index()
        {
            //if (Session["sum"] == null)
            //{
            //    Session["sum"] = ((List<OrderLine>)Session["cart"]).Sum(x => x.Product.Price);
            //}

            if (Session["cart"] == null)
            {
                Session["cart"] = new List<OrderLine>();
            }

            return View(_pClient.GetAllProducts());
        }

        public ActionResult ToCart(string id)
        {
            //var refP = _pClient.GetProductById(id);
            //var p = ParseProduct(refP);

            var cart = (List<OrderLine>) Session["cart"];
            var index = DoesProductExist(id);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            else
            {
                cart.Add(new OrderLine {Product = ParseProduct(_pClient.GetProductById(id)), Quantity = 1});
            }

            Session["cart"] = cart;
            
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            var cart = (List<OrderLine>)Session["cart"];
            var index = DoesProductExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public ActionResult AddOrder(string comment)
        {
            var sum = 0d;
            foreach (var orderLine in (List<OrderLine>) Session["cart"])
            {
                sum += orderLine.Product.Price * orderLine.Quantity;
            }

            _oClient.InsertOrder(new Order
            {
                Price = new decimal(sum),
                Tables = new List<Table> { new Table { Id = 2 } },
                OrderLines = (List<OrderLine>)Session["cart"],
                Employee = new Employee { Id = 1 },
                Comment = comment
            });

            return RedirectToAction("Index", "Home");
        }

        private static OrderServiceRef.Product ParseProduct(ProductServiceRef.Product p)
        {
            var orderProduct = new OrderServiceRef.Product()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            };
            return orderProduct;
        }

        private int DoesProductExist(string id)
        {
            var cart = (List<OrderLine>)Session["cart"];
            for (var i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(int.Parse(id)))
                    return i;
            return -1;
        }

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
