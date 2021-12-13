using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    class Yacht
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string View { get; set; }
        public string Size { get; set; }

        public string GetInfo()
        {
            if
            (!string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(Title) &&
            !string.IsNullOrEmpty(View) && !string.IsNullOrEmpty(Size))
            {
                return $"ID: {ID}, Title: {Title}, Country: {Country}, View: {View}, Size:{Size}";
            }
            else
            {
                return "Error!";
            }
        }
    }
}
