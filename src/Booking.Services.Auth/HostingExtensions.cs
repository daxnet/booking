using Booking.Services.Auth.Data;
using Booking.Services.Auth.Models;
using Duende.IdentityServer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Booking.Services.Auth
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddIdentityServer(options =>
                {
                    options.IssuerUri = builder.Configuration["identityServer:issuer"];
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                    options.EmitStaticAudienceClaim = true;
                })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            //builder.Services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //        // register your IdentityServer with Google at https://console.developers.google.com
            //        // enable the Google+ API
            //        // set the redirect URI to https://localhost:5001/signin-google
            //        options.ClientId = "copy client ID from Google here";
            //        options.ClientSecret = "copy client secret from Google here";
            //    });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsProduction())
            {
                var fordwardedHeaderOptions = new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                    ForwardLimit = 2
                };
                fordwardedHeaderOptions.KnownNetworks.Clear();
                fordwardedHeaderOptions.KnownProxies.Clear();
                app.UseForwardedHeaders(fordwardedHeaderOptions);

                
                var basePath = app.Configuration["identityServer:basePath"];
                if (!string.IsNullOrEmpty(basePath))
                {
                    app.Map(basePath, app =>
                    {
                        app.UseSerilogRequestLogging();
                        app.UseStaticFiles();
                        app.UseRouting();
                        app.UseIdentityServer();
                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                            endpoints.MapRazorPages().RequireAuthorization();
                        });

                    });
                }
                else
                {
                    app.MapRazorPages().RequireAuthorization();
                }

                return app;
            }
            else
            {
                app.UseSerilogRequestLogging();
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseIdentityServer();
                app.UseAuthorization();

                app.MapRazorPages()
                    .RequireAuthorization();

                return app;
            }
        }
    }
}