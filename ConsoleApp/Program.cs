class Program
{
    private static readonly string _penguin = "Penguin";

    static void Main(string[] args)
    {
        Dictionary<int, List<string>> zooCages = new(){
            {1, new List<string>(){"Lion", "Tiger"}},
            {2, new List<string>(){"Elephant", "Penguin", "Snake"}},
            {3, new List<string>(){"Penguin", "Seal", "Penguin"}},
            {4, new List<string>(){"Monkey", "Penguin", "Giraffe"}},
            {5, new List<string>()}
        };

        PrintCollection(zooCages);

        TestDelegateMethod(zooCages);
        TestAnonymousMethod(zooCages);
        TestLambdaExpression(zooCages);
        TestExtensionMethod(zooCages);

        PrintCollection(zooCages);

        TestLINQ(zooCages);
    }

    delegate void AnimalRemover(Dictionary<int, List<string>> collection, string animalToRemove);

    static void TestDelegateMethod(Dictionary<int, List<string>> zooCages)
    {
        AnimalRemover remover = RemoveAnimal;

        remover(zooCages, _penguin);
    }

    static void RemoveAnimal(Dictionary<int, List<string>> cages, string animalToRemove)
    {
        foreach (var cage in cages)
        {
            List<string> animals = cage.Value;
            for (int i = animals.Count - 1; i >= 0; i--)
            {
                if (animals[i] == animalToRemove)
                {
                    animals.RemoveAt(i);
                }
            }
        }
    }

    static void TestAnonymousMethod(Dictionary<int, List<string>> zooCages)
    {
        AnimalRemover remover = delegate (Dictionary<int, List<string>> cages, string animalToRemove)
        {
            foreach (var cage in cages)
            {
                List<string> animals = cage.Value;
                for (int i = animals.Count - 1; i >= 0; i--)
                {
                    if (animals[i] == animalToRemove)
                    {
                        animals.RemoveAt(i);
                    }
                }
            }
        };

        remover(zooCages, _penguin);
    }

    static void TestLambdaExpression(Dictionary<int, List<string>> zooCages)
    {
        AnimalRemover remover = (collection, animalToRemove) =>
        {
            foreach (var cage in collection)
            {
                collection[cage.Key] = cage.Value.Where(animal => animal != animalToRemove).ToList();
            }
        };
        remover(zooCages, _penguin);
    }

    static void TestExtensionMethod(Dictionary<int, List<string>> zooCages)
    {
        zooCages.RemoveAnimal(_penguin);
    }

    static void TestLINQ(Dictionary<int, List<string>> zooCages)
    {
        var removedPenguinsZoo = zooCages
            .Select(cage => new { CageNumber = cage.Key, Animals = cage.Value.Where(animal => animal != _penguin).ToList() })
            .ToDictionary(item => item.CageNumber, item => item.Animals);

        PrintCollection(removedPenguinsZoo);
    }

    static void PrintCollection(Dictionary<int, List<string>> zooCages)
    {
        Console.WriteLine("Zoo cages:");
        foreach (var cage in zooCages)
        {
            Console.WriteLine($"Cage {cage.Key}: {string.Join(", ", cage.Value)}");
        }
        Console.WriteLine();
    }
}