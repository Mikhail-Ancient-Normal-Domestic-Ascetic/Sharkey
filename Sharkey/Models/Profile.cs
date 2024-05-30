using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;

namespace Sharkey.Models;

public class Profile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Login { get; set; }
    public string Hash { get; set; }
    [NotMapped]
    public int Number { get; set; } = 1;
    public Profile(string name,string category,string login,string hash)
    {
        this.Name = name;
        this.Category = category;
        this.Login = login;
        this.Hash = hash;
    }
}