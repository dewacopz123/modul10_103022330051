using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace modul10_103022330051.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        // Static List untuk menyimpan data Mahasiswa
        private static List<Movie> daftarMovie = new List<Movie>
        {
            new Movie { Title = "The Shawshank Redemption", Director = "Drank Darabont",Stars = ["Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler"],  Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." },
            new Movie { Title = "The Godfather", Director = "Francis Ford Coppola",Stars = ["Marlon Brando", "Al Pacino", "James Caan", "Diane Keaton"],  Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
            new Movie { Title = "The Dark Knight", Director = "Christopher Nolan",Stars = ["Christian Bale", "Heath Ledger", "James Caan", "Aaron Eckhart"],  Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." }
        };

        // GET: /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return daftarMovie;
        }

        // GET: /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Movie> Get(int index)
        {
            if (index < 0 || index >= daftarMovie.Count)
            {
                return NotFound();
            }
            return daftarMovie[index];
        }

        // POST: /api/mahasiswa
        [HttpPost]
        public ActionResult Post([FromBody] Movie mahasiswaBaru)
        {
            daftarMovie.Add(mahasiswaBaru);
            return Ok();
        }

        // DELETE: /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= daftarMovie.Count)
            {
                return NotFound();
            }
            daftarMovie.RemoveAt(index);
            return Ok();
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Stars { get; set; }
        public string Description { get; set; }
    }
}