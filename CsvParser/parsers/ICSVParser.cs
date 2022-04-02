
/// <summary>
/// A contract for implementing a csv parser
/// </summary>
public interface ICSVParser
{
    /// <summary>
    /// This method will parse a csv record and will add it to the CSVAggregate
    /// </summary>
    /// <param name="csvRecord">the records that was loaded from the csv, parsed by the csv delimiter</param>
    /// <param name="agg">the <see cref="CSVAggregate"/> that holds all the records that were processed allready</param>
    /// <returns></returns>
    bool Parse(string[] csvRecord, CSVAggregate agg );
    /// <summary>
    /// Indicates wheter this is the first parser.it will be used to indicate if we need to add or update the 
    /// </summary>
    bool IsFirstParser { get; set; }
    /// <summary>
    /// Indicates whether this parser should run only on the last record in the csv
    /// </summary>
    bool ShouldRunAtTheEnd { get; }
}
