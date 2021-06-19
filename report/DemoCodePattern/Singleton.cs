using System.Collections.Generic;
using System;

/*
    https://phambinh.net/bai-viet/singleton-design-pattern/
    https://www.oodesign.com/singleton-pattern.html

    _ It involve one class which is responsible to make sure there is no more than one instance
    _ It does by instantiating itseft in the same time, it provides a global point of access to that instance
    _ By doing it, the singleton class ensures the same instance can be use from everywhere, predicting direct invocation of the singleton constructor

    _ 2 things
        + Ensure that only one instance of a class is created
        + Provide a global point of access to the object


    _ In my application, I apply singleton pattern for the database connection. There are some problem if i use connection string and new keyword to create the database object for each time i need to get data from database.
        + First problem: your code will be repeated
        + Second problem: if 2 form run sequentially, you will have 2 connections in connection initialized
            => More connection => your computer can be consumed more resources => it can be poor performance
*/


namespace pj.DesignPatterm.Singleton
{
    public class MyDatabase
    {
        public string connectionString;
        public MyDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void openConnection()
        {
            Console.WriteLine("Successful to open connection");
        }

        public void closeConnection()
        {
            Console.WriteLine("Successful to close connection");
        }

        public void getData(string query)
        {
            Console.WriteLine($"Successful to get product from query: {query}");
        }

    }

    public class ThreadSafetySingleton
    {
        private static MyDatabase  _instance = null;
        private static string connectionString = "123";
        private static object syncRoot = new object();
        private ThreadSafetySingleton()
        {

        }
        public static MyDatabase getInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new MyDatabase(connectionString);
                    }
                }
            }
            return _instance;
        }
    
    }

    public class SingletonPattern
    {
        public static void Form1()
        {
            string connectionString = "123";
            var myDatabase = new MyDatabase(connectionString);
            myDatabase.openConnection();
            myDatabase.getData("SELECT * FROM dbo.Food");
            myDatabase.closeConnection();
            Console.WriteLine(myDatabase.GetHashCode());
        }

        public static void Form2()
        {
            string connectionString = "123";
            var myDatabase = new MyDatabase(connectionString);
            myDatabase.openConnection();
            myDatabase.getData("SELECT * FROM dbo.Drink");
            myDatabase.closeConnection();
            Console.WriteLine(myDatabase.GetHashCode());
        }

        public static void Form3()
        {
            var myDatabase = ThreadSafetySingleton.getInstance();
            myDatabase.openConnection();
            myDatabase.getData("SELECT * FROM dbo.Clothes");
            myDatabase.closeConnection();
            Console.WriteLine(myDatabase.GetHashCode());
        }

        public static void Form4()
        {
            var myDatabase = ThreadSafetySingleton.getInstance();
            myDatabase.openConnection();
            myDatabase.getData("SELECT * FROM dbo.Shoe");
            myDatabase.closeConnection();
            Console.WriteLine(myDatabase.GetHashCode());
        }
        
        public static void Run()
        {
            // Normal connection
            // Console.WriteLine("Form 1: ");
            // Form1();
            // Console.WriteLine();
            // Console.WriteLine("Form 2: ");
            // Form2();

            // SingleTon Connection
            Console.WriteLine("Form 3: ");
            Form3();
            Console.WriteLine();
            Console.WriteLine("Form 4: ");
            Form4();
        }
    }
}
