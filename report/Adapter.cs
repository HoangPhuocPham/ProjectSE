using System;
namespace pj.DesignPatterm.Adapter
{
    /*
        https://gpcoder.com/4483-huong-dan-java-design-pattern-adapter/
        https://www.oodesign.com/adapter-pattern.html

        _ To be adapting between classes and objects.
        _ Example: phone connect to laptop by adapter. The idea of this pattern like this
        _
            + Target - defines the domain-specific interface that Client uses
            + Adapter - adapts the interface Adaptee to the Target interface
            + Adaptee - defines an existing interface that needs adapting
            + Client - collaborates with objects conforming to the Target interface
    */

    // Target
    public interface ITarget
    {
        void SendInfo(User userInfo);
    }

    // Adaptee
    public class SecurityService
    {
        public string Encode(User data)
        {
            return "Successful to Encode";
        }
        public string DeCode(User data)
        {
            return "Successful to Decode";
        }
    }

    // Adapter
    class Registration : ITarget
    {
        private SecurityService _service;

        public Registration(SecurityService service)
        {
            this._service = service;
        }
        public void SendInfo(User userInfo)
        {
            Console.WriteLine("To be Encoding");
            Console.WriteLine($"firstName: {userInfo.firstName}, lastName: {userInfo.lastName}");
            string encode = _service.Encode(userInfo);
            Console.WriteLine($"your encode: {encode}. To be sending to database...");
        }

    }

    public class AdapterPattern
    {
        public static void Run()
        {
            User userInfo = new User() {firstName = "Phuoc", lastName = "Pham", address = "Bien Hoa"};
            SecurityService service = new SecurityService();
            ITarget target = new Registration(service);
            target.SendInfo(userInfo);
        }
    }
}