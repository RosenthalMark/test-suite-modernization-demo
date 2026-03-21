using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
 
namespace TherapyNotes.Selenium.Tests.Pages;
 
public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
 
    private IWebElement PracticeCodeField =>
        _driver.FindElement(By.CssSelector("input[name='practice_code'], input[id*='practice'], input[placeholder*='practice' i]"));
 
    private IWebElement ContinueButton =>
        _driver.FindElement(By.XPath("//button[contains(translate(text(),'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ'),'CONTINUE') or contains(translate(text(),'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ'),'NEXT')]"));
 
    private IWebElement UsernameField =>
        _driver.FindElement(By.CssSelector("input[name='username'], input[id*='username'], input[type='text']"));
 
    private IWebElement PasswordField =>
        _driver.FindElement(By.CssSelector("input[name='password'], input[id*='password'], input[type='password']"));
 
    private IWebElement LoginButton =>
        _driver.FindElement(By.XPath("//button[contains(translate(text(),'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ'),'LOG IN') or contains(translate(text(),'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ'),'SIGN IN')]"));
 
    private IWebElement LoginLink =>
        _driver.FindElement(By.XPath("//a[contains(translate(text(),'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ'),'LOG IN')]"));
 
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
 
    public void Navigate()
    {
        _driver.Navigate().GoToUrl("https://www.therapynotes.com");
    }
 
    public void ClickLoginLink()
    {
        _wait.Until(d => LoginLink.Displayed);
        LoginLink.Click();
    }
 
    public void Login(string practiceCode, string username, string password)
    {
        _wait.Until(d => PracticeCodeField.Displayed);
        PracticeCodeField.Clear();
        PracticeCodeField.SendKeys(practiceCode);
        ContinueButton.Click();
 
        _wait.Until(d => UsernameField.Displayed);
        UsernameField.Clear();
        UsernameField.SendKeys(username);
        PasswordField.SendKeys(password);
        LoginButton.Click();
    }
}
