using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SD_OrderTests
{
    [TestClass]
    public class OrderPageTests
    {
        [TestCategory("規格")]
        [TestMethod]
        public void 訂單_每頁3筆_每頁的Cost總和_應該是6_15_24_21()
        {
            //Arrange
            IOrder order = new Order();

            var item = "Cost";
            var rows = 3;
            var expected = new List<int>(){6,15,24,21};

            OrderPage target = new OrderPage(order);

            //Act
            List<int> actual = target.OrderPageItemSumGet(item,rows);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCategory("規格")]
        [TestMethod()]
        public void 訂單_每頁4筆_每頁的Revenue總和_應該是50_66_60()
        {
            //Arrange
            IOrder order = new Order();

            var item = "Revenue";
            var rows = 4;
            var expected = new List<int>(){50,66,60};

            OrderPage target = new OrderPage(order);
            //Act
            List<int> actual = target.OrderPageItemSumGet(item,rows);

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }
    }
}
