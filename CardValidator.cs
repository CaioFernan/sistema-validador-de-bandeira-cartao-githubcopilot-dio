using System;
using System.Text;

// Nomes simples em portugues e estilo claro, como um desenvolvedor junior faria
public enum Bandeira
{
    Desconhecida,
    Visa,
    Mastercard,
    AmericanExpress,
    Discover,
    Diners,
    Jcb,
    Elo,
    Hipercard
}

public static class ValidadorCartao
{
    // Normaliza removendo qualquer coisa que nao seja digito
    public static string Normalizar(string numero)
    {
        if (numero == null)
        {
            return string.Empty; //Representa uma string vazia (""):
        }

        StringBuilder resultado = new StringBuilder();
        foreach (char c in numero)
        {
            if (char.IsDigit(c)) //verificar se um caractere é um dígito numérico (0 a 9).
            {
                resultado.Append(c); //é um método usado para adicionar algo ao final de uma coleção ou texto.
            }
        }
        return resultado.ToString();
    }

    // Retorna a bandeira baseada em prefixos e tamanho
    public static Bandeira ObterBandeira(string numero)
    {
        string n = Normalizar(numero);
        if (string.IsNullOrEmpty(n))
        {
            return Bandeira.Desconhecida;
        }
        if (EhVisa(n))
        {
            return Bandeira.Visa;
        }
        else if (EhMastercard(n))
        {
            return Bandeira.Mastercard;
        }
        else if (EhAmericanExpress(n))
        {
            return Bandeira.AmericanExpress;
        }
        else if (EhDiscover(n))
        {
            return Bandeira.Discover;
        }
        else if (EhDiners(n))
        {
            return Bandeira.Diners;
        }
        else if (EhJcb(n))
        {
            return Bandeira.Jcb;
        }
        else if (EhElo(n))
        {
            return Bandeira.Elo;
        }
        else if (EhHipercard(n))
        {
            return Bandeira.Hipercard;
        }
        else
        {
            return Bandeira.Desconhecida;
        }
    }

    // Luhn simples
    public static bool ValidaLuhn(string numero)
    {
        string n = Normalizar(numero);
        if (n.Length == 0) return false;

        int soma = 0;
        bool dobro = false;
        for (int i = n.Length - 1; i >= 0; i--)
        {
            int digito = n[i] - '0';
            if (dobro)
            {
                digito = digito * 2;
                if (digito > 9) digito -= 9;
            }
            soma += digito;
            dobro = !dobro;
        }
        return soma % 10 == 0;
    }

    static bool EhVisa(string n)
    {
        return n.StartsWith("4") && (n.Length == 13 || n.Length == 16 || n.Length == 19);
    }

    static bool EhMastercard(string n)
    {
        if (n.Length != 16) return false;
        int prefix2 = TryParsePrefix(n, 2);
        int prefix4 = TryParsePrefix(n, 4);
        if (prefix2 >= 51 && prefix2 <= 55) return true;
        if (prefix4 >= 2221 && prefix4 <= 2720) return true;
        return false;
    }

    static bool EhAmericanExpress(string n)
    {
        return (n.StartsWith("34") || n.StartsWith("37")) && n.Length == 15;
    }

    static bool EhDiscover(string n)
    {
        if (n.Length != 16 && n.Length != 19) return false;
        if (n.StartsWith("6011") || n.StartsWith("65")) return true;
        int p3 = TryParsePrefix(n, 3);
        if (p3 >= 644 && p3 <= 649) return true;
        int p6 = TryParsePrefix(n, 6);
        if (p6 >= 622126 && p6 <= 622925) return true;
        return false;
    }

    static bool EhDiners(string n)
    {
        if (n.Length != 14) return false;
        int p3 = TryParsePrefix(n, 3);
        if (p3 >= 300 && p3 <= 305) return true;
        if (n.StartsWith("36") || n.StartsWith("38") || n.StartsWith("39")) return true;
        return false;
    }

    static bool EhJcb(string n)
    {
        if (n.Length < 16 || n.Length > 19) return false;
        int p4 = TryParsePrefix(n, 4);
        return p4 >= 3528 && p4 <= 3589;
    }

    static bool EhElo(string n)
    {
        if (n.Length < 16 || n.Length > 19) return false;
        string[] bins = { "4011", "4312", "4389", "4514", "4576", "431274", "504175", "506699", "5067", "509", "627780", "636297", "636368" };
        foreach (string b in bins)
        {
            if (n.StartsWith(b)) return true;
        }
        return false;
    }

    static bool EhHipercard(string n)
    {
        if (n.Length < 13 || n.Length > 19) return false;
        if (n.StartsWith("606282")) return true;
        if (n.StartsWith("38") || n.StartsWith("60")) return true;
        return false;
    }

    static int TryParsePrefix(string n, int tamanho)
    {
        if (n.Length < tamanho) return -1;
        string s = n.Substring(0, tamanho);
        int valor;
        if (int.TryParse(s, out valor)) return valor;
        return -1;
    }
}
