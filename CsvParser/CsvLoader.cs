
public class CsvLoader
{
    private string _csvPath;
    private string _csvDelimiter;
    private List<ICSVParser> _parsers ;
    private CSVAggregate _agg;

    public CsvLoader(string csvPath, string csvDelimiter)
    {
        _csvPath = csvPath;
        _csvDelimiter = csvDelimiter;
        _parsers = new List<ICSVParser>();
        _agg = new CSVAggregate();
    }
    
    public CsvLoader With(ICSVParser parser)
    {
        _parsers.Add(parser);
        return this;
    } 
    public void Run()
    {
        //mark the first parser
        _parsers.Where(p => !p.ShouldRunAtTheEnd).First().IsFirstParser = true;
        string line;
        using (var streamReader = new StreamReader(_csvPath))
        {
            while ((line = streamReader.ReadLine()) != null)
            {
                var columns = line.Split(_csvDelimiter);                
                ParseRecord(columns, _parsers.Where(p => !p.ShouldRunAtTheEnd));
                if (streamReader.EndOfStream)
                {
                    ParseRecord(columns, _parsers.Where(p => p.ShouldRunAtTheEnd));
                }
            }
        }
        return _agg.Result;

        void ParseRecord(string[] columns,IEnumerable<ICSVParser> parsers)
        {
            //in case that the parser failed to parse,no need to continue to other parser because there is no data
            var shouldContinue = true; 
            foreach (var parser in parsers)
            {
                if (shouldContinue)
                {
                    shouldContinue = parser.Parse(columns, _agg);
                }
            }
        }
    }
}
