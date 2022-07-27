﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.Common.Ports
{
    public interface IInputPort<InteractorRequestType, InteractorResponseType> :
        IRequest
    {
        public InteractorRequestType ResquestData { get; }
        public IOutputPort<InteractorResponseType> OutputPort { get; }

    }
}