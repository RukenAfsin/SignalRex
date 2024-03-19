using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

namespace SignalRServerExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Servisleri konteynýra ekle.
            builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
            policy.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin=>true)
            ));

            builder.Services.AddTransient<MyBusiness>();

            builder.Services.AddControllers();
            // Swagger/OpenAPI yapýlandýrmasý hakkýnda daha fazla bilgi için: https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddControllers();

            var app = builder.Build();

            // HTTP isteði boru hattýný yapýlandýr.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MyHub>("/myhub");
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
