# Misturador de Caracteres

Um utilitário de console em C# que embaralha caracteres de uma string fornecida pelo usuário, com a opção de manter uma sequência específica fixa. Simples, interativo e perfeito para gerar variações aleatórias de texto!

## Funcionalidades

- **Entrada com contador em tempo real**: Digite caracteres e veja a contagem atualizada dinamicamente.
- **Sequência fixa**: Escolha uma parte da string para permanecer inalterada durante o embaralhamento.
- **Múltiplas misturas**: Defina quantas versões embaralhadas deseja gerar (padrão: 1).
- **Suporte a espaços**: Inclua espaços na entrada, com contador ajustado.
- **Menu interativo**: Após gerar as misturas, escolha entre gerar mais, reiniciar ou sair.
- **Interface amigável**: Tela limpa apenas no reinício, com resultados claros e organizados.

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior recomendada).
- Um terminal ou IDE compatível (ex.: Visual Studio, VS Code).

## Como usar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/misturador-de-caracteres.git
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd misturador-de-caracteres
   ```
3. Execute o programa:
   ```bash
   dotnet run
   ```
4. Siga as instruções no console:
   - Digite os caracteres a serem misturados.
   - (Opcional) Informe uma sequência para manter fixa.
   - Escolha o número de misturas.
   - Use o menu para gerar mais misturas, reiniciar ou sair.

## Exemplo

**Entrada**:
- Caracteres: `Asjduiwiwue83874873`
- Sequência fixa: `8387`
- Quantidade de misturas: `2`

**Saída**:
```
=== Misturador de Caracteres ===
Digite os caracteres para misturar: Asjduiwiwue83874873
2
Informe a sequência para manter fixa (ou deixe em branco para misturar todos): 8387
Quantas misturas (padrão 1)? 2

=== Resultados (Original: Asjduiwiwue83874873, 18 caracteres) ===
1. uiwjdsAiwue83874873
2. jwuisdAiwue83874873

O que deseja fazer?
1. Gerar mais (2)
2. Reiniciar
3. Sair
```

## Estrutura do projeto

- `MisturadorDeCaracteres.cs`: Código-fonte principal com toda a lógica do programa.
- `.gitignore`: Configurado para ignorar arquivos de build (`bin/`, `obj/`), arquivos temporários e configurações de IDE.

## Contribuindo

Sinta-se à vontade para abrir issues ou enviar pull requests com melhorias, como novas funcionalidades ou correções. Todas as contribuições são bem-vindas!

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

Desenvolvido com 💻 e paixão por código! 🚀