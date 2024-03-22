
using Microsoft.AspNetCore.SignalR;
using SignalRChatEx.Hubs;

namespace SignalRChatEx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            policy.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => true)
            ));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chathub");

            });


            app.Run();
        }
    }
}
