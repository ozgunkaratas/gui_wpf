using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Replaces Program.cs from the WinForms version.
    ///
    /// Where is Main()? WPF generates it in obj\Debug\net10.0-windows\App.g.cs:
    ///     var app = new App(); app.InitializeComponent(); app.Run();
    /// InitializeComponent() hooks Startup -> App_Startup (from App.xaml),
    /// and app.Run() raises Startup once the message loop is running.
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            // WinForms used "using var dialog" because a Form is IDisposable.
            // A WPF Window is not, so a plain variable is enough.
            var dialog = new InputDialog();

            // ShowDialog() returns bool? in WPF:
            //   true  -> OK was confirmed (DialogResult = true in OnOkClicked)
            //   false -> Cancel / Escape / window closed with the X
            if (dialog.ShowDialog() == true)
            {
                // The user typed a value and confirmed it in the message box.
                // Do something with dialog.InputValue here.
            }

            Shutdown();
        }
    }
}
