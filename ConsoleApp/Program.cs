class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, List<String>> zooCages = new(){
            {1, new List<String>(){"Lion", "Tiger"}},
            {2, new List<String>(){"Elephant", "Penguin", "Snake"}},
            {3, new List<String>(){"Penguin", "Seal", "Penguin"}},
            {4, new List<String>(){"Monkey", "Penguin", "Giraffe"}},
            {5, new List<String>()}
        };

        PrintCollection(zooCages);

        // TestDelegateMethod(zooCages);
        // TestAnonymousMethod(zooCages);
        // TestLambdaExpression(zooCages);
        // TestExtensionMethod(zooCages);

        // PrintCollection(zooCages);

        TestLINQ(zooCages);
    }

    public delegate void ModifyCollection(Dictionary<int, List<String>> collection);

    static void TestDelegateMethod(Dictionary<int, List<String>> zooCages)
    {
        ModifyCollection modifier = RemovePenguins;
        modifier(zooCages);
    }

    static void TestAnonymousMethod(Dictionary<int, List<String>> zooCages)
    {
        ModifyCollection modifier = delegate (Dictionary<int, List<String>> collection)
        {
            foreach (var cage in collection)
            {
                collection[cage.Key] = cage.Value.Where(animal => animal != "Penguin").ToList();
            }
        };
        modifier(zooCages);
    }

    static void TestLambdaExpression(Dictionary<int, List<String>> zooCages)
    {
        ModifyCollection modifier = (collection) =>
        {
            foreach (var cage in collection)
            {
                collection[cage.Key] = cage.Value.Where(animal => animal != "Penguin").ToList();
            }
        };
        modifier(zooCages);
    }

    static void TestExtensionMethod(Dictionary<int, List<String>> zooCages)
    {
        zooCages.RemoveAnimal("Penguin");
    }

    static void TestLINQ(Dictionary<int, List<String>> zooCages)
    {
        foreach (var cage in zooCages)
        {
            zooCages[cage.Key] = cage.Value.Where(animal => animal != "Penguin").ToList();
        }

        PrintCollection(zooCages);
    }

    public static void RemovePenguins(Dictionary<int, List<String>> collection)
    {
        var removedPenguinsZoo = collection
            .Select(cage => new { CageNumber = cage.Key, Animals = cage.Value.Where(animal => animal != "Penguin").ToList() })
            .ToDictionary(item => item.CageNumber, item => item.Animals);

        PrintCollection(removedPenguinsZoo);
    }

    static void PrintCollection(Dictionary<int, List<String>> zooCages)
    {
        Console.WriteLine("Zoo cages:");
        foreach (var cage in zooCages)
        {
            Console.WriteLine($"Cage {cage.Key}: {String.Join(", ", cage.Value)}");
        }
        Console.WriteLine();
    }
}