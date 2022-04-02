
public class Sum : ICSVParser
{
    public bool IsFirstParser { get; set; }
    public bool ShouldRunAtTheEnd { get => true; }
    public bool Parse(string[] csvRecord, CSVAggregate agg)
    {
        var t = agg.Filtered.Sum(c => Convert.ToDecimal(c[0]));
        agg.Result.Add(new string[] { t.ToString() });
        return true;
    }
}
