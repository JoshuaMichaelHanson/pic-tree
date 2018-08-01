using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TreeIDTestProgram
{
    public class Option
    {
        string name;
        string image;
        string height;
        string width;
        string fontSize;
        string callMethod;
        string description;
        string callFile;
        string pageTitle;
        string type;

        public string Name
        {
            get { return name; }
            set { name = value; }  
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public string Width
        {
            get { return width; }
            set { width = value; }
        }

        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        public string FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        public string CallMethod
        {
            get { return callMethod; }
            set { callMethod = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string CallFile
        {
            get { return callFile; }
            set { callFile = value; }
        }

        public string PageTitle
        {
            get { return pageTitle; }
            set { pageTitle = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
    }
}
