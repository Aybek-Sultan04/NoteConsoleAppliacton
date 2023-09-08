using Note.Application.Exeption;
using Note.Presentation.Menu;

namespace Note.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool move = true;
            while (move)
            {
                try
                {
                    Console.WriteLine("Select an action\n1.sing in\n2.create accaut\n3.Exit");
                    string action = Console.ReadLine()??"4";
                    if (action == "1")
                    {
                        SingIn singIn = new SingIn();
                        singIn.InnerId();
                    }
                    else if (action == "2")
                    {
                            CreateAccaunt createAccaunt = new CreateAccaunt();
                        bool res = createAccaunt.Create();
                        if (res)
                            Console.WriteLine("Complited Succsessfuly");
                        else Console.WriteLine("Something went wrong\nTry again...");
                    }
                    else if (action == "3")
                    {
                        move = false;
                        Console.Clear(); 
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("no such operation!\nTry again...");
                        
                    }
                }
                catch (InvalidAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IvalidEmailException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
} 