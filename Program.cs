using System;

namespace Cinema_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            Random rand = new Random();

            Movie[] movies = new Movie[]
                {
                    new Movie("A Space Odyssey", "Stanley Kubrick", 141, new string[]{"William Sylvester, Keir Dullea, Gary Lockwood, Leonard Rossiter"}),
                    new Movie("The Godfather", "Francis Ford Coppola", 175, new string[]{"Richard Castellano, Robert Duvall, Marlon Brando"}),
                    new Movie("The French Dispatch", "Wes Anderson", 108, new string[]{"Benicio Del Toro, Adrien Brody, Tilda Swinton"}),
                    new Movie("BLACK PANTHER", "Ryan Coogler", 134, new string[]{"Chadwick Boseman, Michael B. Jordan, Lupita Nyong'o"}),
                    new Movie("AVENGERS: ENDGAME", "Anthony Russo, Joe Russo", 181, new string[]{"Robert Downey Jr., Chris Evans, Mark Ruffalo"}),
                    new Movie("MISSION: IMPOSSIBLE -- FALLOUT", "Christopher McQuarrie", 147, new string[]{"Tom Cruise, Henry Cavill, Ving Rhames"}),
                    new Movie("SPIDER-MAN: INTO THE SPIDER-VERSE", "Bob Persichetti, Peter Ramsey, Rodney Rothman", 117, new string[]{"Shameik Moore, Jake Johnson, Hailee Steinfeld" }),
                    new Movie("WONDER WOMAN", "Patty Jenkins", 141, new string[]{"Gal Gadot, Chris Pine, Connie Nielsen" }),
                    new Movie("STAR WARS: THE LAST JEDI", "Rian Johnson", 152, new string[]{"Mark Hamill, Carrie Fisher, Adam Driver, Daisy Ridley"}),
                    new Movie("INCREDIBLES 2", "Brad Bird", 118, new string[]{"Craig T. Nelson, Holly Hunter, Sarah Vowell"}),
                    new Movie("ZOOTOPIA", "Byron Howard, Rich Moore", 108, new string[]{"Ginnifer Goodwin, Jason Bateman, Shakira"}),
                    new Movie("SPIDER-MAN: HOMECOMING", "Jon Watts", 133, new string[]{"Tom Holland, Michael Keaton, Robert Downey Jr."}),
                    new Movie("THE JUNGLE BOOK", "Jon Favreau", 105, new string[]{"Neel Sethi, Bill Murray, Ben Kingsley" }),
                    new Movie("HARRY POTTER AND THE DEATHLY HALLOWS: PART 2", "David Yates", 131, new string[]{"Daniel Radcliffe, Rupert Grint, Emma Watson"}),
                    new Movie("Dune: Part One", "Denis Villeneuve", 155, new string[]{"Timothée Chalamet, Rebecca Ferguson, Oscar Isaac" })
                };
            for (int i = 0; i < 15; i++)
            {
                menu.AddNewMovie(movies[i]);
            }
            


            string[] firstname = {"Adney", "Addison", "Amherst", "Annabeth", "Ashland",
                                  "Baker", "Blade", "Carol", "Christy", "Corky",
                                  "Brawley", "Devon", "Diamond", "Ellen", "Byron",
                                  "Norvin", "Tacey", "Taria", "Randal", "Velvet"};   //I set these things to insert customer information to collections. This is just used for testing my code will work.
            
            string[] lastname = {"Adams", "Allen", "Anderson", "Armstrong", "Atkinson",
                                 "Bailey", "Ball", "Barker", "Barnes","Bell",
                                 "Bennett", "Booth", "Bradley", "Brooks","Brown",
                                 "Burton", "Cole", "Davidson", "Davies", "Ford"};    //Therefore, this is not nessesary if I do not need to test my code.
            
            string[] paymethod = { "Cash", "Card", "Mobile payment", "Else" };
            int numberofvisit;
            int customernumber = 130;
            const int max = 9;

            for (int x = 0; x < customernumber; x++)
            {
                string givenname = firstname[rand.Next(20)];
                string surname = lastname[rand.Next(20)];
                string phonenumber = "0";
                int first = rand.Next(4, 6);
                phonenumber += first;
                for (int y = 0; y < max; y++)
                {
                    phonenumber += rand.Next(10);
                }
                string payment = paymethod[rand.Next(4)];
                numberofvisit = rand.Next(10);
                Customer customer = new Customer(givenname, surname, phonenumber, payment, numberofvisit);
                menu.AddNewCustomer(customer);
            }
            menu.MainMenu();
        }
    }
}
