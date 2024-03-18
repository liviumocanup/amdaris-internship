public static class DictionaryExtenstions {
    public static void RemoveAnimal(this Dictionary<int, List<string>> collection, string animalToRemove)
    {
        foreach (var cage in collection)
        {
            collection[cage.Key] = cage.Value.Where(animal => animal != animalToRemove).ToList();
        }
    }
}