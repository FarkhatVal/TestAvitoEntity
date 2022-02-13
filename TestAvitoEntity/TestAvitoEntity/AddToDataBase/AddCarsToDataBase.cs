using Microsoft.EntityFrameworkCore;
using TestAvitoEntity;
using TestAvitoEntity.models;
namespace TestAvitoEntity
{
    public class AddCarsToDataBase
    {
        public static void AddCars(string nameText, int priceVolue, string specificParamsText,
            string geoText, string itemIdText, string linkText, string PathToScreenToDb)
        {
         using (ContextDb contextDb = new ContextDb())
         {
             Car car = new Car()
                 {Name = nameText, Price = priceVolue, SpecificParams = specificParamsText, Geo = geoText, Link = linkText, itemId = itemIdText, photoPath = PathToScreenToDb};
             contextDb.Cars.AddRange(car);
             contextDb.Database.SetCommandTimeout(80000);
             contextDb.SaveChanges();               
         }
        }
    }
}