using System.Windows;
using Sharkey.Models;

namespace Sharkey;

public partial class EditProfileWindow : Window
{
    SharkeyContext db = new SharkeyContext();
    private MainWindow _mainWindow;
    private Profile _editProfile;
    
    public EditProfileWindow(MainWindow mainWindow, Profile editProfile)
    {
        _editProfile = editProfile;
        _mainWindow = mainWindow;
        InitializeComponent();
        textBoxName.Text = editProfile.Name;
        textBoxCategory.Text = editProfile.Category;
        textBoxLogin.Text = editProfile.Login;
        PasswordTextBox.Text = editProfile.Hash;

    }
    private void GeneratePassword_Click(object sender, RoutedEventArgs e)
    {
        PasswordTextBox.Text = PasswordGenerator.GeneratePassword(16); // Генерация пароля длиной 16 символов
    }
    
    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    
    private void ButtonSave_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        var findProfile = db.Profiles.FirstOrDefault(p=>p.Id==_editProfile.Id);
        findProfile.Name = textBoxName.Text;
        findProfile.Category = textBoxCategory.Text;
        findProfile.Login = textBoxLogin.Text;
        findProfile.Hash = PasswordTextBox.Text;
        db.SaveChanges();
        Close();
    }
}