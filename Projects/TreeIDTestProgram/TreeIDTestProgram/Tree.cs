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
    public class Tree
    {
        string name;
        string otherName;
        string scientificName;
        string description;
        string leaves;
        string twigs;
        string seedConeOrFruit;
        string bark;
        string range;
        string remarks;
        string pic1;
        string pic2;
        string pic3;
        string pic4;
        string pic5;//for now lets limit to 5 pics of any certain tree type


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string OtherName
        {
            get { return otherName; }
            set { otherName = value; }
        }
        public string ScientificName
        {
            get { return scientificName; }
            set { scientificName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Leaves
        {
            get { return leaves; }
            set { leaves = value; }
        }
        public string Twigs
        {
            get { return twigs; }
            set { twigs = value; }
        }
        public string SeedConeOrFruit
        {
            get { return seedConeOrFruit; }
            set { seedConeOrFruit = value; }
        }
        public string Bark
        {
            get { return bark; }
            set { bark = value; }
        }
        public string Range
        {
            get { return range; }
            set { range = value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public string Pic1
        {
            get { return pic1; }
            set { pic1 = value; }
        }
        public string Pic2
        {
            get { return pic2; }
            set { pic2 = value; }
        }
        public string Pic3
        {
            get { return pic3; }
            set { pic3 = value; }
        }
        public string Pic4
        {
            get { return pic4; }
            set { pic4 = value; }
        }
        public string Pic5
        {
            get { return pic5; }
            set { pic5 = value; }
        }
    }
}
