using CsvHelper;
using System.Globalization;

using (var reader = new StreamReader("enrollees.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var enrollees = csv.GetRecords<Enrollee>();
    var enrolleesGroupedByCompany = enrollees.GroupBy(e => e.Company);

    foreach(var company in enrolleesGroupedByCompany) {
        var enrolleeMap = new Dictionary<string, Enrollee>();

        foreach(var enrollee in company) {
            if (enrolleeMap.ContainsKey(enrollee.UserId)) {
                if (enrollee.Version > enrolleeMap[enrollee.UserId].Version) {
                    enrolleeMap[enrollee.UserId] = enrollee;
                }
            } else {
                enrolleeMap.Add(enrollee.UserId, enrollee);
            }
        }

        var sortedEnrollees = enrolleeMap.Values.OrderBy(e => e.LastName).OrderBy(e => e.FirstName);
        var outputFileName = string.Format("{0}-enrollees.csv", company.Key);

        using (var writer = new StreamWriter(outputFileName))
        using (var outputCsv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            outputCsv.WriteRecords(sortedEnrollees);
        }
    }
}