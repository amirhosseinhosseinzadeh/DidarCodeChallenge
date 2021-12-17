namespace DidarCodeChallenge.Api.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task InsertAsync(TEntity entity);

}