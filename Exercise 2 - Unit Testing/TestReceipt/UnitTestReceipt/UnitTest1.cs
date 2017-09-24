using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestReceipt
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReceiptMethod()
        {
            var receipt = new TestReceipt.Receipt();
            receipt.AddItem(1, "Newspaper", 1.50);
            receipt.AddItem(1, "Milk", 3);
            receipt.AddItem(2, "Bread", 2.50);

            var expected =
                    @"1 Newspaper @ $1.50 = $1.50
1 Milk @ $3.00 = $3.00
2 Bread @ $2.50 = $5.00
Sub Total = $9.50
Tax (10%) = $0.95
Total = $10.45";

            string receiptStr = receipt.ToString();
            Assert.AreEqual(expected, receiptStr, true);
        }
    }
}
