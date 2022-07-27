using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCaseDTOs.CreateOrder;
using NorthWind.UseCases.CreateOrder;

namespace NorthWind.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create-order")]
        public async Task<string> CreateOrder(
            CreateOrderParams orderparams)
        {
            CreateOrderPresenter Presenter = new CreateOrderPresenter();
            await mediator.Send(new CreateOrderInputPort(orderparams, Presenter));
            return Presenter.Content;
        }
    }
}