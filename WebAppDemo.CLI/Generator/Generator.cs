namespace WebAppDemo.CLI.Generator;

internal static class Generator
{
    public static void Generate(string[] args)
    {
        validateArgs(args);
        IGenerator? generator = defineGenerator(args);

        if (generator == null)
        {
            Console.WriteLine("Generationtype is unsupported.");
            Environment.Exit(0);
        }

        generator.Generate(args);
    }

    private static void validateArgs(string[] mainArgs)
    {
        if (mainArgs.Length <= 1)
        {
            Console.WriteLine("Generationtype needed.");
            Environment.Exit(0);
        }

        if(mainArgs.Length <= 2) 
        {
            Console.WriteLine("Name of generated File needed.");
            Environment.Exit(0);
        }
    }

    private static IGenerator? defineGenerator(string[] mainArgs)
    {
        switch (mainArgs[1].ToLower())
        {
            case "entity":
                return new EntityGenerator();
            default:
                return null;
        }
    }
}
