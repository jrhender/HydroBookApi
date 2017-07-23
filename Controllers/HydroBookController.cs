using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HydroBookApi.Models;
using System.Linq;

namespace HydroBookApi.Controllers
{
    [Route("api/[controller]")]
    public class HydroBookController : Controller
    {
        private readonly HydroBookContext _context;

        public HydroBookController(HydroBookContext context)
        {
            _context = context;

            if (_context.HydroBookStories.Count() == 0)
            {
                _context.HydroBookStories.Add(new Story { 
                    Summary = "First Story",
                    Title = "Story1",
                    Text = "blah blah blah",
                    PublicationDate = "2017/07/23",
                    SourceUrl = "https://www.google.com",
                    SourceName = "Google"
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Story> GetAll()
        {
            return _context.HydroBookStories.ToList();
        }

        [HttpGet("{id}", Name = "GetStory")]
        public IActionResult GetById(long id)
        {
            var item = _context.HydroBookStories.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Story story)
        {
            if (story == null)
            {
                return BadRequest();
            }

            _context.HydroBookStories.Add(story);
            _context.SaveChanges();

            return CreatedAtRoute("GetStory", new { id = story.Id }, story);
        }       
    }
}