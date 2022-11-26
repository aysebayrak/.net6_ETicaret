using ETicaretAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



/*
 * NOTLAR  :
 * IOC  için serviceregistration.cs oluþturduk ve using    Microsoft.Extensions.DependencyInjection; yi nuget ettik.
 * Yazdýðýmýz metodu prgram.cs de tetiklemem lazým. Ve persistence katmaný içindeki tüm servisler IOC containere eklenmiþ bir þekilde elde etmiþ oluyoruz.
 * 
 * 
 * 
 */

/* KATMANLAR NOTLAR :
 * Domain ve Application katmanlarý Core klasöründe oluþturulur. Çünkü; bunlar çekirdelk katmanlar.
 * 
 * Servislerimizi yazdýðýmýz infrastructure ve persistence katmanlrý ÝNTRASTRUCE klasörü içinde oluþturulur.
 * 
 * 
 * 
 */


