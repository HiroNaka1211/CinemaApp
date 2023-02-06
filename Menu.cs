using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Cinema_app
{
    class Menu
    {
        CustomerCollection customercollection = new CustomerCollection();
        MovieCollection moviecollection = new MovieCollection();
        public Menu() { }

        public void MainMenu()
        {
            bool end = false;

            WriteLine();
            WriteLine("                        #*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*");
            WriteLine("#*#*#*#*#*#*#*#*#*#*#*#* Manage cinema and customer aplication #*#*#*#*#*#*#*#*#*#*#*#*");
            WriteLine("                        #*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*");
            WriteLine();
            WriteLine("Welcome to the cinema management application");
            WriteLine("You can manage customers and cinemas in this application.");
            WriteLine();
            WriteLine("#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#* Start screen #*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*");

            while (!end)
            {
                WriteLine("What do you want to do? Please select the number from the below options");
                WriteLine("1: Manage customers");
                WriteLine("2: Manage cinemas");
                WriteLine("0: Quit");
                WriteLine();
                Write("Your selection >> ");
                string input = ReadLine();

                bool correctinput = Int32.TryParse(input, out int selection);

                if (!correctinput || selection < 0 || 2 < selection)
                {
                    WriteLine("Your input number is not valid.");
                    continue;
                }

                switch (selection)
                {
                    case 0:
                        end = true;
                        continue;
                    case 1:
                        ManageCustomer();
                        continue;
                    case 2:
                        ManageCinema();
                        continue;
                }
            }
        }
        public void ManageCustomer()
        {
            bool end = false;


            WriteLine("                        #*#*#*#*#*#*#*#*#*#*#*#*");
            WriteLine("#*#*#*#*#*#*#*#*#*#*#*#* Manage customers #*#*#*#*#*#*#*#*#*#*#*#*");
            WriteLine("                        #*#*#*#*#*#*#*#*#*#*#*#*");

            while (!end)
            {

                string firstname = "";
                string lastname = "";
                string payment = "";
                string inputfullname = "";
                int paymentselection = -1;
                string[] paymethod = { "Cash", "Card", "Mobile payment", "Else" };
                int nopay = 0;
                string mobile = "";  //I set string for mobile phone number because the phone number start 0 (not international code). If I set int for this, 0 will be ignored. Informtion from https://www.ringcentral.com/au/en/blog/understanding-international-phone-numbers/
                int numberofvisit = 1;
                string fullname = "";
                bool correctmobile = false;

                WriteLine();
                WriteLine("#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#* Management customer screen #*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*");
                WriteLine();
                WriteLine("1: Add new customer");
                WriteLine("2: Delete registered customer");
                WriteLine("3: Sell a ticket to registered customer");
                WriteLine("4: See the all customer information");
                WriteLine("5: Find customer");
                WriteLine("0: Go back to previous menu");
                WriteLine();
                Write("Your selection >> ");
                string input = ReadLine();
                bool correctinput = Int32.TryParse(input, out int selection);

                if (!correctinput || selection < 0 || 5 < selection)
                {
                    WriteLine("Your input is not valid.\nPlease input valid number.\nTry again.");
                    continue;
                }
                switch (selection)
                {
                    case 0:
                        end = true;
                        continue;
                    case 1:
                        WriteLine();
                        WriteLine("Please input new customer details.");
                        while (firstname == "")
                        {
                            WriteLine();
                            Write("Enter new customer firstname >> ");
                            firstname = ReadLine();
                        }
                        while (lastname == "")
                        {
                            WriteLine();
                            Write("Enter new customer lastname >> ");
                            lastname = ReadLine();
                        }
                        inputfullname = (firstname + "," + lastname).ToUpper();
                        while (mobile == "")
                        {
                            WriteLine();
                            Write("Enter new customer's mobile phone number(No hyphen, only numbers) >> ");
                            string phone = ReadLine();
                            correctmobile = long.TryParse(phone, out var phonenum);
                            if (!correctmobile || phonenum < 0)
                            {
                                WriteLine("The phone number must be assembled of only numbers");
                                continue;
                            }
                            mobile = phone;
                        }
                        foreach (Customer checkcustomer in customercollection)  //The owner can't input two guests who has the same name and mobile phone number. 
                        {
                            if (checkcustomer.FullName.ToUpper() == inputfullname && checkcustomer.Mobile == mobile)
                            {
                                WriteLine("The guest who has the same name ({0}) and the same mobile phone number {1} has alrady been registered.", inputfullname, mobile);
                                WriteLine("Please input new guest.");
                                firstname = "";
                                lastname = "";
                                mobile = "";
                                break;
                            }
                        }
                        if (firstname != "" && lastname != "" && mobile != "")
                        {
                            while (paymentselection < 0)
                            {
                                WriteLine();
                                WriteLine("Please select customer payment method below by number");
                                WriteLine();
                                foreach (var method in paymethod)
                                {
                                    nopay += 1;
                                    WriteLine("{0}: {1}", nopay.ToString(), method);
                                }
                                Write("Payment method (by number) >> ");
                                string correctpay = ReadLine();
                                correctmobile = Int32.TryParse(correctpay, out int payselection);
                                if (!correctmobile)
                                {
                                    WriteLine();
                                    WriteLine("Please input correct number");
                                    nopay = 0;
                                    continue;
                                }
                                if (payselection < 1 || payselection > 4)
                                {
                                    WriteLine();
                                    WriteLine("You should enter a number between 1 and 4");
                                    nopay = 0;
                                    continue;
                                }
                                paymentselection = payselection;

                                switch (paymentselection)
                                {
                                    case 1:
                                        payment = paymethod[0];
                                        continue;
                                    case 2:
                                        payment = paymethod[1];
                                        continue;
                                    case 3:
                                        payment = paymethod[2];
                                        continue;
                                    case 4:
                                        payment = paymethod[3];
                                        continue;
                                }

                            }
                            Customer customer = new Customer(firstname, lastname, mobile, payment, numberofvisit);

                            customercollection.InsertCustomer(customer);
                            WriteLine();
                            WriteLine("Adding {0}  {1} is succeeded.", customer.FullName, customer.Mobile);
                        }

                        continue;

                    case 2:
                        if (customercollection.Count > 0)
                        {
                            string phonenumber = "";
                            bool deleted = false;
                            WriteLine();
                            WriteLine("Input the details of the customer you want to delete.");
                            Write("Input firstname >> ");
                            firstname = ReadLine();
                            WriteLine();
                            Write("Input the lastname >> ");
                            lastname = ReadLine();
                            fullname = (firstname + "," + lastname).ToUpper();
                            while (phonenumber == "")
                            {
                                WriteLine();
                                Write("Enter new customer's mobile phone number(No hyphen, only numbers) >> ");
                                string phone = ReadLine();
                                correctmobile = long.TryParse(phone, out var phonenum);
                                if (!correctmobile || phonenum < 0)
                                {
                                    WriteLine("The phone number must be assembled of only numbers");
                                    continue;
                                }
                                phonenumber = phone;
                            }
                            WriteLine();
                            foreach (Customer deletecustomer in customercollection)
                            {
                                if (deletecustomer.FullName.ToUpper() == fullname && deletecustomer.Mobile == phonenumber)
                                {
                                    customercollection.Delete(deletecustomer);
                                    WriteLine("Delete completed of the customer >> {0}    {1}", fullname, phonenumber);
                                    deleted = true;
                                    break;
                                }
                            }
                            if (!deleted)
                            {
                                WriteLine("Not found such a customer : {0}    {1}", fullname, phonenumber);
                            }
                        }
                        else
                        {
                            WriteLine("There is no customer in the customer database.");
                        }


                        continue;

                    case 3:
                        string mobnum = "";
                        bool finduser = false;
                        if (customercollection.Count > 0)
                        {
                            WriteLine();
                            WriteLine("Which guest came? Input the guest information.");
                            Write("Input firstname >> ");
                            firstname = ReadLine();
                            WriteLine();
                            Write("Input the lastname >> ");
                            lastname = ReadLine();
                            fullname = (firstname + "," + lastname).ToUpper();
                            while (mobnum == "")
                            {
                                WriteLine();
                                Write("Enter new customer's mobile phone number(No hyphen, only numbers) >> ");
                                string phone = ReadLine();
                                correctmobile = long.TryParse(phone, out var phonenum);
                                if (!correctmobile || phonenum < 0)
                                {
                                    WriteLine("The phone number must be assembled of only numbers");
                                    continue;
                                }
                                mobnum = phone;
                            }
                            WriteLine();

                            int counter = 0;
                            foreach (Customer visitedguest in customercollection)
                            {
                                counter += 1;
                                if (visitedguest.FullName.ToUpper() == fullname && visitedguest.Mobile == mobnum)
                                {
                                    finduser = true;
                                    visitedguest.NumberOfVisit += 1;
                                    if (visitedguest.NumberOfVisit == 10)
                                    {
                                        visitedguest.NumberOfVisit = 0;
                                        WriteLine("The guest: {0}   {1} has atteneded 10 screenings.\nPlease give the guest a free ticket", fullname, mobnum);
                                        break;
                                    }
                                    else
                                    {
                                        WriteLine("The number of the guest's ({0}) screening attended  >> {1}", visitedguest.FullName, visitedguest.NumberOfVisit);
                                        WriteLine("Input size: {0}  Efficiency: {1}", customercollection.Count, counter);
                                    }

                                }
                            }
                            if (!finduser)
                            {
                                WriteLine("Not finded such a guest : {0}    {1}", fullname, mobnum);
                            }
                        }
                        else
                        {
                            WriteLine("There is no customer in the customer database");
                        }

                        continue;

                    case 4:
                        WriteLine();
                        WriteLine("{0,-15} {1, -15} {2, -20} {3, -15} {4,-5}", "Firstname", "Lastname", "Mobile phone number", "Payment method", "Number of visit");
                        foreach (Customer allcustomer in customercollection)
                        {
                            WriteLine();
                            WriteLine("{0,-15} {1, -15} {2, -20} {3, -15} {4, -5}", allcustomer.FirstName, allcustomer.LastName, allcustomer.Mobile,
                                allcustomer.Payment, allcustomer.NumberOfVisit.ToString());
                        }
                        continue;
                    case 5:
                        string phnumber = "";
                        bool find = false;
                        var correctphone = false;
                        WriteLine();
                        WriteLine("Input the details of the customer you want to find.");
                        Write("Input firstname >> ");
                        firstname = ReadLine();
                        WriteLine();
                        Write("Input the lastname >> ");
                        lastname = ReadLine();
                        fullname = (firstname + "," + lastname).ToUpper();
                        while (phnumber == "")
                        {
                            WriteLine();
                            Write("Enter new customer's mobile phone number(No hyphen, only numbers) >> ");
                            string phone = ReadLine();
                            correctphone = long.TryParse(phone, out var phonenum);
                            if (!correctphone || phonenum < 0)
                            {
                                WriteLine("The phone number must be assembled of only numbers");
                                continue;
                            }
                            phnumber = phone;
                        }
                        WriteLine();

                        foreach (Customer findcustomer in customercollection)
                        {
                            if (findcustomer.FullName.ToUpper() == fullname && findcustomer.Mobile == phnumber)
                            {
                                WriteLine("{0,-15} {1, -15} {2, -20} {3, -15} {4,-5}", "Firstname", "Lastname", "Mobile phone number", "Payment method", "Number of visit");
                                WriteLine();
                                WriteLine("{0,-15} {0, -15} {2, -20} {3, -15} {4, -5}", findcustomer.FirstName, findcustomer.LastName, findcustomer.Mobile,
                                    findcustomer.Payment, findcustomer.NumberOfVisit.ToString());
                                find = true;
                                break;
                            }
                        }
                        if (!find)
                        {
                            WriteLine("Not found such a customer : {0}    {1}", fullname, phnumber);
                        }
                        continue;
                }

            }
        }

        public void ManageCinema()
        {
            bool end = false;

            while (!end)
            {
                string title = "";
                string director = "";
                int time = -1;
                string inputtime;
                string[] cast = null;
                bool correcttime = false;
                WriteLine();
                WriteLine("#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#* Management movie screen #*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*");
                WriteLine("1: Add new movie");
                WriteLine("2: Delete the current movie");
                WriteLine("3: Select the next movie");
                WriteLine("4: See the schedule");
                WriteLine("5: Check the movie collection");
                WriteLine("0: Go back to previous menu");
                WriteLine();
                Write("Your selection >> ");
                string input = ReadLine();
                bool correctinput = Int32.TryParse(input, out int selection);

                if (!correctinput || selection < 0 || 5 < selection)
                {
                    WriteLine("Your input is not valid.\nPlease input valid number.\nTry again.");
                    continue;
                }

                switch (selection)
                {
                    case 0:
                        end = true;
                        continue;

                    case 1:
                        WriteLine("Please input new movie information.");
                        while (title == "")
                        {
                            WriteLine();
                            Write("Input new movie title >> ");
                            title = ReadLine();
                        }
                        while (title == "")
                        {
                            WriteLine();
                            Write("Input the directro >> ");
                            director = ReadLine();
                        }
                        while (time < 0)
                        {
                            WriteLine();
                            Write("Input duration of movie (minutes) >> ");
                            inputtime = ReadLine();
                            correcttime = Int32.TryParse(inputtime, out var duration);
                            if (!correcttime)
                            {
                                WriteLine();
                                WriteLine("The duration of movie must be number");
                                WriteLine();
                                continue;
                            }

                            time = duration;

                        }
                        while (cast == null)
                        {
                            WriteLine();
                            Write("Input casts (Please input comma(,) between casts) >> ");
                            cast = ReadLine().Split(",");
                            for (int x = 0; x < cast.Length; x++)
                            {
                                cast[x] = cast[x].Trim();
                            }
                        }
                        Movie movie = new Movie(title, director, time, cast);

                        moviecollection.InsertMovie(movie);
                        WriteLine("Adding {0} is succeeded.", title);


                        continue;
                    case 2:
                        WriteLine();
                        moviecollection.Pop();
                        WriteLine("Delete succeeded.");
                        continue;

                    case 3:
                        WriteLine();
                        moviecollection.Pop();
                        moviecollection.GetNewMovie();
                        continue;

                    case 4:
                        WriteLine();
                        moviecollection.Showschedule();
                        continue;
                    case 5:
                        WriteLine();
                        moviecollection.ShowmovieCollection();
                        continue;
                }
            }
        }

        public void AddNewCustomer(Customer customer)        //This assignment, I will insert some customers first because I need to test if this program works well.
        {                                                    //Therefore, if you do not need to insert any values first, this method is not needed.
            customercollection.InsertCustomer(customer);
        }
        public void AddNewMovie(Movie movie)
        {
            moviecollection.InsertMovie(movie);
        }
    }

}
