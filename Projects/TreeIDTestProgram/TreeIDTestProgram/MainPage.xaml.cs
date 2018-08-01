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
using Microsoft.Phone.Shell;




namespace TreeIDTestProgram
{
    public partial class MainPage : PhoneApplicationPage
    {
        Brush accentBrush;
        
        IDictionary buttDic;//button dictionary for main options
        // Constructor
        ButtonHelper btnHelper;
        

        public MainPage()
        {
            InitializeComponent();

            //set forground color for default items with no image
            accentBrush = this.Resources["PhoneAccentBrush"] as Brush;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            (Application.Current as App).picTreeWorking = new ProgressIndicator
            {
                IsVisible = true,
                IsIndeterminate = true,
                Text = "Working"
            };

            SystemTray.SetProgressIndicator(this, (Application.Current as App).picTreeWorking);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //get main screen ready
            LoadMainOptions();
            //Touch.FrameReported += OnTouchFrameReported;
        }

       
        private void LoadMainOptions()
        {
           btnHelper = new ButtonHelper();
          
            Option option; //used to add last button if happends to be one after loop
            //open main options XML file
           XDocument loadedData = XDocument.Load("XmlFiles/mainOptions.xml");
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
           
           
            int buttonCount = 0;
            int lastButton = 0;
            Button button;
            
            int dataCount = data.Count();
            //we are going to build a array of strings to hold button names and methods to call
            buttDic = new ButtonDictionary(dataCount);
            //build a dictionary of button names with the method they should call

            foreach(var item in data)
            {
                option = item;
                ++buttonCount;//lets line up two buttons per panel
               ++lastButton;//track buttons for case of only one at end

                if (buttonCount == 3)
                {
                    buttonCount = 1;
                   
                }
               
                if(item.Image == "NoImage")
                {     
                    //Button noImageButton = new Button();
                    button = new Button();
                  

                    //;btnHelper.BuildSingleButtonNoBorder(item, accentBrush, noImageButton);
                    
                    MainStackPanel.Children.Add(btnHelper.BuildSingleButtonNoImage(item, accentBrush, button));
                   
                    //button count back to 0 in-case I add more options
                    buttonCount = 0;
                }
                else
                {

                    button = new Button();
                    if (buttonCount == 1)
                    {
                        button.HorizontalAlignment = HorizontalAlignment.Left;
                    }
                    else
                    {
                        button.HorizontalAlignment = HorizontalAlignment.Right;
                    }

                    if (buttonCount == 2)
                    {
                       
                        MainStackPanel.Children.Add(btnHelper.BuildTwoButtonStackPanelWithTopText(item, accentBrush, button));
                    }
                    else if(buttonCount == 1 && lastButton == dataCount)
                    {
                        //this hadles case at end with only one button
                        MainStackPanel.Children.Add(btnHelper.BuildTwoButtonStackPanelWithTopText(item, accentBrush, button));
                    }
                    else
                    {   //call and add button but discard retured stackPanel till it has two buttons
                        btnHelper.BuildTwoButtonStackPanelWithTopText(item, accentBrush, button);
                    }

                   


                    

                   
                }//end else
                //lets put button logic here was missing case of noImage and must just make into button
                buttDic.Add(button, item.CallMethod); //remember to add to dictionary or it will not know which button was taped!!!!


                ////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Start Button Tap///////////////////////////////////////////////////////////////////////////////////////
                button.Tap += (s, e) =>
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
                                case "ConiferousOptions":
                                    BuildConiferousPage();
                                    break;
                                case "DeciduousOptions":
                                    BuildDeciduousPage();
                                    break;
                                case "BrowseOptions":
                                    BuildBrowsePage();
                                    break;

                            }
                        }
                        //BuildNewPage();

                        ++counter;
                    }
                };
                //////////////////End Button Tap COOL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                /////////////////////////////////////////////////////////////////////////////////////////////////////

                
            }//end for

            (Application.Current as App).picTreeWorking.IsVisible = false;
        }

        //this will handle the buttons from main page
        /*void OnTouchFrameReported(object sender, TouchFrameEventArgs args)
        {
            //here will find out what button was pushed and call the appropriate method to build the new page.
            TouchPoint primaryTouchPoint = args.GetPrimaryTouchPoint(null);

            //having trouble scrollig while finger is on button
            if (primaryTouchPoint != null && primaryTouchPoint.Action == TouchAction.Move)
            {

            }
            else if(primaryTouchPoint != null && primaryTouchPoint.Action == TouchAction.Down)
            {
                int counter = 0;
                ICollection btns = buttDic.Keys;//make collection of buttons
                ICollection callMethod = buttDic.Values;//make collection of button functions to call
                Button[] btnButtons = new Button[btns.Count];//array of buttons
                String[] btnMethod = new String[callMethod.Count];//build string of method to call
                btns.CopyTo(btnButtons, 0);//copy collection to array
                callMethod.CopyTo(btnMethod, 0);//copy method to array
                Button btn;
               

                while(counter < buttDic.Count)
                {
                    btn = (Button)btnButtons.GetValue(counter);

                    if(btn.IsPressed)
                    {

                        switch ((String)btnMethod.GetValue(counter))
                        {
                            //call the method associated with the button that was pressed
                            case "ConiferousOptions":
                                BuildConiferousPage();
                                break;

                                
                        }
                        //BuildNewPage();
                    }
                    ++counter;
                }
            }
        }
        */
        public void BuildConiferousPage()
        {
            this.NavigationService.Navigate(new Uri("/ConiferousOptions.xaml", UriKind.Relative));
        }

        public void BuildDeciduousPage()
        {
            //didnt want to rewrite entire main program so Im hard coding this.  Not right but works fine :)
            (Application.Current as App).currentOptionsFile = "XmlFiles/Trees/Deciduous/Options/MainDeciduousOptions.xml";
            this.NavigationService.Navigate(new Uri("/OptionsPage.xaml", UriKind.Relative));
        }

        public void BuildBrowsePage()
        {
            (Application.Current as App).picTreeWorking.IsVisible = true;

            //this is going to look at all the tree previews and load a huge page the user can scroll down
            //and just pick the tree they want more information about
            //going to neeed this directory XmlFiles/Trees/TreePreview
            (Application.Current as App).currentPreviewType = "XmlFiles/Trees/TreePreview/MasterList.xml";
            this.NavigationService.Navigate(new Uri("/BrowsePage.xaml", UriKind.Relative));
        }
    }
}