
/// <summary>
/// CSVAggregate Holds all the records that were processed allready.
/// </summary>
public class CSVAggregate
{
    /// <summary>
    /// Holds the records that were filtered by the parsers.
    /// </summary>
    public List<string[]> Filtered { get; set; } = new List<string[]>();

    /// <summary>
    /// Holds the end result after all processors ran. this is a list of strings
    /// </summary>
    public List<string[]> Result { get; set; } = new List<string[]>();

    /// <summary>
    /// AddOrUpdate the processed record. for the first parser in the pipeline we will need to add this record, 
    /// but for the other parsers we will need to update it.
    /// </summary>
    public void AddOrUpdate( string[] record, bool shouldAdd)
    {
        if (shouldAdd)
        {
            Filtered.Add(record);
        }
        else
        {
            Filtered[Filtered.Count-1] = record;
        }
    }
}
