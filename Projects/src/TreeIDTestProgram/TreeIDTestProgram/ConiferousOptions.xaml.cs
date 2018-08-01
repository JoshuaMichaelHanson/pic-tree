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
    public partial class ConiferousOptions : PhoneApplicationPage
    {
        Brush accentBrush;
        IDictionary buttDic;//button dictionary for main options
        // Constructor

        public ConiferousOptions()
        {
            //set forground color for default items with no image
            accentBrush = this.Resources["PhoneAccentBrush"] as Brush;

            InitializeComponent();

            //load coniferousoptions
            LoadConiferousOptions();
            //Touch.FrameReported += OnTouchFrameReported;
        }

        //have to decrement gethome for everypage
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;//still want it to go back
            --(Application.Current as App).getHome; //want the home button options to know the user pressed the back key
        }  


        private void LoadConiferousOptions()
        {
            XDocument loadedData = XDocument.Load("XmlFiles/ConiferousOptions.xml");
           var data = from query in loadedData.Descendants("Option")
                      select new Option
                      {
                          Name = (string)query.Element("Name"),
                          Image = (string)query.Element("Image"),
                          Width = (string)query.Element("Width"),
                          Height = (string)query.Element("Height"),
                          FontSize = (string)query.Element("FontSize"),
                          CallMethod = (string)query.Element("CallMethod")
                      };
           
            Grid addGrid;  //we are going to add this to MainStackPanel
           
            
            int dataCount = data.Count();
            //we are going to build a array of strings to hold button names and methods to call
            buttDic = new ButtonDictionary(dataCount);
            //build a dictionary of button names with the method they should call

            foreach (var item in data)
            {
                addGrid = new Grid();
                TextBlock txtBlk = new TextBlock();
                txtBlk.Text = item.Name;

                //txtBlk.Foreground = accentBrush;

                txtBlk.FontSize = Convert.ToInt32(item.FontSize);

                addGrid.Height = (Convert.ToInt32(item.Height) + 35);//should probably have this be a app resource
                addGrid.Width = Convert.ToInt32(item.Width);

                Button btn = new Button();
                btn.Width = addGrid.Width;
                btn.Height = Convert.ToInt32(item.Height);

                Uri uriImg = new Uri(item.Image, UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uriImg);
                Image img = new Image();

                img.Source = imgSource;

                btn.Content = img;
                btn.BorderBrush = new SolidColorBrush(Colors.Transparent);

                txtBlk.HorizontalAlignment = HorizontalAlignment.Center;
                addGrid.Children.Add(txtBlk);

                buttDic.Add(btn, item.CallMethod);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                btn.Tap += (s, e) =>
                {
                    int counter = 0;
                    ICollection btns = buttDic.Keys;//make collection of buttons
                    ICollection callMethod = buttDic.Values;//make collection of button functions to call
                    Button[] btnButtons = new Button[btns.Count];//array of buttons
                    String[] btnMethod = new String[callMethod.Count];//build string of method to call
                    btns.CopyTo(btnButtons, 0);//copy collection to array
                    callMethod.CopyTo(btnMethod, 0);//copy method to array

                    Button tapBtn = new Button();

                    while (counter < buttDic.Count)
                    {
                        tapBtn = (Button)btnButtons.GetValue(counter);

                        if (tapBtn == s)
                        {
                            ++(Application.Current as App).getHome;

                            switch ((String)btnMethod.GetValue(counter))
                            {
                                //call the method associated with the button that was pressed
                                case "Scalelike":
                                    BuildScalelike();
                                    break;
                                case "Needlelike":
                                    (Application.Current as App).currentOptionsFile = "XmlFiles/Trees/Coniferous/Options/LinearNeedlelikeOptions.xml";
                                    this.NavigationService.Navigate(new Uri("/OptionsPage.xaml", UriKind.Relative));
                                    break;
                            }
                        }
                        //BuildNewPage();

                        ++counter;
                    }
                };
                //////////////////End Button Tap COOL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                /////////////////////////////////////////////////////////////////////////////////////////////////////

                btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn.Background = accentBrush;

                addGrid.Children.Add(btn);

                addGrid.HorizontalAlignment = HorizontalAlignment.Left;
                MainStackPanel.Children.Add(addGrid);
            }
        }

        private void BuildScalelike()
        {
            this.NavigationService.Navigate(new Uri("/ScalelikeOptions.xaml", UriKind.Relative));
        }
    }
}