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
    public class ButtonHelper
    {
        StackPanel stackPanel;//this persistise for the life of the button helper
        

        //remember to add button name to button before sending to this funciton
        //also add button to a button dictionary
        public Grid BuildSingleButtonNoImage(Option op, Brush clr, Button btn)
        {
            Grid sbGrid = new Grid();
            TextBlock txtBlk = new TextBlock();

            txtBlk.Text = op.Name;//put name of option in text block

            txtBlk.FontSize = Convert.ToInt32(op.FontSize);

            sbGrid.Height = Convert.ToInt32(op.Height);
            sbGrid.Width = Convert.ToInt32(op.Width);

            btn.Background = clr;
            btn.BorderBrush = new SolidColorBrush(Colors.Transparent);//eliminate the border

            btn.Width = sbGrid.Width;
            btn.Height = sbGrid.Height;

            txtBlk.HorizontalAlignment = HorizontalAlignment.Left;
            txtBlk.TextWrapping = TextWrapping.Wrap;
            btn.Content = txtBlk;

            sbGrid.Children.Add(btn);
            sbGrid.HorizontalAlignment = HorizontalAlignment.Left;

            return sbGrid;
        }

        //remember to add button to buttDick
        //This function returns a stack panel and must be called twice for small buttons discard first call
        public StackPanel BuildTwoButtonStackPanelWithTopText(Option op, Brush clr, Button btn)
        {

            if (btn.HorizontalAlignment == HorizontalAlignment.Left)
            {
                //we need new stack panel
                stackPanel = new StackPanel();
                stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
            }

            TextBlock txtBlk = new TextBlock();
            txtBlk.Text = op.Name;

            txtBlk.FontSize = Convert.ToInt32(op.FontSize);

            Grid addGrid = new Grid();
            addGrid.Height = (Convert.ToInt32(op.Height) + 35);  //add room for discription above
            addGrid.Width = Convert.ToInt32(op.Width);

            btn.Width = addGrid.Width;
            btn.Height = Convert.ToInt32(op.Height);

            Uri uriImg = new Uri(op.Image, UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uriImg);
            Image img = new Image();
            img.Source = imgSource;

            btn.Content = img;

            btn.BorderBrush = new SolidColorBrush(Colors.Transparent);

            txtBlk.HorizontalAlignment = HorizontalAlignment.Center;

            addGrid.Children.Add(txtBlk);

            btn.Background = clr;

            addGrid.Children.Add(btn);

            //addGrid.HorizontalAlignment = HorizontalAlignment.Left;
            stackPanel.Children.Add(addGrid);

            return stackPanel;
        }

        public Grid BuildSingleButtonPreviewButton(Preview prv, Brush clr, Button btn, double txtSize)
        {
            Grid sbGrid = new Grid();
            TextBlock txtBlk = new TextBlock();

            txtBlk.Text = prv.Name;
            //txtBlk.Style = stl;
            txtBlk.FontSize = txtSize;

            sbGrid.Height = (Convert.ToInt32(prv.Height) + 35); //add room for text on top of button
            sbGrid.Width = Convert.ToInt32(prv.Width);

            btn.Width = sbGrid.Width;
            btn.Height = Convert.ToInt32(prv.Height);

            Uri uriImg = new Uri(prv.Image, UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uriImg);
            Image img = new Image();

            img.Source = imgSource;

            btn.Content = img;
            btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
            btn.Background = clr;

            txtBlk.HorizontalAlignment = HorizontalAlignment.Center;
            sbGrid.Children.Add(txtBlk);

            sbGrid.Children.Add(btn);
            sbGrid.HorizontalAlignment = HorizontalAlignment.Left;
           
            return sbGrid;
        }

        public Grid BuildSingleButtonOptionButton(Option opt, Brush clr, Button btn, double txtSize)
        {
            Grid sbGrid = new Grid();
            TextBlock txtBlk = new TextBlock();
            txtBlk.TextWrapping = TextWrapping.Wrap;
            txtBlk.Text = opt.Name;
            //txtBlk.Style = stl;
            txtBlk.FontSize = txtSize;
         
            //lets add a check here to see if I need to move the picture down to make more room for text
            //I dont want to do this but see no other way to get the needed amount of information to the user
            if (txtBlk.ActualWidth > 596)
            {
                sbGrid.Height = (Convert.ToInt32(opt.Height) + 145);
            }
            else if (txtBlk.ActualWidth > 336.8)
            {
                //someday this should not be hard coded ;)
                sbGrid.Height = (Convert.ToInt32(opt.Height) + 83);
            }
            else
            {
                sbGrid.Height = (Convert.ToInt32(opt.Height) + 35); //add room for text on top of button
            }
           
            sbGrid.Width = Convert.ToInt32(opt.Width);

            btn.Width = sbGrid.Width;
            btn.Height = Convert.ToInt32(opt.Height);
            //btn.BorderThickness = new Thickness(0.0);
            //btn.Padding = new Thickness(0.0);

            Uri uriImg = new Uri(opt.Image, UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uriImg);
            Image img = new Image();

            img.Source = imgSource;

            btn.Content = img;
            btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
            btn.Background = clr;

            txtBlk.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlk.VerticalAlignment = VerticalAlignment.Top;
            sbGrid.Children.Add(txtBlk);

            sbGrid.Children.Add(btn);
            sbGrid.HorizontalAlignment = HorizontalAlignment.Left;
           
            return sbGrid;
        }
    
    }

   
}
