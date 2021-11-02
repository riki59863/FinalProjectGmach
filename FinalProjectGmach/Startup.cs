using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DL;
using DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FinalProjectGmach
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
            services.AddControllers();
            services.AddScoped(typeof(ILoanBl), typeof(LoanBl));
            services.AddScoped(typeof(ILoanDl), typeof(LoanDl));
            services.AddScoped(typeof(IDepositsBl), typeof(DepositsBl));
            services.AddScoped(typeof(IDepositsDl), typeof(DepositsDl));
            services.AddScoped(typeof(IpaymentsBl), typeof(paymentsBl));
            services.AddScoped(typeof(IPaymentDl), typeof(paymentsDl));
            services.AddScoped(typeof(IWarningBl), typeof(WarningBl));
            services.AddScoped(typeof(IWarningDl), typeof(WarningDl));
            services.AddScoped(typeof(ILoginBl), typeof(LoginBl));
            services.AddScoped(typeof(ILoginDl), typeof(LoginDl));
            services.AddScoped(typeof(IUserBl), typeof(UserBl));
            services.AddScoped(typeof(IUserDl), typeof(UserDl));
            services.AddScoped(typeof(ICurrencyTypeBl), typeof(CurrencyTypeBl));
            services.AddScoped(typeof(ICurrencyTypeDl), typeof(CurrencyTypeDl));
            services.AddScoped(typeof(IGuarantyBl), typeof(GuarantyBl));
            services.AddScoped(typeof(IGuarantyDl), typeof(GuarantyDl));
            services.AddScoped(typeof(IDirectDebitBl), typeof(DirectDebitBl));
            services.AddScoped(typeof(IDirectDebitDl), typeof(DirectDebitDl));
            services.AddAutoMapper(typeof(AutoMapping));
            //services.AddScoped(typeof(IGuaranteeForLoanDl), typeof(GuaranteeForLoanDl));
            services.AddScoped(typeof(IWarningDl), typeof(WarningDl));
            services.AddDbContext<gmach1112020Context>(Options => Options.UseSqlServer(Configuration.GetConnectionString("MySiteDB")));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

        }
    }
}
