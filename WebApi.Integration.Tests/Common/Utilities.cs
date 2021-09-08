using AppForSkills.Persistance;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApi.Integration.Tests.Common
{
    public class Utilities
    {
        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static async Task<ByteArrayContent> SendObjectAsContent(object obj)
        {
            var myContent = JsonConvert.SerializeObject(obj);

            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
        public static void InitiliazeDbForTests(AppForSkillsDbContext context)
        {
            var discussion = new AppForSkills.Domain.Entities.Discussion()
            {
                Id = 3,
                FirstPost = "Jakie sporty uprawiacie?",
                StatusId = 1
            };
            context.Discussions.Add(discussion);

            var postInDiscussion = new AppForSkills.Domain.Entities.PostInDiscussion()
            {
                Id = 7,
                DiscussionId = 3,
                PostText = "Piłkę nożną",
                StatusId = 1
            };
            context.PostsInDiscussion.Add(postInDiscussion);

            var user = new AppForSkills.Domain.Entities.User()
            {
                Id = 4,
                Username = "user",
                RegistrationDate = new DateTime(1999, 12, 29),
                RecentLoginDate = new DateTime(2000, 1, 1),
                StatusId = 1
            };
            context.Users.Add(user);

            var alice = new AppForSkills.Domain.Entities.User()
            {
                Id = 5,
                Username = "alice",
                RegistrationDate = new DateTime(1999, 12, 29),
                RecentLoginDate = new DateTime(2000, 1, 1),
                StatusId = 1
            };
            context.Users.Add(alice);

            context.SaveChanges();
        }
    }
}
