using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using CinemaAllocations.Infra.DataPersistence;
using CinemaAllocations.Tests.Acceptance.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.Tests.Acceptance
{
    internal static class Given
    {
        internal static class The
        {
            internal static string FordTheaterId
            {
                get
                {
                    const string fordTheaterId = "1";
                
                    RetrieveMovieScreeningFromJson(fordTheaterId);

                    return fordTheaterId;
                }
            }

            private static MovieScreeningRepository RetrieveMovieScreeningFromJson(string showId)
            {
                var options = new DbContextOptionsBuilder<CinemaContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

                var cinemaContext = new CinemaContext(options);

                AddMovieScreeningIfDoesExists(showId, cinemaContext);

                return new MovieScreeningRepository(cinemaContext);
            }

            private static void AddMovieScreeningIfDoesExists(string showId, CinemaContext cinemaContext)
            {
                var directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}\\MovieScreenings\\";

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                    RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}/MovieScreenings/";
                }

                foreach (var fileFullName in Directory.EnumerateFiles($"{directoryName}"))
                {
                    var fileName = Path.GetFileName(fileFullName);
                    var eventId = Path.GetFileName(fileName.Split("-")[0]);

                    if (eventId != showId) continue;

                    var movieScreeningDto = JsonFile.ReadFromJsonFile<MovieScreeningDto>(fileFullName);

                    cinemaContext.MovieScreenings.Add(movieScreeningDto.ToDataModel(eventId));
                    cinemaContext.SaveChanges();

                    break;
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