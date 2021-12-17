using DidarCodeChallenge.Api.Domains;

namespace DidarCodeChallenge.Api.Services;

public interface IRequestService
{
    Task InsertAsync(Request request);
}
