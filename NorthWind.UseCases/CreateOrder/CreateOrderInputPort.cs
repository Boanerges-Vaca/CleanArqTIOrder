using MediatR;
using NorthWind.UseCaseDTOs.CreateOrder;
using NorthWind.UseCases.Common.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrderParams, int>
    {
        public CreateOrderParams ResquestData { get; }

        public IOutputPort<int> OutputPort { get; }

        public CreateOrderInputPort(CreateOrderParams requestData,
            IOutputPort<int> outputPort) =>
            (ResquestData, OutputPort) = (requestData, outputPort);
    }
}
