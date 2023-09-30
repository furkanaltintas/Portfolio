using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete;
using Portfolio.Core.Utilities.Results.Concrete.Error;

namespace Portfolio.Core.Utilities.Business
{
    public class BusinessRules
    {
        // İş Kurallarını Çalıştır

        public static Result Run(params IResult[] logics)
        {
            var resultError = ResultError(logics);
            return (resultError.Item1 ? new ErrorResult(resultError.Item2) : null)!;
        }

        public static DataResult<T> Run<T>(params IResult[] logics)
        {
            var resultError = ResultError(logics);
            return (resultError.Item1 ? new ErrorDataResult<T>(resultError.Item2) : null)!;
        }

        private static (bool, string) ResultError(params IResult[] logics)
        {
            var errorResults = logics.Where(x => !x.IsSuccess).ToList(); // IsSuccess değeri false olanları getirdi
            var hasError = errorResults.Any(); // errorResult değeri var mı kontrol edildi var ise hasError true oldu
            var messages = string.Join("\n", errorResults.Select(x => x.Message)); // Join ile birleştirme yapılarak aralara \n ifadesi konuldu
            return (hasError, messages);
        }
    }
}