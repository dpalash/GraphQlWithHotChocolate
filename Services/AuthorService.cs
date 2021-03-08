using System.Collections.Generic;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Repositories;
using GraphQlWithHotChocolate.Interfaces.Services;

namespace GraphQlWithHotChocolate.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author CreateAuthor(Author author)
        {
            return _authorRepository.CreateAuthor(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }

        public BlogPost CreateBlogPost(BlogPost blogPost)
        {
            return _authorRepository.CreatePost(blogPost);
        }

        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return _authorRepository.GetPostsByAuthor(id);
        }
    }
}
