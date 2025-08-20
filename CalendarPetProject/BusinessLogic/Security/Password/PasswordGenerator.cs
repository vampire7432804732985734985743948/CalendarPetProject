using System;
using System.Collections.ObjectModel;
using System.Text;
namespace CalendarPetProject.BusinessLogic.Security.Password
{
    public partial class PasswordGenerator
    {
        private readonly string _smallLetters = "abcdefghijklmnopqrstuvwxyz";
        private readonly string _uppercasedLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string _integers = "1234567890";
        private readonly string _specialSymbols = "!@#$%^&*()_-+=<>?-" +
            "";

        public string GeneratePassword(int passwordLength)
        {
            List<char> password = new List<char>();
            Random randomSelection = new Random();
            Collection<string> dataset = new Collection<string> {
                _smallLetters,
                _uppercasedLetters,
                _integers,
                _specialSymbols,
            };

            for (int i = 0; i < passwordLength; i++)
            {
                password.Add(SelectRandomLetter(dataset, randomSelection.Next(0, 4)));
            }
            return new string(password.ToArray());
        }

        private char SelectRandomLetter(Collection<string> dataSet, int id)
        {
            Random random = new Random();
            int randomSymbol = random.Next(0, dataSet[id].Length);
            return dataSet[id][randomSymbol];
        }
    }
}
