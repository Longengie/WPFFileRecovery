using ControlzEx.Theming;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WPFFileRecovery.Service.Commands;
using WPFFileRecovery.Service.Commands.Interfaces;
using WPFFileRecovery.Service.Folders;
using WPFFileRecovery.Service.Folders.Interfaces;

namespace WPFFileRecovery.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
            => _host = Host
                .CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
        private static void ConfigureServices(IServiceCollection service)
        {
            _ = service.AddSingleton<MainWindow>();
            _ = service.AddTransient<IExecuteCmd, ExecuteCmd>();
            _ = service.AddTransient<IExecuteWinfrCommand, ExecuteWinfrCommand>();
            _ = service.AddTransient<IDirectoryRepository, DirectoryRepository>();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            // Set MainWindows show only
            _host.Services.GetRequiredService<MainWindow>().Show();
            ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithAppMode;
            ThemeManager.Current.SyncTheme();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
