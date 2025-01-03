using Autofac;
using Autofac.Extensions.DependencyInjection;
using OverallAuth01.PlugInUnit;

namespace OverallAuth01
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add SwaggerPlugInUnit to the container.
            builder.Services.InitSwagger();
            //�Զ���Autofac�м��
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule<AutofacPlugIn>();
            });

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // �������������� Swagger
            if (app.Environment.IsDevelopment())
            {
                // use Swagger Plugin Unit
                app.InitSwagger();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
