
// See https://aka.ms/new-console-template for more information


var loader = new CsvLoader("CsvToProcess.csv", ",");
var result = loader.With(new FilterRows(3, "Iowa"))
    .With(new GetColumn(9))
    .With(new Avg())
    .Run();


foreach (var results in result)
{
    foreach (var str in results)
    {
        Console.WriteLine($"runing all parsers result:{ str}");
    }
}
