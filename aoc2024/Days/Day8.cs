namespace Aoc2024;

public class Day8(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var map = lines.Select(it => it.ToCharArray()).ToArray();

        var nodeDictionary = BuildNodeDictionary(map);

        HashSet<(int, int)> antiNodes = [];

        foreach (var key in nodeDictionary.Keys)
        {
            var keyNodes = GetAntiNodes(nodeDictionary[key], map.Length, map[0].Length);
            antiNodes.UnionWith(keyNodes);
        }

        return antiNodes.Count;
    }

    public override long Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var map = lines.Select(it => it.ToCharArray()).ToArray();

        var nodeDictionary = BuildNodeDictionary(map);

        HashSet<(int, int)> antiNodes = [];

        foreach (var key in nodeDictionary.Keys)
        {
            var keyNodes = GetResonantAntiNodes(nodeDictionary[key], map.Length, map[0].Length);
            antiNodes.UnionWith(keyNodes);
        }

        return antiNodes.Count;
    }

    private static Dictionary<char, List<(int, int)>> BuildNodeDictionary(char[][] map)
    {
        Dictionary<char, List<(int row, int col)>> nodeDictionary = [];
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] != '.')
                {
                    if (nodeDictionary.TryGetValue(map[row][col], out var nodes))
                    {
                        nodes.Add((row, col));
                    }
                    else
                    {
                        nodeDictionary.Add(map[row][col], [(row, col)]);
                    }
                }
            }
        }
        return nodeDictionary;
    }

    private static bool MapContains((int, int) node, int gridRows, int gridCols)
    {
        return node.Item1 >= 0 && node.Item1 < gridRows && node.Item2 >= 0 && node.Item2 < gridCols;
    }

    private static HashSet<(int, int)> GetAntiNodes(List<(int, int)> nodes, int gridRows, int gridCols)
    {
        if (nodes.Count == 1)
        {
            return [];
        }

        var node = nodes[0];
        var remainingNodes = nodes.Skip(1).ToList();

        var antiNodes = new HashSet<(int, int)>();

        foreach (var pairedNode in remainingNodes)
        {
            (int, int) delta = (pairedNode.Item1 - node.Item1, pairedNode.Item2 - node.Item2);
            for (var row = 0; row < gridRows; row++)
            {
                for (var col = 0; col < gridCols; col++)
                {
                    var rowDelta = (row - node.Item1) * delta.Item2;
                    var colDelta = (col - node.Item2) * delta.Item1;
                    if (rowDelta == colDelta)
                    {
                        if (CheckCandidateNode(node, pairedNode, (row, col)))
                        {
                            antiNodes.Add((row, col));
                        }
                    }
                }
            }
        }

        antiNodes.UnionWith(GetAntiNodes(remainingNodes, gridRows, gridCols));

        return antiNodes;
    }

    private static bool CheckCandidateNode((int, int) node1, (int, int) node2, (int, int) candidateNode)
    {
        var distance1 = Math.Sqrt(Math.Pow(candidateNode.Item1 - node1.Item1, 2) + Math.Pow(candidateNode.Item2 - node1.Item2, 2));
        var distance2 = Math.Sqrt(Math.Pow(candidateNode.Item1 - node2.Item1, 2) + Math.Pow(candidateNode.Item2 - node2.Item2, 2));

        return distance1 == 2 * distance2 || distance2 == 2 * distance1;
    }

    private static HashSet<(int, int)> GetResonantAntiNodes(List<(int, int)> nodes, int gridRows, int gridCols)
    {
        var antiNodes = new HashSet<(int, int)>();
        foreach (var start in nodes)
        {
            foreach (var other in nodes)
            {
                if (start == other)
                {
                    continue;
                }

                var delta = (other.Item1 - start.Item1, other.Item2 - start.Item2);

                var current = start;
                while (MapContains(current, gridRows, gridCols))
                {
                    antiNodes.Add(current);
                    current = (current.Item1 + delta.Item1, current.Item2 + delta.Item2);
                }

            }
        }
        return antiNodes;
    }
}