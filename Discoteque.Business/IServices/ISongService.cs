using Discoteque.Data.Models;
namespace Discoteque.Data.Services;

public interface ISongService {

    Task <IEnumerable<Song>> GetAllSongsAsync(bool loadAlbum);

    Task<Song> GetSongById(int id);

    Task<IEnumerable<Song>> GetSongsByAlbum(string albumName);

    Task<IEnumerable<Song>> GetSongsByDurationRange(double duration1, double duration2);

    Task<Song> CreateSong(Song song);

    Task<IEnumerable<Song>> InsertSongs(List<Song> songs);

    Task<string> DeleteSong(int id);

    Task<Song> UpdateSong(Song song);
}