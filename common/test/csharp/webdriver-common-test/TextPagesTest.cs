using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQa.Selenium.Environment;

namespace OpenQa.Selenium
{
    [TestFixture]
    public class TextPagesTest : DriverTestFixture
    {
        private string textPage = EnvironmentManager.Instance.UrlBuilder.WhereIs("plain.txt");

        [Test]
        [IgnoreBrowser(Browser.IE)]
        [IgnoreBrowser(Browser.Chrome)]
        [IgnoreBrowser(Browser.Firefox)]
        public void ShouldBeAbleToLoadASimplePageOfText()
        {
            driver.Url = textPage;

            String source = driver.PageSource;
            Assert.AreEqual("Test", source);
        }

        [Test]
        [IgnoreBrowser(Browser.Chrome)]
        [ExpectedException(typeof(NoSuchElementException))]
        public void FindingAnElementOnAPlainTextPageWillNeverWork()
        {
            driver.Url = textPage;
            driver.FindElement(By.Id("foo"));
        }

        [Test]
        [IgnoreBrowser(Browser.IE)]
        [IgnoreBrowser(Browser.Chrome)]
        [ExpectedException(typeof(WebDriverException))]
        public void ShouldThrowExceptionWhenAddingCookieToAPageThatIsNotHtml()
        {
            driver.Url = textPage;

            Cookie cookie = new Cookie("hello", "goodbye");
            driver.Manage().AddCookie(cookie);
        }
    }
}
