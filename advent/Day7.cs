namespace advent;
public class Day7
{
    private readonly string[] _input;

    public Day7(string input)
    {
        _input = input.Split(Environment.NewLine);
    }

    public sealed class Directory
    {
        public Directory(string name, Directory? parent)
        {
            Name = name;
            Parent = parent;
            Directories = new List<Directory>();
            Files = new List<File>();
        }
        public string Name { get; set; }
        public int Size { get; set; }
        public Directory? Parent { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files { get; set; }
    }

    public record File(string Name, int Size);

    public Directory BuildMap()
    {
        var currentDirectory = new Directory("/", null);
        foreach (var line in _input)
        {
            if (line.StartsWith("$"))
            {
                currentDirectory = HandleCommand(currentDirectory, line);
            }
            else
            {
                HandleFileOrDirectory(currentDirectory, line);
            }
        }

        while (currentDirectory.Parent != null)
        {
            currentDirectory = currentDirectory.Parent;
        }
        return currentDirectory;
    }

    public void CalculateSize(Directory directory)
    {
        foreach (var subDirectory in directory.Directories)
        {
            CalculateSize(subDirectory);
            directory.Size += subDirectory.Size;
        }
        foreach (var file in directory.Files)
        {
            directory.Size += file.Size;
        }
    }

    // Find direcories with maxSize < x
    public IList<Directory> FindDirectoriesWithSizeMatching(Directory directory, Func<int, bool> predicate)
    {
        var result = new List<Directory>();
        if (predicate(directory.Size))
        {
            result.Add(directory);
        }
        foreach (var subDirectory in directory.Directories)
        {
            var subResult = FindDirectoriesWithSizeMatching(subDirectory, predicate);
            result.AddRange(subResult);
        }
        return result;
    }

    public Directory HandleCommand(Directory currentDirectory, string line)
    {
        var command = line.Split(" ");
        if (command[1] == "ls")
        {
            return currentDirectory;
        }
        else if (command[1] == "cd")
        {
            return HandleCdCommand(currentDirectory, command);
        }
        else
        {
            throw new ArgumentException($"Unknown command: {line}");
        }
    }

    public Directory HandleCdCommand(Directory currentDirectory, string[] command)
    {
        if (command[2] == "..")
        {
            return currentDirectory.Parent!;
        }
        else if (command[2] == currentDirectory.Name)
        {
            return currentDirectory;
        }
        else
        {
            return EnterOrCreateDirectory(currentDirectory, command[2]);
        }
    }

    public Directory EnterOrCreateDirectory(Directory currentDirectory, string directoryName)
    {
        var directory = currentDirectory.Directories.FirstOrDefault(d => d.Name == directoryName);
        if (directory == null)
        {
            directory = new Directory(directoryName, currentDirectory);
            currentDirectory.Directories.Add(directory);
        }
        return directory;
    }

    public void HandleFileOrDirectory(Directory currentDirectory, string line)
    {
        /*
dir e
29116 f
        */
        try
        {
            if (string.IsNullOrEmpty(line))
            {
                return;
            }

            var parts = line.Split(" ");
            if (parts[0] == "dir")
            {
                var directory = new Directory(parts[1], currentDirectory);
                currentDirectory.Directories.Add(directory);
            }
            else
            {
                var file = new File(parts[1], int.Parse(parts[0]));
                currentDirectory.Files.Add(file);
            }
        }
        catch
        {
            Console.WriteLine($"Error parsing line: {line}");
            throw;
        }
    }
}
