using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private IToDoRepository toDoRepo;

        public HomeController(IToDoRepository toDoRepo)
        {
            this.toDoRepo = toDoRepo;
        }

        public ViewResult Index()
        {
            var model = toDoRepo.GetAll();
            return View(model);
        }
    }
}
