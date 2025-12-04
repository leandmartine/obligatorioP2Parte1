namespace Obligatorio_Martinez_Rodriguez_Parte_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Source - https://stackoverflow.com/a
            // Posted by jd0x0021, modified by community. See post 'Timeline' for change history
            // Retrieved 2025-11-13, License - CC BY-SA 4.0

            builder.Services.AddSession();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Source - https://stackoverflow.com/a
            // Posted by jd0x0021, modified by community. See post 'Timeline' for change history
            // Retrieved 2025-11-13, License - CC BY-SA 4.0

            app.UseSession();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
