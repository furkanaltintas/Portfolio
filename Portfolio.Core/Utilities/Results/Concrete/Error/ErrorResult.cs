namespace Portfolio.Core.Utilities.Results.Concrete.Error;

public class ErrorResult : Result
{
    public ErrorResult(string message) : base(false, message) { }

    public ErrorResult() : base(false) { }
}
