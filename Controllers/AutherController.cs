using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Repository_Pattern.DTO;
using Repository_Pattern.Models;
using Repository_Pattern.Repository;
using System.Xml.Linq;

namespace Repository_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
        private readonly IBaseRepo<Auther> baseRepo;
        private readonly ALLDTO dto;

        public AutherController(IBaseRepo<Auther> baseRepo, ALLDTO dto)
        {
            this.baseRepo = baseRepo;
            this.dto = dto; 

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok(await baseRepo.GetById(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await baseRepo.GetAll());
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await baseRepo.find(a=>a.Name==name));
        }
        [HttpGet("GetInclude")]
        public async Task<IActionResult> GetInclude(string name)
        {
            return Ok(await baseRepo.FindInclude(a => a.Name == name, new[] { "books" }));
        }
        [HttpPost("AddOne")]
        public async Task<IActionResult> Add(Auther auther)
        {
            //return Ok(await baseRepo.Add(new Auther { Name="taha"}));
            return Ok(await baseRepo.Add(auther));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Auther auther)
        {
            return Ok(await baseRepo.Update(auther));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Auther auther)
        {
            baseRepo.Delete(auther);
            return Ok("Deleted");
        }
        [HttpGet("GetByIdDTO")]

        public async Task<IActionResult> GetByIdDTO(int id)
        {
            var autherBook = await baseRepo.FindInclude(a => a.Id == id, new[] { "books" });
            //ALLDTO dto = new ALLDTO();
            dto.Id = autherBook.Id;
            dto.AName = autherBook.Name;
            dto.BName = autherBook.books[0].Name;
            dto.BPrice = autherBook.books[0].Price;
            return Ok(dto);
        }
       

    }
}
