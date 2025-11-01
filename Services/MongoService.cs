using MongoDB.Driver;
using MovieEventBooking.Models;

namespace MovieEventBooking.Services
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Booking> Bookings => _database.GetCollection<Booking>("Bookings");
        public IMongoCollection<Movie> Movies => _database.GetCollection<Movie>("Movies");

        public MongoService(IConfiguration config)
        {
            var connectionString = config["MongoDbSettings:ConnectionString"];
            var dbName = config["MongoDbSettings:DatabaseName"];
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(dbName);
        }
    }
}
