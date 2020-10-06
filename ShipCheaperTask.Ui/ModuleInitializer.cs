using Catel.IoC;
using Microsoft.EntityFrameworkCore;
using ShipCheaperTask.Ui.Helpers;
using ShipCheaperTaskLibrary.Api;
using ShipCheaperTaskLibrary.Database;
using ShipCheaperTaskLibrary.Repositories;
using System.Configuration;

/// <summary>
/// Used by the ModuleInit. All code inside the InitializeResourceGroups method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDatabaseContext>();
        optionsBuilder.UseSqlite("Data Source=favorites.db");
        var serviceLocator = ServiceLocator.Default;
        serviceLocator.RegisterType<IFavoriteMoviesRepository, FavoriteMoviesRepository>();
        serviceLocator.RegisterInstance<MyDatabaseContext>(new MyDatabaseContext(optionsBuilder.Options));
        serviceLocator.RegisterType<ISearchMovieEndPoint, SearchMovieEndPoint>();
        serviceLocator.RegisterType<MovieInfoModelsMapper>();
    }
}