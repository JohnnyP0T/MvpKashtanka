using Kashtanka.Api.Dal;
using Microsoft.AspNetCore.Mvc;

namespace Kashtanka.Api.Controllers;

[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly ApplicationContext _context;
    public PetController(ApplicationContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Pets.ToList());
    }
    
    [HttpGet("GetVideo")]
    public IResult WriteContentToStream() {  
        var filename = "file_example.mp4";  
        //Build the File Path.  
        string path = Path.Combine( Directory.GetCurrentDirectory() + "/Files/") + filename;  // the video file is in the wwwroot/files folder  
  
        var filestream = System.IO.File.OpenRead(path);  
        return Results.File(filestream, contentType: "video/mp4", fileDownloadName: filename, enableRangeProcessing: true);   
    }  
    
}