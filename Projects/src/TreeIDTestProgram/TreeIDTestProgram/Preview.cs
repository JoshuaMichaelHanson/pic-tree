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
    public class Preview
    {
        string name;
        string image;
        string treeType;
        string width;
        string height;
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

        public string TreeType
        {
            get { return treeType; }
            set { treeType = value; }
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

        public string Type
        {
            get { return type; }
            set {type = value; }
        }
    }
}
