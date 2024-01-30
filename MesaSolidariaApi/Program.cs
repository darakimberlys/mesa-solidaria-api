using MesaSolidariaApi.IoC;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddServices();
builder.Services.AddDataBaseConnection(configuration);
builder.Services.AddPubSubConfiguration(configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Donation}/{action=Index}/{id?}");
});


app.Run();