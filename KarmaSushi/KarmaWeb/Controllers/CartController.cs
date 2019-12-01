using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarmaWeb.OrderServiceRef;
using KarmaWeb.ProductServiceRef;

namespace KarmaWeb.Controllers
{
    public class CartController : Controller
    {
        /// <summary>
        /// Client reference for the Product service.
        /// </summary>
        private readonly ProductServicesClient _pClient = new ProductServicesClient();
        /// <summary>
        /// List holding order lines used when creating order to assign quantity to products.
        /// </summary>
        //private readonly List<OrderLine> _cart = new List<OrderLine>();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(string id)
        {
            var refP = _pClient.GetProductById(id);
            var p = ParseProduct(refP);

            if (Session["cart"] == null)
            {
                var cart = new List<OrderLine>
                {
                    new OrderLine { Product = p, Quantity = 1 }
                };
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<OrderLine>)Session["cart"];
                var index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new OrderLine { Product = ParseProduct(_pClient.GetProductById(id)), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            var cart = (List<OrderLine>) Session["cart"];
            var index = IsExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return Redirect("Index");
        }

        private OrderServiceRef.Product ParseProduct(ProductServiceRef.Product p)
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

        private int IsExist(string id)
        {
            var cart = (List<OrderLine>)Session["cart"];
            for (var i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(int.Parse(id)))
                    return i;
            return -1;
        }
    }
}