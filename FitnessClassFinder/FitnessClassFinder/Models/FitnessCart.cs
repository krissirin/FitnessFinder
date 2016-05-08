//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.ComponentModel.DataAnnotations;

//namespace FitnessClassFinder.Models
//{
//    public partial class FitnessCart : IDisposable
//    {
//        public string FitnessCartId { get; set; }
//        private FitnessDBContext fitnessDB = new FitnessDBContext();
//        public const string CartSessionKey = "BookingCartId";

//        public void AddToCart(int id)
//        {
//            // Retrieve the schedule from the database.            
//            FitnessCartId = GetCartId();

//            var bookingCart = fitnessDB.BookingCarts.SingleOrDefault(
//                c => c.BookingCartId == FitnessCartId
//                && c.FitnessClassID == id);
//            if (bookingCart == null)
//            {
//                // Create a new cart item if no cart item exists.                  
//                bookingCart = new BookingCart
//                {
//                    BookingId = Guid.NewGuid().ToString(),
//                    FitnessClassID = id,
//                    BookingCartId = FitnessCartId,
//                    Schedules = fitnessDB.Schedules.SingleOrDefault(
//                    p => p.FitnessClassID == id),
//                    Count = 1,
//                    DateCreated = DateTime.Now
//                };

//                fitnessDB.BookingCarts.Add(bookingCart);
//            }
//            else
//            {
//                // If the item does exist in the cart,                   
//                // then add one to the quantity.                  
//                bookingCart.Count++;
//            }
//            fitnessDB.SaveChanges();
//        }

//        public void Dispose()
//        {
//            if (fitnessDB != null)
//            {
//                fitnessDB.Dispose();
//                fitnessDB = null;
//            }
//        }
//        public string GetCartId()
//        {
//            if (HttpContext.Current.Session[CartSessionKey] == null)
//            {
//                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
//                {
//                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
//                }
//                else
//                {
//                    // Generate a new random GUID using System.Guid class.      
//                    Guid tempCartId = Guid.NewGuid();
//                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
//                }
//            }
//            return HttpContext.Current.Session[CartSessionKey].ToString();
//        }

//        public List<BookingCart> GetCartItems()
//        {
//            FitnessCartId = GetCartId();

//            return fitnessDB.BookingCarts.Where(
//                c => c.BookingCartId == FitnessCartId).ToList();
//        }

//        public decimal GetTotal()
//        {
//            FitnessCartId = GetCartId();
//            // Multiply product price by quantity of that product to get         
//            // the current price for each of those products in the cart.   
//            // Sum all product price totals to get the cart total.
//            decimal? total = decimal.Zero;
//            total = (decimal?)(from bookingCart in fitnessDB.BookingCarts
//                          where bookingCart.BookingCartId == FitnessCartId
//                          select (int?)bookingCart.Count).Sum();
//            // Return 0 if all entries are null
//            return total ?? decimal.Zero;
//        }

//        public FitnessCart GetCart(HttpContext context)
//        {
//            using (var cart = new FitnessCart())
//            {
//                cart.FitnessCartId = cart.GetCartId();
//                return cart;
//            }
//        }

//        public void UpdateShoppingCartDatabase(String bookingCartId, FitnessCartUpdates[] CartItemUpdates)
//        {
//            using (var fitnessDB = new FitnessClassFinder.Models.FitnessDBContext())
//            {
//                try
//                {
//                    int CartItemCount = CartItemUpdates.Count();
//                    List<BookingCart> myCart = GetCartItems();
//                    foreach (var bookingCart in myCart)
//                    {
//                        // Iterate through all rows within shopping cart list 
//                        for (int i = 0; i < CartItemCount; i++)
//                        {
//                            if (bookingCart.Schedules.FitnessClassID == CartItemUpdates[i].ProductId)
//                            {
//                                if (CartItemUpdates[i].BookingQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
//                                {
//                                    RemoveItem(bookingCartId, bookingCart.FitnessClassID);
//                                }
//                                else
//                                {
//                                    UpdateItem(bookingCartId, bookingCart.FitnessClassID, CartItemUpdates[i].BookingQuantity);
//                                }
//                            }
//                        }
//                    }
//                }
//                catch (Exception exp)
//                {
//                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
//                }
//            }
//        }

//        public void RemoveItem(string removeCartID, int removeProductID)
//        {
//            using (var fitnessDB = new FitnessDBContext())
//            {
//                try
//                {
//                    var myItem = (from c in fitnessDB.BookingCarts where c.BookingCartId == removeCartID && c.Schedules.FitnessClassID == removeProductID select c).FirstOrDefault();
//                    if (myItem != null)
//                    {
//                        // Remove Item. 
//                        fitnessDB.BookingCarts.Remove(myItem);
//                        fitnessDB.SaveChanges();
//                    }
//                }
//                catch (Exception exp)
//                {
//                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
//                }
//            }
//        }

//        public void UpdateItem(string updateCartID, int updateProductID, int count)
//        {
//            using (var fitnessDB = new FitnessDBContext())
//            {
//                try
//                {
//                    var myItem = (from c in fitnessDB.BookingCarts where c.BookingCartId == updateCartID && c.Schedules.FitnessClassID == updateProductID select c).FirstOrDefault();
//                    if (myItem != null)
//                    {
//                        myItem.Count = count;
//                        fitnessDB.SaveChanges();
//                    }
//                }
//                catch (Exception exp)
//                {
//                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
//                }
//            }
//        }

//        public void EmptyCart()
//        {
//            FitnessCartId = GetCartId();
//            var cartItems = fitnessDB.BookingCarts.Where(
//                c => c.BookingCartId == FitnessCartId);
//            foreach (var cartItem in cartItems)
//            {
//            fitnessDB.BookingCarts.Remove(cartItem);
//            }
//            // Save changes.              
//            fitnessDB.SaveChanges();
//        }

//        public int GetCount()
//        {
//            FitnessCartId = GetCartId();

//            // Get the count of each item in the cart and sum them up           
//            int? count = (from cartItems in fitnessDB.BookingCarts
//                          where cartItems.BookingCartId == FitnessCartId
//                          select (int?)cartItems.Count).Sum();
//            // Return 0 if all entries are null          
//            return count ?? 0;
//        }

//        public struct FitnessCartUpdates
//        {
//            public int ProductId;
//            public int BookingQuantity;
//            public bool RemoveItem;
//        }

//        public void MigrateCart(string bookingCartId, string userName)
//        {
//            var fitnessCart = fitnessDB.BookingCarts.Where(
//                c => c.BookingCartId == bookingCartId );

//            foreach (BookingCart item in fitnessCart)
//            {
//                item.BookingCartId = userName;
//            }
//            HttpContext.Current.Session[CartSessionKey] = userName;
//            fitnessDB.SaveChanges();
//        }
//    }
//}

//////#######################################################################
////public static FitnessCart GetCart(HttpContextBase context)
////        {
////            var bookingcart = new FitnessCart();
////            bookingcart.FitnessCartId = bookingcart.GetCartId(context);
////            return bookingcart;
////        }
////        // Helper method to simplify fitness cart calls
////        public static FitnessCart GetCart(Controller controller)
////        {
////            return GetCart(controller.HttpContext);
////        }
////        public void AddToCart(ClassSchedule schedule)
////        {
////            // Get the matching booking cart and schedule instances
////            var cartItem = fitnessDB.BookingCarts.SingleOrDefault(
////                c => c.BookingCartId == FitnessCartId
////                && c.FitnessClassID == schedule.FitnessClassID);

////            if (cartItem == null)
////            {
////                // Create a new cart item if no cart item exists
////                cartItem = new BookingCart
////                {
////                    FitnessClassID = schedule.FitnessClassID,
////                    BookingCartId = FitnessCartId,
////                    Count = 1,
////                    DateCreated = DateTime.Now
////                };
////                fitnessDB.BookingCarts.Add(cartItem);
////            }
////            else
////            {
////                // If the item does exist in the cart, 
////                // then add one to the quantity
////                cartItem.Count++;
////            }
////            // Save changes
////            fitnessDB.SaveChanges();
////        }
////        public int RemoveFromCart(int id)
////        {
////            // Get the cart
////            var cartItem = fitnessDB.BookingCarts.Single(
////                bookingCart => bookingCart.BookingCartId == FitnessCartId
////                && bookingCart.BookingId == id);

////            int itemCount = 0;

////            if (cartItem != null)
////            {
////                if (cartItem.Count > 1)
////                {
////                    cartItem.Count--;
////                    itemCount = cartItem.Count;
////                }
////                else
////                {
////                    fitnessDB.BookingCarts.Remove(cartItem);
////                }
////                // Save changes
////                fitnessDB.SaveChanges();
////            }
////            return itemCount;
////        }
////        public void EmptyCart()
////        {
////            var cartItems = fitnessDB.BookingCarts.Where(
////                bookingCart => bookingCart.BookingCartId == FitnessCartId);

////            foreach (var cartItem in cartItems)
////            {
////                fitnessDB.BookingCarts.Remove(cartItem);
////            }
////            // Save changes
////            fitnessDB.SaveChanges();
////        }
////        public List<BookingCart> GetCartItems()
////        {
////            return fitnessDB.BookingCarts.Where(
////                bookingCart => bookingCart.BookingCartId == FitnessCartId).ToList();
////        }
////        //public int GetCount()
////        //{
////        //    // Get the count of each item in the cart and sum them up
////        //    int? count = (from cartItems in fitnessDB.BookingCarts
////        //                  where cartItems.BookingCartId == FitnessCartId
////        //                  select (int?)cartItems.Count).Sum();
////        //    // Return 0 if all entries are null
////        //    return count ?? 0;
////        }
////        public decimal GetTotal()
////        {
////            // Multiply album price by count of that album to get 
////            // the current price for each of those albums in the cart
////            // sum all album price totals to get the cart total
////            decimal? total = (from cartItems in fitnessDB.BookingCarts
////                              where cartItems.BookingCartId == FitnessCartId
////                              select (int?)cartItems.Count *
////                              cartItems.Schedules.Fee).Sum();

////            return total ?? decimal.Zero;
////        }

////        public int CreateOrder(BookingOrder bookingOrder)
////        {
////            decimal orderTotal = 0;

////            var cartItems = GetCartItems();
////            // Iterate over the items in the cart, 
////            // adding the order details for each
////            foreach (var item in cartItems)
////            {
////                var bookingDetail = new BookingDetail
////                {
////                    FitnessClassID = item.FitnessClassID,
////                    BookingOrderId = bookingOrder.BookingOrderId,
////                    UnitPrice = item.Schedules.Fee,
////                    Quantity = item.Count
////                };
////                // Set the order total of the fitness cart
////                orderTotal += (item.Count * item.Schedules.Fee);

////                fitnessDB.BookingDetails.Add(bookingDetail);

////            }
////            // Set the order's total to the orderTotal count
////            bookingOrder.Total = orderTotal;

////            // Save the order
////            fitnessDB.SaveChanges();
////            // Empty the shopping cart
////            EmptyCart();
////            // Return the OrderId as the confirmation number
////            return bookingOrder.BookingOrderId;
////        }
////        // We're using HttpContextBase to allow access to cookies.
////        public string GetCartId(HttpContextBase context)
////        {
////            if (context.Session[CartSessionKey] == null)
////            {
////                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
////                {
////                    context.Session[CartSessionKey] =
////                        context.User.Identity.Name;
////                }
////                else
////                {
////                    // Generate a new random GUID using System.Guid class
////                    Guid tempCartId = Guid.NewGuid();
////                    // Send tempCartId back to client as a cookie
////                    context.Session[CartSessionKey] = tempCartId.ToString();
////                }
////            }
////            return context.Session[CartSessionKey].ToString();
////        }
////        // When a user has logged in, migrate their shopping cart to
////        // be associated with their Email
////        public void MigrateCart(string email)
////        {
////            var fitnessCart = fitnessDB.BookingCarts.Where(
////                c => c.BookingCartId == FitnessCartId);

////            foreach (BookingCart item in fitnessCart)
////            {
////                item.BookingCartId = email;
////            }
////            fitnessDB.SaveChanges();
////        }
////    }
////}