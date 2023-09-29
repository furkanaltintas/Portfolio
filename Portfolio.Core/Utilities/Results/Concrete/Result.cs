using Portfolio.Core.Utilities.Results.Abstract;

namespace Portfolio.Core.Utilities.Results.Concrete;

public class Result : IResult
{
    public Result(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; }

    public string Message { get; } = null!;
}
