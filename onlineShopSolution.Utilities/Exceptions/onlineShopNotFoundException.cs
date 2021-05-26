using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Utilities
{
    /// <summary>
    /// Exception người dùng tự định nghĩa
    /// </summary>
    public class onlineShopNotFoundException : Exception
    {
        public onlineShopNotFoundException()
        {
        }

        public onlineShopNotFoundException(string message)
            : base(message)
        {
        }

        public onlineShopNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
