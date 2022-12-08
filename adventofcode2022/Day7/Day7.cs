using adventofcode2022.Helpers;

namespace adventofcode2022.Day7;

public class Day7
{
    private readonly IReadInputFile _readInputFile;
    private int[] _listOfValuesUnderLimit = { };
    private TreeNode _root;
    
    public Day7(IReadInputFile readInputFile)
    {
        _readInputFile = readInputFile;
    }

    public string Part1()
    {
        var rawStrings = _readInputFile.GetListOfStringsFromInput(@"Day7\input.txt").ToArray();
        _root = CreateTree(rawStrings);
        
        // Dont care about y, the function makes _root into a weighted graph
        var y = SumAllNodes(_root);

        return _listOfValuesUnderLimit.Sum().ToString();
    }

    public string Part2()
    {
        var spaceRequired = 30000000 - (70000000 - _root.Size);
        var smallestFound = FindSmallestDirectory(_root, spaceRequired, _root.Size);
        
        return smallestFound.ToString();
    }

    private int FindSmallestDirectory(TreeNode node, int neededSpace, int smallestFound) => 
        node.Children.Select(child => 
            (!child.IsFile && child.Size > neededSpace && child.Size < smallestFound)
                ? Math.Min(child.Size, FindSmallestDirectory(child, neededSpace, smallestFound)) 
                : smallestFound).Min();
    
    
    private int SumAllNodes(TreeNode node)
    {
        node.Size += node.Children.Select(childNode => childNode.IsFile ? childNode.Size : SumAllNodes(childNode)).Sum();
        if (node.Size < 100000) _listOfValuesUnderLimit = _listOfValuesUnderLimit.Append(node.Size).ToArray();
        return node.Size;
    }
    
    private TreeNode CreateTree(string[] rawStrings)
    {
        var root = new TreeNode("/", false);
        var currentTree = root;
        foreach (var line in rawStrings.Skip(1))
        {
            var lineSplit = line.Split(" "); 
            if (line == "$ cd /") 
                currentTree = root;
            if (lineSplit[1] == "cd" && lineSplit[2] != "/" && lineSplit[2] != "..") 
                currentTree = currentTree!.Children.Find(x => x.DisplayName == lineSplit[2]);
            if (lineSplit[1] == "cd" && lineSplit[2] != "/" && lineSplit[2] == "..") 
                currentTree = currentTree!.Parent;
            if (lineSplit[0] != "$" && lineSplit[0] != "dir")
                currentTree!.AddChild(new TreeNode(lineSplit[1], true, Int32.Parse(lineSplit[0])));
            if (lineSplit[0] != "$" && lineSplit[0] == "dir")
                currentTree!.AddChild(new TreeNode(lineSplit[1], false));
        }

        return root;
    }
}