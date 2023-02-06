using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_app
{
    class Movie
    {
        private string title;
        private string director;
        private int time;
        private string [] cast;
        
        public Movie(string title, string director, int time, string[] cast)
        {
            this.title = title;
            this.director = director;
            this.time = time;
            this.cast = cast;
        }
        public Movie() { }
        public string Title
        {
            get { return title; }
        }
        public string Director
        {
            get { return director; }
        }
        public int Time
        {
            get { return time; }
        }
        public string [] Cast
        {
            get { return cast; }
        }

        public override string ToString()
        {
            return (title + " | " + director + " | " + time.ToString() + " minutes | " + string.Join(",", Cast));
        }

    }
}
