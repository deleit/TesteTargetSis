using Newtonsoft.Json.Linq;

namespace TesteTargetSis;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("---------");
    PrimeiraQuestao(13);
    SegundaQuestao();
    TerceiraQuestao();
    QuartaQuestao();
    QuintaQuestao();
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
    Console.WriteLine("Digite um número: ");

    var entrada = Console.ReadLine();
    long numero;

    // Validação da entrada
    while (entrada == null || !(long.TryParse(entrada, out numero)))
    {
      Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro:");
      entrada = Console.ReadLine();
    }
    if (entrada != null && long.TryParse(entrada, out numero))
    {
      ConfereSequencia(numero);
    }

    void ConfereSequencia(long numero)
    {
      bool estaNaSequencia = false;

      List<long> sequencia = new List<long>() { 0, 1 };

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
            long ultimoElemento = sequencia[sequencia.Count - 1];
            long penultimoElemento = sequencia[sequencia.Count - 2];
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

  static void QuintaQuestao()
  {
    Console.WriteLine("Questão 5:");
    Console.WriteLine("insira um texto: ");

    char[] charArray;
    var entrada = Console.ReadLine();

    // Validação da entrada
    while (entrada == null || entrada == "")
    {
      Console.WriteLine("Entrada inválida. Por favor, insira um texto:");
      entrada = Console.ReadLine();
    }

    if (entrada != null)
    {
      ReverteString(entrada);
    }

    void ReverteString(string entrada)
    {
      charArray = entrada.ToCharArray();

      for (int i = 0; i < charArray.Length / 2; i++)
      // "charArray.Length / 2" -> dividido por 2 para evitar que a reversão seja feita 2 vezes
      {
        char tmp = charArray[i];
        charArray[i] = charArray[charArray.Length - i - 1];
        charArray[charArray.Length - i - 1] = tmp;
      }

      string entradaReversa = new string(charArray);

      Console.WriteLine(entradaReversa);
    }

    Console.WriteLine("----------");
  }
}