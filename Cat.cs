//Copyright 2023 Gilgamech Technologies
//Title: Cat v0.1
//Author: Stephen Gillie
//Created 5/31/2023
//Updated 5/31/2023
//Update Notes: 
//0.1: Starting from OPB and pulling out what I don't want.


using System;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace CatNamespace {
    public class CatContext : Form {
//{ Ints
        public int build = 55;
        public Button goButton;
		public TextBox urlBox = new TextBox();
		public RichTextBox outBox = new RichTextBox();
		public System.Drawing.Bitmap myBitmap;
		public System.Drawing.Graphics pageGraphics;
		
		public string appTitle = "Cat chases your mouse! - Build ";
		public int checkSeconds = 10;
		public int WindowWidth = 600;
		public int WindowHeight = 300;
		public int sleepSec = 5;
		public bool shouldRun = true;
		private NotifyIcon trayIcon;


        [STAThread]
        static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new CatContext());
        }// end Main

        public CatContext() {
			//this.Icon = Icon.ExtractAssociatedIcon("cat.ico");
			//Console.WriteLine("Reflection Location "+System.Reflection.Assembly.GetExecutingAssembly().Location);
			this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
			trayIcon = new NotifyIcon();
			trayIcon.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
			trayIcon.Text = appTitle+build;
			trayIcon.ContextMenu = new ContextMenu();
			trayIcon.Visible = true;
			//trayIcon.ContextMenu.MenuItems.Add(new MenuItem("Option 1", new EventHandler(handler_method)));

			Point newMouse = Cursor.Position;
			Point oldMouse = new Point(0,0);
			//Console.WriteLine("Starting oldMouse "+oldMouse+" newMouse "+newMouse);
			while (shouldRun) {
				if (oldMouse.X == newMouse.X && oldMouse.Y == newMouse.Y ) {
					moveMouse();
					//Console.WriteLine("move");
				}
				Thread.Sleep(sleepSec * 1000);
				oldMouse = newMouse;
				newMouse = Cursor.Position;
				//Console.WriteLine("oldMouse "+oldMouse+" newMouse "+newMouse);
			}
        } // end CatContext
//Functions
			public Rectangle GetScreen() {
				return Screen.FromControl(this).Bounds;
			}
			public void moveMouse() {
				int X = GetScreen().Width;
				int Y = GetScreen().Height/2;
				Cursor.Position = new Point(X, Y);
			}
    }// end CatContext




}// end CatNamespace

