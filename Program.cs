using System;

Console.WriteLine("Validador de Bandeira de Cartão\n");

void ProcessarCartao(string entrada)
{
	if (string.IsNullOrWhiteSpace(entrada)) return;
	string numero = entrada.Trim();
	Bandeira bandeira = ValidadorCartao.ObterBandeira(numero);
	bool luhnValido = ValidadorCartao.ValidaLuhn(numero);

	Console.WriteLine($"Número: {numero}");
	Console.WriteLine($"Bandeira: {bandeira}");
	
	if (luhnValido)
	{
		Console.WriteLine("Check Luhn: Válido\n");
	}
	else
	{
		Console.WriteLine("Check Luhn: Inválido\n");
	}
}

if (args.Length > 0)
{
	for (int i = 0; i < args.Length; i++)
	{
		ProcessarCartao(args[i]);
	}
	return;
}

while (true)
{
	Console.Write("Digite o número do cartão (ou 'sair' para encerrar): ");
	string? linha = Console.ReadLine();
	if (linha == null) break;
	if (linha.Trim().ToLower() == "sair") break;
	ProcessarCartao(linha);
}

Console.WriteLine("Encerrando.");
