public struct BankInfo
{

    public BankInfo(string ibanIn, string ownerIn, string ibanOut, string ownerOut, string referenz, string street, string place, string coopPartner) : this()
    {
        IbanIn = ibanIn;
        IbanOut = ibanOut;
        OwnerIn = ownerIn;
        OwnerOut = ownerOut;
        Referenz = referenz;
        Street = street;
        Place = place;
        CoopPartner = coopPartner;
    }

    public string IbanIn { get; private set; }
    public string IbanOut { get; private set; }
    public string OwnerIn { get; private set; }
    public string OwnerOut { get; private set; }
    public string Referenz { get; private set; }
    public string Street { get; private set; }
    public string Place { get; private set; }
    public string CoopPartner { get; private set; }
   
}