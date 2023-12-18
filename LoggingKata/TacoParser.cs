namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                logger.LogWarning("Less than 3 items, incomplete data.");
                return null; 
            }

            // DONE: Grab the latitude from your array at index 0
            var latitude = double.Parse(cells[0]);
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`


            // DONE: Grab the longitude from your array at index 1
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            var longitude = double.Parse(cells[1]);


            // DONE: Grab the name from your array at index 2

            var name = cells[2];

            // DONE: Create a TacoBell class
            // that conforms to ITrackable

            // DONE: Create an instance of the Point Struct
            // DONE: Set the values of the point correctly (Latitude and Longitude) 
            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            // DONE: Create an instance of the TacoBell class
            // DONE: Set the values of the class correctly (Name and Location)
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;

            // DONE: Then, return the instance of your TacoBell class,
            // since it conforms to ITrackable

            return tacoBell;
        }
    }
}
