using EC04_C_sharp_Adress_book_ConsoleApp.Services;

// Instance of MenuService
var menu = new MenuService();

// Where the JSON file goes
menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";

// Keeps app running,could add bool to break it.
while (true)
{
    menu.MainMenu();
}