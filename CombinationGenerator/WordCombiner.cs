namespace CombinationGenerator
{
    public static class WordCombiner
    {
        public static IEnumerable<string> GenerateCombinations(List<string> lines, int combinationLength)
        {
            var count = lines.Count();
            var resultList = new List<string>();
            var index = 0;

            foreach (var line in lines)
            {
                index++;
                var linesToAdd = lines.Where(l => l.Length <= combinationLength - line.Length && !line.Split("+").Contains(l)).Select(l => line + "+" + l).ToList();

                while (linesToAdd.Any(l => l.Replace("+", "").Length < combinationLength))
                {
                    IEnumerable<string> nestedLinesToAdd = new List<string>();
                    foreach (var nestedLineToAdd in linesToAdd.Where(l => l.Replace("+", "").Length < combinationLength)
                            )
                    {
                        nestedLinesToAdd = lines.Where(l => l.Length <= combinationLength - nestedLineToAdd.Replace("+", "").Length && !nestedLineToAdd.Split("+").Contains(l))
                            .Select(l => nestedLineToAdd + "+" + l);

                    }

                    linesToAdd.AddRange(nestedLinesToAdd);
                    linesToAdd = linesToAdd.Where(l => l.Replace("+", "").Length == combinationLength).ToList();
                }

                Console.WriteLine($"{index} of {count}");
                resultList.AddRange(linesToAdd);
            }

            return resultList.Distinct();
        }
    }
}
