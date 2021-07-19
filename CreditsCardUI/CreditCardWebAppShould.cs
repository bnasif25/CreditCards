using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace CreditsCardUI
{
	public class CreditCardWebAppShould
	{
		private const string HomeURL = "http://localhost:44108/";
		private const string AboutURL = "http://localhost:44108/Home/About";
		private const string HomeTitle = "Home Page - Credit Cards";		

		[Fact]
		[Trait("Category", "Smoke")]

		public void LoadApplicationPage()
		{
			using (IWebDriver driver = new ChromeDriver())
			{
				

				driver.Navigate().GoToUrl(HomeURL);

				DemoHelper.Pause();


				Assert.Equal(HomeTitle, driver.Title);
				Assert.Equal(HomeURL, driver.Url);
			}
		}

		[Fact]
		[Trait("Category","Smoke")]
		public void ReloadHomePage()
		{
			using(IWebDriver driver = new ChromeDriver()) 
			{

				driver.Navigate().GoToUrl(HomeURL);

				DemoHelper.Pause();

				driver.Navigate().Refresh();

				Assert.Equal(HomeTitle, driver.Title);
				Assert.Equal(HomeURL, driver.Url);
			}

		}

		[Fact]
		[Trait("Category", "Smoke")]

		public void ReloadHomePageOnBack()
		{
			using(IWebDriver driver = new ChromeDriver())
			{
				driver.Navigate().GoToUrl(HomeURL);
				IWebElement generationTokenElement = driver.FindElement(By.Id("GenerationToken"));

				string initialToken = generationTokenElement.Text; // string to store captured data
				DemoHelper.Pause();

				driver.Navigate().GoToUrl(AboutURL);
				DemoHelper.Pause();

				driver.Navigate().Back();
				DemoHelper.Pause();

				Assert.Equal(HomeTitle, driver.Title);
				Assert.Equal(HomeURL, driver.Url);

				string reloadedToken = driver.FindElement(By.Id("GenerationToken")).Text;
				Assert.NotEqual(initialToken, reloadedToken);
			}
		}

		[Fact]
		[Trait("Category", "Smoke")]

		public void ReloadHomePageOnForward()
		{
			using (IWebDriver driver = new ChromeDriver())
			{
			
				driver.Navigate().GoToUrl(AboutURL);
				DemoHelper.Pause();

				driver.Navigate().GoToUrl(HomeURL);
				DemoHelper.Pause();

				driver.Navigate().Back();
				DemoHelper.Pause();

				driver.Navigate().Forward();
				DemoHelper.Pause();

				Assert.Equal(HomeTitle, driver.Title);
				Assert.Equal(HomeURL, driver.Url);
			}
		}
		
	}
}
