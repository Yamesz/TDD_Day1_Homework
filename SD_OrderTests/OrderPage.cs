using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SD_OrderTests
{
    class OrderPage
    {
        private IOrder order;

        public OrderPage(IOrder order)
        {
            // TODO: Complete member initialization
            this.order = order;
        }
        internal List<int> OrderPageItemSumGet(string item, int rows)
        {
            throw new NotImplementedException();
        }
    }
}
