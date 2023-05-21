namespace LAB4
{
    public static class InputHelper
    {
        public static int GetInteger()
        {
            string input;
            int result;
            while (true)
            {
                input = GetNotEmptyString();
                bool flag = int.TryParse(input, out result);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                break;
            }
            return result;
        }
        public static string GetNotEmptyString()
        {
            string? result;
            while (true)
            {
                result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result) || string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("Рядок пустий! Введіть значення ще раз");
                    continue;
                }
                break;
            }
            return result;
        }
    }
}
