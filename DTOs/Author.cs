using CSharpFunctionalExtensions;
using System;

namespace GraphQlWithHotChocolate.DTOs
{
    [Serializable]
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Author(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public static Result<Author> CreateAuthor(int id, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<Author>("FirstName can not be null or empty!");

            ///TODO: Add validatation logic for others here

            // Data Manipulation
            id += 1;

            var author = new Author(id, firstName, lastName);

            return Result.Success(author);
        }
    }
}
