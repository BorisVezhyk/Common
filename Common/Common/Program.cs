
var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(o => o.UseInMemoryDatabase("UserDb"));
builder.Services.AddTransient<IUserRepo, UserRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/users", async (IUserRepo repo) =>
{
	return Results.Ok(await repo.GetUsersAsync());
});

app.MapGet("api/user/{id}", async (IUserRepo repo, int id) =>
{
	User? user = await repo.GetUserAsync(id);
	
	return user is null ? Results.NotFound() : Results.Ok(user);
});

app.MapPost("api/user", async (IUserRepo repo, User user) =>
{
	await repo.AddUserAsync(user);
	
	return Results.Created($"api/user/{user.Id}", user);
});

app.MapPut("api/user", async (IUserRepo repo, User updateUser) =>
{
	try
	{
		await repo.UpdateUserAsync(updateUser);
		return Results.NoContent();
	}
	catch (InvalidOperationException)
	{
		return Results.NotFound();
	}
});

app.MapDelete("api/user/{id}", async (IUserRepo repo, int id) =>
{
	try
	{
		await repo.RemoveUserAsync(id);
		return Results.Ok();
	}
	catch (InvalidOperationException)
	{
		return Results.NotFound();
	}
});

app.Run();
