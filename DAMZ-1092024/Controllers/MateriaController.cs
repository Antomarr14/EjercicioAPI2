using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAMZ_1092024.Models;

namespace DAMZ_1092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        static List<Materia> materias = new List<Materia>();
        [HttpGet]
        public IEnumerable<Materia> Get(){
            return materias;
        }

        [HttpGet("{id}")]
        public Materia Get(int id){
            var materia = materias.FirstOrDefault(m => m.Id == id);
            return materia;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Materia materia){
            materias.Add(materia);
            return Ok();
        }

        [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Materia materia){
        var existingMateria = materias.FirstOrDefault(m => m.Id == id);
        if (existingMateria != null){
            existingMateria.Nombre = materia.Nombre;
            existingMateria.Descripcion = materia.Descripcion;
            return Ok();
        }
        else{
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var existingMateria = materias.FirstOrDefault(m => m.Id == id);
        if(existingMateria != null){
            materias.Remove(existingMateria);
            return Ok();
        }
        else{
            return NotFound();
        }
        
    }

    }

    
}

