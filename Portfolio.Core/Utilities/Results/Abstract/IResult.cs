namespace Portfolio.Core.Utilities.Results.Abstract;

public interface IResult
{
    bool IsSuccess { get; }
    string Message { get; } // Sadece okunabilir olacak
}
