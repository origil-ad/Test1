using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CinemaCity.Core;

namespace CinemaCitySeatsReservation
{
    public static class AjaxParser
    {
        public static List<MovieMetadata> Parse(string path)
        {
            string text = File.ReadAllText(path, Encoding.UTF8);
            string tempText = text;
            List<string> moviesStrings = new List<string>();

            while (tempText.Contains("dc"))
            {
                tempText = tempText.Substring(tempText.IndexOf("dc") + 16);
                moviesStrings.Add(tempText.Split(']').First());
            }

            List<MovieMetadata> moviesMetadatas = new List<MovieMetadata>();
            foreach (string movieString in moviesStrings)
            {
                string movie;
                movie = 
                    movieString.Contains("fn") ?
                    movieString.Substring(movieString.IndexOf("\"") + 6) : movieString.Substring(movieString.IndexOf("\"") + 1);
                string movieName = movie.Remove(movie.Substring(0).IndexOf("\""));

                MovieMetadata movieMetadata = new MovieMetadata(movieName);

                while (movie.Contains("dt"))
                {
                    movie = movie.Substring(movie.IndexOf("dt") + 3);
                    string[] dateTime = movie.Split('"');
                    if (dateTime.Contains("db"))
                    {
                        movieMetadata.AddTime(dateTime[1], dateTime[7]);
                    }
                    else
                    {
                        movieMetadata.AddTime(dateTime[1], dateTime[5]);
                    }
                }
                moviesMetadatas.Add(movieMetadata);
            }
            return moviesMetadatas;
        }

    }
}
