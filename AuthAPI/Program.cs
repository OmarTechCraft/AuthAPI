using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthAPI.Data; //  √ﬂœ „‰  ⁄œÌ· «·„”«— ≈–« ·“„ «·√„—

var builder = WebApplication.CreateBuilder(args);

// ≈÷«›… Œœ„«  DbContext „⁄ «” Œœ«„ « ’«· Supabase
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseConnection")));

// ≈÷«›… «·Œœ„«  «·√Œ—Ï
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  ﬂÊÌ‰ Œÿ √‰«»Ì» ÿ·» HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
