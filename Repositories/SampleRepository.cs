using System.Collections.Generic;
using System.Linq;
using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Repositories;

namespace GraphQlWithHotChocolate.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private static readonly List<Author> Authors = new List<Author>();
        private static readonly List<BlogPost> Posts = new List<BlogPost>();

        public SampleRepository()
        {
            if (!Authors.Any())
            {
                var author1CreateResult = Author.CreateAuthor(0, "PALASH", "DEBNATH");
                if (author1CreateResult.IsSuccess)
                    Authors.Add(author1CreateResult.Value);

                var author2CreateResult = Author.CreateAuthor(1, "PRITAM", "DEBNATH");
                if (author2CreateResult.IsSuccess)
                    Authors.Add(author2CreateResult.Value);

                if (!Posts.Any())
                {
                    var blogPost1CreateResult = BlogPost.CreateBlogPost(
                        1,
                        "Mastering C#",
                        "This is a series of articles on C#.",
                        author1CreateResult.Value);

                    if (blogPost1CreateResult.IsSuccess)
                        Posts.Add(blogPost1CreateResult.Value);

                    var blogPost2CreateResult = BlogPost.CreateBlogPost(
                        2,
                        "Mastering Mechanical Engineering",
                        "This is a series of articles on Mechanical Engineering",
                        author2CreateResult.Value);

                    if (blogPost2CreateResult.IsSuccess)
                        Posts.Add(blogPost2CreateResult.Value);
                }
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

        public int GetLastAuthorId()
        {
            return Authors.OrderByDescending(x => x.Id).FirstOrDefault().Id;
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
            Posts.Add(blogPost);

            return blogPost;
        }

        public int GetLastPostId()
        {
            return Posts.OrderByDescending(x => x.Id).FirstOrDefault().Id;
        }

        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return Posts.Where(post => post.Author.Id == id).ToList();
        }
    }
}
