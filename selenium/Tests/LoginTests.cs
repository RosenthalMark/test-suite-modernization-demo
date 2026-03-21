using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TherapyNotes.Selenium.Tests.Pages;
using Xunit;
 
namespace TherapyNotes.Selenium.Tests;
 
public class LoginTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;
    private readonly HomePage _homePage;
 
    public LoginTests()
    {
        var options = new ChromeOptions();
        _driver = new ChromeDriver(options);
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _loginPage = new LoginPage(_driver);
        _homePage = new HomePage(_driver);
    }
 
    [Fact]
    public void LoginToTherapyNotes()
    {
        _loginPage.Navigate();
        _loginPage.ClickLoginLink();
        _loginPage.Login(
            practiceCode: "QaInterviewPractoce",
            username: "QaInterviewPractoce",
            password: "HorshamPA19044!!"
        );
        _homePage.AssertWelcomeMessage("Test User");
    }
 
    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
