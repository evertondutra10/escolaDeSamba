// Escolas de Samba
List<string> listaDasEscolas = new List<string>();// Estou criando uma variável de listas string para que os nomes das escolas sejam registrados e armazenados.
Dictionary<string, List<int>> escolasRegistradas = new Dictionary<string, List<int>>();


void ExibirLogo()
{
    Console.WriteLine(@"
███████╗░██████╗░█████╗░░█████╗░██╗░░░░░░█████╗░░██████╗  ██████╗░███████╗
██╔════╝██╔════╝██╔══██╗██╔══██╗██║░░░░░██╔══██╗██╔════╝  ██╔══██╗██╔════╝
█████╗░░╚█████╗░██║░░╚═╝██║░░██║██║░░░░░███████║╚█████╗░  ██║░░██║█████╗░░
██╔══╝░░░╚═══██╗██║░░██╗██║░░██║██║░░░░░██╔══██║░╚═══██╗  ██║░░██║██╔══╝░░
███████╗██████╔╝╚█████╔╝╚█████╔╝███████╗██║░░██║██████╔╝  ██████╔╝███████╗
╚══════╝╚═════╝░░╚════╝░░╚════╝░╚══════╝╚═╝░░╚═╝╚═════╝░  ╚═════╝░╚══════╝

░██████╗░█████╗░███╗░░░███╗██████╗░░█████╗░
██╔════╝██╔══██╗████╗░████║██╔══██╗██╔══██╗
╚█████╗░███████║██╔████╔██║██████╦╝███████║
░╚═══██╗██╔══██║██║╚██╔╝██║██╔══██╗██╔══██║
██████╔╝██║░░██║██║░╚═╝░██║██████╦╝██║░░██║
╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═════╝░╚═╝░░╚═╝");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo(); //Sempre que o menu aparecer a função do logo será chamada.
    Console.WriteLine("\nDigite 1 para registrar uma Escola");
    Console.WriteLine("Digite 2 para mostrar todas as Escolas");
    Console.WriteLine("Digite 3 para avaliar uma Escola");
    Console.WriteLine("Digite 4 para exibir a média da Escola");
    Console.WriteLine("Digite -1 para sair");
    Console.Write("\nDigite a sua opção: "); //Ao digitar só Write o cursor dgitável do RedLine ficará nessa linha e não na de baixo.
    string opcaoEscolhida = Console.ReadLine()!; //Criei uma variável string para rececer o valor. ReadLine faz com que o valor seja digitado na linha de cima. A Exclamação evita que o valor retorne nulo.
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); //Estou transformando a variável opçãoEscolhida que é uma string, em uma variável int. 


    switch (opcaoEscolhidaNumerica) //utilizado se temos muitas condicionais, no nosso caso temos 5. Caso fosse um número menor, poderíamos usar o if e else tranquilamente.
    {
        case 1:
            RegistrarEscola();// Número escolhido 1, chama a função aplicada.
            break; // Usado para finalizar a sessão, caso contrário não irá codar.
        case 2:
            MostrarEscolaRegistrada();
            break;
        case 3:
            AvaliarUmaEscola();
            break;
        case 4:
            ExibirMedia();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default: // Se for utilizado qualquer opção que não seja os cases acima, o resultado será uma mensagem de Opção inválida.
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarEscola()
{
    Console.Clear();// Limpa a tela do menu para abrir essa tela
    Console.WriteLine("Registro de Escolas\n");
    Console.Write("Digite o nome da Escola que deseja registrar: ");
    string nomeDaEscola = Console.ReadLine()!;
    escolasRegistradas.Add(nomeDaEscola, new List<int> { });//Estou invocando a variável Dicionary list criada no início, para registrar todas as escolas que eu digitar.
    Console.WriteLine($"A Escola {nomeDaEscola} foi registrada com sucesso!"); // O sinal se $ permite que eu invoque uma variável dentro da string, colocando a vaíável entre chaves.
    Thread.Sleep(4000);// Tempo que eu quero que a mensagem seja exibida na tela, nesse caso 4000 mílisegundos.
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarEscolaRegistrada()
{
    Console.Clear();
    Console.WriteLine("Exibindo todas as Escolas registradas:");
    //for (int i = 0; i < listaDasEscolas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasEscolas[i]}");
    //}
    foreach (string escola in escolasRegistradas.Keys) // uma forma alternativa de utilizar o for comentado acima. 
    {
        Console.WriteLine($"Escola: {escola}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void AvaliarUmaEscola()
{
    //digite qual banda deseja avaliar
    // se a banda existir no dicionario >> atribuir uma nota
    // senão, volta ao menu principal

    Console.Clear();
    Console.WriteLine("Avaliar Escola");
    Console.Write("Digite o nome da Escola que deseja avaliar: ");
    string nomeDaEscola = Console.ReadLine()!;
    if (escolasRegistradas.ContainsKey(nomeDaEscola))//ContainsKeys pega tudo que está dentro da chave do escolasRegistradas declarada no início do código, e faz uma comparação para ver se é TRue
    {
        Console.Write($"Qual a nota que a escola {nomeDaEscola} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        escolasRegistradas[nomeDaEscola].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a escola {nomeDaEscola}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA Escola {nomeDaEscola} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void ExibirMedia()
{
    Console.Clear();
    Console.Write("Digite o nome da escola que deseja exibir a média: ");
    string nomeDaEscola = Console.ReadLine()!;
    if (escolasRegistradas.ContainsKey(nomeDaEscola))
    {
        List<int> notasDaEscola = escolasRegistradas[nomeDaEscola];
        Console.WriteLine($"\nA média da escola {nomeDaEscola} é {notasDaEscola.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\n A escola {nomeDaEscola} não foi encontrada.");
        Console.WriteLine("Digite ma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}


ExibirOpcoesDoMenu();
