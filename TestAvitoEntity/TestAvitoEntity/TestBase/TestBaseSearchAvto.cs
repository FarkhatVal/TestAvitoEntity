using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAvitoEntity.models;

public class TestBaseSearchAvto : TestBase
{
    public static (int count, ReadOnlyCollection<IWebElement> price, ReadOnlyCollection<IWebElement> name, ReadOnlyCollection<IWebElement> specificParams, ReadOnlyCollection<IWebElement> geo, ReadOnlyCollection<IWebElement> itemId, ReadOnlyCollection<IWebElement> link, ReadOnlyCollection<IWebElement> photo) SearchAvtoXPath(WebDriver driver, string Url, string ValuePriceFrom, string ValuePriceTo, WebDriverWait wait)
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
        //var searchReults = driver.FindElement(By.XPath("//div[@class='items-items-kAJAg']"));
        ReadOnlyCollection<IWebElement> searchReults = wait.Until(e => e.FindElements(By.XPath("//div[@data-marker='item']")));
        //ReadOnlyCollection<IWebElement> link = wait.Until(e => e.FindElements(By.XPath("//a[@itemprop='url']")));
        //Линков по 2 на 1 объявление
        ReadOnlyCollection<IWebElement> link = wait.Until(e => e.FindElements(By.XPath("//a[@class='iva-item-sliderLink-uLz1v'][@itemprop='url']")));
        ReadOnlyCollection<IWebElement> itemId = wait.Until(e => e.FindElements(By.XPath("//div[@data-item-id]")));
        ReadOnlyCollection<IWebElement> price = wait.Until(e => e.FindElements(By.XPath("//meta[@itemprop='price']")));
        ReadOnlyCollection<IWebElement> name = wait.Until(e => e.FindElements(By.XPath("//h3[@itemprop='name']")));
        ReadOnlyCollection<IWebElement> specificParams = wait.Until(e => e.FindElements(By.XPath("//div[@data-marker='item-specific-params']")));
        ReadOnlyCollection<IWebElement> geo = wait.Until(e => e.FindElements(By.XPath("//div[@class='geo-georeferences-SEtee text-text-LurtD text-size-s-BxGpL']/span")));
        ReadOnlyCollection<IWebElement> photo = wait.Until(e => e.FindElements(By.XPath("//div[@class='photo-slider-root-Exoie photo-slider-redesign-q6DEc']")));
        var count = searchReults.Count;
        
        return (count, name, price, specificParams, geo, itemId, link, photo);
        }
}