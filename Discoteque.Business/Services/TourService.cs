using Discoteque.Data.Services;
using Discoteque.Data.Models;
using Discoteque.Data;

namespace Discoteque.Business.Services;

public class TourService : ITourService {

    private IUnitOfWork _UnitOfWork;

    public TourService(IUnitOfWork unitOfWork) {
        _UnitOfWork = unitOfWork;
    }

    public async Task <IEnumerable<Tour>> GetAllToursAsync(bool loadArtist) {

        IEnumerable<Tour> tours;

        if(loadArtist){
            tours = await _UnitOfWork.TourRepository.GetAllAsync(null, s => s.OrderBy(s => s.Id), new Artist().GetType().Name);
        }
        else{
            tours = await _UnitOfWork.TourRepository.GetAllAsync();
        }

        return tours;
    }

    public async Task<Tour> GetTourById(int id) {
        return await _UnitOfWork.TourRepository.FindAsync(id);
    }

    public async Task<IEnumerable<Tour>> GetToursByArtist(string artistName) {
        return await _UnitOfWork.TourRepository.GetAllAsync(s => s.Artist.Name == artistName, s => s.OrderBy(s => s.Id), new Artist().GetType().Name);
    }

    public async Task<IEnumerable<Tour>> GetToursBySoldOut(bool soldOut) {
        return await _UnitOfWork.TourRepository.GetAllAsync(s => s.isSoldOut == true, s => s.OrderBy(s => s.Id), "");
    }

    public async Task<Tour> CreateTour(Tour tour) {

        DateOnly parsedDate;
        bool isSuccess = DateOnly.TryParse(tour.Date.ToString(), out parsedDate);
        if(!isSuccess) {
            throw new Exception("Invalid date format.");
        }
        var validDate = tour.Date.Year > 2021;

        if(!validDate){
            throw new ArgumentException("The tour date must be greater than 2021.");
        }

        Tour newTour = new Tour {
            Name = tour.Name,
            City = tour.City,
            Date = tour.Date,
            isSoldOut = tour.isSoldOut,
            ArtistId = tour.ArtistId,
        };

        await _UnitOfWork.TourRepository.AddAsync(newTour);
        await _UnitOfWork.SaveAsync();
        return newTour;
    }

    public async Task<string> DeleteTour(int id) {
        await _UnitOfWork.TourRepository.Delete(id);
        await _UnitOfWork.SaveAsync();
        return string.Format("Tour number {0} deleted", id);
    }

    public async Task<Tour> UpdateTour(Tour tour) {
        await _UnitOfWork.TourRepository.Update(tour);
        await _UnitOfWork.SaveAsync();
        return tour;
    }

}