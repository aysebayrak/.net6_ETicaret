using ETicaretAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy=>
   policy.WithOrigins("http://localhost:4200/", "https://localhost:4200/").AllowAnyHeader().AllowAnyMethod()
));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

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

/*
 * Senkron Ve Asenkron Programlama:
 * 
 *Senkron :yazýlýþ sýrasýna göre yukarýdan aþaðýya doðru iþleyerek ilerler.
 * her þeyi sýrayla iþlemesi ve her bir iþlemin birbirini beklemesi yeri geldiðinde programýmýz
 * çok yavaþlatabilir, hatta iþlem bitene kadar durdurabilir. 
 * 
 * 
 * Asenkron : akýþýnýn sýrayla iþlemediði, iþlemlerin birbirini beklemediði, kod akýþýnýn iþlem 
 * durumlarýna göre devam ettiði programlamaya Asenkron Programlama denir.
 * 
 * 
 * 
 */

/* KATMANLAR NOTLAR :
 * Domain ve Application katmanlarý Core klasöründe oluþturulur. Çünkü; bunlar çekirdelk katmanlar.
 * 
 * Servislerimizi yazdýðýmýz infrastructure ve persistence katmanlrý ÝNTRASTRUCE klasörü içinde oluþturulur.
 * Veri tabaný ile ilgili Verinin gelmesi ile ilgili kodlar persistence ya yazýlýr. Context gibi
 * 
 * DbContextimde eklediðim dbsetleri  ýoc containere eklemem lazým.
 * Buný serviceregistration dan yapacaðým.
 */

/* Change Tracker : ef core aracýlýðýyla veri tabanýndan gelen  veriyi takip eden mekanizma.
* dbcontext üzerinden sorgulama neticesinde gelen datalalrýn, üzrinde de yapýlan deðiþikleri ef bu mekanizda sayesinde anlýyor.
* Takip edilen nesne üzerinde yapýlan deðiþikliði deleted, update ..  olup olmadýðýný anlayan mekanizma.
* EF core ile yapýlan tüm sorgular da default olarak change tracker devreye girer. Ve datalar takip edilir.
* GetAll gibi sadece son kullanýcýya göstermek  için çekilen veriler yani üzedinde update deleted gibi iþlemler yapmayacaksam üzeriden tracking operasyonunun olmasý mantýklý deðil. Bu olay maliyetlidir ve bazý noktalarda törpülememiz  gerek. Bunun için optimizasyon yapalým.
* 
* 
* Tracking devre dýþý býrakýldýðinda yapýlan deðiþiklilker veri tabanýna  kaydedilmeyecektir.
* 
*/


/* IQueryable ise LINQ for Database için yani veritabanýndan sorgulanan deðerler için kullanýlýyor.
* IEnumerable LINQ for Objects için, yani hafýzadaki List , dizi vs. sorgulamasý sonucunda elde edilecek deðerler için kullanýlýyor.
* 

*/

/* 
 * INTERCEPTER:
 * Baþlangýcý  ve bitiþi belli olan iþte araya girmeye denir.
 * Gelen datayý creatdate,update date  Datetimre.UtcNow  ver, yani otomatik doldur.
 * Ve yoluna devam et.
 * Bunlarý  merkezi bir konuma taþýayacaðýz.
 * Context içerisinde  SaveChangesAsync   ile yapalým. (repositýry de kullandýðýmýz SaveChangesAsync ile )
 * Gelen isteklerde yani insert ve update, de insert ise  creadetdate, update ise update kolanlarýný doldur diyeceðiz.
 * 
 * Kod içerisinde ChangeTracker ile deðiþklik yapýlan yada yeni eklenen veriyi yakalayabiliyoruz.
 * ChangeTracker.Entries = Entries ile gelen girdileri yakalýyoruz.
 * 
 * 
 */

/*  CORS
 *Program.cs de yapalým.  
 *
 * 
 */



