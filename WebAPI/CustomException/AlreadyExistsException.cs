using Microsoft.AspNetCore.Http.Features;
using System.Net;

namespace Tandem_Diabetes_BE_challenge.CustomException
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
