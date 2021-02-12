using CoreLibrary.Exceptions;
using CoreLibrary.Interfaces;

namespace CoreLibrary.Services
{
    public class ValidateRequestString: IValidations
    {
        public void Validate(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new InvalidStringException("string is null or empty.");
            }
        }
    }
}
