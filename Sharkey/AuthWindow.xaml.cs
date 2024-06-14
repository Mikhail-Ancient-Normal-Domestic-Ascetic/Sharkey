using System.Windows;

namespace Sharkey;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ButtonAuth_OnClick(object sender, RoutedEventArgs e)
    {
        if (textBoxUserName.Text=="Mikhail"& textBoxPassword.Text=="123456")
        {
            new MainWindow().Show();
            Close();
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}