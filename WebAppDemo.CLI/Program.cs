using System.Reflection;

namespace WebAppDemo.CLI;

public class Program
{
    private static string? solutionDir = null;
    public static void Main(string[] args)
    {
        solutionDir= GetSolutionRootDirectory();

        if (solutionDir == null)
        {
            Console.WriteLine("Can't finde solution root.");
            return;
        }

        if (args.Length == 0)
        {
            Console.WriteLine("There is no action parameter given.");
            return;
        }

        var actionParameter = GetActionParameter(args[0]);

        if(actionParameter == null)
        {
            Console.WriteLine("Given action parameter is not supported.");
            return;
        }

        ExecuteAction(actionParameter, args);

    }

    private static ActionType? GetActionParameter(string? actionParameter)
    {
        switch(actionParameter.ToLower())
        {
            case "generate":
                return ActionType.generate;
            default: return null;
        }
    }

    private static string? GetSolutionRootDirectory()
    {
        int numberOfTries = 7;
        string currentLocation = NavigateUp(Assembly.GetEntryAssembly().Location);
        string searchedFileName = "WebAppDemo.sln";
        bool fileFound = false;

        while (fileFound == false || numberOfTries > 0)
        {
            var filePath = Path.GetFullPath(Path.Combine(currentLocation, searchedFileName));
            fileFound = File.Exists(filePath);

            if(fileFound == false)
            {
                currentLocation = NavigateUp(currentLocation);
            }
            else
            {
                return currentLocation;
            }

            numberOfTries--;
        }

        return null;
    }

    private static string NavigateUp(string path)
    {
        return Path.GetFullPath(Path.Combine(path, @"..\"));
    }

    private static void ExecuteAction(ActionType? actionType, string[] args)
    {
        if(actionType == null)
        {
            return;
        }

        switch (actionType)
        {
            case ActionType.generate:
                Generator.Generator.Generate(args);
                break;
            default: return;
        }
    }
}
