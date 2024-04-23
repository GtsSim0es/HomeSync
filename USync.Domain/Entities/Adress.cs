namespace USync.Domain.Entities;

public class Adress(string streat, int zipCode, int number)
{
    public string Streat { get; set; } = streat;
    public int ZipCode { get; set; } = zipCode;
    public int Number { get; set; } = number;

}
