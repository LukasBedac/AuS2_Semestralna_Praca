// See https://aka.ms/new-console-template for more information
using Semestralna_Praca2;

string[] s = new string[10];
for (int i = 0; i < 10; i++)
{
    s[i] = string.Empty;
}
s[0] = "Tire removal";
s[1] = "Filter change";
s[2] = "Fluid change";
s[7] = "Battery change";
ServiceVisit sv = new ServiceVisit(DateTime.Now, 20, s);
Console.Write("Price: " + sv.Price + " Date: " + sv.Date + " Description: ");
foreach (string st in sv.WorkDescription)
{
    if (st[0] == '\0')
    {
        continue;
    }
    Console.Write(st + ", ");
}
byte[] test = sv.ToByteArray();
sv.FromByteToArray(test);
Console.WriteLine();
Console.Write("Price: " + sv.Price + " Date: " + sv.Date + " Description: ");
foreach (string st in sv.WorkDescription)
{
    if (st[0] == '\0')
    {
        continue;
    }
    Console.Write(st + ", ");
}
