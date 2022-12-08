namespace adventofcode2022.Day7;

public class TreeNode  
{
    public TreeNode(string name, bool isFile, int value = 0)
    {
        IsFile = isFile;
        DisplayName = name;
        Size = value;
    }

    public string DisplayName { get; }
    public bool IsFile { get; }
    public int Size { get; set; }
    public List<TreeNode> Children { get; } = new();
    public TreeNode? Parent { get; private set; } //null if root
    public void AddChild (TreeNode child)   
    {  
        child.Parent = this;  
        Children.Add(child);  
    }
}  