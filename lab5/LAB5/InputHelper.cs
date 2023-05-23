namespace LAB5
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
                if (result < 0 || result > 2)
                {
                    Console.WriteLine("Індекс має бути в межах від 0 до 2");
                    continue;
                }
                break;
            }
            return result;
        }
        public static string GetNotEmptyString()
        {
            string result;
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
        public static char GetChar()
        {
            char result;
            while (true)
            {
                bool flag = char.TryParse(Console.ReadLine(), out result);
                if (!flag)
                {
                    Console.WriteLine("Введіть значення ще раз");
                    continue;
                }
                if (char.IsWhiteSpace(result) || !char.IsLetter(result))
                {
                    Console.WriteLine("Введіть інший символ");
                    continue;
                }
                break;
            }
            return char.ToUpper(result);
        }
    }
}
