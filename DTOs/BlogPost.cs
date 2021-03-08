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
    }
}
