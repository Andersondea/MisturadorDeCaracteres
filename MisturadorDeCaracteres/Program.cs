using System;
using System.Linq;
using System.Text;

class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Misturador de Caracteres ===");
            string input = LerEntradaComContador();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Nenhum caractere informado! Pressione qualquer tecla...");
                Console.ReadKey();
                continue;
            }

            Console.Write("\nInforme a sequência para manter fixa (ou deixe em branco para misturar todos): ");
            string fixa = Console.ReadLine();

            Console.Write("\nQuantas misturas (padrão 1)? ");
            string quantidadeStr = Console.ReadLine();
            int quantidade = int.TryParse(quantidadeStr, out int valor) && valor > 0 ? valor : 1;

            GerarMisturas(input, quantidade, fixa);

            // Menu pós-mistura
            while (true)
            {
                Console.WriteLine($"\nO que deseja fazer?");
                Console.WriteLine($"1. Gerar mais ({quantidade})");
                Console.WriteLine("2. Reiniciar");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    GerarMisturas(input, quantidade, fixa);
                }
                else if (opcao == "2")
                {
                    break; // Volta ao início do loop principal, que limpa a tela
                }
                else if (opcao == "3")
                {
                    Console.WriteLine("Tchau, até a próxima!");
                    return;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla...");
                    Console.ReadKey();
                }
            }
        }
    }

    static string LerEntradaComContador()
    {
        Console.Write("Digite os caracteres para misturar: ");
        int cursorInicio = Console.CursorLeft; // Posição inicial para caracteres
        StringBuilder input = new StringBuilder();
        int contador = 0;

        // Exibe contador inicial em nova linha
        Console.WriteLine();
        Console.Write($"{contador}    "); // Espaço extra pra até 9999 caracteres
        int contadorLinha = Console.CursorTop;
        int contadorColuna = Console.CursorLeft - 4; // Posição inicial do contador
        Console.SetCursorPosition(cursorInicio, contadorLinha - 1); // Volta ao prompt

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true); // Captura tecla sem eco imediato

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine(); // Nova linha após Enter
                break;
            }
            else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input.Length--; // Remove último caractere
                contador--;
                Console.SetCursorPosition(cursorInicio + input.Length, contadorLinha - 1);
                Console.Write(" "); // Apaga caractere na tela
                Console.SetCursorPosition(cursorInicio + input.Length, contadorLinha - 1);
                // Atualiza contador
                Console.SetCursorPosition(contadorColuna, contadorLinha);
                Console.Write($"{contador}    "); // Reescreve com espaço pra limpar
                Console.SetCursorPosition(cursorInicio + input.Length, contadorLinha - 1);
            }
            else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow)
            {
                continue; // Ignora setas de navegação
            }
            else if (key.Key != ConsoleKey.Backspace && (char.IsLetterOrDigit(key.KeyChar) || char.IsWhiteSpace(key.KeyChar)))
            {
                input.Append(key.KeyChar); // Adiciona caractere
                contador++;
                Console.Write(key.KeyChar); // Exibe caractere
                // Atualiza contador
                Console.SetCursorPosition(contadorColuna, contadorLinha);
                Console.Write($"{contador}    "); // Reescreve com espaço pra limpar
                Console.SetCursorPosition(cursorInicio + input.Length, contadorLinha - 1);
            }
        }

        return input.ToString();
    }

    static void GerarMisturas(string input, int quantidade, string fixa = "")
    {
        Console.WriteLine($"\n=== Resultados (Original: {input}, {input.Length} caracteres) ===");

        if (string.IsNullOrWhiteSpace(fixa))
        {
            // Misturar todos os caracteres
            for (int i = 0; i < quantidade; i++)
            {
                string misturado = new string(input.OrderBy(c => random.Next()).ToArray());
                Console.WriteLine($"{i + 1}. {misturado}");
            }
        }
        else
        {
            // Encontrar a posição da sequência fixa
            int index = input.IndexOf(fixa);
            if (index == -1)
            {
                Console.WriteLine($"Sequência '{fixa}' não encontrada na entrada. Misturando todos os caracteres.");
                for (int i = 0; i < quantidade; i++)
                {
                    string misturado = new string(input.OrderBy(c => random.Next()).ToArray());
                    Console.WriteLine($"{i + 1}. {misturado}");
                }
            }
            else
            {
                // Extrair caracteres antes, a sequência fixa e depois
                string antes = input.Substring(0, index);
                string depois = input.Substring(index + fixa.Length);

                // Misturar apenas os caracteres antes e depois
                for (int i = 0; i < quantidade; i++)
                {
                    string misturadoAntes = new string(antes.OrderBy(c => random.Next()).ToArray());
                    string misturadoDepois = new string(depois.OrderBy(c => random.Next()).ToArray());
                    string misturado = misturadoAntes + fixa + misturadoDepois;
                    Console.WriteLine($"{i + 1}. {misturado}");
                }
            }
        }
    }
}