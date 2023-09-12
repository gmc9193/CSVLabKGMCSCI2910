using System.Globalization;
using System.Xml.Linq;

namespace CSVLab;

public class Videogame : IComparable
{
    public string Name { get; set; }
    public string Platform { get; set; }
    public DateOnly Year { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public float NaSales { get; set; }
    public float EuSales { get; set; }
    public float JpSales { get; set; }
    public float OtherSales { get; set; }
    public float GlobalSales { get; set; }

    public Videogame(string csvInput)
    {
        var elements = csvInput.Split(',');
        Name = elements[0];
        Platform = elements[1];
        Year = DateOnly.Parse("01/01/" + elements[2]);
        Genre = elements[3];
        Publisher = elements[4];
        NaSales = float.Parse(elements[5]);
        EuSales = float.Parse(elements[6]);
        JpSales = float.Parse(elements[7]);
        OtherSales = float.Parse(elements[8]);
        GlobalSales = float.Parse(elements[9]);
    }


public override string ToString()
{
    return $"{nameof(Name)}: {Name}, " +
           $"{nameof(Platform)}: {Platform}, " +
           $"{nameof(Year)}: {Year}, " +
           $"{nameof(Genre)}: {Genre}, " +
           $"{nameof(Publisher)}: {Publisher}, " +
           $"{nameof(NaSales)}: {NaSales.ToString("F2", CultureInfo.InvariantCulture)}, " +
           $"{nameof(EuSales)}: {EuSales.ToString("F2", CultureInfo.InvariantCulture)}, " +
           $"{nameof(JpSales)}: {JpSales.ToString("F2", CultureInfo.InvariantCulture)}, " +
           $"{nameof(OtherSales)}: {OtherSales.ToString("F2", CultureInfo.InvariantCulture)}, " +
           $"{nameof(GlobalSales)}: {GlobalSales.ToString("F2", CultureInfo.InvariantCulture)}";
}
    public int CompareTo(object? obj)
    {
        if (obj is Videogame vid)
        {
            return string.Compare(this.Name, vid.Name, StringComparison.InvariantCultureIgnoreCase);
        }
        return -1;
    }
}