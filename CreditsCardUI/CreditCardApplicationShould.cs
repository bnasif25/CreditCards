using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace CreditsCardUI
{
	[Trait("Category", "Applications")]
	public class CreditCardApplicationShould
	{
		private const string HomeURL = "http://localhost:44108/";
		private const string ApplyURL = "http://localhost:44108/Apply";

		[Fact]
		public void BeInitiatedFromHomePage_NewLowRate()
		{
			using (IWebDriver driver = new ChromeDriver())
			{
				driver.Navigate().GoToUrl(HomeURL);
				DemoHelper.Pause();

				IWebElement applyLink = driver.FindElement(By.Name("ApplyLowRate"));
				applyLink.Click(); // clicking on a link

				DemoHelper.Pause();

				Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
				Assert.Equal(ApplyURL, driver.Url);
			}
		}
		[Fact]
		public void BeInitiatedFromHomePage_EasyApplication()
		{
			using (IWebDriver driver = new ChromeDriver())
			{
				driver.Navigate().GoToUrl(HomeURL);
				DemoHelper.Pause();

				IWebElement carouselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
				carouselNext.Click();
				DemoHelper.Pause(1000); //giving the carousel time to load

				IWebElement applylink = driver.FindElement(By.LinkText("Easy: Apply Now!"));
				applylink.Click(); // clicking on another link

				DemoHelper.Pause();

				Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
				Assert.Equal(ApplyURL, driver.Url);
			}
		}
		[Fact]
		public void BeInitiatedFromHomePage_CustomerService()
		{
			using(IWebDriver driver = new ChromeDriver())
			{
				driver.Navigate().GoToUrl(HomeURL);
				DemoHelper.Pause();

				IWebElement carouselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
				carouselNext.Click();
				DemoHelper.Pause(1000);
				carouselNext.Click();
				DemoHelper.Pause(1000);

				IWebElement applyLink = driver.FindElement(By.ClassName("customer-service-apply-now"));
				applyLink.Click();

				DemoHelper.Pause();

				Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
				Assert.Equal(ApplyURL, driver.Url);
			}
		}
		[Fact]
		public void BeInitiatedFromHomePage_RandomGreeting()
		{
			using(IWebDriver driver = new ChromeDriver())
			{
				driver.Navigate().GoToUrl(HomeURL);
				DemoHelper.Pause();

				IWebElement randomGreetingApplyLink = driver.FindElement(By.PartialLinkText("- Apply Now!"));
				randomGreetingApplyLink.Click();

				DemoHelper.Pause();

				Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
				Assert.Equal(ApplyURL, driver.Url);
			}
		}
	}
}
