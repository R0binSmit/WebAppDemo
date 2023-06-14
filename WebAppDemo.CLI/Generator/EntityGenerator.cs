namespace WebAppDemo.CLI.Generator;

internal class EntityGenerator : IGenerator
{
    public void Generate(string[] args)
    {
        Console.WriteLine($"Generating Enity: {args[2]}");
    }
}
