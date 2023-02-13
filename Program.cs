// See https://aka.ms/new-console-template for more information
// ask for input
string? resp = Console.ReadLine();
string file = "data.txt";
string line;

do
{
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
resp = Console.ReadLine();


if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new Random();
     // create file
    StreamWriter sw = new StreamWriter("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
  // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
     sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data fil
   if (File.Exists(file))
    {
        StreamReader sr = new StreamReader(file);
        line = sr.ReadLine();
        while (line != null)
        {
            //Console.WriteLine(line);
            // Get index of comma
            var commaIndex = line.IndexOf(",");
            var slashIndex = line.IndexOf("|");
            
            
            //Get Everything before the comma
            var dateString = line.Substring(0, commaIndex);
            var hourString = line.Substring(10, slashIndex);
            
            // Change date string to a Date Type
            var dateType = DateTime.Parse(dateString);
            
            //Console.WriteLine(dateType);
            //Console.WriteLine(hourString);
            // Format dateType to 
            var formattedMonth = dateType.ToString("Week of MMM, dd, yyyy");
            Console.WriteLine(formattedMonth);
            Console.WriteLine("Su Mo Tu We Th Fr Sa");
            Console.WriteLine("-- -- -- -- -- -- --");
            
            Console.WriteLine(hourString);

            line = sr.ReadLine();
        }
        sr.Close();
        
        //Console.WriteLine("Hi youve done it");
    }
    else
    {
        Console.WriteLine("File does not exist.");
    }

}
} while(resp == "1" || resp == "2");
