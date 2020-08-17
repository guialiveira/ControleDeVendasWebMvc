using System;

namespace ControleDeVendasWebMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(String message) : base(message)
        {

        }


    }
}
