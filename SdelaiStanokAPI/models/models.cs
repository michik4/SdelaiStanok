/*namespace SdelaiStanokAPI.models {
    public class GalleryItem // Позиция галереи 
    {
        public int Id { get; set; }
        public required string Title { get; set; } // Заголовок позиции (можно взять из имени папки)
        public required string MainImagePath { get; set; } // Путь к главной картинке
        public int DescriptionId { get; set; }
        public required Description Description { get; set; }
        public List<GalleryImage> Images { get; set; } = new(); // Список изображений в позиции
        public List<Tag> Tags { get; set; } = new();
    }

    public class GalleryImage // Отдельное изображение
    {
        public int Id { get; set; }
        public required string ImagePath { get; set; } 
        public int GalleryItemId { get; set; }
        public required GalleryItem GalleryItem { get; set; }
    }

    public class Tag // Тег
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<GalleryItem> GalleryItems { get; set; } = new(); 

    }

    public class Description // Описание
    {
        public int Id { get; set; }
        public required string Text { get; set; }
    }
}
*/
namespace SdelaiStanokAPI.models
{
    public class GalleryItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string MainImagePath { get; set; } = null!;

        public int DescriptionId { get; set; }
        public Description Description { get; set; } = null!;

        public List<GalleryImage> Images { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
    }

    public class GalleryImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = null!;

        public int GalleryItemId { get; set; }
        public GalleryItem GalleryItem { get; set; } = null!;
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Many-to-many relationship with GalleryItem
        public List<GalleryItem> GalleryItems { get; set; } = new();
    }

    public class Description
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;

        // One-to-one relationship with GalleryItem (Optional)
        // public int GalleryItemId { get; set; } // If you want a bidirectional navigation property
        // public GalleryItem GalleryItem { get; set; } = null!; // Bidirectional navigation property

    }
}