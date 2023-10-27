using elosztott_gyak.Model;

namespace elosztott_gyak.Persistence
{
    public class CarDb
    {
        private static CarDb instance;

        private List<Car> cars;

        private CarDb()
        {
            cars = new List<Car>();
        }

        public static CarDb GetInstance()
        {
            if (instance is null)
            {
                instance = new CarDb();
            }

            return instance;
        }

        public List<Car> GetCars()
        {
            return cars;
        }

        public Car? GetCar(string licensePlate)
        {
            foreach (var car in cars)
            {
                if (car.LicensePlate == licensePlate)
                    return car;
            }

            return null;
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }
    }
}