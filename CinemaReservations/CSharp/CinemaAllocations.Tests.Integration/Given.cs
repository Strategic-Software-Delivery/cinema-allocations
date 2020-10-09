using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using CinemaAllocations.Domain;
using CinemaAllocations.Infra.DataPersistence;
using CinemaAllocations.Tests.Integration.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.Tests.Integration
{
    internal static class Given
    {
        internal static class The
        {
            internal static IMovieScreeningRepository FordTheater
            {
                get
                {
                    var options = new DbContextOptionsBuilder<CinemaContext>()
                        .UseInMemoryDatabase(databaseName: "CinemaTest")
                        .Options;
                    
                    var cinemaContext = new CinemaContext(options);
                    
                    var directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}\\MovieScreenings\\";

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}/MovieScreenings/";
                    }

                    foreach (var fileFullName in Directory.EnumerateFiles($"{directoryName}"))
                    {
                        var fileName = Path.GetFileName(fileFullName);
                        var eventId = Path.GetFileName(fileName.Split("-")[0]);
                        
                        if (eventId != "1") continue;
                        
                        var movieScreeningDto = JsonFile.ReadFromJsonFile<MovieScreeningDto>(fileFullName);

                        cinemaContext.MovieScreenings.Add(movieScreeningDto.ToDataModel(1));
                        cinemaContext.SaveChanges();
                        
                        break;
                    }
                    
                    return new MovieScreeningRepository(cinemaContext);
                }
            }

            private static string GetExecutingAssemblyDirectoryFullPath()
            {
                var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

                if (directoryName.StartsWith(@"file:\"))
                {
                    directoryName = directoryName.Substring(6);
                }

                if (directoryName.StartsWith(@"file:/"))
                {
                    directoryName = directoryName.Substring(5);
                }

                return directoryName;
            }
        }
    }
}