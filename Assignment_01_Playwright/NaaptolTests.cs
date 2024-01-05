using Microsoft.Playwright.NUnit;

namespace Assignment_01_Playwright
{
    [TestFixture]
    public class NaaptolTests : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("https://www.naaptol.com/");
            Console.WriteLine("Page Loaded");
        }

        [Test]
        public async Task Test1()
        {
            await Page.Locator("#header_search_text").FillAsync("eyewear");
            await Console.Out.WriteLineAsync("Typed");
        }
    }
}