using elosztott_gyak.Model;
using MongoDB.Driver;

namespace elosztott_gyak.Persistence
{
    public class CarDb
    {
        private const string ConnectionString = "mongodb://root:rootpassword@localhost:27017";
        private const string DbName = "db1";
        private const string DbCollection = "cars";

        private static CarDb instance;

        private IMongoDatabase database;

        private CarDb()
        {
            Connect(ConnectionString, DbName);
        }

        private void Connect(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(dbName);
        }

        public static CarDb GetInstance()
        {
            if (instance is null)
            {
                instance = new CarDb();
            }

            return instance;
        }

        public async Task<List<Car>> GetCars()
        {
            if (database == null) return null;

            IMongoCollection<Car> carsCollection = database.GetCollection<Car>(DbCollection);

            return (await carsCollection.FindAsync(Builders<Car>.Filter.Empty)).ToList();
        }

        public async Task<Car> GetCar(string licensePlate)
        {
            if (database == null) return null;

            IMongoCollection<Car> carsCollection = database.GetCollection<Car>(DbCollection);

            return (await carsCollection.FindAsync(car => car.LicensePlate.Equals(licensePlate))).ToList()
                .FirstOrDefault();
        }

        public async Task<Car> AddCar(Car car)
        {
            if (car == null) return null;

            IMongoCollection<Car> carsCollection = database.GetCollection<Car>(DbCollection);
            if (carsCollection == null) return null;

            await carsCollection.InsertOneAsync(car);
            return car;
        }
    }
}