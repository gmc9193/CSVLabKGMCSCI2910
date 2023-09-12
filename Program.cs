namespace CSVLab
{
    public class Program
    {
        public static void Main()
        {
            //Populating list
            var lines = File.ReadLines("videogames.csv");
            List<Videogame> gameList = lines.Skip(1).Select(line => new Videogame(line)).ToList();
            
            //Test Sorting
            Console.WriteLine("Unsorted List");
            gameList.ForEach(Console.WriteLine);
            gameList.Sort();
            Console.WriteLine("Sorted List");
            gameList.ForEach(Console.WriteLine);
            
            //Get Nintendo Games
            var nintendoGames = gameList.Where(x => x.Publisher == "Nintendo").ToList();
            nintendoGames.Sort();
            nintendoGames.ForEach(Console.WriteLine);

            // Get nintendo percentages
            double percentage;
            var rolePlayingGames = gameList.Where(x => x.Genre == "Role-Playing").ToList();

            percentage = Math.Round(rolePlayingGames.Count * 100.0 / gameList.Count, 2);
            Console.WriteLine($"Out of {gameList.Count}, {rolePlayingGames.Count} are Role-Playing games. Which is {percentage:F2}%.");
            
            percentage = Math.Round(nintendoGames.Count * 100.0 / gameList.Count, 2);
            Console.WriteLine($"Out of {gameList.Count}, {nintendoGames.Count} are developed by Nintendo. Which is {percentage:F2}%.");

            //Test Methods
            PublisherData("Electronic Arts", gameList);
            GenreData("Shooter", gameList);
            
            //User Input 
            Console.WriteLine("Enter Publisher:");
            PublisherData(Console.ReadLine()!, gameList);
            
            Console.WriteLine("Enter Genre:");
            GenreData(Console.ReadLine()!, gameList);
            
        }

        public static void PublisherData(string input, List<Videogame> gameList)
        {
            var publisherGames = gameList.Where(x => x.Publisher == input).ToList();
            publisherGames.Sort();
            publisherGames.ForEach(Console.WriteLine);

            double percentage = (double)publisherGames.Count / gameList.Count * 100.0;
            percentage = Math.Round(percentage, 2);
            Console.WriteLine($"Out of {gameList.Count}, {publisherGames.Count} are developed by {input}. Which is {percentage:F2}%.");
        }

        public static void GenreData(string input, List<Videogame> gameList)
        {
            var genreGames = gameList.Where(x => x.Genre == input).ToList();
            genreGames.Sort();
            genreGames.ForEach(Console.WriteLine);

            double percentage = (double)genreGames.Count / gameList.Count * 100.0;
            percentage = Math.Round(percentage, 2);
            Console.WriteLine($"Out of {gameList.Count}, {genreGames.Count} are {input} games. Which is {percentage:F2}%.");
        }

    }

}

