using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenwellSolutionTest2.Model;
using SenwellSolutionTest2.Repository.Interface;

namespace SenwellSolutionTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookAsyncRepository asyncRepository;
        public BookController(IBookAsyncRepository asyncRepository)
        {
            this.asyncRepository = asyncRepository;
        }   

        [HttpPost("AddNewBook")]
        public async Task<IActionResult> AddNewBook(Book book)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await asyncRepository.AddNewBook(book);
                if (result > 0)
                {
                    baseResponse.StatusMessage = $"Book with title {book.title} added successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.StatusMessage = $"Something is wrong...!";
                    baseResponse.StatusCode= StatusCodes.Status409Conflict;
                    return Ok(baseResponse);
                }
            }
           catch (Exception ex)
            {
                baseResponse.StatusMessage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baseResponse);
            }

           
          
        }
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                var result = await asyncRepository.GetAllBooks();
                if (result.Count() > 0)
                {
                    baseResponse.StatusMessage = $"All book records are fetch successfully...!";
                    baseResponse.StatusCode=StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.StatusMessage = "There is no any book record...!";
                    baseResponse.StatusCode = StatusCodes.Status409Conflict;
                    return Ok(baseResponse);
                }
            }
            catch(Exception ex)
            {
                baseResponse.StatusMessage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baseResponse);
            }
          
         
        }
    }
}
