using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReceipt
{
    public class ReceiptItem
    {
        public ReceiptItem(int itemCount, string itemName, double itemPrice)
        {
            this.ItemCount = itemCount;
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
        }

        public int ItemCount { get; set; }

        public string ItemName { get; set; }

        public double ItemPrice { get; set; }

        public double TotalPrice
        {
            get
            {
                return ItemCount * ItemPrice;
            }
        }
    }
}
