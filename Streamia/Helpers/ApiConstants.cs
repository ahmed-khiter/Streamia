using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Helpers
{
    public static class ApiConstants
    {
        public static readonly string baseUrl = "https://api.themoviedb.org/3/";
        public static readonly string apiKey = "415e9238d5188172426c3858b367e468";
        public static readonly string getMovies = "movie/{searchType}?language=en-US&page=1&";
        public static readonly string searchMovies = "search/movie?query={searchText}&language=en-US&page=1&";
        public static readonly string movieById = "movie/{movieId}?page=1&language=en-US&";
        public static readonly string movieAlreadyExists = "Movie is already there in watchlist";
    }
}
