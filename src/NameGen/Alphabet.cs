using NameGen.Models;

namespace NameGen;

internal static class Alphabet
{
    public static string[] Endings => new[]
    {
        "а", "в", "и", "л", "м", "н", "о", "р", "с", "т", "э"
    };

    public static Letter[] Letters => new[]
    {
        new Letter()
        {
            Value = 'а',
            Combos = new[]
            {
                'в', 'г', 'д', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'э', 'у'
            },
            Endings = new[]
            {
                'г', 'д', 'к', 'л', 'м', 'н', 'р', 'с', 'т'
            }
        },
        new Letter()
        {
            Value = 'б',
            Combos = new[]
            {
                'е', 'и', 'о', 'р', 'э'
            },
            Endings = new[]
            {
                'и', 'о', 'б'
            }
        },
        new Letter()
        {
            Value = 'в',
            Combos = new[]
            {
                'г', 'е', 'и', 'л', 'н', 'о', 'р', 'с', 'э'
            },
            Endings = new[]
            {
                'с', 'о'
            }
        },
        new Letter()
        {
            Value = 'г',
            Combos = new[]
            {
                'а', 'в', 'д', 'и', 'л', 'м', 'н', 'о', 'р', 'с', 'э'
            },
            Endings = new[]
            {
                'о', 'г'
            }
        },
        new Letter()
        {
            Value = 'д',
            Combos = new[]
            {
                'а', 'в', 'д', 'и', 'м', 'н', 'о', 'р', 'э'
            },
            Endings = new[]
            {
                'а', 'о', 'р', 'э'
            }
        },
        new Letter()
        {
            Value = 'е',
            Combos = new[]
            {
                 'а', 'в', 'г', 'д', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с'
            },
            Endings = new[]
            {
                 'г', 'к', 'л', 'н', 'р', 'т'
            }
        },
        new Letter()
        {
            Value = 'и',
            Combos = new[]
            {
                'б', 'в', 'г', 'д', 'к', 'л', 'м', 'н', 'о', 'р', 'с', 'т'
            },
            Endings = new[]
            {
                'в', 'д', 'л', 'н', 'р', 'с', 'т'
            }
        },
        new Letter()
        {
            Value = 'й',
            Combos = new[]
            {
                'в', 'м', 'н'
            },
            Endings = new[]
            {
                'в', 'л', 'н', 'с', 'т'
            }
        },
        new Letter()
        {
            Value = 'к',
            Combos = new[]
            {
                'а', 'б', 'в', 'е', 'и', 'к', 'л', 'м', 'н', 'о', 'р', 'с', 'т'
            },
            Endings = new[]
            {
                'а', 'и', 'о', 'р', 'с', 'т'
            }
        },
        new Letter()
        {
            Value = 'л',
            Combos = new[]
            {
                'а', 'г', 'е', 'и', 'к', 'л', 'м', 'н', 'о', 'р', 'э'
            },
            Endings = new[]
            {
                'а', 'в', 'к'
            }
        },
        new Letter()
        {
            Value = 'м',
            Combos = new[]
            {
                'а', 'д', 'е', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'э'
            },
            Endings = new[]
            {
                'а', 'и', 'н', 'о'
            }
        },
        new Letter()
        {
            Value = 'н',
            Combos = new[]
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'и', 'к', 'л', 'н', 'о', 'р', 'т', 'э'
            },
            Endings = new[]
            {
                'а', 'г', 'д', 'и', 'к', 'о', 'т'
            }
        },
        new Letter()
        {
            Value = 'о',
            Combos = new[]
            {
                'б', 'в', 'г', 'д', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т'
            },
            Endings = new[]
            {
                'г', 'д', 'к', 'л', 'м', 'н', 'р', 'с', 'т'
            }
        },
        new Letter()
        {
            Value = 'п',
            Combos = new[]
            {
                'а', 'л', 'о', 'п', 'р', 'т'
            },
            Endings = new[]
            {
                'а', 'о', 'п'
            }
        },
        new Letter()
        {
            Value = 'р',
            Combos = new[]
            {
                'а', 'б', 'г', 'д', 'и', 'к', 'м', 'н', 'о', 'р', 'с', 'т', 'э'
            },
            Endings = new[]
            {
                'а', 'д', 'и', 'к', 'н', 'с', 'т'
            }
        },
        new Letter()
        {
            Value = 'с',
            Combos = new[]
            {
                'а', 'е', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'т', 'э'
            },
            Endings = new[]
            {
                'а', 'и', 'т'
            }
        },
        new Letter()
        {
            Value = 'т',
            Combos = new[]
            {
                'а', 'в', 'и', 'л', 'м', 'н', 'о', 'р', 'с', 'т', 'э'
            },
            Endings = new[]
            {
                'а', 'и', 'о', 'с'
            }
        },
        new Letter()
        {
            Value = 'х',
            Combos = new[]
            {
                'а', 'в', 'и', 'л', 'м', 'н', 'о', 'р', 'э'
            },
            Endings = new[]
            {
                'о', 'а', 'т'
            }
        },
        new Letter()
        {
            Value = 'э',
            Combos = new[]
            {
                'а', 'в', 'л', 'м', 'н', 'о', 'р', 'с', 'т'
            },
            Endings = new[]
            {
                'л', 'н', 'р', 'с', 'т'
            }
        },
    };
}
