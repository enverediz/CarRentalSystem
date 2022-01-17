// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

Console.WriteLine("Hello, World!");

CarManager carManager = new CarManager(new EfCarDal());

var result = carManager.GetCarDetails();

foreach (var car in result.Data)
{
    if (result.Success)
    {
        Console.WriteLine(car.BrandName +" " + car.ModelName +" " + car.CarBodyTypeName + " " + car.FuelTypeName);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
    
}

