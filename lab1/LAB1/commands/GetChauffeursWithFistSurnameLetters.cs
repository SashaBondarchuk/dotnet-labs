using LAB1.interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace LAB1.commands
{
    class GetChauffeursWithFistSurnameLetters : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetChauffeursWithFistSurnameLetters(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            const string pattern = @"^[А-Яа-я]+$";
            Console.WriteLine("Введіть літеру(літери): ");
            while (true)
            {
                string startLetters = Console.ReadLine();

                if (!Regex.IsMatch(startLetters, pattern))
                {
                    Console.WriteLine("Пробіли, символи і латиниця заборонені! Введіть ще раз");
                    continue;
                }

                var chaffeurs = dataHandler.GetChauffeursWithFistSurnameLetters(startLetters.ToLower());

                if (chaffeurs.Count() <= 0)
                {
                    Console.WriteLine("Таких шоферів не зареєстровано.");
                    break;
                }

                foreach (var ch in chaffeurs)
                {
                    Console.WriteLine(ch);
                }
                Console.WriteLine();
                break;
            }
        }
    }
}
