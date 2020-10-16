using Clipboard_PROX.Utilities;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace Clipboard_PROX
{
	public partial class Form1 : Form
	{
		#region-   Hot Keys Section   -
		// Hot Key KeyModifiers ID-s
		const int None = 0x0000;
		const int Alt = 0x0001;
		const int Control = 0x0002;
		const int Shift = 0x0004;
		const int WinKey = 0x0008;

		// Hot Key ID-s
		const int V = (int)Keys.V;
		const int W = (int)Keys.W;
		const int Up = (int)Keys.Up;
		const int Down = (int)Keys.Down;
		const int Delete = (int)Keys.Delete;
		const int Backspace = (int)Keys.Back;
		const int Cr = (int)Keys.Enter;

		// WinProc Message/Event Codes
		const int WM_HOTKEY = 0x0312;
		const int WM_CLIPBOARDUPDATE = 0x031D;

		const int MOD_NOREPEAT = 0x4000;

		// Hot Key Registration OK Flags
		bool Clipboard_Listener = false;

		bool Ctrl_V = false;
		bool Ctrl_Alt_V = false;
		bool Ctrl_Up = false;
		bool Ctrl_Down = false;
		bool Ctrl_Delete = false;
		bool Ctrl_Backspace = false;
		bool Ctrl_Cr = false;
		#endregion

		#region-   Clipboard Data section   -
		// Clipboard Data current row value
		string Current_Clipboard = string.Empty;

		// Clipboard Data current row index
		int Clipboard_Data_Selected_Row = -1;

		// Clipboard entry OK flag
		bool Clipboard_Entry_OK = false;
		#endregion

		#region-   Registration Section   -
		// Registration message
		string Registration_Message = string.Empty;

		// Registration caption
		const string Registration_Caption = " Hot Key registration info   ";

		// Registration flag
		bool Registration_Ok = true;
		#endregion

		// Current Foreground Window Pointer
		IntPtr handle = new IntPtr();

		#region-   Form1 Section  -
		public Form1()
		{
			InitializeComponent();

			// Initialize Clipboard Data Table
			Initialize_Clipboard_Data();

			// Register Hot Key Enter
			Register_Hot_Key_Enter();

			// Call ENTER MEthod
			ENTER();
		}
		#endregion
	

		#region-   Initialize, Register & Unregister Section   -
		void Initialize_Clipboard_Data()
		{
			// Clear table Clipboard Data
			Clipboard_Data.Rows.Clear();

			// Set Current Clipboard
			Current_Clipboard = string.Empty;

			// Set Selected Row Index
			Clipboard_Data_Selected_Row = -1;
		}

		void Register_Clipboard_Listener_And_HotKeys()
		{
			// Reset Registration message
			Registration_Message = string.Empty;

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows, UIPermissionClipboard.AllClipboard).Demand();

			// Set Clipboard listener
			Clipboard_Listener = UnsafeNativeMethods.AddClipboardFormatListener(this.Handle);

			if (Clipboard_Listener == false)
			{
				Registration_Message += "   Clipboard listener could not be registered.  \n\n";
				Registration_Ok = false;
				return;
			}

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			// Register Hot Key Combination Control + V
			Ctrl_V = UnsafeNativeMethods.RegisterHotKey(this.Handle, V, Control | MOD_NOREPEAT, V);
			if (Ctrl_V == false)
			{
				Registration_Message += "   Hot Key - Ctrl + V - could not be registered.  \n\n";
				Registration_Ok = false;
				return;
			}

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			// Register Hot Key Combination Control + Alt + V
			Ctrl_Alt_V = UnsafeNativeMethods.RegisterHotKey(this.Handle, W, Control | Alt | MOD_NOREPEAT, V);
			if (Ctrl_Alt_V == false)
			{
				Registration_Message += "   Hot Key - Ctrl + Alt + V - could not be registered.  \n\n";
				Registration_Ok = false;
				return;
			}

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			// Register Hot Key Combination Control + Up
			Ctrl_Up = UnsafeNativeMethods.RegisterHotKey(this.Handle, Up, Control, Up);
			if (Ctrl_Up == false)
			{
				Registration_Message += "   Hot Key - Ctrl + Up - could not be registered.  \n\n";
				Registration_Ok = false;
				return;
			}

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			// Register Hot Key Combination Control + Down
			Ctrl_Down = UnsafeNativeMethods.RegisterHotKey(this.Handle, Down, Control, Down);
			if (Ctrl_Down == false)
			{
				Registration_Message += "Hot Key - Ctrl + Down - could not be registered.  \n\n";
				Registration_Ok = false;
				return;
			}

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			// Register Hot Key Combination to Control + Delete
			Ctrl_Delete = UnsafeNativeMethods.RegisterHotKey(this.Handle, Delete, Control, Delete);
			if (Ctrl_Delete == false)
			{
				Registration_Message += "   Hot Key - Ctrl + Delete - could not be registered.  \n\n";
				Registration_Ok = false;
				return;
			}

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			// Register Hot Key Combination Control + Backspace
			Ctrl_Backspace = UnsafeNativeMethods.RegisterHotKey(this.Handle, Backspace, Control | MOD_NOREPEAT, Backspace);
			if (Ctrl_Backspace == false)
			{
				Registration_Message += "   Hot Key - Ctrl + Backspace - could not be registered.  \n\n";
				Registration_Ok = false;
				return;
			}
		}

		void Register_Hot_Key_Enter()
		{
			// Reset Registration message
			Registration_Message = string.Empty;

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			// Register Hot Key Combination Control + Enter
			Ctrl_Cr = UnsafeNativeMethods.RegisterHotKey(this.Handle, Cr, Control | MOD_NOREPEAT, Cr);
			if (Ctrl_Cr == false)
			{
				Registration_Message += "   Hot Key - Ctrl + Enter - could not be registered.  \n\n   Application must be closed.   \n\n";
				_ = MessageBox.Show(Registration_Message, Registration_Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		void Unregister_Clipboard_Listener_And_HotKeys()
		{
			// Clear Clipboard
			Clipboard.Clear();

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows, UIPermissionClipboard.AllClipboard).Demand();

			if (Clipboard_Listener == true)
				_ = UnsafeNativeMethods.RemoveClipboardFormatListener(this.Handle);

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			if (Ctrl_V == true)
				_ = UnsafeNativeMethods.UnregisterHotKey(this.Handle, V);

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			if (Ctrl_Alt_V == true)
				_ = UnsafeNativeMethods.UnregisterHotKey(this.Handle, W);

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			if (Ctrl_Up == true)
				_ = UnsafeNativeMethods.UnregisterHotKey(this.Handle, Up);

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			if (Ctrl_Down == true)
				_ = UnsafeNativeMethods.UnregisterHotKey(this.Handle, Down);

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			if (Ctrl_Delete == true)
				_ = UnsafeNativeMethods.UnregisterHotKey(this.Handle, Delete);

			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			if (Ctrl_Backspace == true)
				_ = UnsafeNativeMethods.UnregisterHotKey(this.Handle, Backspace);
		}

		void Unregister_Hot_Key_Enter()
		{
			// Demand new security permission
			new UIPermission(UIPermissionWindow.AllWindows).Demand();

			if (Ctrl_Cr == true)
				_ = UnsafeNativeMethods.UnregisterHotKey(this.Handle, Cr);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Unregister_Clipboard_Listener_And_HotKeys();

			Unregister_Hot_Key_Enter();
		}
		#endregion

		#region-   WndProc   -
		protected override void WndProc(ref Message m)
		{
			// Listen for operating system Hot Key messages
			if (m.Msg == WM_HOTKEY)
			{
				//
				// Registered Hot Key Is Pressed
				//

				// Get Hot Key unique ID
				int ID = m.WParam.ToInt32();

				switch (ID)
				{
					case V:
						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Get Foreground Window Handle
						handle = UnsafeNativeMethods.GetForegroundWindow();

						PASTE();
						break;
					case W:
						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Get Foreground Window Handle
						handle = UnsafeNativeMethods.GetForegroundWindow();

						PASTE_ALL();
						break;
					case Up:
						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Get Foreground Window Handle
						handle = UnsafeNativeMethods.GetForegroundWindow();

						UP();
						break;
					case Down:
						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Get Foreground Window Handle
						handle = UnsafeNativeMethods.GetForegroundWindow();

						DOWN();
						break;
					case Delete:
						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Get Foreground Window Handle
						handle = UnsafeNativeMethods.GetForegroundWindow();

						DELETE();
						break;
					case Backspace:
						BACKSPACE();
						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Get Foreground Window Handle
						handle = UnsafeNativeMethods.GetForegroundWindow();

						break;
					case Cr:
						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Get Foreground Window Handle
						handle = UnsafeNativeMethods.GetForegroundWindow();

						ENTER();
						break;
					default:
						break;
				}

				//
				// If foreground window handle has changed
				// set handle of window that invoke Message
				//

				// Demand new security permission
				new UIPermission(UIPermissionWindow.AllWindows).Demand();

				// Set Foreground Window Handle
				_ = UnsafeNativeMethods.SetForegroundWindow(handle);
			}
			else if (m.Msg == WM_CLIPBOARDUPDATE)
			{
				// System Clipboard has changed content
				if (Clipboard.ContainsText(TextDataFormat.Text))
				{
					//// Demand new security permission
					new UIPermission(UIPermissionWindow.AllWindows).Demand();

					////Get Foreground Window Handle
					handle = UnsafeNativeMethods.GetForegroundWindow();

					// Get Clipboard text
					string clipboard_text = Clipboard.GetText(TextDataFormat.Text);
					clipboard_text = clipboard_text.Trim();
					clipboard_text = clipboard_text.Replace("\n", "");
					clipboard_text = clipboard_text.Replace("\r", "");
					clipboard_text = clipboard_text.Replace("\t", "");

					if (!string.IsNullOrEmpty(clipboard_text))
					{
						// Set Clipboard text to Clipboard Data table
						Clipboard_Data.Rows.Add(clipboard_text);
					}

					// Clear system clipboard
					Clipboard.Clear();

					//
					// If foreground window handle has changed
					// set handle of window that invoke Message
					//
					// Demand new security permission
					new UIPermission(UIPermissionWindow.AllWindows).Demand();

					// Set Foreground Window Handle
					_ = UnsafeNativeMethods.SetForegroundWindow(handle);
				}
			}
			else
				base.WndProc(ref m);
		}
		#endregion

		#region-   Hot Keys Press Methods   -
		void UP()
		{
			// Ctrl + Up is pressed
			if (Clipboard_Data.RowCount > 0)
			{
				Clipboard_Data_Selected_Row--;
				if (Clipboard_Data_Selected_Row < 0)
					Clipboard_Data_Selected_Row = 0;

				// Set current cell
				Clipboard_Data.CurrentCell = Clipboard_Data[0, Clipboard_Data_Selected_Row];

				Clipboard_Data_Selected_Row = Clipboard_Data.CurrentCell.RowIndex;



			}
		}

		void DOWN()
		{
			// Ctrl + Down is pressed
			if (Clipboard_Data.RowCount > 0)
			{
				Clipboard_Data_Selected_Row++;
				if (Clipboard_Data_Selected_Row > Clipboard_Data.Rows.Count - 1)
					Clipboard_Data_Selected_Row = Clipboard_Data.Rows.Count - 1;

				// Set current cell
				Clipboard_Data.CurrentCell = Clipboard_Data[0, Clipboard_Data_Selected_Row];

				Clipboard_Data_Selected_Row = Clipboard_Data.CurrentCell.RowIndex;
			}
		}

		void DELETE()
		{
			// Ctrl + Del is pressed
			foreach (DataGridViewCell cell in Clipboard_Data.SelectedCells)
			{
				Clipboard_Data.Rows.RemoveAt(cell.RowIndex);
			}
			if (Clipboard_Data.RowCount == 0)
				Clipboard_Data_Selected_Row = -1;
		}

		void BACKSPACE()
		{
			// Ctrl + Backspace is pressed
			Initialize_Clipboard_Data();
		}

		void PASTE()
		{
			// Ctrl + V is pressed

			if (handle != this.Handle)
			{
				//
				// Paste Clipboard Data 
				//
				if (Clipboard_Data.RowCount > 0)
				{
					Current_Clipboard = Clipboard_Data.CurrentCell.Value.ToString();

					// Demand new security permission
					new UIPermission(UIPermissionWindow.AllWindows).Demand();

					// Set Foreground Window Handle
					_ = UnsafeNativeMethods.SetForegroundWindow(handle);

					SendKeys.SendWait("^+%");
					SendKeys.SendWait(Current_Clipboard);

					Stopwatch s = new Stopwatch();
					if (Enter_Keystrokes.Value >= 1)
					{
						// Make pause
						s.Start();
						while (s.Elapsed.Seconds < Enter_Delay.Value)
						{

						}
						s.Stop();
						s.Reset();

						// Type ENTER
						SendKeys.SendWait("{ENTER}");
					}

					if (Enter_Keystrokes.Value == 2)
					{
						// Make pause
						s.Restart();
						while (s.Elapsed.Seconds < Enter_Delay.Value)
						{

						}
						s.Stop();
						s.Reset();

						// Type ENTER
						SendKeys.SendWait("{ENTER}");
					}

					// Select new row
					if (Select_Next_Row.Checked == true)
					{
						if (Clipboard_Data.CurrentCell.RowIndex < Clipboard_Data.RowCount - 1)
						{
							// Select new row
							Clipboard_Data.CurrentCell = Clipboard_Data[0, Clipboard_Data.CurrentCell.RowIndex + 1];
							Refresh();

							// Set Selected Row
							Clipboard_Data_Selected_Row = Clipboard_Data.CurrentCell.RowIndex;
						}
					}
				}
			}
		}

		void PASTE_ALL()
		{
			// Ctrl + Alt + V is pressed

			if (handle != this.Handle)
			{
				//
				// Paste All Clipboard Data 
				//
				if (Clipboard_Data.RowCount > 0)
				{
					foreach (DataGridViewRow item in Clipboard_Data.Rows)
					{
						// Select new row
						Clipboard_Data.CurrentCell = Clipboard_Data[0, item.Index];
						Refresh();

						// Set Selected Row
						Clipboard_Data_Selected_Row = item.Index;

						// Set Current Clipboard
						Current_Clipboard = item.Cells[0].Value.ToString();

						// Demand new security permission
						new UIPermission(UIPermissionWindow.AllWindows).Demand();

						// Set Foreground Window Handle
						_ = UnsafeNativeMethods.SetForegroundWindow(handle);

						SendKeys.SendWait("^+%");
						SendKeys.SendWait(Current_Clipboard);

						Stopwatch s = new Stopwatch();
						if (Enter_Keystrokes.Value >= 1)
						{
							// Make pause
							s.Start();
							while (s.Elapsed.Seconds < Enter_Delay.Value)
							{

							}
							s.Stop();
							s.Reset();

							// Type ENTER
							SendKeys.SendWait("{ENTER}");
						}

						if (Enter_Keystrokes.Value == 2)
						{
							// Make pause
							s.Restart();
							while (s.Elapsed.Seconds < Enter_Delay.Value)
							{

							}
							s.Stop();
							s.Reset();

							// Type ENTER
							SendKeys.SendWait("{ENTER}");
						}
					}
				}
			}
		}

		void ENTER()
		{
			// Ctrl + Enter is pressed

			// Register Hot Keys and Clipboard Listener
			switch (Clipboard_Entry_OK)
			{
				case false:
					Registration_Message = string.Empty;
					Registration_Ok = true;
					if (Stay_Active.Checked == false)
						Register_Clipboard_Listener_And_HotKeys();
					if (!Registration_Ok)
					{
						Registration_Message += "   Application needs to close  \n\n";
						_ = MessageBox.Show(Registration_Message, Registration_Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
					}
					else
					{
						Clipboard_Entry_OK = true;
						this.WindowState = FormWindowState.Maximized;
					}
					break;
				case true:
					if (Stay_Active.Checked == false)
						Unregister_Clipboard_Listener_And_HotKeys();
					Clipboard_Entry_OK = false;
					WindowState = FormWindowState.Minimized;
					break;

				default:
					break;
			}
		}
		#endregion

		#region-  WinForm Event Handlers   -
		private void Clipboard_Data_SelectionChanged(object sender, EventArgs e)
		{
			if (Clipboard_Data.RowCount > 0)
				Clipboard_Data_Selected_Row = Clipboard_Data.CurrentCell.RowIndex;
		}

		private void Clipboard_Data_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				DELETE();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized && Clipboard_Entry_OK == true)
			{
				ENTER();
			}
			else if ((this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal) && Clipboard_Entry_OK == false)
			{
				ENTER();
			}
		}

		private void Transparency_Up_Down_ValueChanged(object sender, EventArgs e)
		{
			this.Opacity = (double)Transparency_Up_Down.Value / 100;
			Refresh();
		}

        private void Clipboard_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
			this.CredentrialsDataView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;


            //DirectoryInfo d = new DirectoryInfo(Folder.GetTodayFolderName());

            //if (!d.Exists)
            //{
            //	d.Create();

            //}
            //FileInfo[] Files = d.GetFiles("*.csv");

            //string t = Files[0].ToString();


            //	DataTable w = CSV.GetDataTableFromCSVFile(t);

            //this.CredentrialsDataView.DataSource = w;

            this.CredentrialsDataView.Rows.Add("five1", "six1");
            this.CredentrialsDataView.Rows.Add("five2", "six2");
            this.CredentrialsDataView.Rows.Add("five3", "six3");
            this.CredentrialsDataView.Rows.Add("five4", "six5");




        }





		void CredentrialsDataView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{

				if (CredentrialsDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
				{
					Clipboard.SetText(CredentrialsDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
				}

			}
			catch (Exception )
            {

            }

		}

        void Clipboard_Data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {


				string str = Clipboard_Data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				//	Clipboard_Data.Rows.RemoveAt(e.RowIndex);


				int lastrow = Clipboard_Data.Rows.Count;
				Clipboard_Data.Rows.RemoveAt(lastrow);


				if ( str != null)
                {
                    Clipboard.SetText(str);
                }

				Clipboard_Data.Rows.RemoveAt(lastrow +1);

			}
            catch (Exception)
            {

            }

        }







    }


    #endregion
    //}


    //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    //{
    //	if (dataGridView1.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
    //	{
    //		if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
    //			MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
    //	}



    //}

    #region-	DllImport section	-
    [SuppressUnmanagedCodeSecurityAttribute]
	internal static class UnsafeNativeMethods
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		internal static extern int SetForegroundWindow(IntPtr point);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool AddClipboardFormatListener(IntPtr hwnd);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

		[DllImport("user32.dll")]
		internal static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

		[DllImport("user32.dll")]
		internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);
	}
	#endregion


}

