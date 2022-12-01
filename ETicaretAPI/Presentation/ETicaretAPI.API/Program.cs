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
 * IOC  i�in serviceregistration.cs olu�turduk ve using    Microsoft.Extensions.DependencyInjection; yi nuget ettik.
 * Yazd���m�z metodu prgram.cs de tetiklemem laz�m. Ve persistence katman� i�indeki t�m servisler IOC containere eklenmi� bir �ekilde elde etmi� oluyoruz.
 * 
 * 
 * 
 */

/*
 * Senkron Ve Asenkron Programlama:
 * 
 *Senkron :yaz�l�� s�ras�na g�re yukar�dan a�a��ya do�ru i�leyerek ilerler.
 * her �eyi s�rayla i�lemesi ve her bir i�lemin birbirini beklemesi yeri geldi�inde program�m�z
 * �ok yava�latabilir, hatta i�lem bitene kadar durdurabilir. 
 * 
 * 
 * Asenkron : ak���n�n s�rayla i�lemedi�i, i�lemlerin birbirini beklemedi�i, kod ak���n�n i�lem 
 * durumlar�na g�re devam etti�i programlamaya Asenkron Programlama denir.
 * 
 * 
 * 
 */

/* KATMANLAR NOTLAR :
 * Domain ve Application katmanlar� Core klas�r�nde olu�turulur. ��nk�; bunlar �ekirdelk katmanlar.
 * 
 * Servislerimizi yazd���m�z infrastructure ve persistence katmanlr� �NTRASTRUCE klas�r� i�inde olu�turulur.
 * Veri taban� ile ilgili Verinin gelmesi ile ilgili kodlar persistence ya yaz�l�r. Context gibi
 * 
 * DbContextimde ekledi�im dbsetleri  �oc containere eklemem laz�m.
 * Bun� serviceregistration dan yapaca��m.
 */

/* Change Tracker : ef core arac�l���yla veri taban�ndan gelen  veriyi takip eden mekanizma.
* dbcontext �zerinden sorgulama neticesinde gelen datalalr�n, �zrinde de yap�lan de�i�ikleri ef bu mekanizda sayesinde anl�yor.
* Takip edilen nesne �zerinde yap�lan de�i�ikli�i deleted, update ..  olup olmad���n� anlayan mekanizma.
* EF core ile yap�lan t�m sorgular da default olarak change tracker devreye girer. Ve datalar takip edilir.
* GetAll gibi sadece son kullan�c�ya g�stermek  i�in �ekilen veriler yani �zedinde update deleted gibi i�lemler yapmayacaksam �zeriden tracking operasyonunun olmas� mant�kl� de�il. Bu olay maliyetlidir ve baz� noktalarda t�rp�lememiz  gerek. Bunun i�in optimizasyon yapal�m.
* 
* 
* Tracking devre d��� b�rak�ld��inda yap�lan de�i�iklilker veri taban�na  kaydedilmeyecektir.
* 
*/


/* IQueryable ise LINQ for Database i�in yani veritaban�ndan sorgulanan de�erler i�in kullan�l�yor.
* IEnumerable LINQ for Objects i�in, yani haf�zadaki List , dizi vs. sorgulamas� sonucunda elde edilecek de�erler i�in kullan�l�yor.
* 

*/

/* 
 * INTERCEPTER:
 * Ba�lang�c�  ve biti�i belli olan i�te araya girmeye denir.
 * Gelen datay� creatdate,update date  Datetimre.UtcNow  ver, yani otomatik doldur.
 * Ve yoluna devam et.
 * Bunlar�  merkezi bir konuma ta��ayaca��z.
 * Context i�erisinde  SaveChangesAsync   ile yapal�m. (reposit�ry de kulland���m�z SaveChangesAsync ile )
 * Gelen isteklerde yani insert ve update, de insert ise  creadetdate, update ise update kolanlar�n� doldur diyece�iz.
 * 
 * Kod i�erisinde ChangeTracker ile de�i�klik yap�lan yada yeni eklenen veriyi yakalayabiliyoruz.
 * ChangeTracker.Entries = Entries ile gelen girdileri yakal�yoruz.
 * 
 * 
 */

/*  CORS
 *Program.cs de yapal�m.  
 *
 * 
 */



