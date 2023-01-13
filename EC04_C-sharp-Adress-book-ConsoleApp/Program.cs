using EC04_C_sharp_Adress_book_ConsoleApp.Services;

var Menu = new MenuService();
Menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

while (true)
{
    Menu.MainMenu();
}