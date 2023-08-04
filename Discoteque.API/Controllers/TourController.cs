using Microsoft.AspNetCore.Mvc;
using Discoteque.Data.Services;
using Discoteque.Data.Models;

namespace Discoteque.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TourController : ControllerBase {

    private readonly ITourService _tourService;

    public TourController(ITourService tourService){
        _tourService = tourService;
    }

    [HttpGet]
    [Route("GetTours")]
    public async Task<IActionResult> GetTours(bool loadArtist) {
       var tours = await _tourService.GetAllToursAsync(loadArtist);
       return Ok(tours);
    }

    [HttpGet]
    [Route("GetTourById")]
    public async Task<IActionResult> GetTourById(int id) {
        var tour = await _tourService.GetTourById(id);
        return Ok(tour);
    }

    [HttpGet]
    [Route("GetToursByArtist")]
    public async Task<IActionResult> GetToursByArtist(string artistName) {
        var tours = await _tourService.GetToursByArtist(artistName);
        return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "There was no tours found for that artist.");
    }

    [HttpGet]
    [Route("GetToursBySoldOut")]
    public async Task<IActionResult> GetToursBySoldOut(bool soldOut) {
        var tours = await _tourService.GetToursBySoldOut(soldOut);
        return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "There was no tours sold out.");
    }

    [HttpPost]
    [Route("CreateTour")]
    public async Task<IActionResult> CreateTour(Tour tour) {
        try
        {
            var newTour = await _tourService.CreateTour(tour);
            return Ok(newTour);
        }
        catch (System.Exception e)
        {
            
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        
    }

    [HttpDelete]
    [Route("DeleteTour")]
    public async Task<IActionResult> DeleteTour(int id){
        var result = await _tourService.DeleteTour(id);
        return Ok(result);
    }

    [HttpPut]
    [Route("UpdateTour")]
    public async Task<IActionResult> UpdateTour(Tour tour){
        var updatedTour = await _tourService.UpdateTour(tour);
        return Ok(updatedTour);
    }
}