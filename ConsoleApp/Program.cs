class Program
{
    static void Main()
    {
        // LINQ Joins Examples
        Console.WriteLine("LINQ Join Methods Example:");
        JoinMethods();
        Console.WriteLine();

        // LINQ Grouping Examples
        Console.WriteLine("LINQ Grouping Example:");
        GroupByExample();
        Console.WriteLine();

        // LINQ Set Methods Examples
        Console.WriteLine("LINQ Set Methods Example:");
        SetMethods();
        Console.WriteLine();

        // LINQ Aggregation Methods Examples
        Console.WriteLine("LINQ Aggregation Method Example:");
        AggregationMethods();
        Console.WriteLine();

        // LINQ Quantifiers Methods Examples
        Console.WriteLine("LINQ Quantifiers Method Example:");
        QuantifiersMethods();
        Console.WriteLine();

        // LINQ Element Methods Examples
        Console.WriteLine("LINQ Element Method Example:");
        ElementMethods();
        Console.WriteLine();
    }

    static void JoinMethods()
    {
        // LINQ Join Examples
        Console.WriteLine("Join:\n```");
        JoinExample();
        Console.WriteLine("```\n");

        // LINQ GroupJoin Examples
        Console.WriteLine("GroupJoin:\n~~~");
        GroupJoinExample();
        Console.WriteLine("~~~\n");

        // LINQ Zip Examples
        Console.WriteLine("Zip:");
        ZipExample();
        Console.WriteLine("=====================================");
    }

    static void JoinExample()
    {
        var employees = new[]
        {
            new { Id = 1, Name = "Alice", DeptId = 1 },
            new { Id = 2, Name = "Bob", DeptId = 2 },
            new { Id = 3, Name = "John", DeptId = 4 }
        };

        var departments = new[]
        {
            new { DeptId = 1, DeptName = "HR" },
            new { DeptId = 2, DeptName = "IT" },
            new { DeptId = 3, DeptName = "Finance" },
        };

        var employeeDepartments = employees.Join(
            departments,
            emp => emp.DeptId,
            dept => dept.DeptId,
            (emp, dept) => new { emp.Name, Department = dept.DeptName }
        );

        foreach (var item in employeeDepartments)
        {
            Console.WriteLine($"{item.Name} works in {item.Department}");
        }
    }

    static void GroupJoinExample()
    {
        var categories = new[]
        {
            new { Id = 1, Name = "Beverages" },
            new { Id = 2, Name = "Condiments" },
            new { Id = 3, Name = "Dessert" }
        };

        var products = new[]
        {
            new { Name = "Tea", CategoryId = 1 },
            new { Name = "Mustard", CategoryId = 2 },
            new { Name = "Pepper", CategoryId = 2 },
            new { Name = "Coffee", CategoryId = 1 }
        };

        var categoryProducts = categories.GroupJoin(
            products,
            category => category.Id,
            product => product.CategoryId,
            (category, prods) => new { Category = category.Name, Products = prods }
        );

        foreach (var category in categoryProducts)
        {
            Console.WriteLine($"{category.Category}:");
            foreach (var product in category.Products)
            {
                Console.WriteLine($"  - {product.Name}");
            }
        }
    }

    static void ZipExample()
    {
        var firstNames = new[] { "John", "Jane", "Jim" };
        var lastNames = new[] { "Doe", "Smith", "Johnson" };

        var fullNames = firstNames.Zip(lastNames, (first, last) => $"{first} {last}");

        foreach (var name in fullNames)
        {
            Console.WriteLine(name);
        }
    }

    static void GroupByExample()
    {
        var fruits = new[]
        {
            new { Name = "Apple", Color = "Red" },
            new { Name = "Banana", Color = "Yellow" },
            new { Name = "Cherry", Color = "Red" },
            new { Name = "Grape", Color = "Green" },
            new { Name = "Lemon", Color = "Yellow" }
        };

        var groupedByColor = fruits.GroupBy(fruit => fruit.Color);

        foreach (var colorGroup in groupedByColor)
        {
            Console.WriteLine($"{colorGroup.Key}:");
            foreach (var fruit in colorGroup)
            {
                Console.WriteLine($"  - {fruit.Name}");
            }
        }
    }

    static void SetMethods()
    {
        ConcatExample();

        UnionExample();

        IntersectExample();

        ExceptExample();
    }

    static void ConcatExample()
    {
        string[] first = { "1", "2", "3" };
        string[] second = { "a", "b", "c" };

        var combined = first.Concat(second);

        Console.Write("Concat: ");
        foreach (var word in combined)
        {
            Console.Write($"{word} ");
        }
        Console.WriteLine();
    }

    static void UnionExample()
    {
        int[] first = { 1, 2, 3, 2 };
        int[] second = { 3, 4, 5 };

        var combinedUnique = first.Union(second);

        Console.Write("Union: ");
        foreach (var number in combinedUnique)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }

    static void IntersectExample()
    {
        int[] first = { 1, 2, 3 };
        int[] second = { 2, 3, 4 };

        var common = first.Intersect(second);

        Console.Write("Intersect: ");
        foreach (var number in common)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }

    static void ExceptExample()
    {
        int[] first = { 1, 2, 3, 4 };
        int[] second = { 3, 4, 5, 6 };

        var exclusiveToFirst = first.Except(second);

        Console.Write("Except: ");
        foreach (var number in exclusiveToFirst)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }

    static void AggregationMethods()
    {
        int[] numbers = { 5, 4, 1, 3, 9 };

        int evenNumbersCount = numbers.Count(n => n % 2 == 0);
        Console.WriteLine($"Count of even numbers: {evenNumbersCount}");

        int minNumber = numbers.Min();
        Console.WriteLine($"Minimum number: {minNumber}");

        int maxNumber = numbers.Max();
        Console.WriteLine($"Maximum number: {maxNumber}");

        int total = numbers.Sum();
        Console.WriteLine($"Sum of all numbers: {total}");

        double average = numbers.Average();
        Console.WriteLine($"Average of all numbers: {average}");

        int product = numbers.Aggregate((currentProduct, nextNumber) => currentProduct * nextNumber);
        Console.WriteLine($"Product of all numbers: {product}");
    }

    static void QuantifiersMethods()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int[] secondSequence = { 1, 2, 3, 4, 5 };

        bool containsThree = numbers.Contains(3);
        Console.WriteLine($"Does the sequence contain the number 3? {containsThree}");

        bool hasEvenNumber = numbers.Any(n => n % 2 == 0);
        Console.WriteLine($"Does the sequence contain any even numbers? {hasEvenNumber}");

        bool areAllNumbersEven = numbers.All(n => n % 2 == 0);
        Console.WriteLine($"Are all numbers in the sequence even? {areAllNumbersEven}");

        bool sequencesAreEqual = numbers.SequenceEqual(secondSequence);
        Console.WriteLine($"Are the two sequences equal? {sequencesAreEqual}");
    }

    static void ElementMethods()
    {
        int[] numbers = Enumerable.Range(1, 5).ToArray();
        int[] emptyArray = Enumerable.Empty<int>().ToArray();

        int firstNumber = numbers.First();
        Console.WriteLine($"First number: {firstNumber}");

        int firstOrDefault = emptyArray.FirstOrDefault();
        Console.WriteLine($"First number (or default): {firstOrDefault}");

        int lastNumber = numbers.Last();
        Console.WriteLine($"Last number: {lastNumber}");

        int lastNumberOrDefault = emptyArray.LastOrDefault();
        Console.WriteLine($"Last number (or default): {lastNumberOrDefault}");

        int singleNumber = numbers.Single(n => n == 3);
        Console.WriteLine($"Single number: {singleNumber}");

        int singleOrDefault = emptyArray.SingleOrDefault();
        Console.WriteLine($"Single number (or default): {singleOrDefault}");

        int elementAt = numbers.ElementAt(2);
        Console.WriteLine($"Element at index 2: {elementAt}");

        int elementAtOrDefault = emptyArray.ElementAtOrDefault(2);
        Console.WriteLine($"Element at index 2 (or default): {elementAtOrDefault}");

        IEnumerable<int> defaultIfEmpty = numbers.DefaultIfEmpty(10);
        Console.WriteLine($"First element (or default): {defaultIfEmpty.First()}");
    }
}
