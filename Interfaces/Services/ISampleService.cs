using System.Collections.Generic;
using GraphQlWithHotChocolate.DTOs;

namespace GraphQlWithHotChocolate.Interfaces.Services
{
    public interface ISampleService
    {
        Author CreateAuthor(Author author);
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        BlogPost CreateBlogPost(BlogPost blogPost);
        List<BlogPost> GetPostsByAuthor(int id);
    }
}