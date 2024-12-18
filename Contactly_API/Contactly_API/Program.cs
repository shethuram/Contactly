
using Contactly_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Contactly_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ContactlyDbcontext>(options =>
            options.UseInMemoryDatabase("ContactsDb"));              // we injected our Dbcontext here




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(policy =>policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()); // This allows DELETE, POST, GET, PUT, etc. from anyother server 


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
