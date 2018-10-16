using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using ToDoApp.Controllers;
using ToDoApp.Models;
using Xunit;

namespace ToDoApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_A_View()
        {
            var toDoRepo = Substitute.For<IToDoRepository>();
            var underTest = new HomeController(toDoRepo);

            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Passes_Todos_To_View()
        {
            var expected = new List<ToDo>();
            var toDoRepo = Substitute.For<IToDoRepository>();
            toDoRepo.GetAll().Returns(expected);

            var underTest = new HomeController(toDoRepo);
            
            var result = underTest.Index();
            var model = result.Model;

            Assert.Same(expected, model);
            //Assert that All Todos were passed into View

        }
    }
}
