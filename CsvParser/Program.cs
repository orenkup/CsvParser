
// See https://aka.ms/new-console-template for more information


var loader = new CsvLoader("CsvToProcess.csv", ",");
loader.With(new FilterRows(3, "Iowa"))
       .With(new GetColumn(9))
       .With(new Avg())
    .Run();
    ;
