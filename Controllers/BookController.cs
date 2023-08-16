using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.DTO;
using Repository_Pattern.Models;
using Repository_Pattern.Repository;
using System.Xml;

namespace Repository_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepo<Book> baseRepo;
        private readonly ALLDTO dto;
        public BookController(IBaseRepo<Book> baseRepo, ALLDTO dto)
        {
            this.baseRepo = baseRepo;
            this.dto = dto;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> getId(int id)
        {
            return Ok(await baseRepo.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await baseRepo.GetAll());
        }
        [HttpGet("GetByPrice")]
        public async Task<IActionResult> GetByPrice(int price)
        {
            return Ok(await baseRepo.find(a=>a.Price==price ));
        }
        [HttpGet("GetInclude")]
        public async Task<IActionResult> GetInclude(int price)
        {
            return Ok(await baseRepo.FindInclude(b => b.Price == price, new[] { "Auther" }));
        }
        [HttpGet("FindAll")]

        public async Task<IActionResult> FindAll(int price)
        {
            return Ok(await baseRepo.FindAll(b => b.Price == price, new[] { "Auther" }));
        }
        [HttpPost("AddOne")]
        public async Task<IActionResult> Add(Book Book)
        {
            //return Ok(await baseRepo.Add(new Book {Name="C#",AutherId=1}));
            return Ok(await baseRepo.Add(Book));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            return Ok(await baseRepo.Update(book));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Book book)
        {
             baseRepo.Delete(book);
            return Ok("deleted");
        }
        [HttpPut("UpdateById")]
        public async Task<IActionResult> UpdateByIddd(int id)
        {
            var res=await baseRepo.GetById(id);
            return Ok(await baseRepo.Update(res));
        }
        [HttpGet("GetByIdDTO")]
        public async Task<IActionResult> GetByIdDTO(int id)
        {
            var autherBook = await baseRepo.FindInclude(a => a.Id == id, new[] { "Auther" });
            //ALLDTO dto = new ALLDTO();
            dto.Id = autherBook.Id;
            dto.AName = autherBook.Auther.Name;
            dto.BName = autherBook.Name;
            dto.BPrice = autherBook.Price;
            return Ok(dto);
            //Problem serialiazation operation cycle occur only with GetIncude (المؤلف مع كتبه او العكس)
        }
    }
}
