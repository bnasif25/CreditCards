using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace CreditsCardUI
{
	public class CreditCardWebAppShould
	{
		private const string HomeURL = "http://localhost:44108/";
		private const string AboutURL = "http://localhost:44108/Home/About";
		private const string HomeTitle = "Home Page - Credit Cards";		

		[Fact]
		[Trait("Category", "Smoke")]

		public void LoadHomePage()
		{
			using (IWebDriver driver = new ChromeDriver())
			{
				
				driver.Navigate().GoToUrl(HomeURL);

				driver.Manage().Window.Maximize();
				DemoHelper.Pause();

				driver.Manage().Window.Minimize();
				DemoHelper.Pause();

				driver.Manage().Window.Size = new System.Drawing.Size(300, 400);
				DemoHelper.Pause();

				driver.Manage().Window.Size = new System.Drawing.Point(1, 1);
				DemoHelper.Pause();

				driver.Manage().Window.Size = new System.Drawing.Point(50, 50);
				DemoHelper.Pause();

				driver.Manage().Window.Size = new System.Drawing.Point(100, 100);
				DemoHelper.Pause();

				driver.Manage().Window.FullScreen();

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

		[Fact]

		public void DisplayProductAndRates()
		{
			using (IWebDriver driver = new ChromeDriver())
			{
				driver.Navigate().GoToUrl(HomeURL);
				DemoHelper.Pause();

				ReadOnlyCollection<IWebElement> tableCells = driver.FindElements(By.TagName("td"));

				Assert.Equal("Easy Credit Card", tableCells[0].Text);
				Assert.Equal("20% APR", tableCells[1].Text);

				Assert.Equal("Silver Credit Card", tableCells[2].Text);
				Assert.Equal("18% APR", tableCells[3].Text);
			}
		}
		
	}
}
