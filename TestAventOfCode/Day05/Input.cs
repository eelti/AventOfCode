namespace TestAventOfCode.Day05;

public static class Input
{
    public static List<Map> GetMaps()
    {
        return new List<Map>()
        {
// seed-to-soil map:
// 50 98 2
// 52 50 48
//
// soil-to-fertilizer map:
// 0 15 37
// 37 52 2
// 39 0 15
//
// fertilizer-to-water map:
// 49 53 8
// 0 11 42
// 42 0 7
// 57 7 4
//
// water-to-light map:
// 88 18 7
// 18 25 70
//
// light-to-temperature map:
// 45 77 23
// 81 45 19
// 68 64 13
//
// temperature-to-humidity map:
// 0 69 1
// 1 0 69
//
// humidity-to-location map:
// 60 56 37
// 56 93 4

            new()
            {
                Type = "seed-to-soil map",
                Source = 98,
                Destination = 50,
                Duration = 2
            },
            new()
            {
                Type = "seed-to-soil map",
                Source = 50,
                Destination = 52,
                Duration = 48
            },
            new()
            {
                Type = "soil-to-fertilizer map",
                Source = 15,
                Destination = 0,
                Duration = 37
            },
            new()
            {
                Type = "soil-to-fertilizer map",
                Source = 52,
                Destination = 37,
                Duration = 2
            },
            new Map()
            {
                Type = "soil-to-fertilizer map",
                Source = 0,
                Destination = 39,
                Duration = 15
            },
            new Map()
            {
                Type = "fertilizer-to-water map",
                Source = 53,
                Destination = 49,
                Duration = 8
            },
            new Map()
            {
                Type = "fertilizer-to-water map",
                Source = 11,
                Destination = 0,
                Duration = 42
            },
            new Map()
            {
                Type = "fertilizer-to-water map",
                Source = 0,
                Destination = 42,
                Duration = 7
            },

            new Map()
            {
                Type = "fertilizer-to-water map",
                Source = 7,
                Destination = 57,
                Duration = 4
            },
            new Map()
            {
                Type = "water-to-light map",
                Source = 18,
                Destination = 88,
                Duration = 7
            },
            new Map()
            {
                Type = "water-to-light map",
                Source = 25,
                Destination = 18,
                Duration = 70
            },
            new Map()
            {
                Type = "light-to-temperature map",
                Source = 77,
                Destination = 23,
                Duration = 45
            },
            new Map()
            {
                Type = "light-to-temperature map",
                Source = 45,
                Destination = 81,
                Duration = 19
            },
            new Map()
            {
                Type = "light-to-temperature map",
                Source = 64,
                Destination = 68,
                Duration = 13
            },
            new Map()
            {
                Type = "temperature-to-humidity map",
                Source = 69,
                Destination = 0,
                Duration = 1
            },
            new Map()
            {
                Type = "temperature-to-humidity map",
                Source = 0,
                Destination = 1,
                Duration = 69
            },
            new Map()
            {
                Type = "humidity-to-location map",
                Source = 56,
                Destination = 60,
                Duration = 37
            },
            new Map()
            {
                Type = "humidity-to-location map",
                Source = 93,
                Destination = 56,
                Duration = 4
            }
        };
    }
}