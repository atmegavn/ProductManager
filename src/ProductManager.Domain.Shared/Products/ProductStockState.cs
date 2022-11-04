using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Products
{
    public enum ProductStockState:byte
    {
        PreOrder,
        InStock,
        NotAvailable,
        Stopped
    }
}
