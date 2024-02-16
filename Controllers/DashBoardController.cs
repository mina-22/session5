using crud_system.Data;
using crud_system.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace crud_system.Controllers
{
    public class DashBoardController : Controller
    {
    
      private readonly  AppDbContext _database;
        public DashBoardController(AppDbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewBlog() 
        {
           var blogs = _database.blogs.Include(blogs => blogs.type);
            return View(blogs);

        }
        public IActionResult Delete(int id)
        {
            Blog? blog = _database.Set<Blog>().Find(id);
            _database.blogs.Remove(blog) ;
            _database.SaveChanges();
            return RedirectToAction("ViewBlog");
        }
        

        public IActionResult AddBlog(int id=0)
        {
            // if you Add new item id will be 0 else you update item and pass id in parametar
            Blog ?blog;
            if (id == 0)
            {
                //so we create new address in memory for new item
                blog = new Blog();
            }
            else
            {
                // so we take same address in the list and bass it to form 
                blog = _database.Set<Blog>().Find(id);
            }

            // blog you passed
            return View(blog);
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {


            if (blog.Id == 0)
            {
                _database.Set<Blog>().Add(blog);
                _database.SaveChanges();
            }
            else
            {
                var NewBlog = _database.Set<Blog>().Find(blog.Id);
                NewBlog.Name = blog.Name;
                NewBlog.Discription = blog.Discription;
                NewBlog.Enable = blog.Enable;
                NewBlog.TypeId = blog.TypeId;
                _database.Set<Blog>().Update(NewBlog);
                _database.SaveChanges();
           
            }
            
            return RedirectToAction("ViewBlog");
        }


    }
}
