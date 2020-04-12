using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try {
                var result = await _repo.GetAllProfessoresAsync(true);
                return Ok(result);
            } 
            catch(System.Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> gerByProfessorId(int ProfessorId)
        {
            try {
                var result = await _repo.GetProfessoresAsyncById(ProfessorId, true);
                return Ok(result);
            } 
            catch(System.Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try {
                _repo.add(model);
                if(await _repo.SaveChangeAsync()) {
                    return Created($"/api/professor/{model.Id}", model);
                }
            } 
            catch(System.Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorId, Professor model)
        {
            try {
                var Professor = await _repo.GetProfessoresAsyncById(ProfessorId, false);
                if(Professor == null) return NotFound();

                _repo.Update(model);
                
                if(await _repo.SaveChangeAsync()) {
                    return Created($"/api/aluno/{model.Id}", model);
                }
            } 
            catch(System.Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }
        
        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int ProfessorId)
        {
            try {
                var Professor = await _repo.GetProfessoresAsyncById(ProfessorId, false);
                if(Professor == null) return NotFound();

                _repo.Delete(Professor);
                
                if(await _repo.SaveChangeAsync()) {
                    return Ok();
                }
            } 
            catch(System.Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }
    }
}