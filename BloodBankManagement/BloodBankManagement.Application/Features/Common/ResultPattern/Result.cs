using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Common.Result
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public ErrorModel Error { get; }

        protected Result(bool isSuccess, ErrorModel error)
        {
            var checkSucces = !isSuccess && error.Code == ErrorEnum.None;
            var checkFailure = isSuccess && error.Code != ErrorEnum.None;

            var validParamenters = checkFailure || checkSucces;

            if (validParamenters)
                throw new ArgumentException("Invalid error", nameof(error));

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success()
        {
            var errorNone = new ErrorModel(ErrorEnum.None, string.Empty, string.Empty);

            return new Result(true, errorNone);
        }

        public static Result Failure(ErrorModel error)
        {
            return new Result(false, error);
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; }

        protected Result(bool isSuccess, ErrorModel error, T data) : base(isSuccess, error)
        {
            Data = data;
        }

        public static Result<T> Success(T data)
        {
            var errorNone = new ErrorModel(ErrorEnum.None, string.Empty, string.Empty);

            return new Result<T>(true, errorNone, data);
        }

        public new static Result<T> Failure(ErrorModel error)
        {
            return new Result<T>(false, error, default);
        }
    }
}
