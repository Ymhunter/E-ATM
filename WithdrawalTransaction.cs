class WithdrawalTransaction
{
    public int CardNumber { get; set; }
    public int Pin { get; set; }
    public int Amount { get; set; }

    public WithdrawalTransaction(int amount, int cardNumber, int pin)
    {
        Amount = amount;
        CardNumber = cardNumber;
        Pin = pin;
    }
}
