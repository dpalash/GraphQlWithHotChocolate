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

        //public CreateAuthor([Service] IAuthorService authorService, [Service] ITopicEventSender eventSender, string departmentName)
        //{
        //    var newDepartment = new Department
        //    {
        //        Name = departmentName
        //    };

        //    var createdDepartment = authorService.CreateAuthor(newDepartment);

        //    await eventSender.SendAsync("PostCreated", createdDepartment);

        //    return createdDepartment;
        //}
    }
}
