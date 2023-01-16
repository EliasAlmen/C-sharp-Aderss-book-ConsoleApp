using EC04_C_sharp_Adress_book_ConsoleApp.Services;

var menu = new MenuService();
menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";
while (true)
{
    menu.MainMenu();
}