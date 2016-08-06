namespace MuledumpCleaner
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.outputTextbox = new System.Windows.Forms.TextBox();
			this.loadAccountsButton = new System.Windows.Forms.Button();
			this.fileLabel = new System.Windows.Forms.Label();
			this.cleanButton = new System.Windows.Forms.Button();
			this.progressLabel = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.outputBannedCheckbox = new System.Windows.Forms.CheckBox();
			this.outputErrorAccountsCheckbox = new System.Windows.Forms.CheckBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.progressProgressLabel = new System.Windows.Forms.Label();
			this.fixAccountListFileCheckbox = new System.Windows.Forms.CheckBox();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.saveAsMuledumpFormatCheckbox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// outputTextbox
			// 
			this.outputTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.outputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.outputTextbox.ForeColor = System.Drawing.Color.White;
			this.outputTextbox.Location = new System.Drawing.Point(12, 108);
			this.outputTextbox.Multiline = true;
			this.outputTextbox.Name = "outputTextbox";
			this.outputTextbox.Size = new System.Drawing.Size(582, 281);
			this.outputTextbox.TabIndex = 0;
			// 
			// loadAccountsButton
			// 
			this.loadAccountsButton.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.loadAccountsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loadAccountsButton.ForeColor = System.Drawing.Color.White;
			this.loadAccountsButton.Location = new System.Drawing.Point(12, 12);
			this.loadAccountsButton.Name = "loadAccountsButton";
			this.loadAccountsButton.Size = new System.Drawing.Size(190, 30);
			this.loadAccountsButton.TabIndex = 1;
			this.loadAccountsButton.Text = "Load";
			this.loadAccountsButton.UseVisualStyleBackColor = false;
			this.loadAccountsButton.Click += new System.EventHandler(this.loadAccountsButton_Click);
			// 
			// fileLabel
			// 
			this.fileLabel.AutoSize = true;
			this.fileLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
			this.fileLabel.ForeColor = System.Drawing.Color.White;
			this.fileLabel.Location = new System.Drawing.Point(12, 50);
			this.fileLabel.Name = "fileLabel";
			this.fileLabel.Size = new System.Drawing.Size(61, 13);
			this.fileLabel.TabIndex = 2;
			this.fileLabel.Text = "accounts.js";
			// 
			// cleanButton
			// 
			this.cleanButton.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.cleanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cleanButton.ForeColor = System.Drawing.Color.White;
			this.cleanButton.Location = new System.Drawing.Point(208, 12);
			this.cleanButton.Name = "cleanButton";
			this.cleanButton.Size = new System.Drawing.Size(190, 30);
			this.cleanButton.TabIndex = 3;
			this.cleanButton.Text = "Clean";
			this.cleanButton.UseVisualStyleBackColor = false;
			this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
			// 
			// progressLabel
			// 
			this.progressLabel.AutoSize = true;
			this.progressLabel.ForeColor = System.Drawing.Color.White;
			this.progressLabel.Location = new System.Drawing.Point(78, 67);
			this.progressLabel.Name = "progressLabel";
			this.progressLabel.Size = new System.Drawing.Size(24, 13);
			this.progressLabel.TabIndex = 4;
			this.progressLabel.Text = "0/0";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "accounts.js";
			// 
			// outputBannedCheckbox
			// 
			this.outputBannedCheckbox.AutoSize = true;
			this.outputBannedCheckbox.ForeColor = System.Drawing.Color.White;
			this.outputBannedCheckbox.Location = new System.Drawing.Point(15, 85);
			this.outputBannedCheckbox.Name = "outputBannedCheckbox";
			this.outputBannedCheckbox.Size = new System.Drawing.Size(128, 17);
			this.outputBannedCheckbox.TabIndex = 5;
			this.outputBannedCheckbox.Text = "List banned accounts";
			this.outputBannedCheckbox.UseVisualStyleBackColor = true;
			// 
			// outputErrorAccountsCheckbox
			// 
			this.outputErrorAccountsCheckbox.AutoSize = true;
			this.outputErrorAccountsCheckbox.ForeColor = System.Drawing.Color.White;
			this.outputErrorAccountsCheckbox.Location = new System.Drawing.Point(208, 85);
			this.outputErrorAccountsCheckbox.Name = "outputErrorAccountsCheckbox";
			this.outputErrorAccountsCheckbox.Size = new System.Drawing.Size(153, 17);
			this.outputErrorAccountsCheckbox.TabIndex = 6;
			this.outputErrorAccountsCheckbox.Text = "List all accounts with errors";
			this.outputErrorAccountsCheckbox.UseVisualStyleBackColor = true;
			// 
			// saveButton
			// 
			this.saveButton.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveButton.ForeColor = System.Drawing.Color.White;
			this.saveButton.Location = new System.Drawing.Point(404, 12);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(190, 30);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = false;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// progressProgressLabel
			// 
			this.progressProgressLabel.AutoSize = true;
			this.progressProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.progressProgressLabel.ForeColor = System.Drawing.Color.White;
			this.progressProgressLabel.Location = new System.Drawing.Point(12, 67);
			this.progressProgressLabel.Name = "progressProgressLabel";
			this.progressProgressLabel.Size = new System.Drawing.Size(60, 13);
			this.progressProgressLabel.TabIndex = 8;
			this.progressProgressLabel.Text = "Progress:";
			// 
			// fixAccountListFileCheckbox
			// 
			this.fixAccountListFileCheckbox.AutoSize = true;
			this.fixAccountListFileCheckbox.Checked = true;
			this.fixAccountListFileCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fixAccountListFileCheckbox.ForeColor = System.Drawing.Color.White;
			this.fixAccountListFileCheckbox.Location = new System.Drawing.Point(404, 85);
			this.fixAccountListFileCheckbox.Name = "fixAccountListFileCheckbox";
			this.fixAccountListFileCheckbox.Size = new System.Drawing.Size(189, 17);
			this.fixAccountListFileCheckbox.TabIndex = 9;
			this.fixAccountListFileCheckbox.Text = "Clean account list (disable if errors)";
			this.fixAccountListFileCheckbox.UseVisualStyleBackColor = true;
			// 
			// saveAsMuledumpFormatCheckbox
			// 
			this.saveAsMuledumpFormatCheckbox.AutoSize = true;
			this.saveAsMuledumpFormatCheckbox.ForeColor = System.Drawing.Color.White;
			this.saveAsMuledumpFormatCheckbox.Location = new System.Drawing.Point(404, 66);
			this.saveAsMuledumpFormatCheckbox.Name = "saveAsMuledumpFormatCheckbox";
			this.saveAsMuledumpFormatCheckbox.Size = new System.Drawing.Size(145, 17);
			this.saveAsMuledumpFormatCheckbox.TabIndex = 10;
			this.saveAsMuledumpFormatCheckbox.Text = "Save in muledump format";
			this.saveAsMuledumpFormatCheckbox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
			this.ClientSize = new System.Drawing.Size(606, 401);
			this.Controls.Add(this.saveAsMuledumpFormatCheckbox);
			this.Controls.Add(this.fixAccountListFileCheckbox);
			this.Controls.Add(this.progressProgressLabel);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.outputErrorAccountsCheckbox);
			this.Controls.Add(this.outputBannedCheckbox);
			this.Controls.Add(this.progressLabel);
			this.Controls.Add(this.cleanButton);
			this.Controls.Add(this.fileLabel);
			this.Controls.Add(this.loadAccountsButton);
			this.Controls.Add(this.outputTextbox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Muledump Cleaner by 059 version 1.0";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox outputTextbox;
		private System.Windows.Forms.Button loadAccountsButton;
		private System.Windows.Forms.Label fileLabel;
		private System.Windows.Forms.Button cleanButton;
		private System.Windows.Forms.Label progressLabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.CheckBox outputBannedCheckbox;
		private System.Windows.Forms.CheckBox outputErrorAccountsCheckbox;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label progressProgressLabel;
		private System.Windows.Forms.CheckBox fixAccountListFileCheckbox;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.CheckBox saveAsMuledumpFormatCheckbox;
	}
}

