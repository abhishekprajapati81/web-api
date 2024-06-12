using ABC._11june_Abhishek.DB.Data;
using ABC._11june_Abhishek.Repository.Implementation;
using ABC._11june_Abhishek.Repository.Interface;
using ABC._11june_Abhishek.Service.Interface;
using ABC._11june_Abhishek.Service.Service;
using Microsoft.EntityFrameworkCore;

namespace ABC._11june_Abhishek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SongManagementContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SongManagementContext") ?? throw new InvalidOperationException("Connection string 'SongManagementContext' not found.")));
            builder.Services.AddTransient(typeof(ISong), typeof(SongService));
            builder.Services.AddTransient(typeof(ISongRepository<>), typeof(SongRepository<>));
			// Add services to the container.
			builder.Services.AddCors((options) =>
			{
				options.AddPolicy("DevCors", (corsBuilder) =>
				{
					corsBuilder.WithOrigins(builder.Configuration.GetSection("ClientApplicationUrl").Value)

						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials();
				});
			});


			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseCors("DevCors");
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
