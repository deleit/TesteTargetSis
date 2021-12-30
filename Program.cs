static void PrimeiraQuestao(int indice)
{
  int soma = 0;
  int k = 0;

  while (k < indice)
  {
    k = k + 1;
    soma = soma + k;
  }

  Console.WriteLine($"Questão 1: o valor da variável soma é {soma}");
}

static void SegundaQuestao()
{
  Console.WriteLine("Digite um número: ");
  var entrada = Console.ReadLine();
  int numero = 0;
  if (entrada != null)
  {
    numero = int.Parse(entrada);
  }

  bool estaNaSequencia = false;

  List<int> sequencia = new List<int>() { 0, 1 };

  if (numero == 0 || numero == 1)
    estaNaSequencia = true;
  else
  {
    while (numero >= sequencia[^1])
    {
      if (numero == sequencia[^1])
      {
        estaNaSequencia = true;
        break;
      }
      else
      {
        int ultimoElemento = sequencia[sequencia.Count - 1];
        int penultimoElemento = sequencia[sequencia.Count - 2];
        sequencia.Add(ultimoElemento + penultimoElemento);
      }
    }
  }

  if (estaNaSequencia)
    Console.WriteLine($"Questão 2: o número {numero} está na sequência de Fibonacci");
  else
    Console.WriteLine($"Questão 2: o número {numero} não está na sequência de Fibonnaci");
}

PrimeiraQuestao(13);
SegundaQuestao();