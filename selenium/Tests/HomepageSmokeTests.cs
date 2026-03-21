using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TherapyNotes.Selenium.Tests;

public class HomepageSmokeTests : IDisposable
{
    private readonly IWebDriver _driver;

    public HomepageSmokeTests()
    {
        var options = new ChromeOptions();
        _driver = new ChromeDriver(options);
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Navigate().GoToUrl("https://www.therapynotes.com");
    }

    [Fact]
    public void Homepage_HasCorrectTitle()
    {
        Assert.Contains("TherapyNotes", _driver.Title);
    }

    [Fact]
    public void Homepage_MainNavigationIsVisible()
    {
        var nav = _driver.FindElement(By.Id("MainMenu__Header"));
        Assert.True(nav.Displayed);
    }

    [Fact]
    public void Homepage_LogoIsPresent()
    {
        var logo = _driver.FindElement(By.Id("MainMenu__Logo"));
        Assert.True(logo.Displayed);
    }

    [Fact]
    public void Homepage_LogoLinksToHomepage()
    {
        var logoLink = _driver.FindElement(By.Id("MainMenu__LogoLink"));
        Assert.Equal("/", new Uri(logoLink.GetAttribute("href")).AbsolutePath);
    }

    [Fact]
    public void Homepage_FeaturesNavLinkIsVisible()
    {
        var link = _driver.FindElement(By.Id("MainMenu__FeaturesLink"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void Homepage_PricingNavLinkIsVisible()
    {
        var link = _driver.FindElement(By.Id("MainMenu__PricingLink"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void Homepage_BlogNavLinkIsVisible()
    {
        var link = _driver.FindElement(By.Id("MainMenu__BlogLink"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void Homepage_AboutNavLinkIsVisible()
    {
        var link = _driver.FindElement(By.Id("MainMenu__AboutLink"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void Homepage_ContactNavLinkIsVisible()
    {
        var link = _driver.FindElement(By.Id("MainMenu__ContactLink"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void Homepage_LogInButtonIsPresentInNav()
    {
        var link = _driver.FindElement(By.CssSelector("a[href='/app/login/']"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void Homepage_TryFreeButtonIsPresentInNav()
    {
        var link = _driver.FindElement(By.CssSelector("a[href='/about/signup/']"));
        Assert.True(link.Displayed);
    }

    [Fact]
    public void Homepage_HeroSectionIsVisible()
    {
        var hero = _driver.FindElement(By.Id("HomePage__HeroSection"));
        Assert.True(hero.Displayed);
    }

    [Fact]
    public void Homepage_HeroHeadingIsPresent()
    {
        var heading = _driver.FindElement(By.Id("hero-section-heading"));
        Assert.True(heading.Displayed);
    }

    [Fact]
    public void Homepage_HeroHeadingContainsExpectedText()
    {
        var heading = _driver.FindElement(By.Id("hero-section-heading"));
        Assert.Contains("Trusted EHR", heading.Text);
    }

    [Fact]
    public void Homepage_PracticeManagementSectionIsPresent()
    {
        var section = _driver.FindElement(By.Id("HomePage__ClinicalSegments1"));
        Assert.True(section.Displayed);
    }

    [Fact]
    public void Homepage_SupportSectionIsPresent()
    {
        var section = _driver.FindElement(By.Id("HomePage__SupportSection"));
        Assert.True(section.Displayed);
    }

    [Fact]
    public void Homepage_TherapyFuelSectionIsPresent()
    {
        var section = _driver.FindElement(By.Id("HomePage__TherapyFuelSection"));
        Assert.True(section.Displayed);
    }

    [Fact]
    public void Homepage_MobileAppSectionIsPresent()
    {
        var section = _driver.FindElement(By.Id("HomePage__MobileAppSection"));
        Assert.True(section.Displayed);
    }

    [Fact]
    public void Homepage_FooterIsPresent()
    {
        var footer = _driver.FindElement(By.CssSelector(".SiteFooter"));
        Assert.True(footer.Displayed);
    }

    [Fact]
    public void Homepage_FooterPhoneNumberIsPresent()
    {
        var phone = _driver.FindElement(By.CssSelector("a[href='tel:+12156584550']"));
        Assert.True(phone.Displayed);
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
