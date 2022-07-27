using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCaseDTOs.CreateOrder;
using NorthWind.UseCasePorts.CreateOrder;
using NorthWind.UseCases.CreateOrder;

namespace NorthWind.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutputPort;
        //readonly IPresenter<string> Presenter;


        public OrderController(ICreateOrderInputPort InputPort, ICreateOrderOutputPort OutputPort)
        {
            this.InputPort = InputPort;
            this.OutputPort = OutputPort;
        }

        [HttpPost("create-order")]
        public async Task<string> CreateOrder(
            CreateOrderParams orderparams)
        {
            //CreateOrderPresenter Presenter = new CreateOrderPresenter();
            //await mediator.Send(new CreateOrderInputPort(orderparams, Presenter));
            //return Presenter.Content;
            await InputPort.Handle(orderparams);
            var Presenter = OutputPort as CreateOrderPresenter;
            return Presenter.Content;
            
        }
    }
}