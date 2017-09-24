using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReceipt
{
    public class Receipt
    {
        private List<ReceiptItem> _Items;

        public Receipt()
        {
            this._Items = new List<ReceiptItem>();
        }

        public void AddItem(int itemCount, string itemName, double itemPrice)
        {
            this._Items.Add(new ReceiptItem(itemCount, itemName, itemPrice));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool _isFirst = true;
            double subTotal = 0;
            double tax = 0;
            double total = 0;
            if(this._Items != null && this._Items.Count > 0)
            {
                foreach(var item in this._Items)
                {
                    if(!_isFirst)
                    {
                        sb.Append("\r\n");
                    }
                    else
                    {
                        _isFirst = false;
                    }
                    subTotal = subTotal + item.TotalPrice;
                    sb.Append(item.ItemCount.ToString() + " " + item.ItemName + " @ " + item.ItemPrice.ToString("C", new CultureInfo("en-AU")) + " = " + item.TotalPrice.ToString("C", new CultureInfo("en-AU")));
                }

                tax = subTotal * 10 / 100;
                total = subTotal + tax;

                sb.Append("\r\nSub Total = " + subTotal.ToString("C", new CultureInfo("en-AU")));
                sb.Append("\r\nTax (10%) = " + tax.ToString("C", new CultureInfo("en-AU")));
                sb.Append("\r\nTotal = " + total.ToString("C", new CultureInfo("en-AU")));
            }
            return sb.ToString();
        }
    }
}
