public static class DictionaryExtenstions {
    public static void RemoveAnimal(this Dictionary<int, List<String>> collection, string animal)
    {
        foreach (var cage in collection)
        {
            collection[cage.Key] = cage.Value.Where(x => x != animal).ToList();
        }
    }
}