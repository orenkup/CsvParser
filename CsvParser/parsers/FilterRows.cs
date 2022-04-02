
/// <summary>
/// CSVAggregate Holds all the records that were processed allready.
/// </summary>
public class FilterRows : ICSVParser
{
    private int _columnIdx;
    private string _value;
    public bool IsFirstParser { get; set; }
    public bool ShouldRunAtTheEnd { get => false; }

    public FilterRows(int columnIdx, string value)
    {
        _columnIdx = columnIdx;
        _value = value;
    }

    public bool Parse(string[] csvRecord,CSVAggregate agg) 
    {
        if (csvRecord.Length>= _columnIdx && csvRecord[_columnIdx]== _value)
        {
            agg.AddOrUpdate(csvRecord, IsFirstParser);
            return true;
        }
        return false;
    }
}
