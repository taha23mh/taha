using ConsoleApp13;
using System.Collections.Generic;
using System;
using System.ComponentModel;

class Program
{
    static List<Person> users = new List<Person>();
    static Random random = new Random();

    static void Main()
    {
        Console.WriteLine("Welcome!");
        while (true)
        {
            Console.WriteLine("\n******************************************* ");
            Console.WriteLine("Please select one of the options below");
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("1-Creat100user");
            Console.WriteLine("\n ");
            Console.WriteLine("2-Enter the user");
            Console.WriteLine("\n ");
            Console.WriteLine("3-Search");
            Console.WriteLine("\n ");
            Console.WriteLine("4-PrintUsers");
            Console.WriteLine("\n ");
            Console.WriteLine("5-Exit");
            Console.WriteLine("\n============================================");




            var choice = Console.ReadKey();

            switch (choice.KeyChar)
            {
                case '1':
                    CreateRandomUsers(100);
                    break;
                case '2':
                    EnterUser();
                    break;
                case '3':
                    SearchUser();
                    break;
                case '4':
                    PrintUsers();
                    break;
                case '5':
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;


            }
        }
    }

    static void CreateRandomUsers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            users.Add(new Person
            {
                Id = i + 1,
                Name = "User" + (i + 1),
                NationalCode = random.Next(100000000, 999999999).ToString(),
                PhoneNumber = "09" + random.Next(10000000, 99999999).ToString(),
                Gender = random.Next(0, 2) == 0 ? true : false

            });
        }
        Console.WriteLine("\n ");
        Console.WriteLine($"{count} Random user created");
    }

    static void EnterUser()
    {
        Person newUser = new Person();

        Console.Write("Enter the name : \n ");
        newUser.Name = Console.ReadLine();


        Console.Write("Enter the national code: \n ");
        newUser.NationalCode = Console.ReadLine();

        Console.Write("Enter the phone number: \n ");
        newUser.PhoneNumber = Console.ReadLine();

        Console.Write("Enter Gender 1 (Male) / 2(Female): \n ");
        newUser.Gender = Console.ReadKey().KeyChar == '1' ? true : false;

        newUser.Id = users.Count + 1;
        users.Add(newUser);

        Console.WriteLine("New user added");
    }

    static void SearchUser()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("First you need to create users");
            return;
        }

        Console.Write("Enter the user's name or national code to search : \n");
        string searchTerm = Console.ReadLine();
        List<Person> fundUsers = new List<Person>();
        foreach (var user in users)
        {
            if (user.Name.Contains(searchTerm) || user.NationalCode.Contains(searchTerm))
            {
                fundUsers.Add(user);
            }
        }
        if (fundUsers.Count > 0)
        {
            Console.WriteLine("Users found");
            foreach (var user in fundUsers)
            {
                Console.WriteLine(user);
            }
        }
        else
        {
            Console.WriteLine("No user found");
        }
    }

    static void PrintUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("First you need to create users");
            return;
        }
        Console.WriteLine("\n -------------------------------------------");
        Console.WriteLine("UserList : \n");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}