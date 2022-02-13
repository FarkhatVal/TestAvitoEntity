using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestAvitoEntity;

public class FieldValuesOfCarsInAvito
{
    static int priceVolue = 0;
    private static string linkText, nameText, priseText, specificParamsText, geoText, cleanText, itemIdText;
    
    //private static string pathToScreen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"AddCarsToDataBase\screen\");
    private static string path = Directory.GetCurrentDirectory();
    private static string pathToScreen = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString();
    
    public static void CheckAvtoWithDatabase(int count, ReadOnlyCollection<IWebElement> itemId, ReadOnlyCollection<IWebElement> price,
            ReadOnlyCollection<IWebElement> name, ReadOnlyCollection<IWebElement> specificParams,
            ReadOnlyCollection<IWebElement> geo, ReadOnlyCollection<IWebElement> link, ReadOnlyCollection<IWebElement> photo)
    {
        for (int i = 0; i < count; i++)
        {
            linkText = link[i].GetAttribute("href");
            itemIdText = itemId[i].GetAttribute("Id");
            nameText = name[i].Text;
            priseText = price[i].GetAttribute("content");
            specificParamsText = specificParams[i].Text;
            geoText = geo[i].Text;
            cleanText = Regex.Replace(priseText, "[^0-9]", "");
            priceVolue = int.Parse(cleanText);
            using (ContextDb contextDb = new ContextDb())
            {
                List<string> avtoGeo = contextDb.Cars.Where(c => c.itemId == itemIdText).Select(c => c.Geo).ToList();
                string geoOfDb = avtoGeo[0];
                Assert.True(geoOfDb == geoText, $"Для {itemIdText} Гео не совпадает. Ожидалось: {geoText}, получили: {avtoGeo} ");
            }
        }
    }
    
    public static void
        AddFieldValuesToDbCars(int count, ReadOnlyCollection<IWebElement> itemId, ReadOnlyCollection<IWebElement> price,
            ReadOnlyCollection<IWebElement> name, ReadOnlyCollection<IWebElement> specificParams,
            ReadOnlyCollection<IWebElement> geo, ReadOnlyCollection<IWebElement> link, ReadOnlyCollection<IWebElement> photo)
    {
        for (int i = 0; i < count; i++)
        {
            linkText = link[i].GetAttribute("href");
            itemIdText = itemId[i].GetAttribute("Id");
            nameText = name[i].Text;
            priseText = price[i].GetAttribute("content");
            specificParamsText = specificParams[i].Text;
            geoText = geo[i].Text;
            cleanText = Regex.Replace(priseText, "[^0-9]", "");
            priceVolue = int.Parse(cleanText);
            Screenshot screenshotPhoto = ((ITakesScreenshot)photo[i]).GetScreenshot(); 
            screenshotPhoto.SaveAsFile(pathToScreen + $"/AddToDataBase/screenToDB/screenshotPhoto+{i}.png",
                ScreenshotImageFormat.Png);
            string PathToScreenForDb = pathToScreen + $"/AddToDataBase/screenToDB/screenshotPhoto+{i}.png";
            AddCarsToDataBase.AddCars(nameText, priceVolue, specificParamsText, geoText, itemIdText, linkText, PathToScreenForDb);
        }
    }
}