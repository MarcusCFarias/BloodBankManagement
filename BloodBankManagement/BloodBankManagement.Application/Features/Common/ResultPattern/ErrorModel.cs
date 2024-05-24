using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Common.Result
{
    public enum ErrorEnum
    {
        None = 0,
        NotFound = 1,
        BadRequest = 2,
        InternalServerError = 3
    }
    public class ErrorModel
    {
        public ErrorEnum Code { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public ErrorModel(ErrorEnum code, string title, string message)
        {
            Code = code;
            Title = title;
            Message = message;
        }

        public override string ToString()
        {
            return $"{Code}: {Title} - {Message}";
        }
    }
}
