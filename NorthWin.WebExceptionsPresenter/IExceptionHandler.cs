using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWin.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {

        /// <summary>
        /// Atrapa las Exceptions y las formatea
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task Handler(ExceptionContext context);


    }
}
