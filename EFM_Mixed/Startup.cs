using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFM_Mixed.Domain.Repositories;
using EFM_Mixed.Domain.Services;
using EFM_Mixed.Persistence.SQL.Contexts;
using EFM_Mixed.Persistence.SQL.Repositories;
using EFM_Mixed.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EFM_Mixed
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<SQLDbContext>(options =>
            {
                options.UseSqlServer(Configuration["SQLServerConnection:ConnectionString"]);
            });

            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<IAssignmentRepository, SQLAssignmentRepository>();
            services.AddScoped<IEmployeeAssignmentRepository, SQLEmployeeAssignmentRepository>();
            services.AddScoped<IUnitOfWork, SQLUnitOfWork>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IEmployeeAssignmentService, EmployeeAssignmentService>();
            services.AddAutoMapper();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
