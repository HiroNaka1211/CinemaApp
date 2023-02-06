using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Cinema_app
{
    class LinkedList<T>  //Stack can be created by using linked list. Therefore, in this class, Node<T> is used.
    {
        private Node<T> latest = default; // Having empty node, this is useuful to judge if the loop continue. Tis bottom is always changing to the latest one.
        public LinkedList() { }          
        public Node<T> Latest
        {
            get { return this.latest; }
        }
        public int Count { get; set; }
        public Node<T> Push(T obj)
        {
            Node<T> newnode = new Node<T>(obj, this.latest);
            this.latest = newnode;
            this.Count += 1; 
            return newnode;
        }

        public Node<T> Pop()
        {
            if (this.latest != null) //If the node is not bottom, the node can be deleted.
            {
                Node<T> store = latest;
                this.latest = latest.Next;
                this.Count -= 1;
                return store;

            }
            WriteLine("There is no movie in the database anymore. The current one is the last.");
            return default;
        }
        public Node<T> InsertMovie(T obj)
        {
            if (latest != default)
            {
                Node<T> newnode = new Node<T>(obj, this.latest.Next);
                this.latest.Next = newnode;
                this.Count += 1;
                return newnode;
            }
            else
            {
                Node<T> newnode = new Node<T>(obj, this.latest);
                this.latest = newnode;
                this.Count += 1;
                return newnode;
            }
            

        }

        public void ShowmovieCollection()
        {
            Node<T> current = this.Latest;
            WriteLine("Movie title | Director | Time(minutes) | casts");
            WriteLine();
            while (current != null)
            {
                WriteLine(current.Element);
                WriteLine();
                current = current.Next;
            } 
        }
        

        
        public T GetNewMovie()
        {
            if (Latest != null)
            {
                WriteLine("Next movie is {0}", Latest.Element);
                return Latest.Element;
            }
            WriteLine("There is no movie in the database");
            return default;
        }

        public T GetMovie()    //This method is for scheduling
        {
            if (Latest != null)
            {
                return Latest.Element;
            }
            WriteLine("There is no movie in the database");
            return default;
        }
        public T ShowNextMovie()
        {
            if (Latest != null)
            {
                return Latest.Next.Element;
            }
            WriteLine("There is no movie in the database");
            return default;
        }

        public void Showschedule()
        {
            bool correctinput = false;

            while (!correctinput)
            {
                var today = DateTime.Today;
                var s1 = today.ToString("yyyy/MM/dd");
                int countofnumber = 1;
                bool countinput = false;
                string cou = "";
                WriteLine("Current screening movie >> {0}", GetMovie());
                WriteLine();
                WriteLine("Next screenign movie >> {0}", ShowNextMovie());
                WriteLine();
                Write("How many screenings does the current movie been left? \nIf three times has already shown, input 0.\nNote: In that case,current screening movie which was shown above will be deleted automatically >> ");

                cou = ReadLine();
                countinput = Int32.TryParse(cou, out var inputcount);
                countofnumber = 1;
                Node<T> current = this.Latest;
                if (inputcount == 0)
                { Pop(); }
                if (0 <= inputcount && inputcount <= 3)
                {
                    for (int i = 0; i < inputcount; i++)
                    {
                        WriteLine(s1 + ": " + current.Element);
                        if (countofnumber % 2 == 0)
                        {
                            today = today.AddDays(1);
                            s1 = today.ToString("yyyy/MM/dd");
                            WriteLine();
                        }
                        countofnumber += 1;
                    }
                    current = current.Next;

                    while (current != null)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            WriteLine(s1 + ": " + current.Element);
                            if (countofnumber % 2 == 0)
                            {
                                today = today.AddDays(1);
                                s1 = today.ToString("yyyy/MM/dd");
                                WriteLine();
                            }
                            countofnumber += 1;
                        }
                        current = current.Next;
                    }
                    correctinput = true;
                }
                else
                {
                    WriteLine("Your input is not valid. Please input between 1 or 2");
                }
            }
        }
    }
}
