using Examination.Application.Commands.V1.StartExam;
using Examination.Application.Mapping;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Domain.AggregateModels.UserAggregate;
using Examination.Infrastructure.Repositories;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace Examination.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddSingleton<IMongoClient>(c =>
            {
                return new MongoClient(
                    "mongodb://linh2nguyen:mr6iLL5KNp5piiK1M8gSFoiEqlVrYyMl0gcwv2LdbN2tlAITKnzTIij8TbkwnsxWkHUMFEv878y6ypY9RqVHzw==@linh2nguyen.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@linh2nguyen@");
            });
            services.AddScoped(c => c.GetService<IMongoClient>()?.StartSession());
            services.AddAutoMapper(cfg => { cfg.AddProfile(new MappingProfile()); });
            services.AddMediatR(typeof(StartExamCommandHandler).Assembly);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examination.API V1", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Examination.API V2", Version = "v2" });
            });
            services.Configure<ExamSettings>(Configuration);

            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IExamResultRepository, ExamResultRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examination.API v1");

                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Examination.API v2");
                } );

            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}