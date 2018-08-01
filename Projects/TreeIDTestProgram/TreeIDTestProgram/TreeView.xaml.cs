using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Xml;
using System.Xml.Linq; // for XDocument
using System.Windows.Media.Imaging;//for jpgs
using System.Collections;

namespace TreeIDTestProgram
{
    public partial class TreeView : PhoneApplicationPage
    {
        Style txtBlkStyle = new Style();

        public TreeView()
        {
            txtBlkStyle = this.Resources["PhoneTextLargeStyle"] as Style;

            InitializeComponent();
            BuildView();
        }

        //have to decrement gethome for everypage
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;//still want it to go back
            --(Application.Current as App).getHome; //want the home button options to know the user pressed the back key
        }  


        private void BuildView()
        {
            XDocument loadedData = XDocument.Load((Application.Current as App).currentTreeType);
            var data = from query in loadedData.Descendants("Def")
                       select new Tree
                       {
                           Name = (string)query.Element("Name"),
                           OtherName = (string)query.Element("OtherName"),
                           ScientificName = (string)query.Element("ScientificName"),
                           Description = (string)query.Element("Description"),
                           Leaves = (string)query.Element("Leaves"),
                           Twigs = (string)query.Element("Twigs"),
                           SeedConeOrFruit = (string)query.Element("SeedConeOrFruit"),
                           Bark = (string)query.Element("Bark"),
                           Range = (string)query.Element("Range"),
                           Remarks = (string)query.Element("Remarks"),
                           Pic1 = (string)query.Element("Pic1"),
                           Pic2 = (string)query.Element("Pic2"),
                           Pic3 = (string)query.Element("Pic3"),
                           Pic4 = (string)query.Element("Pic4"),
                           Pic5 = (string)query.Element("Pic5")
                       };
            //we know only one in data set since we only put one tree in a file at this point
            foreach (var item in data)
            {
                pivotControl.Title = item.Name;

                TextBlock textBlockAdd = new TextBlock();
                textBlockAdd.TextWrapping = TextWrapping.Wrap;
                textBlockAdd.Style = txtBlkStyle;

                textBlockAdd.Text = "Tree Name: " + "\n" + item.Name + "\n" + "\n" +
                    "Other Name:" + "\n" + item.OtherName + "\n" + "\n" +
                    "Scientific Name:" + "\n" + item.ScientificName + "\n" + "\n" +
                    "Description:" + "\n" + item.Description;

                descriptionGrid.Children.Add(textBlockAdd);

                textBlockAdd = new TextBlock();
                textBlockAdd.TextWrapping = TextWrapping.Wrap;
                textBlockAdd.Style = txtBlkStyle;

                textBlockAdd.Text = item.Leaves;
                leavesGrid.Children.Add(textBlockAdd);

                textBlockAdd = new TextBlock();
                textBlockAdd.TextWrapping = TextWrapping.Wrap;
                textBlockAdd.Style = txtBlkStyle;

                textBlockAdd.Text = item.Twigs;
                twigsGrid.Children.Add(textBlockAdd);

                textBlockAdd = new TextBlock();
                textBlockAdd.TextWrapping = TextWrapping.Wrap;
                textBlockAdd.Style = txtBlkStyle;

                textBlockAdd.Text = item.SeedConeOrFruit;
                seedConeOrFruitGrid.Children.Add(textBlockAdd);

                textBlockAdd = new TextBlock();
                textBlockAdd.TextWrapping = TextWrapping.Wrap;
                textBlockAdd.Style = txtBlkStyle;

                textBlockAdd.Text = item.Bark;
                barkGrid.Children.Add(textBlockAdd);

                textBlockAdd = new TextBlock();
                textBlockAdd.TextWrapping = TextWrapping.Wrap;
                textBlockAdd.Style = txtBlkStyle;

                textBlockAdd.Text = item.Range;
                rangeGrid.Children.Add(textBlockAdd);

                textBlockAdd = new TextBlock();
                textBlockAdd.TextWrapping = TextWrapping.Wrap;
                textBlockAdd.Style = txtBlkStyle;

                textBlockAdd.Text = item.Remarks;

                //try a rich text block
                //RichTextBox textBlockAdd2 = new RichTextBox();
                //textBlockAdd2.TextWrapping = TextWrapping.Wrap;
                //textBlockAdd2.Style = txtBlkStyle;
                //Paragraph myPar = new Paragraph();
                //myPar.Inlines.Add(item.Remarks);
                //textBlockAdd2.Blocks.Add(myPar);
                
                
                remarksGrid.Children.Add(textBlockAdd);

                //looks like we need a stack panel to place the pictures on and the put the stack panel onto the picPanel
                StackPanel stkPanel = new StackPanel();

                if (item.Pic1 != "NA")
                {
                    Uri uriImg = new Uri(item.Pic1, UriKind.Relative);
                    ImageSource imgSource = new BitmapImage(uriImg);
                    Image img = new Image();
                    img.Source = imgSource;

                    stkPanel.Children.Add(img);

                    if (item.Pic2 != "NA")
                    {
                        uriImg = new Uri(item.Pic2, UriKind.Relative);
                        imgSource = new BitmapImage(uriImg);
                        img = new Image();

                        img.Source = imgSource;

                        stkPanel.Children.Add(img);

                        if (item.Pic3 != "NA")
                        {
                            uriImg = new Uri(item.Pic3, UriKind.Relative);
                            imgSource = new BitmapImage(uriImg);
                            img = new Image();

                            img.Source = imgSource;

                            stkPanel.Children.Add(img);

                            if (item.Pic4 != "NA")
                            {
                                uriImg = new Uri(item.Pic4, UriKind.Relative);
                                imgSource = new BitmapImage(uriImg);
                                img = new Image();

                                img.Source = imgSource;

                                stkPanel.Children.Add(img);

                                //i am limiting it to 5 pictures per tree at this time
                                if (item.Pic5 != "NA")
                                {
                                    uriImg = new Uri(item.Pic5, UriKind.Relative);
                                    imgSource = new BitmapImage(uriImg);
                                    img = new Image();

                                    img.Source = imgSource;

                                    stkPanel.Children.Add(img);
                                }
                            }
                        }
                    }
                
                    //add stackpanel to picpanel here
                    picturesGrid.Children.Add(stkPanel);
                }
            }
        }
    }
}