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
        public List<Author> GetAllAuthors([Service] IAuthorService authorService) => authorService.GetAllAuthors();

        public Author GetAuthorById([Service] IAuthorService authorService, int id) => authorService.GetAuthorById(id);

        public List<BlogPost> GetPostsByAuthor([Service] IAuthorService authorService, int id) => authorService.GetPostsByAuthor(id);
    }
}
