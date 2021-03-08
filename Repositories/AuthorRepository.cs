using System.Collections.Generic;
using System.Linq;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Repositories;

namespace GraphQlWithHotChocolate.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly List<Author> _authors = new List<Author>();
        private readonly List<BlogPost> _posts = new List<BlogPost>();

        public AuthorRepository()
        {
            Author author1 = new Author
            {
                Id = 1,
                FirstName = "PALASH",
                LastName = "DEBNATH"
            };

            Author author2 = new Author
            {
                Id = 2,
                FirstName = "PRITAM",
                LastName = "DEBNATH"
            };

            BlogPost csharp = new BlogPost
            {
                Id = 1,
                Title = "Mastering C#",
                Content = "This is a series of articles on C#.",
                Author = author1
            };

            BlogPost java = new BlogPost
            {
                Id = 2,
                Title = "Mastering Mechanical Engineering",
                Content = "This is a series of articles on Mechanical Engineering",
                Author = author2
            };

            _posts.Add(csharp);
            _posts.Add(java);
            _authors.Add(author1);
            _authors.Add(author2);
        }

        public Author CreateAuthor(Author author)
        {
            var lastAuthor = _authors.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastAuthor != null)
            {
                author.Id = lastAuthor.Id + 1;
                _authors.Add(author);
            }

            return author;
        }

        public List<Author> GetAllAuthors()
        {
            return _authors;
        }

        public Author GetAuthorById(int id)
        {
            return _authors.FirstOrDefault(author => author.Id == id);
        }

        public BlogPost CreatePost(BlogPost blogPost)
        {
            var lastBlogPost = _authors.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastBlogPost != null)
            {
                blogPost.Id = lastBlogPost.Id + 1;
                _posts.Add(blogPost);
            }

            return blogPost;
        }

        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return _posts.Where(post => post.Author.Id == id).ToList();
        }
    }
}
