using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Collections;

namespace Order
{
    public enum OrderItem : byte
    {
        Cost,
        Revenue,
        SellPrice
    }

    public class Order : IOrder
    {
        public int ID { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }

        /// <summary>
        /// 取得訂單資料
        /// </summary>
        public List<Order> OrderDataGet()
        {
            //跟DB或服務取資料
            List<Order> orderList = new List<Order>();
            return orderList;
        }
    }

    public class OrderPage
    {
        private IOrder _order;
        public List<Order> OrderList { get; private set; }
        public OrderPage(IOrder order)
        {
            this._order = order;
        }
        /// <summary>
        ///  取得每個分頁的指定欄位總和
        /// </summary>
        /// <param name="name">目標欄位</param>
        /// <param name="rows">每頁筆數</param>
        /// <returns></returns>
        public List<int> OrderPageItemSumGet(string name, int rows)
        {
            #region init
            List<int> result = new List<int>();
            var orderList = this._order.OrderDataGet();
            int totalPage = TotalPageCountGet(rows, orderList.Count());
            //int pageSum = 0;
            //IEnumerable pageList;
            #endregion

            for (int Loop = 1; Loop <= totalPage; Loop++)
            {
                //System.Linq.Dynamic
                //pageList = orderList.Skip((Loop - 1) * rows)
                //                    .Take(rows)
                //                    .Select(name);
                //foreach (var item in names)
                //{
                //    pageSum += (int)item;
                //}
                //result.Add(pageSum);

                //反射 Reflection
                result.Add(orderList.Skip((Loop - 1) * rows)
                           .Take(rows)
                           .Select(x => (int)x.GetType().GetProperty(name).GetValue(x)).Sum()
                );
            }

            return result;
        }

        private static int TotalPageCountGet(int rows,int count)
        {
            return (int)Math.Ceiling((double)count / rows);
        }

    }
}
