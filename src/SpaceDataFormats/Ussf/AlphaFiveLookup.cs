namespace NickSpace.SpaceDataFormats.Ussf
{
    internal static class AlphaFiveLookup
    {
        internal static Dictionary<char, ushort> AlphaToNumTable { get; } = new Dictionary<char, ushort>(){
        { 'A', 10},
        { 'B', 11},
        { 'C', 12},
        { 'D', 13},
        { 'E', 14},
        { 'F', 15},
        { 'G', 16},
        { 'H', 17},
        { 'J', 18},
        { 'K', 19},
        { 'L', 20},
        { 'M', 21},
        { 'N', 22},
        { 'P', 23},
        { 'Q', 24},
        { 'R', 25},
        { 'S', 26},
        { 'T', 27},
        { 'U', 28},
        { 'V', 29},
        { 'W', 30},
        { 'X', 31},
        { 'Y', 32},
        { 'Z', 33}
      };
        internal static Dictionary<ushort, char> NumToAlphaTable { get; } = new Dictionary<ushort, char>(){
        { 10, 'A'},
        { 11, 'B'},
        { 12, 'C'},
        { 13, 'D'},
        { 14, 'E'},
        { 15, 'F'},
        { 16, 'G'},
        { 17, 'H'},
        { 18, 'J'},
        { 19, 'K'},
        { 20, 'L'},
        { 21, 'M'},
        { 22, 'N'},
        { 23, 'P'},
        { 24, 'Q'},
        { 25, 'R'},
        { 26, 'S'},
        { 27, 'T'},
        { 28, 'U'},
        { 29, 'V'},
        { 30, 'W'},
        { 31, 'X'},
        { 32, 'Y'},
        { 33, 'Z'}
      };
    }
}
