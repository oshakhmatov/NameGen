﻿namespace NameGen.Core.Models;

public class Alphabet(Letter[] letters)
{
    private Letter[] letters = letters;

    public char[] GetAllLetterValues()
    {
        return letters.Select(l => l.Value).ToArray();
    }

    public Letter[] GetAllLetters()
    {
        return [..letters];
    }

    public Letter GetLetter(char c)
    {
        return letters.First(l => l.Value == c);
    }

    public char[] GetEndingsFor(char c)
    {
        return GetLetter(c).Endings;
    }

    public char[] GetCombosFor(char c)
    {
        return GetLetter(c).Combos;
    }

    public void ExcludeLetters(char[] lettersToExclude)
    {
        letters = letters
            .Where(l => !lettersToExclude.Contains(l.Value))
            .ToArray();

        foreach (var letter in letters)
        {
            letter.Combos = letter.Combos
                .Where(c => !lettersToExclude.Contains(c))
                .ToArray();

            letter.Endings = letter.Endings
                .Where(c => !lettersToExclude.Contains(c))
                .ToArray();
        }
    }

    public static Alphabet Default => new([
        new Letter
        {
            Value = 'а',
            Combos =
            [
                'в', 'г', 'д', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'э'
            ],
            Endings =
            [
                'г', 'д', 'к', 'л', 'м', 'н', 'р', 'с', 'т'
            ]
        },
        new Letter
        {
            Value = 'б',
            Combos =
            [
                'е', 'и', 'о', 'р', 'э'
            ],
            Endings =
            [
                'и', 'о', 'б'
            ]
        },
        new Letter
        {
            Value = 'в',
            Combos =
            [
                'г', 'е', 'и', 'л', 'н', 'о', 'р', 'с'
            ],
            Endings =
            [
                'a', 'с', 'о', 'р'
            ]
        },
        new Letter
        {
            Value = 'г',
            Combos =
            [
                'а', 'в', 'д', 'и', 'л', 'м', 'н', 'о', 'р', 'с', 'э'
            ],
            Endings =
            [
                'о', 'а', 'р'
            ]
        },
        new Letter
        {
            Value = 'д',
            Combos =
            [
                'а', 'в', 'и', 'м', 'н', 'о', 'р', 'э'
            ],
            Endings =
            [
                'а', 'о', 'р', 'э'
            ]
        },
        new Letter
        {
            Value = 'е',
            Combos =
            [
                    'а', 'в', 'г', 'д', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с'
            ],
            Endings =
            [
                    'г', 'к', 'л', 'н', 'р', 'т'
            ]
        },
        new Letter
        {
            Value = 'и',
            Combos =
            [
                'б', 'в', 'г', 'д', 'к', 'л', 'м', 'н', 'о', 'р', 'с', 'т'
            ],
            Endings =
            [
                'в', 'д', 'л', 'н', 'р', 'с', 'т'
            ]
        },
        new Letter
        {
            Value = 'й',
            Combos =
            [
                'в', 'м', 'н'
            ],
            Endings =
            [
                'в', 'л', 'н', 'с', 'т'
            ]
        },
        new Letter
        {
            Value = 'к',
            Combos =
            [
                'а', 'б', 'в', 'е', 'и', 'к', 'л', 'м', 'н', 'о', 'р', 'с', 'т'
            ],
            Endings =
            [
                'а', 'р', 'с', 'т'
            ]
        },
        new Letter
        {
            Value = 'л',
            Combos =
            [
                'а', 'г', 'е', 'и', 'к', 'л', 'м', 'н', 'о', 'р', 'э'
            ],
            Endings =
            [
                'а', 'в', 'к'
            ]
        },
        new Letter
        {
            Value = 'м',
            Combos =
            [
                'а', 'д', 'е', 'и', 'к', 'л', 'н', 'о', 'п', 'р', 'с', 'т', 'э'
            ],
            Endings =
            [
                'а', 'и', 'н', 'о'
            ]
        },
        new Letter
        {
            Value = 'н',
            Combos =
            [
                'а', 'б', 'в', 'г', 'д', 'е', 'и', 'к', 'л', 'о', 'р', 'т', 'э'
            ],
            Endings =
            [
                'а', 'г', 'д', 'и', 'к', 'о', 'т'
            ]
        },
        new Letter
        {
            Value = 'о',
            Combos =
            [
                'б', 'в', 'г', 'д', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т'
            ],
            Endings =
            [
                'г', 'д', 'к', 'л', 'м', 'н', 'р', 'с', 'т'
            ]
        },
        new Letter
        {
            Value = 'п',
            Combos =
            [
                'а', 'л', 'о', 'р', 'т'
            ],
            Endings =
            [
                'а', 'о', 'п'
            ]
        },
        new Letter
        {
            Value = 'р',
            Combos =
            [
                'а', 'б', 'г', 'д', 'и', 'к', 'м', 'н', 'о', 'р', 'с', 'т', 'э'
            ],
            Endings =
            [
                'а', 'д', 'и', 'к', 'н', 'с', 'т'
            ]
        },
        new Letter
        {
            Value = 'с',
            Combos =
            [
                'а', 'е', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'т', 'э'
            ],
            Endings =
            [
                'а', 'и', 'т'
            ]
        },
        new Letter
        {
            Value = 'т',
            Combos =
            [
                'а', 'в', 'и', 'л', 'м', 'н', 'о', 'р', 'с', 'э'
            ],
            Endings =
            [
                'а', 'и', 'о', 'с'
            ]
        },
        new Letter
        {
            Value = 'х',
            Combos =
            [
                'а', 'в', 'и', 'л', 'м', 'н', 'о', 'р', 'э'
            ],
            Endings =
            [
                'о', 'а', 'т'
            ]
        },
        new Letter
        {
            Value = 'э',
            Combos =
            [
                'а', 'в', 'л', 'м', 'н', 'о', 'р', 'с', 'т'
            ],
            Endings =
            [
                'л', 'н', 'р', 'с', 'т'
            ]
        },
    ]);
}
