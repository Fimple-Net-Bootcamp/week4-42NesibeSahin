using FluentValidation;
using FluentValidation.AspNetCore;
using DataAccessLayer.Context;
using hafta3.Middleware;
using hafta3.Validations;
using DataAccessLayer;
using EntityLayer;


var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<ProjeDB>(DbContextOptions => DbContextOptions.UseSqlite(
//	builder.Configuration["ConnectionStrings:ProjeDBConnectionString"]
//));

builder.Services.AddDALSubService(builder.Configuration);

builder.Services.AddEntitySubService(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

//builder.Services.AddControllers().AddFluentValidation(s=> {
//	s.RegisterValidatorsFromAssemblyContaining<AktivitelerValidation>();
//	});


builder.Services.AddControllers().AddFluentValidation(s => {
	s.RegisterValidatorsFromAssemblyContaining<AktivitelerValidation>();
	s.RegisterValidatorsFromAssemblyContaining<BesinlerValidation>();
	s.RegisterValidatorsFromAssemblyContaining<BeslenmeValidation>();
	s.RegisterValidatorsFromAssemblyContaining<EgitimValidation>();
	s.RegisterValidatorsFromAssemblyContaining<EvcilHayvanValidation>();
	s.RegisterValidatorsFromAssemblyContaining<KullaniciValidation>();
	s.RegisterValidatorsFromAssemblyContaining<SaglikDurumlariValidation>();
	s.RegisterValidatorsFromAssemblyContaining<SosyalEtkilesimlerValidation>();
});

//builder.Services.AddSingleton<IValidator<AktivitelerDTO>, AktivitelerValidation>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
  
app.UseHttpsRedirection();


app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();

