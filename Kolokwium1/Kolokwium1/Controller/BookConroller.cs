using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }



    [HttpGet("api/books/{id}/authors")]
    public async Task<IActionResult> GetAuthorsByBooks(int id)
    {
        if (!await _bookRepository.DoesBookExist(id))
            return NotFound($"Book with given ID - {id} doesn't exist");

        var author = await _bookRepository.GetAuthorsByTitle(id);
            
        return Ok(author);
    }

    [HttpPost("api/books")]
    public async Task<IActionResult> AddBook(Book book)
    {
        if (!await _bookRepository.DoesBookExist(book.Id))
            return NotFound($" Book with given ID - {book.Id} doesn't exist");

        /*foreach (var procedure in newAnimalWithProcedures.Procedures)
        {
            if (!await _bookRepository.DoesProcedureExist(procedure.ProcedureId))
                return NotFound($"Procedure with given ID - {procedure.ProcedureId} doesn't exist");
        }

        await _bookRepository.A(newAnimalWithProcedures);*/

        return Created(Request.Path.Value ?? "api/books", book);
    }
}
    
    
    
    
    
    
    


/* [HttpGet("{id}")]
public async Task<ActionResult<IEnumerable<Author>>> GetAuthorsOfBook(int id)
{
    var bookAuthors = await _bookRepository.GetAuthorsOfBook(id);
    if (bookAuthors == null)
    {
        return NotFound();
    }
    return Ok(bookAuthors);
}

[HttpPost]
public async Task<ActionResult<Book>> AddBook(Book book)
{
    await _bookRepository.AddBook(book);
    return CreatedAtAction(nameof(GetAuthorsOfBook), new { id = book.Id }, book);
}
}*/
