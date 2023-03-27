using advent;
namespace adventTests;
public class Day7Tests
{
    private readonly string _input;
    private readonly string _inputSample = """
$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k
""";

    public Day7Tests()
    {
        _input = File.ReadAllText("Day7Input.txt");
    }

    [Fact]
    public void FindSmallestDirectoryGreaterThanAnswer()
    {
        const int expected = 12785886;
        var day7 = new Day7(_input);
        var root = day7.BuildMap();
        day7.CalculateSize(root);
        var directories = day7.FindDirectoriesWithSizeMatching(root, x => x >= 8381165);
        var directory = directories.OrderBy(x => x.Size).First();
        var actual = directory.Size;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FindSmallestDirectoryGreaterThanSample()
    {
        const int expected = 24933642;
        var day7 = new Day7(_inputSample);
        var root = day7.BuildMap();
        day7.CalculateSize(root);
        var directories = day7.FindDirectoriesWithSizeMatching(root, x => x >= 8381165);
        var directory = directories.OrderBy(x => x.Size).First();
        var actual = directory.Size;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FindSumOfSizeOfDirectoriesLessThan100kAnswer()
    {
        const int expected = 1348005;
        var day7 = new Day7(_input);
        var root = day7.BuildMap();
        day7.CalculateSize(root);
        var directories = day7.FindDirectoriesWithSizeMatching(root, x => x <= 100000);
        var actual = directories.Sum(x => x.Size);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FindSumOfSizeOfDirectoriesLessThan100kSample()
    {
        const int expected = 95437;
        var day7 = new Day7(_inputSample);
        var root = day7.BuildMap();
        day7.CalculateSize(root);
        var directories = day7.FindDirectoriesWithSizeMatching(root, x => x <= 100000);
        var actual = directories.Sum(x => x.Size);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EnterOrCreateDirectory_WhenNotExists()
    {
        var day7 = new Day7(_inputSample);
        var root = new Day7.Directory("/", null);
        // Create
        var directory = day7.EnterOrCreateDirectory(root, "a");
        Assert.Equal("a", directory.Name);
        Assert.Single(root.Directories);
        Assert.Empty(root.Directories[0].Directories);
    }

    [Fact]
    public void EnterOrCreateDirectory_WhenExists()
    {
        var day7 = new Day7(_inputSample);
        var root = new Day7.Directory("/", null);
        // Create
        var directory = day7.EnterOrCreateDirectory(root, "a");
        Assert.Equal("a", directory.Name);

        // When exists
        var directory2 = day7.EnterOrCreateDirectory(root, "a");
        Assert.Equal("a", directory.Name);
        Assert.Single(root.Directories);
        Assert.Equal("a", root.Directories[0].Name);
        Assert.Empty(root.Directories[0].Directories);
    }
}
