using System;
using System.Linq;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.Entities;
using Carable.AssemblyPayments.Entities.Requests;
using Carable.AssemblyPayments.Tests;
using Carable.AssemblyPayments.ValueTypes;
using Newtonsoft.Json;
using Xunit;

namespace Carable.AssemblyPayments.Tests
{
    public class CallbackTest : AbstractTest
    {
        [Fact]
        public void CreateCallbackSuccessfully()
        {
            var content = Files.ReadAllText("./Fixtures/callback_create.json");

            var client = GetMockClient(content);
            var repo = Get<ICallbackRepository>(client.Object);

            var request = new CallbackRequest
            {
                ObjectType = ObjectType.Users,
                Description = "Users Callback",
                Enabled = true,
                Url = "https://httpbin.org/post"
            };

            var response = repo.CreateCallbackAsync(request).Result;
            Assert.NotNull(response);
            Assert.Equal(request.ObjectType, response.ObjectType);
            Assert.Equal(request.Description, response.Description);
            Assert.Equal(request.Enabled, response.Enabled);
            Assert.Equal(request.Url, response.Url);
        }

        [Fact]
        public void CallbackRequestRendersJsonAs()
        {
            var request = new CallbackRequest
            {
                ObjectType = ObjectType.Users,
                Description = "Users Callback",
                Enabled = true,
                Url = "https://httpbin.org/post"
            };

            var response = JsonConvert.SerializeObject(request);
            Assert.Equal(@"{""description"":""Users Callback"",""url"":""https://httpbin.org/post"",""object_type"":""users"",""enabled"":true}",response);
        }

        [Fact]
        public void UpdateCallbackSuccessfully()
        {
            var content = Files.ReadAllText("./Fixtures/callback_edit.json");

            var client = GetMockClient(content);
            var repo = Get<ICallbackRepository>(client.Object);

            const string callbackId = "f92d4ca1-4ee5-43f3-9e34-ca5f759c5e76";
            var callback = new Callback
            {
                Id = callbackId,
                ObjectType = ObjectType.Accounts,
                Description = "Account Callback",
                Enabled = true,
                Url = "https://httpbin.org/put",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddDays(-1),
                Links = new CallbackLinks
                {
                    Self = "",
                    Responses = ""
                }
            };

            var request = new CallbackRequest
            {
                ObjectType = ObjectType.Users,
                Description = "Users Callback",
                Enabled = true,
                Url = ""
            };

            var updatedCallback = repo.UpdateCallbackAsync(callbackId, request).Result;
            Assert.NotNull(updatedCallback);
            Assert.Equal(callback.Id, updatedCallback.Id);
            Assert.Equal(updatedCallback.ObjectType, ObjectType.Users);
            Assert.Equal(updatedCallback.Description, "Users Callback");
            Assert.Equal(updatedCallback.Enabled, true);
            Assert.Equal(updatedCallback.Url, "https://httpbin.org/put");

        }

        [Fact]
        public void DeleteCallbackSuccessfully()
        {
            var content = "{'callbacks': 'Successfully redacted'}";

            var client = GetMockClient(content);
            var repo = Get<ICallbackRepository>(client.Object);

            const string callbackId = "f92d4ca1-4ee5-43f3-9e34-ca5f759c5e76";
            var response = repo.DeleteCallbackAsync(callbackId).Result;

            Assert.NotNull(response);
            Assert.Equal(response, true);
        }

        [Fact]
        public void GetCallbackSuccessfully()
        {
            var content = Files.ReadAllText("./Fixtures/callback_get_by_id.json");
            var client = GetMockClient(content);
            var repo = Get<ICallbackRepository>(client.Object);

            const string callbackId = "f92d4ca1-4ee5-43f3-9e34-ca5f759c5e76";
            var response = repo.GetCallbackAsync(callbackId).Result;

            Assert.NotNull(response);
            Assert.Equal(callbackId, response.Id);

        }

        [Fact]
        public void GetCallbacksSuccessfull()
        {
            var content = Files.ReadAllText("./Fixtures/callback_get.json");
            var client = GetMockClient(content);
            var repo = Get<ICallbackRepository>(client.Object);

            var response = repo.GetCallbacksAsync(new GetCallbacksRequest()).Result;

            Assert.NotNull(response);
            Assert.True(response.Callbacks.Any());
            Assert.Equal(3, response.Callbacks.Count);
            Assert.Equal(response.Callbacks.Count, response.Meta.Total);

        }
    }
}
