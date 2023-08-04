using Discoteque.Data.Models;
namespace Discoteque.Data.Services;

public interface ITourService {

    Task <IEnumerable<Tour>> GetAllToursAsync(bool loadArtist);

    Task<Tour> GetTourById(int id);

    Task<IEnumerable<Tour>> GetToursByArtist(string artistName);

    Task<IEnumerable<Tour>> GetToursBySoldOut(bool soldOut);

    Task<Tour> CreateTour(Tour tour);

    Task<string> DeleteTour(int id);

    Task<Tour> UpdateTour(Tour tour);
}