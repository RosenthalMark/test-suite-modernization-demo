using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
 
namespace TherapyNotes.Selenium.Tests.Pages;
 
public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
 
    private IWebElement WelcomeHeader =>
        _driver.FindElement(By.XPath("//h1[contains(text(),'Welcome')] | //h2[contains(text(),'Welcome')]"));
 
    private IWebElement DashboardContainer =>
        _driver.FindElement(By.CssSelector("[class*='dashboard'], [id*='dashboard'], main"));
 
    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
 
    public void AssertWelcomeMessage(string? expectedName = null)
    {
        _wait.Until(d => !d.Url.Contains("login"));
        _wait.Until(d => WelcomeHeader.Displayed);
 
        if (expectedName != null)
        {
            Assert.Contains(expectedName, WelcomeHeader.Text);
        }
        else
        {
            Assert.Contains("Welcome", WelcomeHeader.Text);
        }
    }
 
    public void AssertDashboardLoaded()
    {
        _wait.Until(d => DashboardContainer.Displayed);
        Assert.True(DashboardContainer.Displayed);
    }
}
