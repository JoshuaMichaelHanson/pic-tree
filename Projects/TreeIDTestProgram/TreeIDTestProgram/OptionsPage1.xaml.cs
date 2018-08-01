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
    public partial class OptionsPage1 : PhoneApplicationPage
    {
        Brush accentBrush;

        double txtFontSize;
        double txtTitleSize;

        IDictionary buttDic;//button dictionary for options
        IDictionary typeDic;

        ButtonHelper btnHelper;//button building class for this program
        public OptionsPage1()
        {
            InitializeComponent();


            accentBrush = this.Resources["PhoneAccentBrush"] as Brush;

            //reset title size
            Options1PageTitle.Style = (Style)this.Resources["PhoneTextTitle1Style"];

            txtFontSize = (double)this.Resources["PhoneFontSizeMedium"];
            txtTitleSize = (double)this.Resources["PhoneFontSizeExtraLarge"];
            //get screen rdy  may have to add waiting ...... here
            LoadPageOptions();//this loads a page based off off app.xaml.cs currentOptionsFile which is set by calling page or this page
        }

        //have to decrement gethome for everypage
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;//still want it to go back
            --(Application.Current as App).getHome; //want the home button options to know the user pressed the back key
        }  


        private void LoadPageOptions()
        {
            btnHelper = new ButtonHelper();

            XDocument loadedData = XDocument.Load((Application.Current as App).currentOptionsFile);
            var data = from query in loadedData.Descendants("Option")
                       select new Option
                       {
                           Name = (string)query.Element("Name"),
                           Image = (string)query.Element("Image"),
                           Width = (string)query.Element("Width"),
                           Height = (string)query.Element("Height"),
                           CallFile = (string)query.Element("CallFile"),
                           PageTitle = (string)query.Element("PageTitle"),
                           Type = (string)query.Element("Type")
                       };

            int dataCount = data.Count();//get count fromn query
            //buiild array of strings to hold buttons and files
            buttDic = new ButtonDictionary(dataCount);
            typeDic = new ButtonDictionary(dataCount);

            foreach (var item in data)
            {
                Button btn = new Button();

                buttDic.Add(btn, item.CallFile);
                typeDic.Add(btn, item.Type);
                //PreviewStackPanel.Children.Add(btnHelper.BuildSingleButtonPreviewButton(item, accentBrush, btn, txtFontSize));
                Options1StackPanel.Children.Add(btnHelper.BuildSingleButtonOptionButton(item, accentBrush, btn, txtFontSize));

                btn.Tap += (s, e) =>
                {
                    int counter = 0;
                    ICollection btns = buttDic.Keys;//make collection of buttons
                    ICollection callFile = buttDic.Values;//make collection of button functions to call
                    ICollection typeOfFile = typeDic.Values;//make collection of types

                    Button[] btnButtons = new Button[btns.Count];//array of buttons
                    String[] btnFile = new String[callFile.Count];//build string of method to call
                    String[] typeFile = new String[typeOfFile.Count];//build string of types

                    btns.CopyTo(btnButtons, 0);//copy collection to array
                    callFile.CopyTo(btnFile, 0);//copy file to array
                    typeOfFile.CopyTo(typeFile, 0);//copy to types

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
                                loadedData = XDocument.Load(((String)btnFile.GetValue(counter)));//throws fileException!!!
                               
                                ++(Application.Current as App).getHome;//only increment if we go to a new page

                                //this code should not be executed if file does not exist    
                                if ((String)typeFile.GetValue(counter) == "Option")
                                {
                                    (Application.Current as App).currentOptionsFile = ((String)btnFile.GetValue(counter));
                                    BuildNewPage();
                                }
                                else
                                {//must be a preview if its not an option
                                    (Application.Current as App).currentPreviewType = ((String)btnFile.GetValue(counter));
                                    BuildTreePreview();
                                }


                            }
                            catch (Exception fileException)
                            {
                                //--(Application.Current as App).getHome;

                                //bool myFalse = false;
                                //file does not exist 
                                //Debug.Assert(myFalse, ((String)btnFile.GetValue(counter)) + " does not exist");
                                //show a little message box telling my that the file does not exist
                                MessageBox.Show(((String)btnFile.GetValue(counter)) + " does not exist");
                                MessageBox.Show("Comming in the next release v2.0");
                                //--(Application.Current as App).getHome;//decrement get home since we are are not on a new page
                            }
                        }
                        ++counter;
                    }
                };

                //Page title is starting to take up have the page when I need more discriptions going to check for
                //length and mage font smaller as needed
                if (item.PageTitle.Length > 13)
                {
                    Options1PageTitle.FontSize = txtTitleSize;
                }
                Options1PageTitle.Text = item.PageTitle;
            }



        }

        private void BuildNewPage()
        {
            this.NavigationService.Navigate(new Uri("/OptionsPage.xaml", UriKind.Relative));
        }

        private void BuildTreePreview()
        {
            this.NavigationService.Navigate(new Uri("/TreePreview.xaml", UriKind.Relative));
        }
    }
}