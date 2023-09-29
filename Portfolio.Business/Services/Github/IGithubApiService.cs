namespace Portfolio.Business.Services.Github
{
    public interface IGithubApiService
    {
        Task<short> GetRepoCountAsync(string username);
    }
}