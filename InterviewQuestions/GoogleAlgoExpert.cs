namespace ConsoleApp1.InterviewQuestions;

using System.Linq;
using Amenity = string;

// question: https://www.youtube.com/watch?v=rw4s4M3hFfs
internal class GoogleAlgoExpert
{
    public static void Test()
    {
        List<ApartmentBlockType> blocks =
        [
            new ApartmentBlockType(["school"]),
            new ApartmentBlockType(["gym"]),
            new ApartmentBlockType(["school", "gym"]),
            new ApartmentBlockType(["school"]),
            new ApartmentBlockType(["school", "store", "office"]),
        ];

        Amenity[] requests1 = ["school", "store"];
        Amenity[] requests2 = ["gym", "school", "store", "office"];

        Console.WriteLine(MinumumFurthestDistance(blocks, requests2));
    }

    /// <summary>
    /// Find the apartment block with minimum max distance to all ameneties
    /// </summary>
    public static int MinumumFurthestDistance(
        List<ApartmentBlockType> blocks,
        Amenity[] requestedAmenities
    )
    {
        var blocksWithIndex = blocks.Select((b, i) => (block: b, idx: i)).ToList();

        var (block, index, distance) = blocks
            .Select(
                (b, idx) =>
                {
                    var furthestAmenityDistance = requestedAmenities
                        .Select(amenity =>
                        {
                            var minDistanceForCurrentAmenity = blocks
                                .Select((b, i) => (block: b, index: i))
                                .Where(x => x.block.ContainsAmenety(amenity))
                                .Select(x => Math.Abs(x.index - idx))
                                .Order()
                                .FirstOrDefault(int.MaxValue);

                            return (amenity, distance: minDistanceForCurrentAmenity);
                        })
                        .Select(x => x.distance)
                        .OrderDescending()
                        .FirstOrDefault(int.MaxValue);

                    return (block: b, index: idx, distance: furthestAmenityDistance);
                }
            )
            .OrderBy(x => x.distance)
            .FirstOrDefault();

        return index;
    }
}

public record ApartmentBlockType(Amenity[] Ameneties);

public static class ApartmentBlock
{
    public static bool ContainsAmenety(this ApartmentBlockType block, Amenity amenety) =>
        block.Ameneties.Contains(amenety);

    public static int DistanceBetweenBlock(
        this IEnumerable<ApartmentBlockType> blocks,
        ApartmentBlockType block1,
        ApartmentBlockType block2
    )
    {
        var result = blocks.Select((b, i) => (block: b, position: i));

        return 1;
    }
}
