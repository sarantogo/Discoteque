using Microsoft.AspNetCore.Mvc;
using Discoteque.Data.Services;
using Discoteque.Data.Models;

namespace Discoteque.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class SongController : ControllerBase {

    private readonly ISongService _songService;

    public SongController(ISongService songService){
        _songService = songService;
    }

    [HttpGet]
    [Route("GetSongs")]
    public async Task<IActionResult> GetSongs(bool loadAlbum) {
       var songs = await _songService.GetAllSongsAsync(loadAlbum);
       return Ok(songs);
    }

    [HttpGet]
    [Route("GetSongById")]
    public async Task<IActionResult> GetSongById(int id) {
        var song = await _songService.GetSongById(id);
        return Ok(song);
    }

    [HttpGet]
    [Route("GetSongsByAlbum")]
    public async Task<IActionResult> GetSongsByAlbum(string albumName) {
        var songs = await _songService.GetSongsByAlbum(albumName);
        return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "There was no songs found for that album.");
    }

    [HttpGet]
    [Route("GetSongsByDurationRange")]
    public async Task<IActionResult> GetSongsByDurationRange(double duration1, double duration2) {
        var songs = await _songService.GetSongsByDurationRange(duration1, duration2);
        return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "There was no songs found for that duration range.");
    }

    [HttpPost]
    [Route("CreateSong")]
    public async Task<IActionResult> CreateSong(Song song) {
        try
        {
            var newSong = await _songService.CreateSong(song);
            return Ok(newSong);
        }
        catch (System.Exception e)
        {
            
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        
    }

    [HttpPost]
    [Route("InsertSongs")]
    public async Task<IActionResult> InsertSongs(List<Song> songs){
        try
        {
            var newSongs = await _songService.InsertSongs(songs);
            return Ok(newSongs);
        }
        catch (System.Exception e)
        {
            
            return StatusCode(StatusCodes.Status500InternalServerError, "Server error.");
        }
    }

    [HttpDelete]
    [Route("DeleteSong")]
    public async Task<IActionResult> DeleteSong(int id){
        var result = await _songService.DeleteSong(id);
        return Ok(result);
    }

    [HttpPut]
    [Route("UpdateSong")]
    public async Task<IActionResult> UpdateSong(Song song){
        var updatedSong = await _songService.UpdateSong(song);
        return Ok(updatedSong);
    }
}