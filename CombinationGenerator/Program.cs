namespace CombinationGenerator
{
    internal class Program
    {
        static void Main()
        {
            var fileloc = Directory.GetCurrentDirectory() + @"/input.txt";
            var lines = File.ReadLines(fileloc).ToList();
            var resultList = WordCombiner.GenerateCombinations(lines, 3);

            foreach (var combination in resultList)
            {
                Console.Write($"\t{combination}={combination.Replace("+", "")}");
            }

            Console.WriteLine($"\nTotal results count: {resultList.Count()}");

            Console.WriteLine(
                $"Total double combinations count {resultList.GroupBy(x => x.Replace("+", "")).Count()}");

            Console.WriteLine(
                $"The output has also been written to output.txt");

            using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"/output.txt"))
            {

                foreach (var combination in resultList)
                {
                    writer.Write($"\n{combination}={combination.Replace("+", "")}");
                }

                writer.WriteLine($"Total results count: {resultList.Count()}");

                writer.WriteLine(
                    $"Total duplicate combinations count {resultList.GroupBy(x => x.Replace("+", "")).Count()}");

                writer.Close();
            }
        }
    }
}