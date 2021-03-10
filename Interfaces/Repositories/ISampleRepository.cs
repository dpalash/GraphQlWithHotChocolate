using System.Collections.Generic;
using GraphQlWithHotChocolate.DTOs;

namespace GraphQlWithHotChocolate.Interfaces.Repositories
{
    public interface ISampleRepository
    {
        Author CreateAuthor(Author author);
        int GetLastAuthorId();
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        BlogPost CreatePost(BlogPost blogPost);
        int GetLastPostId();
        List<BlogPost> GetPostsByAuthor(int id);
    }
}