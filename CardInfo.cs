class CardInfo
{
  public int Kortnummer { get; set; }
  public int Pin { get; set; }
  public bool registreringerad = false;




  public CardInfo(int kortnummer, int pin)
  {
    Kortnummer = kortnummer;
    Pin = pin;

  }
}

