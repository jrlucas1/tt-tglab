public abstract class Bet {
    public decimal Amount { get; set; }

    protected Bet(decimal amount) {
        if (amount <= 0) throw new ArgumentException("Valor da aposta deve ser positivo");
        this.Amount = amount;
        }

    public abstract decimal GetPayout(int Result);
}

public sealed class StraightBet : Bet
{
    public int Number { get; }

    public StraightBet (decimal amount, int number): base (amount)
    {
        if (number < 0 || number > 36) throw new ArgumentException("Selecione um número válido para apostar");
        Number = number;
    }

    public override decimal GetPayout(int Result)
    {
        return Result == Number ? Amount * 35 : 0;
    }
}

public sealed class OddOrEvenBet : Bet
{
    public bool IsEven;

    public OddOrEvenBet (decimal amount, bool isEven) : base(amount)
    {
        IsEven = isEven;
    }

    public override decimal GetPayout(int Result)
    {
       if (Result == 0) return 0;

       bool resultIsEven = Result % 2 == 0;
       
       return resultIsEven == IsEven ? Amount * 2 : 0;
    }
}

public sealed class DozenBet : Bet
{
    int Dozen { get; set; }

    public DozenBet(decimal amount, int dozen) : base(amount)
    {
        Dozen = dozen;
    }

    public override decimal GetPayout(int Result)
    {
        int correctDozen = 0;

        if (Result == 0) return 0;
        if (Result > 1 && Result <= 12)
            correctDozen = 1;
        if (Result > 13 && Result <= 24)
            correctDozen = 2;
        if (Result > 25 && Result <= 36)
            correctDozen = 3;

        return correctDozen == Dozen ? Amount * 3 : 0;
    }
}

public void Main()
{
    Console.WriteLine('Escolha o tipo de aposta: ')
    Console.WriteLine('')
}