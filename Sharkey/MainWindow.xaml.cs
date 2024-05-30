using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Sharkey.Models;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Microsoft.Win32;

namespace Sharkey
{
    public partial class MainWindow : Window
    {
        SharkeyContext db;
        private static readonly string EncryptionKey = "12345678901234567890123456789012"; // 32 байта ключ

        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            db = new SharkeyContext();
            var list = db.Profiles.ToList();
            var converter = new BrushConverter();
            ObservableCollection<Profile> profiles = new ObservableCollection<Profile>();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Number = i + 1;
            }

            profilesDataGrid.ItemsSource = list;
        }

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void AddProfileButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProfileWindow objAddProfileWindow = new AddProfileWindow(this);
            objAddProfileWindow.ShowDialog();
        }

        private void DeleteProfileButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return;
                }
                Button button = sender as Button;
                Profile profile = button.DataContext as Profile;
                if (profile == null)
                {
                    return;
                }

                Profile findProfile = db.Profiles.FirstOrDefault(p => p.Id == profile.Id);
                db.Profiles.Remove(findProfile);
                db.SaveChanges();
                Update();
            }
            catch
            {
                
            }
        }

        private void EditProfileButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Profile profile = button.DataContext as Profile;
            if (profile == null)
            {
                return;
            }

            Profile findProfile = db.Profiles.FirstOrDefault(p => p.Id == profile.Id);
            if (findProfile == null)
            {
                return;
            }

            EditProfileWindow editProfileWindow = new EditProfileWindow(this, findProfile);
            if (editProfileWindow.ShowDialog() == true)
            {
                Update();
            }
        }

        private void CloseWindowButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        private string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void ExportProfilesToJson()
        {
            var profiles = db.Profiles.ToList();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FileName = "Profiles.txt";
            saveFileDialog.Title = "Выберите место для экспорта профилей";
            string filePath = "Profiles.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                 filePath = saveFileDialog.FileName;
                var tempProfiles = profiles.Select(p => new
                {
                    Name = p.Name,
                    Category = p.Category,
                    Login = p.Login,
                    Hash = p.Hash
                }).ToList();
                string json = JsonConvert.SerializeObject(tempProfiles, Formatting.Indented);
                string encryptedJson = EncryptString(json);
                File.WriteAllText(filePath, encryptedJson);
                MessageBox.Show("Профили экспортированы в Profiles.txt", "Экспорт успешен", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            
        }

        private void ImportProfilesFromJson()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FileName = "Profiles.txt";
            openFileDialog.Title = "Выберите файл для импорта профилей";
            string filePath = "Profiles.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Profiles.txt не найден", "Импорт не удался", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                string encryptedJson = File.ReadAllText(filePath);


                string decryptedJson = DecryptString(encryptedJson);


                var profiles = JsonConvert.DeserializeObject<List<Profile>>(decryptedJson);


                db.Profiles.AddRange(profiles);
                db.SaveChanges();
                Update();
                
                MessageBox.Show("Профили импортированы из Profiles.txt", "Импорт успешен", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExportProfilesButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportProfilesToJson();
        }

        private void ImportProfilesButton_OnClick(object sender, RoutedEventArgs e)
        {
            ImportProfilesFromJson();
        }
    }
}
