using Selu383.SP25.Api.Data;

namespace Selu383.SP25.Api.Seeding
{
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThroeIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredServices<DataContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return app;
        }
    }
}