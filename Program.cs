using Newtonsoft.Json.Linq;

namespace TesteTargetSis;

class Program
{
  static void Main(string[] args)
  {
    PrimeiraQuestao(13);
    SegundaQuestao();
    TerceiraQuestao();
    QuartaQuestao();
  }

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
    Console.WriteLine("----------");
  }

  static void SegundaQuestao()
  {
    Console.WriteLine("Questão 2:");
    Console.WriteLine("digite um número: ");

    var entrada = Console.ReadLine();
    int numero = 0;
    if (entrada != null)
      numero = int.Parse(entrada);

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
      Console.WriteLine($"O número {numero} está na sequência de Fibonacci");
    else
      Console.WriteLine($"O número {numero} não está na sequência de Fibonnaci");

    Console.WriteLine("----------");
  }

  static void TerceiraQuestao()
  {
    // Busca o caminho relativo
    string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\dados.json");
    string sFilePath = Path.GetFullPath(sFile);

    string arquivoDados = File.ReadAllText(sFilePath);
    JArray jsonArray = JArray.Parse(arquivoDados);

    // Encontra o maior faturamento
    double maiorFaturamento = 0;
    int diaMaiorFaturamento = 0;

    for (int i = 0; i < jsonArray.Count; i++)
    {
      JObject dados = JObject.Parse(jsonArray[i].ToString());
      JToken? valorJToken = dados.GetValue("valor");
      JToken? diaJToken = dados.GetValue("dia");
      if (valorJToken != null && diaJToken != null)
      {
        double valor = valorJToken.ToObject<double>();
        if (valor > maiorFaturamento)
        {
          maiorFaturamento = valor;
          diaMaiorFaturamento = diaJToken.ToObject<int>();
        }
      }
    }

    // Encontra o menor faturamento
    double menorFaturamento = maiorFaturamento;
    int diaMenorFaturamento = 0;

    for (int i = 0; i < jsonArray.Count; i++)
    {
      JObject dados = JObject.Parse(jsonArray[i].ToString());
      JToken? valorJToken = dados.GetValue("valor");
      JToken? diaJToken = dados.GetValue("dia");
      if (valorJToken != null && diaJToken != null)
      {
        double valor = valorJToken.ToObject<double>();
        if (valor > 0 && valor < menorFaturamento)
        {
          menorFaturamento = valor;
          diaMenorFaturamento = diaJToken.ToObject<int>();
        }
      }
    }

    // Calcula a média mensal
    double soma = 0;

    for (int i = 0; i < jsonArray.Count; i++)
    {
      JObject dados = JObject.Parse(jsonArray[i].ToString());
      JToken? valorJToken = dados.GetValue("valor");
      if (valorJToken != null)
      {
        double valor = valorJToken.ToObject<double>();
        soma += valor;
      }
    }

    double mediaMensal = soma / jsonArray.Count;

    // Encontra o número de dias no mês em que o valor de faturamento diário foi maior do que a média mensal
    int diasMaioresQueMedia = 0;

    for (int i = 0; i < jsonArray.Count; i++)
    {
      JObject dados = JObject.Parse(jsonArray[i].ToString());
      JToken? valorJToken = dados.GetValue("valor");
      if (valorJToken != null)
      {
        double valor = valorJToken.ToObject<double>();
        if (valor > mediaMensal)
        {
          diasMaioresQueMedia++;
        }
      }
    }

    Console.WriteLine("Questão 3:");
    Console.WriteLine($"O maior faturamento do mês foi {maiorFaturamento}, no dia {diaMaiorFaturamento}");
    Console.WriteLine($"O menor faturamento do mês foi {menorFaturamento}, no dia {diaMenorFaturamento}");
    Console.WriteLine($"Foram {diasMaioresQueMedia} dias com um faturamento maior do que a média mensal");
    Console.WriteLine("-----------");
  }

  static void QuartaQuestao()
  {
    Dictionary<string, double> faturamentos = new Dictionary<string, double>();
    double faturamentoTotal = 0;

    faturamentos.Add("SP", 67836.43);
    faturamentos.Add("RJ", 36678.66);
    faturamentos.Add("MG", 29229.88);
    faturamentos.Add("ES", 27165.48);
    faturamentos.Add("Outros", 19849.53);

    foreach (double faturamento in faturamentos.Values)
      faturamentoTotal += faturamento;

    Console.WriteLine("Questão 4: ");

    foreach (string estado in faturamentos.Keys)
    {
      double faturamento = faturamentos[estado];
      double porcentagem = (faturamento / faturamentoTotal) * 100;
      porcentagem = Math.Round(porcentagem, 2);

      faturamentos[estado] = porcentagem;
      Console.WriteLine($"{estado} - {porcentagem}%");
    }

    Console.WriteLine("---------");
  }
}