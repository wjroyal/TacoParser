using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.

            logger.LogInfo("Log initialized . . . . . .who cares");

            string[] lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("File has no input.");
            }

            if (lines.Length == 1)
            {
                logger.LogError("File has only one line of input");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            ITrackable[] locations = lines.Select(line => parser.Parse(line)).ToArray();


            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;

            double distance = 0;


            // NESTED LOOPS SECTION----------------------------

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];

                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                // SECOND FOR LOOP -
                // TODO: Now, Inside the scope of your first loop, create another loop to iterate through locations again.
                // This allows you to pick a "destination" location for each "origin" location from the first loop. 
                // Naming suggestion for variable: `locB`
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];

                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console.
            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the farthest apart.");


        }
    }
}
