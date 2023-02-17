namespace Day7;

public class DirectoryTree
{
    public DirectoryTree(string name) : this (name, null) { }

    public DirectoryTree(string name, DirectoryTree? parent)
    {
        Name = name;
        Parent = parent;
    }

    public string Name { get; }

    public DirectoryTree? Parent { get; }

    public List<DirectoryTree> Subdirectories { get; } = new ();

    public List<File> Files { get; } = new ();

    public long GetTotalDiskSize()
    {
        var subdirectorySize = Subdirectories.Sum(sd => sd.GetTotalDiskSize());
        var fileSize = Files.Sum(f => f.Size);

        return subdirectorySize + fileSize;
    }

    public List<DirectoryTree> Flatten()
    {
        var directories = Subdirectories.SelectMany(sd => sd.Flatten()).ToList();
        directories.Add(this);

        return directories;
    }
}
