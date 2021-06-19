namespace pj.DesignPatterm.Bridge
{
    using System;

    public interface Screen
    {
        string getType();
    }

    public abstract class Position
    {
        public Screen screen { get; set; }

        public string getType()
        {
            return screen.getType();
        }
    }

    public class UserScreen : Screen
    {
        public string getType()
        {
            return "User Screen";
        }
    }

    class ManagerScreen : Screen
    {
        public string getType()
        {
            return "Manager Screen";
        }
    }

    class UserPosition : Position
    {

    }

    class ManagerPosition : Position
    {

    }

    public class BridgePattern  
    {
        public static void Run()
        {
            var managerscreen = new ManagerScreen();
            var userscreen = new UserScreen();
            var user = new UserPosition { screen = userscreen };
            var manager = new ManagerPosition { screen = managerscreen };


            Console.WriteLine($"Manager: {manager.getType()}");
            Console.WriteLine($"User: {user.getType()}");
        }
    }
}