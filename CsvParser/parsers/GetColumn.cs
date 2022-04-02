
public class GetColumn : ICSVParser
{
    private int _columnIdx;
    public bool IsFirstParser { get; set; }
    public bool ShouldRunAtTheEnd { get => false; }
    public GetColumn(int columnIdx)
    {
        _columnIdx = columnIdx;
    }

    public bool Parse(string[] csvRecord, CSVAggregate agg) 
    {
        if (csvRecord.Length >= _columnIdx )
        {
            agg.AddOrUpdate(new string[] { csvRecord[_columnIdx]}, IsFirstParser);
            return true;
        }
        return false;
    }
}
