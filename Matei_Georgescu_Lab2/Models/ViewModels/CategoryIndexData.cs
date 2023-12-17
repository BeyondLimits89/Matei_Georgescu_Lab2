namespace Matei_Georgescu_Lab2.Models.ViewModels
{
    public class CategoryBooksViewModel
    {
        public IList<Category> Categories { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
        public IList<Book> Books { get; set; }
        

    }
}

