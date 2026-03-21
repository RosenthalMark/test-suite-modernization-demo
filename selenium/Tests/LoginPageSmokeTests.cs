using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TherapyNotes.Selenium.Tests;

public class LoginPageSmokeTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPageSmokeTests()
    {
        var options = new ChromeOptions();
        _driver = new ChromeDriver(options);
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        _driver.Navigate().GoToUrl("https://www.therapynotes.com/app/login/");
    }

    [Fact]
    public void LoginPage_HasCorrectTitle()
    {
        Assert.Contains("Log In", _driver.Title);
    }

    [Fact]
    public void LoginPage_FormContainerIsPresent()
    {
        var container = _driver.FindElement(By.Id("FormContainer"));
        Assert.True(container.Displayed);
    }

    [Fact]
    public void LoginPage_LoginFormIsPresent()
    {
        var form = _driver.FindElement(By.Id("LoginForm"));
        Assert.True(form.Displayed);
    }

    [Fact]
    public void LoginPage_PracticeCodeLabelIsVisible()
    {
        var label = _driver.FindElement(By.CssSelector("label[for='PracticeCode']"));
        Assert.True(label.Displayed);
    }

    [Fact]
    public void LoginPage_PracticeCodeFieldIsPresent()
    {
        var field = _driver.FindElement(By.Id("PracticeCode"));
        Assert.NotNull(field);
    }

    [Fact]
    public void LoginPage_ContinueButtonIsPresent()
    {
        var button = _driver.FindElement(By.Id("Continue__ContinueButton"));
        Assert.True(button.Displayed);
    }

    [Fact]
    public void LoginPage_ContinueButtonTextIsCorrect()
    {
        var button = _driver.FindElement(By.Id("Continue__ContinueButton"));
        Assert.Contains("Continue", button.Text);
    }

    [Fact]
    public void LoginPage_ForgotPracticeCodeLinkIsPresent()
    {
        var link = _driver.FindElement(By.CssSelector("a[href='/help/login/lostpractice/']"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void LoginPage_LogoIsPresent()
    {
        var logo = _driver.FindElement(By.Id("BrandImage"));
        Assert.True(logo.Displayed);
    }

    [Fact]
    public void LoginPage_PracticeCodeFieldAcceptsInput()
    {
        var field = _driver.FindElement(By.Id("PracticeCode"));
        field.SendKeys("QaInterviewPractice");
        Assert.Equal("QaInterviewPractice", field.GetAttribute("value"));
    }

    [Fact]
    public void LoginPage_ValidPracticeCodeRevealsCredentialsForm()
    {
        _driver.FindElement(By.Id("PracticeCode")).SendKeys("QaInterviewPractice");
        _driver.FindElement(By.Id("Continue__ContinueButton")).Click();
        _wait.Until(d => d.FindElement(By.Id("Login__UsernameField")).Displayed);
        Assert.True(_driver.FindElement(By.Id("Login__UsernameField")).Displayed);
    }

    [Fact]
    public void LoginPage_UsernameFieldIsPresentAfterPracticeCode()
    {
        _driver.FindElement(By.Id("PracticeCode")).SendKeys("QaInterviewPractice");
        _driver.FindElement(By.Id("Continue__ContinueButton")).Click();
        _wait.Until(d => d.FindElement(By.Id("Login__UsernameField")).Displayed);
        Assert.True(_driver.FindElement(By.Id("Login__UsernameField")).Displayed);
    }

    [Fact]
    public void LoginPage_PasswordFieldIsPresentAfterPracticeCode()
    {
        _driver.FindElement(By.Id("PracticeCode")).SendKeys("QaInterviewPractice");
        _driver.FindElement(By.Id("Continue__ContinueButton")).Click();
        _wait.Until(d => d.FindElement(By.Id("Login__Password")).Displayed);
        Assert.True(_driver.FindElement(By.Id("Login__Password")).Displayed);
    }

    [Fact]
    public void LoginPage_LogInButtonIsPresentAfterPracticeCode()
    {
        _driver.FindElement(By.Id("PracticeCode")).SendKeys("QaInterviewPractice");
        _driver.FindElement(By.Id("Continue__ContinueButton")).Click();
        _wait.Until(d => d.FindElement(By.Id("Login__LogInButton")).Displayed);
        Assert.True(_driver.FindElement(By.Id("Login__LogInButton")).Displayed);
    }

    [Fact]
    public void LoginPage_ForgotPasswordLinkIsPresentAfterPracticeCode()
    {
        _driver.FindElement(By.Id("PracticeCode")).SendKeys("QaInterviewPractice");
        _driver.FindElement(By.Id("Continue__ContinueButton")).Click();
        _wait.Until(d => d.FindElement(By.CssSelector("a[href='/help/login/lostpassword/']")).Displayed);
        Assert.True(_driver.FindElement(By.CssSelector("a[href='/help/login/lostpassword/']")).Displayed);
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
