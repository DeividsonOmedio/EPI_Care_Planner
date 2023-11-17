using Epi_Care_Planner.Services;
using Epi_Care_Planner.Services.Intrefaces;
using Microsoft.Extensions.Logging;

namespace Epi_Care_Planner
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
            return builder.Build();
        }
    }
}