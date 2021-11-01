using System.IO;
string name = System.Environment.UserName;
Console.WriteLine(name);
Console.WriteLine("Hello, welocme to TempCleaner!");
while (true)
{
    Console.WriteLine("[1] - Clean temp");
    Console.WriteLine("[2] - Exit");
    byte userNum = byte.Parse(Console.ReadLine());
    
    switch (userNum)
    {
        case 1:
            {
                Console.Clear();
                Console.WriteLine("[1] - Clean all temp");
                Console.WriteLine("[2] - Clean windows temp");
                Console.WriteLine("[3] - Clean appdata temp");

                byte userNumMenu = byte.Parse(Console.ReadLine());

                switch (userNumMenu)
                {
                    case 1:
                        {
                            CleanWindowsTemp();
                            CleanAppDataTemp();
                            break;
                        }
                    case 2:
                        {
                            CleanWindowsTemp();
                            break;
                        }
                    case 3:
                        {
                            CleanAppDataTemp();
                            break;
                        }
                    default:
                        {
                            wrongNum();
                            break;
                        }
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("Thanks for use our programme");
                return;
            }
        default:
            {
                wrongNum();
                break;
            }
    }
}

static void CleanWindowsTemp()
{
    DirectoryInfo dirInfo = new("C:\\Windows\\Temp");

    foreach (DirectoryInfo dir in dirInfo.GetDirectories())
    {
        try
        {
            dir.Delete(true);
        }
        catch
        {
            Console.WriteLine($"Folders not deleted: {dir.Name}");
        }
    }
    foreach (FileInfo file in dirInfo.GetFiles())
    {
        try
        {
            file.Delete();
        }
        catch (Exception)
        {
            Console.WriteLine($"Files not deleted: {file.Name}");
        }
    }
    Console.WriteLine("Temp was cleaned secsesfully");
}

void CleanAppDataTemp()
{
    DirectoryInfo dirInfo = new($"C:\\Users\\{name}\\AppData\\Local\\Temp");

    foreach (DirectoryInfo dir in dirInfo.GetDirectories())
    {
        try
        {
            dir.Delete(true);
        }
        catch (Exception)
        {
            Console.WriteLine($"Folders not deleted: {dir.Name}");
        }
    }
    foreach (FileInfo file in dirInfo.GetFiles())
    {
        try
        {
            file.Delete();
        }
        catch (Exception)
        {
            Console.WriteLine($"Files not deleted: {file.Name}");
        }
    }
    Console.WriteLine("AppData was secsessfull cleaned");
}

static void wrongNum()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Soory, you enter wrong number!");
    Console.ResetColor();
}