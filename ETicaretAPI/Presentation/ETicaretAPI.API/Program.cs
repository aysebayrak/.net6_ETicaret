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
 * IOC  i�in serviceregistration.cs olu�turduk ve using    Microsoft.Extensions.DependencyInjection; yi nuget ettik.
 * Yazd���m�z metodu prgram.cs de tetiklemem laz�m. Ve persistence katman� i�indeki t�m servisler IOC containere eklenmi� bir �ekilde elde etmi� oluyoruz.
 * 
 * 
 * 
 */

/* KATMANLAR NOTLAR :
 * Domain ve Application katmanlar� Core klas�r�nde olu�turulur. ��nk�; bunlar �ekirdelk katmanlar.
 * 
 * Servislerimizi yazd���m�z infrastructure ve persistence katmanlr� �NTRASTRUCE klas�r� i�inde olu�turulur.
 * 
 * 
 * 
 */


