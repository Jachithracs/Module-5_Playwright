using Microsoft.Playwright;
using System.Text.Json;

namespace JsonPlaceholder
{
    public class JsonplaceholderTests
    {
        IAPIRequestContext requestContext;

        [SetUp]
        public async Task SetUp()
        {
            var playwright = await Playwright.CreateAsync();
            requestContext = await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL = "https://jsonplaceholder.typicode.com/",
                    IgnoreHTTPSErrors = true,

                });
        }
        [Test]
        public async Task GetAllUsers()
        {
            var getResponse = await requestContext.GetAsync(url: "/posts");
            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("Code :" + getResponse.Status);
            await Console.Out.WriteLineAsync("Text :" + getResponse.StatusText);

            JsonElement responseBody = (JsonElement)await getResponse.JsonAsync();
            await Console.Out.WriteLineAsync("ResponseBody :" + responseBody);


            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        [TestCase(2)]
        public async Task GetSingleUser(int uid)
        {

            var getResponse = await requestContext.GetAsync(url: "posts/"+uid);
            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("Code :" + getResponse.Status);
            await Console.Out.WriteLineAsync("Text :" + getResponse.StatusText);


            JsonElement responseBody = (JsonElement)await getResponse.JsonAsync();
            await Console.Out.WriteLineAsync("ResponseBody :" + responseBody);


            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        public async Task PostSingleUser()
        {
            var postdata = new
            {
                userId = 1,
                title = "qui est esse",
                body = "est rerum"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postdata);
            var getResponse = await requestContext.PostAsync(url: "posts", new APIRequestContextOptions
            {
                Data = jsonData
            });

            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("Code :" + getResponse.Status);
            await Console.Out.WriteLineAsync("Text :" + getResponse.StatusText);
            

            Assert.That(getResponse.Status, Is.EqualTo(201));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        [TestCase(2)]
        public async Task PutSingleUser(int uid)
        {
            var postdata = new
            {
                userId = 1,
                title = "qui est esse",
                body = "est rerum"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postdata);
            var getResponse = await requestContext.PutAsync(url: "posts/"+uid, new APIRequestContextOptions
            {
                Data = jsonData
            });

            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("Code :" + getResponse.Status);
            await Console.Out.WriteLineAsync("Text :" + getResponse.StatusText);
           

            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        [TestCase(2)]
        public async Task DeleteSingleUser(int uid)
        {

            var getResponse = await requestContext.DeleteAsync(url: "posts/"+uid);

            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("Code :" + getResponse.Status);
            await Console.Out.WriteLineAsync("Text :" + getResponse.StatusText);
            

            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
    }
}
