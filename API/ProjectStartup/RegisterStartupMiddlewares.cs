
using API.Middleware;

namespace API.ProjectStartup
{
    public static class RegisterStartupMiddlewares
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}