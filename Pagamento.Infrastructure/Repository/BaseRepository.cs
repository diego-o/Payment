using MongoDB.Driver;
using Payment.Infrastructure.DatabaseSettings;

namespace Payment.Infrastructure.Repository
{
    public class BaseRepository<TModel> where TModel : class
    {
        protected readonly IMongoCollection<TModel> Model;

        public BaseRepository(IPagamentoDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.Model = database.GetCollection<TModel>(typeof(TModel).Name);
        }
    }
}
