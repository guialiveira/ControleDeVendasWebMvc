using System;

namespace ControleDeVendasWebMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(String message) : base(message)
        {

        }
    }
}
