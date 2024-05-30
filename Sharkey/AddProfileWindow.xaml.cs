using System.Windows;
using Sharkey.Models;

namespace Sharkey;

public partial class AddProfileWindow : Window
{
    SharkeyContext db = new SharkeyContext();
    private MainWindow _mainWindow;
    public AddProfileWindow(MainWindow mainWindow )
    {
        _mainWindow = mainWindow;
        InitializeComponent();
        
    }
    private void GeneratePassword_Click(object sender, RoutedEventArgs e)
    {
        PasswordTextBox.Text = PasswordGenerator.GeneratePassword(16); // Генерация пароля длиной 16 символов
    }
    
    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
        
    }

    
    private void ButtonSave_Click(object sender, RoutedEventArgs e)
    {
        string profile_name = textBoxName.Text.Trim();
        string profile_category = textBoxCategory.Text.Trim();
        string profile_login = textBoxLogin.Text.Trim();
        string profile_hash = PasswordTextBox.Text.Trim();
        Profile profile = new Profile(profile_name,profile_category,profile_login,profile_hash);
        db.Profiles.Add(profile);
        db.SaveChanges();
        _mainWindow.Update();
        Close();
    }
}