/*using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAvitoEntity;

public class Tests
{
    private WebDriver driver;
    private WebDriverWait wait;
    const string Url = "https://www.avito.ru/";
    private string ValuePriceFrom = "500000";
    private string ValuePriceTo = "1000000";
    private static int priceVolue;
    private static string linkText, nameText, priseText, specificParamsText, geoText, cleanText, itemIdText, link;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void Test1()
    {
        driver.Navigate().GoToUrl(Url);
        driver.Manage().Window.Maximize();
        var category = driver.FindElement(By.XPath("//*[@id='category']/option[3]"));
        category.Click();
        var priceFrom = driver.FindElement(By.XPath("//input[@data-marker='price/from']"));
        priceFrom.SendKeys(ValuePriceFrom);
        var priceTo = driver.FindElement(By.XPath("//input[@data-marker='price/to']"));
        priceTo.SendKeys(ValuePriceTo);
        var models = driver.FindElement(By.XPath("//input[@data-marker='params[110000]/suggest-input']"));
        models.Click();
        var model = driver.FindElement(By.XPath("//li[@data-marker='params[110000]/suggest-dropdown(5)']"));
        model.Click();
        var searchButton = driver.FindElement(By.XPath("//button[@data-marker='search-filters/submit-button']"));
        searchButton.Click();
        ReadOnlyCollection<IWebElement> searchReults = wait.Until(e => e.FindElements(By.XPath("//div[@data-marker='item']")));
        //ReadOnlyCollection<IWebElement> link = wait.Until(e => e.FindElements(By.XPath("//a[@itemprop='url']")));
        //Линков по 2 на 1 объявление
        ReadOnlyCollection<IWebElement> link = wait.Until(e => e.FindElements(By.XPath("//a[@class='iva-item-sliderLink-uLz1v'][@itemprop='url']")));
        ReadOnlyCollection<IWebElement> itemId = wait.Until(e => e.FindElements(By.XPath("//div[@data-item-id]")));
        ReadOnlyCollection<IWebElement> price = wait.Until(e => e.FindElements(By.XPath("//meta[@itemprop='price']")));
        ReadOnlyCollection<IWebElement> name = wait.Until(e => e.FindElements(By.XPath("//h3[@itemprop='name']")));
        ReadOnlyCollection<IWebElement> specificParams = wait.Until(e => e.FindElements(By.XPath("//div[@data-marker='item-specific-params']")));
        ReadOnlyCollection<IWebElement> geo = wait.Until(e => e.FindElements(By.XPath("//div[@class='geo-georeferences-SEtee text-text-LurtD text-size-s-BxGpL']/span")));
        var count = searchReults.Count;
        
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
            AddCarsToDataBase.AddCars(nameText, priceVolue, specificParamsText, geoText, itemIdText, linkText);
        }
    }
}*/