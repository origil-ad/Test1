using System.Collections.Generic;

namespace CinemaCity.Core
{
    public class MovieMetadata
    {
        public string Name { get; set; }
        public Dictionary<string, List<string>> DateTime { get; }

        public MovieMetadata(string name)
        {
            Name = name;
            DateTime = new Dictionary<string, List<string>>();
        }

        public void AddTime(string date, string time)
        {
            if (!DateTime.ContainsKey(date))
            {
                DateTime.Add(date, new List<string>());
            }
            DateTime[date].Add(time);
        }
    }
}
