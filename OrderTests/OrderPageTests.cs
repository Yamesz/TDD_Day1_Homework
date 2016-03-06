using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Order.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestCategory("實作")]
        [TestMethod()]
        public void 訂單_每頁3筆_每頁的Cost總和_應該是6_15_24_21()
        {
            //Arrange
            IOrder order = Substitute.For<IOrder>();
            order.OrderDataGet().Returns(TestDateCreate());
            
            var item = OrderItem.Cost.ToString();
            var rows = 3;
            var expected = new List<int>(){6,15,24,21};

            OrderPage target = new OrderPage(order);

            //Act
            var actual = target.OrderPageItemSumGet(item,rows);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCategory("實作")]
        [TestMethod()]
        public void 訂單_每頁4筆_每頁的Revenue總和_應該是50_66_60()
        {
            //Arrange
            IOrder order = Substitute.For<IOrder>();
            order.OrderDataGet().Returns(TestDateCreate());

            var item = OrderItem.Revenue.ToString();
            var rows = 4;
            var expected = new List<int>(){50,66,60};

            OrderPage target = new OrderPage(order);

            //Act
            var actual = target.OrderPageItemSumGet(item,rows);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        private static List<Order> TestDateCreate()
        {
            return new List<Order>(){
                new Order { ID = 1,Cost =1,Revenue =11,SellPrice=21 },
                new Order { ID = 2,Cost =2,Revenue =12,SellPrice=22 },
                new Order { ID = 3,Cost =3,Revenue =13,SellPrice=23 },
                new Order { ID = 4,Cost =4,Revenue =14,SellPrice=24 },
                new Order { ID = 5,Cost =5,Revenue =15,SellPrice=25 },
                new Order { ID = 6,Cost =6,Revenue =16,SellPrice=26 },
                new Order { ID = 7,Cost =7,Revenue =17,SellPrice=27 },
                new Order { ID = 8,Cost =8,Revenue =18,SellPrice=28 },
                new Order { ID = 9,Cost =9,Revenue =19,SellPrice=29 },
                new Order { ID = 10,Cost=10,Revenue=20,SellPrice=30 },
                new Order { ID = 11,Cost=11,Revenue=21,SellPrice=31 }
            };
        }
    }
}
