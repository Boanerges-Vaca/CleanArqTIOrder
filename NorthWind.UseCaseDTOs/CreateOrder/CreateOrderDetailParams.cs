using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCaseDTOs.CreateOrder
{
    public class CreateOrderDetailParams
    {
        public int ProductoId { get; set; }
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }
    }
}
