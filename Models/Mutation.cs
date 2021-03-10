using System;
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
        public async Task<Author> CreateAuthorAsync([Service] ISampleService sampleService, [Service] ITopicEventSender eventSender, string firstName, string lastName)
        {
            var lastAuthorId = sampleService.GetLastAuthorId();

            var authorCreationResult = Author.CreateAuthor(lastAuthorId, firstName, lastName);
            if (authorCreationResult.IsFailure)
                throw new Exception(authorCreationResult.Error);

            var createdAuthor = sampleService.CreateAuthor(authorCreationResult.Value);

            var allAuthors = sampleService.GetAllAuthors();

            await eventSender.SendAsync("AuthorCreated", allAuthors);

            return createdAuthor;
        }
    }
}
