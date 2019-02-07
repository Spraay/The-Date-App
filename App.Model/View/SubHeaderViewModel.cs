using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.View
{
    public class SubHeaderViewModel
    {
        public string Title { get; set; } = "some title";
        public string TitleColour { get; set; } = "white-text";
        public string TitleIcon { get; set; } = "white-text";
        public string TitleIconColor { get; set; } = "white";
        public string Message { get; set; } = "";
        public string MessageColor { get; set; } = "";
    }
}
