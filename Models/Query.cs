using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Services;
using HotChocolate;

namespace GraphQlWithHotChocolate.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class Query
    {
        public List<Author> GetAllAuthors([Service] ISampleService sampleService) => sampleService.GetAllAuthors();

        public Author GetAuthorById([Service] ISampleService sampleService, int id) => sampleService.GetAuthorById(id);

        public List<BlogPost> GetPostsByAuthor([Service] ISampleService sampleService, int id) => sampleService.GetPostsByAuthor(id);
    }
}
