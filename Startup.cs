using CursoWebApi.Data;
using CursoWebApi.Interfaces;
using CursoWebApi.Repositorios;
using CursoWebApi.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CursoWebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<BlogDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            //Objetos transitórios são sempre diferentes; uma nova instância é fornecida para todos os controladores e todos os serviços.

            //Objetos com escopo são os mesmos em uma solicitação, mas diferentes entre solicitações diferentes

            //Objetos singleton são os mesmos para cada objeto e cada solicitação(independentemente de uma instância ser fornecida ConfigureServices)

             services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IPostRepositorio, PostRepositorio>();

            services.AddTransient<ICategoriaServico, CategoriaServico>();
            services.AddTransient<IPostServico, PostServico>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
