using System.Collections.Generic;

namespace Saves.MenuSaveManager
{
    public class RandomNameGenerator
    {
        private string[] randomNames;
        private List<string> chosenNames = new List<string>();

        public RandomNameGenerator(string[] names)
        {
            randomNames = names;
        }

        // Возвращает уникальное имя из списка имен
        public string GetUniqueRandomName()
        {
            if (chosenNames.Count >= randomNames.Length)
            {
                return "Anonymous";
            }

            int randomIndex;
            string name;

            do
            {
                randomIndex = UnityEngine.Random.Range(0, randomNames.Length);
                name = randomNames[randomIndex];
            } while (chosenNames.Contains(name));

            chosenNames.Add(name);

            return name;
        }
    }
}