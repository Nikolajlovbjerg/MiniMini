using ServerAPI.Repo;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<ICreateUserRepo, CreateUserRepoMongoDB>();

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors("policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();