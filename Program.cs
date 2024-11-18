Console.WriteLine("API Consume İşlmemine Hoş Geldiniz");
Console.WriteLine();
Console.WriteLine("### Yapmak istediğiniz işlemi seçin ###");
Console.WriteLine();
Console.WriteLine("1-Şehir Listesini Getir");
Console.WriteLine("2-Yeni Şehir Ekleme ");
Console.WriteLine("3-Şehir Silme İşlemi");
Console.WriteLine("4-Şehir Güncelleme İşlemi");
Console.WriteLine("5-Id'ye Göre Şehir Getirme İşlemi");
Console.WriteLine();

string number;
Console.Write("Tercihiniz: ");
number = Console.ReadLine();

if (number == "1")
{
    Console.WriteLine("Şehir Listesi Aşağıdaki gibidir");
}
if (number == "2")
{
    Console.WriteLine("Yeni Şehir Ekleme Alanı");
}
if (number == "3")
{
    Console.WriteLine("Şehir Silme Alanı ");
}
Console.WriteLine();
Console.WriteLine();