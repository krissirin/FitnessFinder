//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using FitnessClassFinder.Models;
//using FitnessClassFinder.ViewModels;

//namespace FitnessClassFinder.Controllers
//{
//    public class FitnessCartController1 : Controller
//    {
//        FitnessDBContext fitnessDB = new FitnessDBContext();

//        GET: FitnessCart
//        public ActionResult Index()
//        {
//            var cart = FitnessCart.GetCart(this.HttpContext);

//            Set up our ViewModel
//            var viewModel = new FitnessCartViewModel
//            {
//                CartItems = cart.GetCartItems(),
//                CartTotal = cart.GetTotal()
//            };
//            Return the view
//            return View(viewModel);
//        }

//        GET: /Store/AddToCart/5
//        public ActionResult AddToCart(int id)
//        {
//            Retrieve the schedule from the database
//            var addedSchedule = fitnessDB.Schedules
//                .Single(ClassSchedule => ClassSchedule.FitnessClassID == id);

//            Add it to the shopping cart
//            var cart = FitnessCart.GetCart(this.HttpContext);

//            cart.AddToCart(addedSchedule);

//            Go back to the main store page for more shopping
//            return RedirectToAction("Index");
//        }

//        AJAX: /BookingCart/RemoveFromCart/5
//        [HttpPost]
//        public ActionResult RemoveFromCart(int id)
//        {
//            Remove the item from the cart
//            var cart = FitnessCart.GetCart(this.HttpContext);

//            Get the name of the album to display confirmation
//            string className = fitnessDB.BookingCarts
//                .Single(item => item.BookingId == id).schedules.ClassName;

//            Remove from cart
//            int itemCount = cart.RemoveFromCart(id);

//            Display the confirmation message
//            var results = new FitnessCartRemoveViewModel
//            {
//                Message = Server.HtmlEncode(className) +
//                    " has been removed from your shopping cart.",
//                CartTotal = cart.GetTotal(),
//                CartCount = cart.GetCount(),
//                ItemCount = itemCount,
//                DeleteId = id
//            };
//            return Json(results);
//        }

//        GET: /ShoppingCart/CartSummary
//       [ChildActionOnly]
//        public ActionResult CartSummary()
//        {
//            var cart = FitnessCart.GetCart(this.HttpContext);

//            ViewData["CartCount"] = cart.GetCount();
//            return PartialView("CartSummary");
//        }
//    }
//}