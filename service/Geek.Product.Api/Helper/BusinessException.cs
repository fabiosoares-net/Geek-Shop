using System.Globalization;

namespace Geek.Product.Api.Helper
{
    public class BusinessException : Exception
    {
        public BusinessException() : base() { }

        public BusinessException(string message) : base(message) { }

        public BusinessException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
