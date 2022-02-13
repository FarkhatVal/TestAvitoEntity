using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAvitoEntity.models;

public class AvitoExtractingCars
{
    private WebDriver driver;
    private WebDriverWait wait;
    const string Url = "https://www.avito.ru/";
    private string ValuePriceFrom = "500000";
    private string ValuePriceTo = "1000000";
    private static List<int> PriceVolueList;
    int count, priceVolue;
    ReadOnlyCollection<IWebElement> link, price, name, specificParams, geo, itemId, photo;
    string nameText, specificParamsText, geoText, linkText;
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        (count, name, price, specificParams, geo, itemId, link, photo) = TestBaseSearchAvto.SearchAvtoXPath(driver, Url, ValuePriceFrom, ValuePriceTo, wait);
        FieldValuesOfCarsInAvito.AddFieldValuesToDbCars(count, itemId, price, name, specificParams, geo, link, photo);
    }

    [SetUp]
    public void Setup()
    {
    (count, name, price, specificParams, geo, itemId, link, photo) = TestBaseSearchAvto.SearchAvtoXPath(driver, Url, ValuePriceFrom, ValuePriceTo, wait);  
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void Test0()
    {
        FieldValuesOfCarsInAvito.CheckAvtoWithDatabase(count, itemId, price, name, specificParams, geo, link, photo);
    }
}