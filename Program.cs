
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

#region Menü_Başlangıcı

Console.WriteLine("API Consume İşlmemine Hoş Geldiniz");
Console.WriteLine();
Console.WriteLine("### Yapmak istediğiniz işlemi seçin ###");
Console.WriteLine();
Console.WriteLine("1-Şehir Listesini Getir");
Console.WriteLine("2-Şehir ve Hava Durumu Listesini Getir");
Console.WriteLine("3-Yeni Şehir Ekleme ");
Console.WriteLine("4-Şehir Silme İşlemi");
Console.WriteLine("5-Şehir Güncelleme İşlemi");
Console.WriteLine("6-Id'ye Göre Şehir Getirme İşlemi");
Console.WriteLine();

#endregion
string number;
Console.Write("Tercihiniz: ");
number = Console.ReadLine();

Console.WriteLine();
Console.WriteLine();

if (number == "1")
{
    string url = "https://localhost:7219/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage responseMessage = await client.GetAsync(url);
        string responseBody = await responseMessage.Content.ReadAsStringAsync();
        JArray jsonWeather =  JArray.Parse(responseBody);

        foreach (var item in jsonWeather)
        {
                string cityName = item["cityName"].ToString();
                Console.WriteLine($"Şehir: {cityName}");
            

        }
    }
}
if (number == "2")
{
    string url = "https://localhost:7219/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync(url);
        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        JArray jsonWeather = JArray.Parse (responseBody);
        foreach (var item in jsonWeather)
        {
            string cityName = item["cityName"].ToString();
            string temperature = item["temperature"].ToString();
            string country = item["country"].ToString();
            Console.WriteLine(cityName + "-"+country+"-->"+temperature+" derece");
            Console.WriteLine("---------------------------------------------------------------");

        }
    }
}
if (number == "3")
{
    Console.WriteLine("### Yeni Şehir Girişi ###");
    Console.WriteLine();

    string cityName, country,detail;
    decimal temperature;

   Console.Write("Şehir Adı: ");
    cityName = Console.ReadLine();

    Console.Write("Ülke Adı: ");
    country= Console.ReadLine();

    Console.Write("Derece: ");
    temperature=decimal.Parse(Console.ReadLine());
    Console.Write("Hava Durumu Detayı: ");
    detail= Console.ReadLine(); 

    string url = "https://localhost:7219/api/Weathers";
    var newWeatherCity = new
    {
        CityName = cityName,
        Country = country,
        Temperature = temperature,
        Detail = detail

    };
    using (HttpClient client = new HttpClient())
    {
       string jsonizedWeather = JsonConvert.SerializeObject(newWeatherCity);
        StringContent content = new StringContent(jsonizedWeather,Encoding.UTF8,"application/json");
        HttpResponseMessage responseMessage= await client.PostAsync(url, content);
        responseMessage.EnsureSuccessStatusCode();
    }

}
if (number == "4")
{

    string url = "https://localhost:7219/api/Weathers?id=";
    
    Console.Write("Silmek İstediğiniz Şehrin Id değeri: ");
    int id=int.Parse(Console.ReadLine());

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage responseMessage = await client.DeleteAsync(url+id);
        responseMessage.EnsureSuccessStatusCode();
    };

}

if (number == "5")
{

    Console.WriteLine("### Şehir üncelleme Girişi ###");
    Console.WriteLine();

    string cityName, country, detail;
    decimal temperature;

    int cityId;

   

    Console.Write("Şehir Adı: ");
    cityName = Console.ReadLine();

    Console.Write("Ülke Adı: ");
    country = Console.ReadLine();

    Console.Write("Derece: ");
    temperature = decimal.Parse(Console.ReadLine());
   
    Console.Write("Hava Durumu Detayı: ");
    detail = Console.ReadLine();

    Console.Write("Şehir Id: ");
    cityId = int.Parse(Console.ReadLine());

    string url = "https://localhost:7219/api/Weathers";

    var updatedValues = new {
       CityId=cityId,
        CityName= cityName, 
        Country=country,
        Temperature= temperature,
        Detail=detail };

    using (HttpClient client = new HttpClient())
    {
        string jsonUpdatedValues = JsonConvert.SerializeObject(updatedValues);
        StringContent content = new StringContent(jsonUpdatedValues, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage= await client.PutAsync(url, content);
    }

}

if (number == "6")
{
    string url = "'https://localhost:7219/api/Weathers/GetByIdWeatherCity?id=";
    Console.Write("Bilgilerini getirmek istediğiniz şehrin id değeri: ");
    
        int id = int.Parse(Console.ReadLine());
    Console.WriteLine();

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync(url+id);
        httpResponseMessage.EnsureSuccessStatusCode();
        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        JObject weatherCityObject = JObject.Parse(responseBody);
        string cityName = weatherCityObject["cityName"].ToString();
        string country = weatherCityObject["country"].ToString();
        string detail = weatherCityObject["detail"].ToString();
        decimal temperature  = decimal.Parse(weatherCityObject["temperature"].ToString());

        Console.WriteLine("Girmiş olduğunuz id değerine ait bilgiler");
        Console.WriteLine();
        Console.Write("Şehir: " + cityName + "Ülke: " + country + "Detay: " + detail + "Sıcaklık: " + temperature);
    }
}


Console.Read();