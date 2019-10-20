using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace APIAutomationTestSuite.Steps
{
    [Binding]
    public sealed class RestApiSteps
    {
        [Given(@"I have an endpint (.*)")]
        public void GivenIHaveAnEndpintEndpoint(string endpoint)
        {
            RestAPIHelper.SetUrl(endpoint);
        }

      
        [When(@"I call get method of api")]
        public void WhenICallGetMethodOfApi()
        {
            RestAPIHelper.CreateRequest();
        }

        [Then(@"I get API response with list of users")]
        public void ThenIGetAPIResponseInJsonFormat()
        {
            var apiResponse = RestAPIHelper.GetResponse();
            dynamic responseContent  = JsonConvert.DeserializeObject<dynamic>(apiResponse.Content);
            Assert.That(apiResponse.StatusCode == HttpStatusCode.OK  && responseContent.Count != 0);           
        }

        [When(@"I call get user infromation using (.*)")]
        public void WhenICallGetUserInfromationUsingUser(string userId)
        {
            RestAPIHelper.CreateRequest(userId);
        }

        [When(@"I call get user infromation using (.*)")]
        public void WhenICallGetUserInfromationUsingUser(string userId, string password)
        {
            RestAPIHelper.CreateRequestWithBody(userId, password);
        }

        
        [Then(@"I will get user information with email, password and token")]
        public void ThenIWillGetUserInformationWithEmailAndPassword()
        {
            var response = RestAPIHelper.GetResponse();
            var content = response.Content;
            Assert.That(content.Contains("token"));
        }

        [When(@"I call post user infromation using details")]
        public void WhenICallPostUserInfromationUsingDetails(Table table)
           
        {
            var email = table.Rows[0]["email"];
            var pass = table.Rows[0]["password"];
            RestAPIHelper.CreateRequestWithBody(email, pass);
        }

        [Then(@"I will get error")]
        public void ThenIWillGetWithError()
        {
            var response = RestAPIHelper.GetResponse();
            Assert.That(response.Content.Contains("error")
                && response.Content.Contains("Missing password") 
                && (response.StatusCode == HttpStatusCode.BadRequest));
        }
    }
}
