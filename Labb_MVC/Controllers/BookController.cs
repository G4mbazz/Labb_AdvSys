using Labb_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using ModelsLib.Models;
using ModelsLib.Models.MVC_Tools;
using Newtonsoft.Json;

namespace Labb_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private int _id { get; set; }
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> BookIndex(string searchString)
        {
            var books = new List<Book>();
            var response = await _bookService.GetAllBooks<ResponseDTO>();
            if (!String.IsNullOrEmpty(searchString))
            {
				response = await _bookService.SearchBookAsync<ResponseDTO>(searchString);
			}
			if (response != null && response.IsSuccess)
            {
                books = JsonConvert.DeserializeObject<List<Book>>(Convert.ToString(response.Result));
            }
            return View(books);
        }
        public async Task<IActionResult> Info(int id)
        {
            var responseDTO = await _bookService.GetBookByID<ResponseDTO>(id);
            if (!responseDTO.IsSuccess)
            {
                return NotFound();
            }
            Book book = JsonConvert.DeserializeObject<Book>(Convert.ToString(responseDTO.Result));
            return View(book);
		}
		public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var responseDto = await _bookService.DeleteAsync<ResponseDTO>(id);
            if (responseDto.IsSuccess)
            {
                return RedirectToAction(nameof(BookIndex));
            }
            return NotFound();
		}
		public async Task<IActionResult> Update(int id)
		{
			var responseDto = await _bookService.GetBookByID<ResponseDTO>(id);
            _id = id;
            if (!responseDto.IsSuccess)
            {
                return NotFound();
            }
			BookDTO dto = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(responseDto.Result));
			return View(dto);
		}
		[HttpPost]
		public async Task<IActionResult> Update(BookDTO updateDto, int id)
		{
			if (!ModelState.IsValid) return View(updateDto);
			var responseDto = await _bookService.UpdateBookAsync<ResponseDTO>(updateDto,id);
			if (responseDto.IsSuccess && responseDto != null)
			{
				return RedirectToAction(nameof(BookIndex));
			}

			return View(updateDto);
		}
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookDTO bdto)
        {
            if (!ModelState.IsValid)
            {
                return View(bdto);
            }
            var responseDto = await _bookService.CreateBookAsync<ResponseDTO>(bdto);
            if (responseDto.IsSuccess)
            {
                return RedirectToAction(nameof(BookIndex));
            }
            return View(bdto);

        }

    }
}
