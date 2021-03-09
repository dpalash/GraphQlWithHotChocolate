using System.Collections.Generic;
using GraphQlWithHotChocolate.DTOs;

namespace GraphQlWithHotChocolate.Interfaces.Repositories
{
    public interface ISampleRepository
    {
        Author CreateAuthor(Author author);
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        BlogPost CreatePost(BlogPost blogPost);
        List<BlogPost> GetPostsByAuthor(int id);
    }
}