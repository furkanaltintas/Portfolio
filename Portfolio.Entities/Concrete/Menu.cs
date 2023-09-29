using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.Concrete;

public class Menu : BaseEntity<int>, IEntity
{
    public string ComponentName { get; set; } = null!; // ViewComponent Adı
    public string Header { get; set; } = null!; // İçerik yazısı
    public string Slug { get; set; } = null!; // path yolu
    public string IconName { get; set; } = null!; // ikon adı
    public short Queue { get; set; } // sırası

    public ICollection<MenuHeader> MenuHeaders { get; set; }
}

// Home, la-home, Introduce, 1, Home