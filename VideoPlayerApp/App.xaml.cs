using System;
using System.Windows;
using System.Windows.Threading;

namespace VideoPlayerApp
{
    public partial class App : Application
    {
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Показываем полное сообщение об ошибке
            MessageBox.Show(
                $"Необработанное исключение:\n{e.Exception.GetType()}: {e.Exception.Message}\n\n{e.Exception.StackTrace}",
                "Ошибка", 
                MessageBoxButton.OK, 
                MessageBoxImage.Error
            );

            // Чтобы приложение не умирало сразу (можно убрать, если хотите жёсткий сброс)
            e.Handled = true;
        }
    }
}