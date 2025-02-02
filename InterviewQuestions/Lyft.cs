namespace Leetcode.InterviewQuestions;

using Shift = List<(int Start, int End)>;

internal class Lyft
{
    // Return true if the driver has driven less than 12 hours since their last 8 hour break
    //private static bool CanDrive(Shift shift, int timeRange)
    //{
    //    var had8HourBreak =
    //        shift
    //            .Zip(
    //                shift.Skip(1),
    //                (first, second) =>
    //                {
    //                    return second.Start - first.End >= 8;
    //                }
    //            )
    //            .Any(x => x == true)
    //        || timeRange - shift.Last().End >= 8;

    //    var worked12HoursOrMore = shift.Select(s => s.End - s.Start).Sum() >= 12;

    //    return (worked12HoursOrMore, had8HourBreak) switch
    //    {
    //        (true, true) => true,
    //        (false, _) => true,
    //        _ => false,
    //    };
    //}

    private static bool CanDrive(Shift shift, int timeRange)
    {
        var (totalDriveTime, totalGapTime) = shift
            .Zip(
                shift.Skip(1).Append((Start: timeRange, End: timeRange)),
                (first, other) =>
                    (DriveTime: first.End - first.Start, GapTime: other.Start - first.End)
            )
            .Aggregate(
                (DriveTime: 0, GapTime: 0),
                (acc, times) =>
                    (
                        DriveTime: acc.DriveTime + times.DriveTime,
                        GapTime: acc.GapTime + (times.GapTime >= 8 ? times.GapTime : 0)
                    )
            );

        return (totalDriveTime >= 12, totalGapTime >= 8) switch
        {
            (true, true) => true,
            (false, _) => true,
            _ => false,
        };
    }

    public static void CanDrive()
    {
        List<Shift> values =
        [
            [(2, 6), (14, 24)], // true
            [(2, 8), (12, 16), (20, 22)], // false
            [(0, 4), (6, 10), (12, 16)], // true
        ];

        values.Select(s => CanDrive(s, 24)).ToList().ForEach(Console.WriteLine);
    }
}
