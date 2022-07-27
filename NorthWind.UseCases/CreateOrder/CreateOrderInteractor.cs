using MediatR;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : AsyncRequestHandler<CreateOrderInputPort>
    {
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUnitOfWork unitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }

        protected async override Task Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.ResquestData.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ResquestData.ShipAdress,
                ShipCity = request.ResquestData.ShipCountry,
                ShipCountry = request.ResquestData.ShipCountry,
                ShipPostalCode = request.ResquestData.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            orderRepository.Create(order);
            foreach(var item in request.ResquestData.OrderDetails)
            {
                orderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = order,
                        ProductId = item.ProductoId,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity
                    });                
            }
            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }
            request.OutputPort.Handle(order.Id);
        }
    }
}
