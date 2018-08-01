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
    public partial class TreePreview : PhoneApplicationPage
    {
        Brush accentBrush;
        Style txtBlockStyle;
        double txtFontSize;

        IDictionary buttDic;//button dictionary for options

        ButtonHelper btnHelper;//button building class for this program

        public TreePreview()
        {
            InitializeComponent();

            accentBrush = this.Resources["PhoneAccentBrush"] as Brush;
            txtBlockStyle = this.Resources["PhoneFontSizeLarge"] as Style;
            txtFontSize = (double)this.Resources["PhoneFontSizeMedium"];
            //get screen rdy  may have to add waiting ...... here
            LoadTreePreview();
        }

        //have to decrement gethome for everypage
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;//still want it to go back
            --(Application.Current as App).getHome; //want the home button options to know the user pressed the back key
        }  


        private void LoadTreePreview()
        {
            btnHelper = new ButtonHelper();

            XDocument loadedData = XDocument.Load((Application.Current as App).currentPreviewType);
            var data = from query in loadedData.Descendants("Def")
                       select new Preview
                       {
                           Name = (string)query.Element("Name"),
                           Image = (string)query.Element("Image"),
                           TreeType = (string)query.Element("TreeType"),
                           Width = (string)query.Element("Width"),
                           Height = (string)query.Element("Height"),
                           Type = (string)query.Element("Type")
                       };

           // int buttonCount = 0;
           // int lastButton = 0;
            //since I am using big buttons dont need these for now

            int dataCount = data.Count();
            //build array of strings to hold buttons and methods
            buttDic = new ButtonDictionary(dataCount);

            foreach (var item in data)
            {
                Button btn = new Button();

                buttDic.Add(btn, item.TreeType);

                PreviewStackPanel.Children.Add(btnHelper.BuildSingleButtonPreviewButton(item, accentBrush, btn, txtFontSize));

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
                            //lets add some error handling incase the file does not exist
                            try
                            {
                               
                                //see if file exists
                                loadedData = XDocument.Load(((String)btnMethod.GetValue(counter)));

                                ++(Application.Current as App).getHome;
                                
                                (Application.Current as App).currentTreeType = ((String)btnMethod.GetValue(counter));
                                BuildTreeView();
                            }
                            catch (Exception noFile)
                            {
                                //--(Application.Current as App).getHome;
                                //dont need this as exception is thrown before get home is incremented
                                //MessageBox.Show(((String)btnMethod.GetValue(counter)) + " does not exist");
                                MessageBox.Show("Coming soon!");
                            }
                        }
                        ++counter;
                    }
                };

                PreviewTitle.Text = item.Type;
            }

        }

        private void BuildTreeView()
        {

            this.NavigationService.Navigate(new Uri("/TreeView.xaml", UriKind.Relative));
        }
    }
}