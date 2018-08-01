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
    public partial class ScalelikeOptions : PhoneApplicationPage
    {
        Brush accentBrush;

        IDictionary buttDic;//button dictionary for options

        ButtonHelper btnHelper;//button building class for this program

        public ScalelikeOptions()
        {
            InitializeComponent();

            accentBrush = this.Resources["PhoneAccentBrush"] as Brush;

            //get screen rdy  may have to add waiting ...... here
            LoadScalelikeOptions();
        }

        //have to decrement gethome for everypage
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;//still want it to go back
            --(Application.Current as App).getHome; //want the home button options to know the user pressed the back key
        }  


        private void LoadScalelikeOptions()
        {
            btnHelper = new ButtonHelper();

            Option option;

            XDocument loadedData = XDocument.Load("XmlFiles/ScalelikeOptions.xml");
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

            int dataCount = data.Count();
            //build array of strings to hold buttons and methods
            buttDic = new ButtonDictionary(dataCount);
            //build a dictionaryt of button names

            foreach (var item in data)
            {
                option = item;
                ++buttonCount;//lets line up two buttons per panel
                ++lastButton;//track buttons for case of only one at end

                if (buttonCount == 3)
                {
                    buttonCount = 1;
                }

                if (item.Image == "NoImage")
                {
                    Button noImageButton = new Button();

                    buttDic.Add(noImageButton, item.CallMethod);//add to button dictonary

                    MainStackPanel.Children.Add(btnHelper.BuildSingleButtonNoImage(item, accentBrush, noImageButton));

                    buttonCount = 0;  //this fills up a whole 173 X 346 button
                }
                else
                {
                    Button button = new Button();

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
                    else if (buttonCount == 1 && lastButton == dataCount)
                    {
                        //this hadles case at end with only one button
                        MainStackPanel.Children.Add(btnHelper.BuildTwoButtonStackPanelWithTopText(item, accentBrush, button));
                    }
                    else
                    {
                        //call and add button but discard 
                        btnHelper.BuildTwoButtonStackPanelWithTopText(item, accentBrush, button);
                    }

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
                                //so home button works
                                ++(Application.Current as App).getHome;

                                switch ((String)btnMethod.GetValue(counter))
                                {
                                   

                                    //call the method associated with the button that was pressed
                                    case "Arborvitae":
                                        //(Application.Current as App).currentTreeType = "XmlFiles/Trees/Coniferous/NorthernWhiteCedar.xml";
                                        //BuildTreeView();
                                        //need to build preview for multiple types
                                        (Application.Current as App).currentPreviewType = "XmlFiles/Trees/TreePreview/ArborvitaePreview.xml";
                                        BuildTreePreview();
                                        break;
                                    case "Junipers":
                                        //(Application.Current as App).currentTreeType = "XmlFiles/Trees/Coniferous/Juniper.xml";
                                        //BuildTreeView();
                                        //need to build preview for multiple types
                                        (Application.Current as App).currentPreviewType = "XmlFiles/Trees/TreePreview/JuniperPreview.xml";
                                        BuildTreePreview();
                                        break;

                                }
                            }
                            //BuildNewPage();

                            ++counter;
                        }
                    };
                    //////////////////End Button Tap COOL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    /////////////////////////////////////////////////////////////////////////////////////////////////////

                }
            }

        }

        private void BuildTreeView()
        {

            this.NavigationService.Navigate(new Uri("/TreeView.xaml", UriKind.Relative));
        }

        private void BuildTreePreview()
        {
            this.NavigationService.Navigate(new Uri("/TreePreview.xaml", UriKind.Relative));
        }
    }
}