using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Service_Hobby
{
    [ServiceContract(Namespace ="WCF_Service_Hobby")]
    public interface IHobby
    {
        [OperationContract]
        string WorstMovieTitle(string year);

        [OperationContract]
        string YearOfMovie(string movieTitle);

    }
    public class HobbyService : IHobby
    {
        public string WorstMovieTitle(string year)
        {
            Console.WriteLine("Mottaget");
            var textFromFile = System.IO.File.ReadAllLines(@"D:\VS projects\WCF.Labb2\WCF_Service_Hobby\WorstMovies.txt");
            var movieTitle = "";

            foreach (var line in textFromFile)
            {
                var split = line.Split('\t');

                if (split.Contains(year))
                {
                    movieTitle = split[1];

                }
            }
            return movieTitle;

        }

        public string YearOfMovie(string movieTitle)
        {
            Console.WriteLine("Mottaget");
            var textFromFile = System.IO.File.ReadAllLines(@"D:\VS projects\WCF.Labb2\WCF_Service_Hobby\WorstMovies.txt");
            var year = "";

            foreach (var line in textFromFile)
            {
                var split = line.Split('\t');

                if (split.Contains(movieTitle))
                {
                    year = "Den som fick en Razzie för sämsta film är: " + "\r\n" + "***" + split[0] + "***";

                }
            }
            return year;
        }
    }
}
