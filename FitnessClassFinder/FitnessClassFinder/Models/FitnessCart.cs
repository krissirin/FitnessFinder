//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace FitnessClassFinder.Models
//{
//    public partial class FitnessCart
//    {
//        FitnessDBContext fitnessDB = new FitnessDBContext();
//        string FitnessCartId { get; set; }
//        public const string CartSessionKey = "CartId";
//        public static FitnessCart GetCart(HttpContextBase context)
//        {
//            var cart = new FitnessCart();
//            cart.FitnessCartId = cart.GetCartId(context);
//            return cart;
//        }
//        // Helper method to simplify shopping cart calls
//        public static FitnessCart GetCart(Controller controller)
//        {
//            return GetCart(controller.HttpContext);
//        }
//        public void AddToCart(Schedule schedule)
//        {
//            // Get the matching cart and album instances
//            var cartItem = fitnessDB.BookingCarts.SingleOrDefault(
//                c => c.CartId == FitnessCartId
//                && c.ScheduleId == schedule.ScheduleId);

//            if (cartItem == null)
//            {
//                // Create a new cart item if no cart item exists
//                cartItem = new BookingCart
//                {
//                    ScheduleID = schedule.ScheduleID,
//                    CartId = FitnessCartId,
//                    Count = 1,
//                    DateCreated = DateTime.Now
//                };
//                fitnessDB.BookingCarts.Add(cartItem);
//            }
//            else
//            {
//                // If the item does exist in the cart, 
//                // then add one to the quantity
//                cartItem.Count++;
//            }
//            // Save changes
//            fitnessDB.SaveChanges();
//        }
//        public int RemoveFromCart(int id)
//        {
//            // Get the cart
//            var cartItem = fitnessDB.BookingCarts.Single(
//                bookingCart => bookingCart.CartId == FitnessCartId
//                && bookingCart.RecordId == id);

//            int itemCount = 0;

//            if (cartItem != null)
//            {
//                if (cartItem.Count > 1)
//                {
//                    cartItem.Count--;
//                    itemCount = cartItem.Count;
//                }
//                else
//                {
//                    fitnessDB.BookingCarts.Remove(cartItem);
//                }
//                // Save changes
//                fitnessDB.SaveChanges();
//            }
//            return itemCount;
//        }
//        public void EmptyCart()
//        {
//            var cartItems = fitnessDB.BookingCarts.Where(
//                bookingCart => bookingCart.CartId == FitnessCartId);

//            foreach (var cartItem in cartItems)
//            {
//                fitnessDB.BookingCarts.Remove(cartItem);
//            }
//            // Save changes
//            fitnessDB.SaveChanges();
//        }
//        public List<BookingCart> GetCartItems()
//        {
//            return fitnessDB.BookingCarts.Where(
//                bookingCart => bookingCart.CartId == FitnessCartId).ToList();
//        }
//        public int GetCount()
//        {
//            // Get the count of each item in the cart and sum them up
//            int? count = (from cartItems in fitnessDB.BookingCarts
//                          where cartItems.CartId == FitnessCartId
//                          select (int?)cartItems.Count).Sum();
//            // Return 0 if all entries are null
//            return count ?? 0;
//        }

//        public int CreateOrder(BookingOrder bookingOrder)
//        {

//            var cartItems = GetCartItems();
//            // Iterate over the items in the cart, 
//            // adding the order details for each
//            foreach (var item in cartItems)
//            {
//                var bookingDetail = new BookingDetail
//                {
//                    ScheduleID = item.ScheduleID,
//                    BookingOrderID = bookingOrder.BookingOrderID,
//                    Quantity = item.Count
//                };

//                fitnessDB.BookingDetails.Add(bookingDetail);

//            }
//            // Set the order's total to the orderTotal count
//            bookingOrder.Total = bookingOrderTotal;

//            // Save the order
//            fitnessDB.SaveChanges();
//            // Empty the shopping cart
//            EmptyCart();
//            // Return the OrderId as the confirmation number
//            return bookingOrder.BookingOrderID;
//        }
//        // We're using HttpContextBase to allow access to cookies.
//        public string GetCartId(HttpContextBase context)
//        {
//            if (context.Session[CartSessionKey] == null)
//            {
//                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
//                {
//                    context.Session[CartSessionKey] =
//                        context.User.Identity.Name;
//                }
//                else
//                {
//                    // Generate a new random GUID using System.Guid class
//                    Guid tempCartId = Guid.NewGuid();
//                    // Send tempCartId back to client as a cookie
//                    context.Session[CartSessionKey] = tempCartId.ToString();
//                }
//            }
//            return context.Session[CartSessionKey].ToString();
//        }
//        // When a user has logged in, migrate their shopping cart to
//        // be associated with their username
//        public void MigrateCart(string userName)
//        {
//            var bookingCart = fitnessDB.BookingCarts.Where(
//                c => c.CartId == FitnessCartId);

//            foreach (BookingCart item in fitnessCart)
//            {
//                item.CartId = userName;
//            }
//            fitnessDB.SaveChanges();
//        }
//    }
//}