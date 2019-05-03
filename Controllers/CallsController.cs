using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;



namespace netcoresb
{
    public class CallsController : Controller
    {
        [Route("")]
        [Route("[controller]/Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[controller]/createsandbox")]
        //Create Sandbox
        public async Task<IActionResult> createSandbox()
        {
            var client = new HttpClient();
            //replace sandbox_id value
            string sandbox_id = "REPLACE_SANDBOX_ID";
            Dictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "sandbox_id", sandbox_id }
                };
            StringContent content = new StringContent(JsonConvert.SerializeObject(dict), Encoding.UTF8, "text/json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
            client.DefaultRequestHeaders.Add("provider", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("provider_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("provider_username", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("username", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("user_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("application_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("sandbox_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("x-ibm-client-id", "b04f0b25-9ccb-4518-a323-54ebc744b7e2");
            HttpResponseMessage response = await client.PostAsync("https://apis.nbg.gr/public/sandbox/obp.account.sandbox/v1.1/sandbox", content);
            var responseText = await response.Content.ReadAsStringAsync();
            client.DefaultRequestHeaders.Accept.Clear();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/json");
            var obj = JsonConvert.DeserializeObject(responseText);
            return Ok(obj);


        }

        [HttpGet("[controller]/myAccounts")]
        public async Task<IActionResult> myAccounts()
        {
            //Get a list of banks supported for current application ID.
            var client = new HttpClient();
            //replace sandbox_id with the id of an existing sandbox

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
            client.DefaultRequestHeaders.Add("provider", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("provider_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("provider_username", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("username", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("user_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("application_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("sandbox_id", "REPLACE_SANDBOX_ID");
            client.DefaultRequestHeaders.Add("x-ibm-client-id", "b04f0b25-9ccb-4518-a323-54ebc744b7e2");
            HttpResponseMessage response = await client.GetAsync("https://apis.nbg.gr/public/sandbox/obp.account.sandbox/v1.1/obp/my/accounts");

            string responseText = await response.Content.ReadAsStringAsync();
            dynamic obj = JsonConvert.DeserializeObject(responseText);
            return Ok(obj);

        }

        [HttpGet("[controller]/deleteSandbox")]
        //Delete Sandbox
        public async Task<IActionResult> deleteSandbox()
        {
            //replace sandbox_id value with the id of an existing sandbox
            string sandbox_id = "REPLACE_SANDBOX_ID";
            var client = new HttpClient();
            Uri uri = new Uri("https://apis.nbg.gr/public/sandbox/obp.account.sandbox/v1.1/sandbox/" + sandbox_id);
            client.DefaultRequestHeaders.Add("request_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("provider", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("provider_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("provider_username", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("username", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("user_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("application_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("sandbox_id", "REPLACE_THIS_VALUE");
            client.DefaultRequestHeaders.Add("x-ibm-client-id", "b04f0b25-9ccb-4518-a323-54ebc744b7e2");
            HttpResponseMessage response = await client.DeleteAsync(uri);
            string responseText = await response.Content.ReadAsStringAsync();
            return Ok(responseText);
        }
    }
}
