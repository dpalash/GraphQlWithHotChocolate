using System.Collections.Generic;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Repositories;
using GraphQlWithHotChocolate.Interfaces.Services;

namespace GraphQlWithHotChocolate.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Author CreateAuthor(Author author)
        {
            return _sampleRepository.CreateAuthor(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _sampleRepository.GetAllAuthors();
        }

        public Author GetAuthorById(int id)
        {
            return _sampleRepository.GetAuthorById(id);
        }

        public BlogPost CreateBlogPost(BlogPost blogPost)
        {
            return _sampleRepository.CreatePost(blogPost);
        }

        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return _sampleRepository.GetPostsByAuthor(id);
        }
    }
}
