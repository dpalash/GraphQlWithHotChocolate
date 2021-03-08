using System.Threading.Tasks;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Services;
using HotChocolate;
using HotChocolate.Subscriptions;

// ReSharper disable ClassNeverInstantiated.Global

namespace GraphQlWithHotChocolate.Models
{
    public class Mutation
    {
        // ReSharper disable once UnusedMember.Global
        public async Task<Author> CreateAuthor([Service] IAuthorService authorService, [Service] ITopicEventSender eventSender, string firstName, string lastName)
        {
            Author author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            var createdAuthor = authorService.CreateAuthor(author);

            var allAuthors = authorService.GetAllAuthors();

            await eventSender.SendAsync("AuthorCreated", allAuthors);

            return createdAuthor;
        }
    }
}
