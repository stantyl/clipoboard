namespace Clipboard_PROX
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CredentrialsDataView = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Stay_Active = new System.Windows.Forms.CheckBox();
            this.Select_Next_Row = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Transparency_Up_Down = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Enter_Delay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Enter_Keystrokes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Clipboard_Data = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CredentrialsDataView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transparency_Up_Down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enter_Delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enter_Keystrokes)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clipboard_Data)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CredentrialsDataView);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(870, 815);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "  Credentials  ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CredentrialsDataView
            // 
            this.CredentrialsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CredentrialsDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.Password});
            this.CredentrialsDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentrialsDataView.Location = new System.Drawing.Point(3, 3);
            this.CredentrialsDataView.Name = "CredentrialsDataView";
            this.CredentrialsDataView.RowHeadersWidth = 62;
            this.CredentrialsDataView.RowTemplate.Height = 28;
            this.CredentrialsDataView.Size = new System.Drawing.Size(864, 809);
            this.CredentrialsDataView.TabIndex = 0;
            this.CredentrialsDataView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CredentrialsDataView_CellMouseClick);
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.MinimumWidth = 8;
            this.Login.Name = "Login";
            this.Login.Width = 150;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 8;
            this.Password.Name = "Password";
            this.Password.Width = 150;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Stay_Active);
            this.tabPage2.Controls.Add(this.Select_Next_Row);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.Transparency_Up_Down);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Enter_Delay);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Enter_Keystrokes);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 815);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "   Program Options  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Stay_Active
            // 
            this.Stay_Active.AutoSize = true;
            this.Stay_Active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Stay_Active.Location = new System.Drawing.Point(98, 152);
            this.Stay_Active.Name = "Stay_Active";
            this.Stay_Active.Size = new System.Drawing.Size(290, 27);
            this.Stay_Active.TabIndex = 10;
            this.Stay_Active.Text = "Stay active when minimized   ";
            this.Stay_Active.UseVisualStyleBackColor = true;
            // 
            // Select_Next_Row
            // 
            this.Select_Next_Row.AutoSize = true;
            this.Select_Next_Row.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Select_Next_Row.Location = new System.Drawing.Point(11, 124);
            this.Select_Next_Row.Name = "Select_Next_Row";
            this.Select_Next_Row.Size = new System.Drawing.Size(409, 27);
            this.Select_Next_Row.TabIndex = 9;
            this.Select_Next_Row.Text = "Select next row when Ctrl + V is pressed   ";
            this.Select_Next_Row.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "percent";
            // 
            // Transparency_Up_Down
            // 
            this.Transparency_Up_Down.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Transparency_Up_Down.Location = new System.Drawing.Point(147, 74);
            this.Transparency_Up_Down.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Transparency_Up_Down.Name = "Transparency_Up_Down";
            this.Transparency_Up_Down.Size = new System.Drawing.Size(51, 30);
            this.Transparency_Up_Down.TabIndex = 7;
            this.Transparency_Up_Down.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Transparency_Up_Down.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Transparency_Up_Down.ValueChanged += new System.EventHandler(this.Transparency_Up_Down_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Transparency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "seconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "times";
            // 
            // Enter_Delay
            // 
            this.Enter_Delay.Location = new System.Drawing.Point(147, 42);
            this.Enter_Delay.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Enter_Delay.Name = "Enter_Delay";
            this.Enter_Delay.Size = new System.Drawing.Size(51, 30);
            this.Enter_Delay.TabIndex = 3;
            this.Enter_Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Delay ENTER key";
            // 
            // Enter_Keystrokes
            // 
            this.Enter_Keystrokes.Location = new System.Drawing.Point(147, 10);
            this.Enter_Keystrokes.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Enter_Keystrokes.Name = "Enter_Keystrokes";
            this.Enter_Keystrokes.Size = new System.Drawing.Size(51, 30);
            this.Enter_Keystrokes.TabIndex = 1;
            this.Enter_Keystrokes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send ENTER key";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Clipboard_Data);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage1.Size = new System.Drawing.Size(474, 817);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "   Clipboard Data     ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Clipboard_Data
            // 
            this.Clipboard_Data.AllowUserToAddRows = false;
            this.Clipboard_Data.AllowUserToDeleteRows = false;
            this.Clipboard_Data.AllowUserToResizeColumns = false;
            this.Clipboard_Data.AllowUserToResizeRows = false;
            this.Clipboard_Data.BackgroundColor = System.Drawing.Color.White;
            this.Clipboard_Data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Clipboard_Data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.Clipboard_Data.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.Clipboard_Data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Clipboard_Data.ColumnHeadersHeight = 34;
            this.Clipboard_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Clipboard_Data.ColumnHeadersVisible = false;
            this.Clipboard_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.Clipboard_Data.Location = new System.Drawing.Point(3, 3);
            this.Clipboard_Data.MultiSelect = false;
            this.Clipboard_Data.Name = "Clipboard_Data";
            this.Clipboard_Data.ReadOnly = true;
            this.Clipboard_Data.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Clipboard_Data.RowHeadersVisible = false;
            this.Clipboard_Data.RowHeadersWidth = 62;
            this.Clipboard_Data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Clipboard_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Clipboard_Data.ShowEditingIcon = false;
            this.Clipboard_Data.Size = new System.Drawing.Size(471, 464);
            this.Clipboard_Data.TabIndex = 0;
            this.Clipboard_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Clipboard_Data_CellContentClick);
            this.Clipboard_Data.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Clipboard_Data_CellMouseClick);
            this.Clipboard_Data.SelectionChanged += new System.EventHandler(this.Clipboard_Data_SelectionChanged);
            this.Clipboard_Data.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Clipboard_Data_PreviewKeyDown);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "clipboard content";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 853);
            this.tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(482, 853);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(500, 900);
            this.MinimumSize = new System.Drawing.Size(500, 900);
            this.Name = "Form1";
            this.Text = "Clipboard PROX";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CredentrialsDataView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transparency_Up_Down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enter_Delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enter_Keystrokes)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Clipboard_Data)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView CredentrialsDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox Stay_Active;
        private System.Windows.Forms.CheckBox Select_Next_Row;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Transparency_Up_Down;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Enter_Delay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Enter_Keystrokes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView Clipboard_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

