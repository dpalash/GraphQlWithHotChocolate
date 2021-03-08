using System.Collections.Generic;
using System.Linq;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Repositories;

namespace GraphQlWithHotChocolate.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private static readonly List<Author> Authors = new List<Author>();
        private static readonly List<BlogPost> Posts = new List<BlogPost>();

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

            if (!Posts.Any())
            {
                Posts.Add(csharp);
                Posts.Add(java);
            }

            if (!Authors.Any())
            {
                Authors.Add(author1);
                Authors.Add(author2);
            }
        }

        public Author CreateAuthor(Author author)
        {
            var lastAuthor = Authors.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastAuthor != null)
            {
                author.Id = lastAuthor.Id + 1;
                Authors.Add(author);
            }

            return author;
        }

        public List<Author> GetAllAuthors()
        {
            return Authors;
        }

        public Author GetAuthorById(int id)
        {
            return Authors.FirstOrDefault(author => author.Id == id);
        }

        public BlogPost CreatePost(BlogPost blogPost)
        {
            var lastBlogPost = Authors.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastBlogPost != null)
            {
                blogPost.Id = lastBlogPost.Id + 1;
                Posts.Add(blogPost);
            }

            return blogPost;
        }

        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return Posts.Where(post => post.Author.Id == id).ToList();
        }
    }
}
