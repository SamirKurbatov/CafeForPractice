using CafeForDevs.Client;

var httpClient = new HttpClient();
var baseCafeUri = new Uri("http://localhost:37820");
var cafeHttpClient = new CafeHttpClient(httpClient, baseCafeUri);
var application = new ClientApplication(cafeHttpClient);
application.Start();