using MontagemBelasPizzas.UI.Components;
using MontagemBelasPizzas.Business.Services.Produtos;
using MontagemBelasPizzas.Business.Services.Utilizadores;
using MontagemBelasPizzas.Data.Repositories.Produtos;
using MontagemBelasPizzas.Data.Repositories.Utilizadores;
using MontagemBelasPizzas.Data.Interfaces;
using MontagemBelasPizzas.Data;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

// Repositories
builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<VendaRepository>();
builder.Services.AddScoped<IngredienteRepository>();
builder.Services.AddScoped<LinhaDeMontagemRepository>();
builder.Services.AddScoped<MontagemRepository>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<OperacaoRepository>();
builder.Services.AddScoped<UtilizadorRepository>();

// Services
builder.Services.AddScoped<CompraService>();
builder.Services.AddScoped<VendaService>();
builder.Services.AddScoped<IngredienteService>();
builder.Services.AddScoped<LinhaDeMontagemService>();
builder.Services.AddScoped<MontagemService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<UtilizadorService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
