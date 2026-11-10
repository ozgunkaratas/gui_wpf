using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// The LOGIC half of the InputDialog class (the layout is in InputDialog.xaml).
    /// A dialog with one text field and OK / Cancel buttons.
    /// OK shows the entered text in a message box, where the user can
    /// confirm (OK) or go back and edit (Cancel).
    /// </summary>
    public partial class InputDialog : Window
    {
        /// <summary>The value the user entered (valid after ShowDialog() returned true).</summary>
        public string InputValue => InputBox.Text;

        public InputDialog()
        {
            // Generated in obj\Debug\net10.0-windows\InputDialog.g.cs:
            // loads InputDialog.baml, creates the controls, assigns the
            // InputBox / OkButton / CancelButton fields and hooks Click -> OnOkClicked.
            // Before this line those fields are still null.
            InitializeComponent();
        }

        // Called because InputDialog.xaml says Click="OnOkClicked".
        // WinForms version: _okButton.Click += OnOkClicked; in the constructor.
        private void OnOkClicked(object sender, RoutedEventArgs e)
        {
            string value = InputBox.Text.Trim();

            if (value.Length == 0)
            {
                MessageBox.Show(this, "Please enter a value.", "Input required",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                InputBox.Focus();
                return;
            }

            MessageBoxResult answer = MessageBox.Show(this,
                $"You entered:\n\n{value}",
                "Confirm",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information);

            if (answer == MessageBoxResult.OK)
            {
                // Validated: report success to the caller.
                // Unlike WinForms, setting DialogResult in WPF closes the window
                // by itself, so no Close() call is needed.
                DialogResult = true;
            }
            else
            {
                // Cancelled in the message box: stay in the dialog to edit the value.
                InputBox.Focus();
                InputBox.SelectAll();
            }
        }
    }
}
