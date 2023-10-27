using System;
using Microsoft.EntityFrameworkCore;
using Discoteque.Data;
using Discoteque.Business.IServices;
using Discoteque.Business.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DiscotequeContext>(
    opt => {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DiscotequeDatabase"));
    }    
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IArtistsService, ArtistsService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<ITourService, TourService>();

var app = builder.Build();
// PopulateDb(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


#region  DB Population
/// <summary>
/// Populate teh Database with some data.
/// </summary>
/// <param name="app"></param>
async void PopulateDb(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var artistService = scope.ServiceProvider.GetRequiredService<IArtistsService>();
        var albumService = scope.ServiceProvider.GetRequiredService<IAlbumService>();
        var songService = scope.ServiceProvider.GetRequiredService<ISongService>();
        var tourService = scope.ServiceProvider.GetRequiredService<ITourService>();
        // Artists
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 1,
            Name = "Karol G",
            Label = "Universal Music Latin",
            IsOnTour = true
        });

        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 2,
            Name = "Juanes",
            Label = "Universal Music Group",
            IsOnTour = false
        });

        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 3,
            Name = "Shakira",
            Label = "Sony Music",
            IsOnTour = false
        });
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 4,
            Name = "Joe Arroyo",
            Label = "AVAYA",
            IsOnTour = false
        });
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 5,
            Name = "Carlos Vives",
            Label = "EMI/Virgin",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 6,
            Name = "Silvestre Dangond",
            Label = "SONY Music",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 7,
            Name = "Fonseca",
            Label = "SONY BMG",
            IsOnTour = false
        });
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 8,
            Name = "Maluma",
            Label = "RCA",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 9,
            Name = "Andrés Cepeda",
            Label = "SONY BMG",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Discoteque.Data.Models.Artist{
            Id = 10,
            Name = "J Balvin",
            Label = "SONY BMG",
            IsOnTour = true
        }); 
        
        // Albums
        #region Karol G
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2017,
            Name = "Unstopabble",
            ArtistId = 1,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2019,
            Name = "Ocean",
            ArtistId = 1,
            Genre = Discoteque.Data.Models.Genres.Urban
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2021,
            Name = "KG0516",
            ArtistId = 1,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2023,
            Name = "Mañana será bonito",
            ArtistId = 1,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Juanes
        // Juanes
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2000,
            Name = "Fijate Bien",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2002,
            Name = "Un día normal",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2004,
            Name = "Mi sangre",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2007,
            Name = "La vida... es un ratico",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2010,
            Name = "P.A.R.C.E",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2014,
            Name = "Loco de amor",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2017,
            Name = "Mis planes son amarte",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2019,
            Name = "Más futuro que pasado",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2021,
            Name = "Origen",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2023,
            Name = "Vida cotidiana",
            ArtistId = 2,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Shakira
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Id = 14,
            Year = 1991,
            Name = "Magia",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1993,
            Name = "Peligro",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1995,
            Name = "Pies Descalzos",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1998,
            Name = "¿Dónde están los ladrones",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2001,
            Name = "Servicio de lavanderia",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2005,
            Name = "Fijación oral vol 1",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2009,
            Name = "Loba / She Wolf",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2010,
            Name = "Sale el sol",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2014,
            Name = "Shakira",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Id = 14,
            Year = 2015,
            Name = "El Dorado",
            ArtistId = 3,
            Genre = Discoteque.Data.Models.Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });        
        #endregion

        #region Joe Arroyo
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1990,
            Name = "La guerra de los callados",
            ArtistId = 4,
            Genre = Discoteque.Data.Models.Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });    
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1992,
            Name = "La voz",
            ArtistId = 4,
            Genre = Discoteque.Data.Models.Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });    
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1976,
            Name = "El bárbaro",
            ArtistId = 4,
            Genre = Discoteque.Data.Models.Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });    
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1975,
            Name = "El grande",
            ArtistId = 4,
            Genre = Discoteque.Data.Models.Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });    
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1979,
            Name = "El teso",
            ArtistId = 4,
            Genre = Discoteque.Data.Models.Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        #endregion

        #region Carlos Vives
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1993,
            Name = "Clásicos de la Provincia",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1995,
            Name = "la Tierra del olvido",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1997,
            Name = "Tengo fe",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1999,
            Name = "El amor de la tierra",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2001,
            Name = "Dejame entrar",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2009,
            Name = "Clásicos de la provincia",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2020,
            Name = "Cumbiana",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2022,
            Name = "Cumbiana II",
            ArtistId = 5,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        #endregion 

        #region Silvestre Dangond
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2002,
            Name = "Tanto para ti",
            ArtistId = 6,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2003,
            Name = "Lo mejor para los dos",
            ArtistId = 6,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2006,
            Name = "el original",
            ArtistId = 6,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2010,
            Name = "Cantinero",
            ArtistId = 6,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        #endregion

        #region Fonseca
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2002,
            Name = "Fonseca",
            ArtistId = 7,
            Genre = Discoteque.Data.Models.Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        }); 
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2005,
            Name = "Corazón",
            ArtistId = 7,
            Genre = Discoteque.Data.Models.Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2008,
            Name = "Gratitud",
            ArtistId = 7,
            Genre = Discoteque.Data.Models.Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2011,
            Name = "Ilusión",
            ArtistId = 7,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Maluma
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2012,
            Name = "Magia",
            ArtistId = 8,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2015,
            Name = "Pretty Boy, Dirty Boy",
            ArtistId = 8,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2018,
            Name = "F.A.M.E.",
            ArtistId = 8,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2019,
            Name = "11:11",
            ArtistId = 8,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2020,
            Name = "Papi Juancho",
            ArtistId = 8,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2023,
            Name = "Don Juan",
            ArtistId = 8,
            Genre = Discoteque.Data.Models.Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Andrés Cepeda
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 1999,
            Name = "Se morir",
            ArtistId = 9,
            Genre = Discoteque.Data.Models.Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2001,
            Name = "El carpintero",
            ArtistId = 9,
            Genre = Discoteque.Data.Models.Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2003,
            Name = "Canción rota",
            ArtistId = 9,
            Genre = Discoteque.Data.Models.Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2005,
            Name = "Para amarte mejor",
            ArtistId = 9,
            Genre = Discoteque.Data.Models.Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region J Balvin
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2013,
            Name = "la familia",
            ArtistId = 10,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2016,
            Name = "Energía",
            ArtistId = 10,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2018,
            Name = "Vibras",
            ArtistId = 10,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2020,
            Name = "Colores",
            ArtistId = 10,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Discoteque.Data.Models.Album{
            Year = 2021,
            Name = "Jose",
            ArtistId = 10,
            Genre = Discoteque.Data.Models.Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Songs
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Id = 1,
            Name = "Alive",
            Duration = 4.23,
            AlbumId = 1,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Bird set free",
            Duration = 4,
            AlbumId = 1,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Provenza",
            Duration = 3.50,
            AlbumId = 2,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Ocean Drive",
            Duration = 3,
            AlbumId = 2,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Master of Puppets",
            Duration = 6.43,
            AlbumId = 3,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Unforgiven",
            Duration = 5.10,
            AlbumId = 3,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Dulce introducción al caos",
            Duration = 6,
            AlbumId = 4,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Locura transitoria",
            Duration = 7.16,
            AlbumId = 4,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "I miss you",
            Duration = 4.20,
            AlbumId = 5,
        });
        await songService.CreateSong(new Discoteque.Data.Models.Song{
            Name = "Stay together for the kids",
            Duration = 4.34,
            AlbumId = 5,
        });
        #endregion

        #region Tours
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Id = 1,
            Name = "Latinoamerica tour",
            City = "Medellín",
            Date = new DateTime(2023, 11, 05),
            IsSoldOut = true,
            ArtistId = 1
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Worldwide tour",
            City = "Los Angeles",
            Date = new DateTime(2024, 03, 11),
            IsSoldOut = false,
            ArtistId = 2
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Tusa tour",
            City = "Barcelona",
            Date = new DateTime(2023, 09, 23),
            IsSoldOut = true,
            ArtistId = 3
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Tour de la marimonda",
            City = "Barranquilla",
            Date = new DateTime(2023, 12, 15),
            IsSoldOut = false,
            ArtistId = 4
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "La tierra del olvido tour",
            City = "Buenos Aires",
            Date = new DateTime(2024, 06, 07),
            IsSoldOut = true,
            ArtistId = 5
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Paracos tour",
            City = "Bogotá",
            Date = new DateTime(2023, 10, 18),
            IsSoldOut = false,
            ArtistId = 6
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Nadie le importa tour",
            City = "Quito",
            Date = new DateTime(2025, 01, 22),
            IsSoldOut = true,
            ArtistId = 7
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Princesa tour",
            City = "Medellín",
            Date = new DateTime(2023, 11, 10),
            IsSoldOut = true,
            ArtistId = 8
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Princesa tour",
            City = "Miami",
            Date = new DateTime(2023, 11, 07),
            IsSoldOut = false,
            ArtistId = 8
        });
        await tourService.CreateTour(new Discoteque.Data.Models.Tour{
            Name = "Guitarra tour",
            City = "Bogotá",
            Date = new DateTime(2024, 02, 20),
            IsSoldOut = true,
            ArtistId = 9
        });
        #endregion
    }
}
#endregion