using CSharpFunctionalExtensions;
using System;

namespace GraphQlWithHotChocolate.DTOs
{
    [Serializable]
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }

        protected BlogPost(int id, string title, string content, Author author)
        {
            Id = id;
            Title = title;
            Content = content;
            Author = author;
        }

        public static Result<BlogPost> CreateBlogPost(int id, string title, string content, Author author)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<BlogPost>("Title can not be null or empty!");

            ///TODO: Add validatation logic for others here
            ///
            var blogPost = new BlogPost(id, title, content, author);

            return Result.Success(blogPost);
        }
    }
}
