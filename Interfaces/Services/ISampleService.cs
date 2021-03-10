using System.Collections.Generic;
using GraphQlWithHotChocolate.DTOs;

namespace GraphQlWithHotChocolate.Interfaces.Services
{
    public interface ISampleService
    {
        Author CreateAuthor(Author author);
        int GetLastAuthorId();
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        BlogPost CreateBlogPost(BlogPost blogPost);
        int GetLastPostId();
        List<BlogPost> GetPostsByAuthor(int id);
    }
}