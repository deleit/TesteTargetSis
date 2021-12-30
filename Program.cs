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

PrimeiraQuestao(13);