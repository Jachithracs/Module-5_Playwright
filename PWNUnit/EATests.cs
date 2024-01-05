using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWNUnit
{
    [TestFixture]
    internal class EATests : PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("Opened Browser");
<<<<<<< HEAD
            await Page.GotoAsync("http://eaapp.somee.com/", new PageGotoOptions
            {
                Timeout = 7000,
                WaitUntil = WaitUntilState.DOMContentLoaded
=======
            await Page.GotoAsync("http://eaapp.somee.com/",new PageGotoOptions
            {
                Timeout = 3000, WaitUntil = WaitUntilState.DOMContentLoaded
>>>>>>> 1b5b2ea6aaf484ff348a1e5d14283cc0ad0767da
            });
            Console.WriteLine("Page Loaded");
        }
        [Test]
        public async Task LoginTest()
        {


            // await Page.GetByText("Login").ClickAsync();//await-since it is asynchronous operation.
            //var lnkLogin= Page.Locator(selector: "text=Login");
            //await lnkLogin.ClickAsync();//if we want to do more than one action on an element 

<<<<<<< HEAD
            await Page.ClickAsync(selector: "text=Login", new PageClickOptions
            { Timeout = 1000 });
=======
            await Page.ClickAsync(selector: "text=Login",new PageClickOptions
            { Timeout = 1000});
>>>>>>> 1b5b2ea6aaf484ff348a1e5d14283cc0ad0767da
            await Console.Out.WriteLineAsync("Login Link Clicked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");

            //way 1
            //await Page.GetByLabel("UserName").FillAsync(value:"admin");
            //await Page.GetByLabel("Password").FillAsync(value:"password");
            //await Console.Out.WriteLineAsync("Typed");

            //way2
            //await Page.Locator("#UserName").FillAsync(value: "admin");
            //await Page.Locator("#Password").FillAsync(value: "password");
            //await Console.Out.WriteLineAsync("Typed");

            //way3
            await Page.FillAsync(selector: "#UserName", "admin");
            await Page.FillAsync(selector: "#Password", "password");
            await Console.Out.WriteLineAsync("Typed");

            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input",
               new PageLocatorOptions { HasTextString = "Log in" });//here locating th element so no need of await
            await btnLogin.ClickAsync();
            await Console.Out.WriteLineAsync("Login button clicked");
            // await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");


            await Expect(
                Page.Locator(selector: "text='Hello admin!'") )
                //Page.Locator(selector: "text='Log off'"
                //))
                .ToBeVisibleAsync();
        }


    }
}
