using MediatR;
using NorthWind.UseCaseDTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort: CrateOrderParams, IRequest<int>
    {

    }
}
