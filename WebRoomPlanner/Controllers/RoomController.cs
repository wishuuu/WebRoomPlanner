using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebRoomPlanner_Domain;
using WebRoomPlanner_Perception.Services;

namespace WebRoomPlanner.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly RoomsService _roomsService;
    private readonly UserService _userService;
    private readonly BaseFurnitureObjectService _baseFurnitureObjectService;

    public RoomController(RoomsService roomsService, UserService userService,
        BaseFurnitureObjectService baseFurnitureObjectService)
    {
        this._roomsService = roomsService;
        this._userService = userService;
        this._baseFurnitureObjectService = baseFurnitureObjectService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Room>))]
    public async Task<IActionResult> getRooms()
    {
        return Ok(await _roomsService.getRooms());
    }

    [HttpGet("{id:int")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Room))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> getRoom(int id)
    {
        try
        {
            return Ok(await _roomsService.getRoom(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound("Nie ma pokoju o takim id");
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Room))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> insertRoom(Room room)
    {
        try
        {
            room = await _roomsService.insertRoom(room);
            return Created("New room", room);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}