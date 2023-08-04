using Discoteque.Data.Services;
using Discoteque.Data.Models;
using Discoteque.Data;

namespace Discoteque.Business.Services;

public class SongService : ISongService {

    private IUnitOfWork _UnitOfWork;

    public SongService(IUnitOfWork unitOfWork) {
        _UnitOfWork = unitOfWork;
    }

    public async Task <IEnumerable<Song>> GetAllSongsAsync(bool loadAlbum) {

        IEnumerable<Song> songs;

        if(loadAlbum){
            songs = await _UnitOfWork.SongRepository.GetAllAsync(null, s => s.OrderBy(s => s.Id), new Album().GetType().Name);
        }
        else{
            songs = await _UnitOfWork.SongRepository.GetAllAsync();
        }

        return songs;
    }

    public async Task<Song> GetSongById(int id) {
        return await _UnitOfWork.SongRepository.FindAsync(id);
    }

    public async Task<IEnumerable<Song>> GetSongsByAlbum(string albumName) {
        return await _UnitOfWork.SongRepository.GetAllAsync(s => s.Album.Name == albumName, s => s.OrderBy(s => s.Id), new Album().GetType().Name);
    }

    public async Task<IEnumerable<Song>> GetSongsByDurationRange(double duration1, double duration2) {
        return await _UnitOfWork.SongRepository.GetAllAsync(s => s.Duration >= duration1 && s.Duration <= duration2, s => s.OrderBy(s => s.Id), "");
    }

    public async Task<Song> CreateSong(Song song) {

        var album = await _UnitOfWork.AlbumRepository.FindAsync(song.AlbumId);

        if (album == null) {
            throw new ArgumentException("Could not found album.");
        }
        Song newSong = new Song {
            Name = song.Name,
            Duration = song.Duration,
            AlbumId = song.AlbumId,
        };

        await _UnitOfWork.SongRepository.AddAsync(newSong);
        await _UnitOfWork.SaveAsync();
        return newSong;
    }

    public async Task<IEnumerable<Song>> InsertSongs(List<Song> songs){
        try
        {
        songs.ForEach(song => 
        _UnitOfWork.SongRepository.AddAsync(song));
        await _UnitOfWork.SaveAsync();
        return songs;
        }
        catch (System.Exception e)
        {
            
            throw e;
        }
        
    }

    public async Task<string> DeleteSong(int id) {
        await _UnitOfWork.SongRepository.Delete(id);
        await _UnitOfWork.SaveAsync();
        return string.Format("Song number {0} deleted", id);
    }

    public async Task<Song> UpdateSong(Song song) {
        await _UnitOfWork.SongRepository.Update(song);
        await _UnitOfWork.SaveAsync();
        return song;
    }

}
