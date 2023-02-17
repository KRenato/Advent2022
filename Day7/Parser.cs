using Common;

namespace Day7;

public class Parser : IParser<DirectoryTree>
{
    public DirectoryTree Parse(string[] input)
    {
        var topLevel = new DirectoryTree("/");
        DirectoryTree currentDirectory = topLevel;

        int i = 0;

        while (i < input.Length)
        {
            var item = input[i];
            switch (item)
            {
                case "$ cd /":
                    currentDirectory = topLevel;
                    i++;
                    break;
                case "$ cd ..":
                    currentDirectory = currentDirectory.Parent ?? topLevel;
                    i++;
                    break;
                case "$ ls":
                    i = MapDirectoryAndReturnNextIndex(currentDirectory, input, i + 1);
                    break;
                default:
                    var parsedDirectoryName = item[5..];
                    currentDirectory = currentDirectory.Subdirectories.First(sd => sd.Name == parsedDirectoryName);
                    i++;
                    break;
            }
        }

        return topLevel;
    }

    private static int MapDirectoryAndReturnNextIndex(DirectoryTree directory, string[] input, int index)
    {
        while (index < input.Length)
        {
            string item = input[index];
            if (item.Contains('$'))
            {
                break;
            }

            if (item[..3] == "dir")
            {
                var subdirectory = new DirectoryTree(item[4..], directory);
                directory.Subdirectories.Add(subdirectory);

                index++;
                continue;
            }

            var file = ParseFile(item);
            directory.Files.Add(file);

            if (index == input.Length - 1)
            {
                index = int.MaxValue;
                break;
            }

            index++;
        }

        return index;
    }

    private static File ParseFile(string input)
    {
        var parsedInput = input.Split(' ');
        int fileSize = int.Parse(parsedInput[0]);

        return new File(parsedInput[1], fileSize);
    }
}
