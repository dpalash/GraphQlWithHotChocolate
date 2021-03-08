using GraphQlWithHotChocolate.DTOs;
using GraphQlWithHotChocolate.Interfaces.Services;
using HotChocolate;

namespace GraphQlWithHotChocolate.Models
{
    public class Mutation
    {
        public Author CreateAuthor([Service] IAuthorService authorService, string firstName, string lastName)
        {
            Author author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            var createdAuthor = authorService.CreateAuthor(author);
            return createdAuthor;
        }
    }
}
