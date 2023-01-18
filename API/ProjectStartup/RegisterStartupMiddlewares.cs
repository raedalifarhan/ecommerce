
namespace API.ProjectStartup
{
    public static class RegisterStartupMiddlewares
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            // // Configure the HTTP request pipeline.
            // if (!app.Environment.IsDevelopment())
            // {
            //     app.UseExceptionHandler("/Home/Error");
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //     app.UseHsts();
            // }
            // app.UseStaticFiles();
            // app.UseHttpsRedirection();
            // app.UseStaticFiles();

            // app.UseRouting();

            // app.UseAuthorization();

            // app.MapControllerRoute(
            //     name: "default",
            //     pattern: "{controller=Books}/{action=Index}/{id?}");

            return app;
        }
    }
}