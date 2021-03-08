using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Services;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace GraphQlWithHotChocolate.Models
{
    public class Query
    {
        public async Task<List<Author>> GetAllAuthors([Service] IAuthorService authorService, [Service] ITopicEventSender eventSender)
        {
            var authors = authorService.GetAllAuthors();

            await eventSender.SendAsync("ReturnedAuthor", authors);

            return authors;
        }

        public Author GetAuthorById([Service] IAuthorService authorService, int id) => authorService.GetAuthorById(id);

        public List<BlogPost> GetPostsByAuthor([Service] IAuthorService authorService, int id) => authorService.GetPostsByAuthor(id);
    }
}
