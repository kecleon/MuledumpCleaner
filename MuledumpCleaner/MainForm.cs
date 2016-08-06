using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuledumpCleaner
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		Dictionary<string, string> FullList = new Dictionary<string, string>(); //full untampered list
		Dictionary<string, string> InvalidList = new Dictionary<string, string>(); //Incorrect account details
		Dictionary<string, string> BannedList = new Dictionary<string, string>(); //Account under maintenance
		Dictionary<string, string> MigrateList = new Dictionary<string, string>(); //Account needs migration
		Dictionary<string, string> ErrorList = new Dictionary<string, string>(); //<Error>, but not under maintenance
		Dictionary<string, string> MiscList = new Dictionary<string, string>(); //neither <Chars> nor <Error>
		Dictionary<string, string> CleanList = new Dictionary<string, string>(); //pruned list
		
		const string CHAR_LIST = "https://realmofthemadgod.appspot.com/char/list?guid=";

		string file;

		int accountCounter = 0;

		string[] fullTextBuffer = new string[] { };

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			outputTextbox.AppendText("Initialized, click Load to select a file with a list of accounts, Clean to purge banned or invalid accounts, then Save to save the rest to a new file\n");
			cleanButton.Enabled = false;
			saveButton.Enabled = false;
		}

		private void updateControlText(Control control, string text, bool isTextBox = false)
		{
			if (isTextBox)
			{
				TextBox textbox = (TextBox)control;
				textbox.BeginInvoke((MethodInvoker)delegate ()
				{
					textbox.AppendText(text);
				});
			}
			else
			{
				Label label = (Label)control;
				label.BeginInvoke((MethodInvoker)delegate ()
				{
					label.Text = text;
				});
			}
		}

		private void updateControlEnabled(Control control, bool enabled)
		{
			control.BeginInvoke((MethodInvoker)delegate ()
			{
				control.Enabled = enabled;
			});
		}

		private void loadAccountsButton_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				file = openFileDialog.FileName;
				fileLabel.Text = file;
				try
				{
					fullTextBuffer = File.ReadAllLines(file);
				}
				catch (IOException)
				{
					fileLabel.Text = "Error reading file";
				}
			}
			else
			{
				fileLabel.Text = "Error opening file";
			}
			FullList.Clear();
			InvalidList.Clear();
			BannedList.Clear();
			MigrateList.Clear();
			ErrorList.Clear();
			MiscList.Clear();
			CleanList.Clear();
			foreach (string line in fullTextBuffer)
			{
				string s = line;
				if (s.Length >= 2)
				{
					if (fixAccountListFileCheckbox.Checked)
					{
						s = Regex.Replace(s, @"\s*'(.*)'\s*:\s*'(.*)'\s*,\s*", "$1:$2");
						s = Regex.Replace(s, @"\+", "%2B");

						if (s.EndsWith(","))
						{
							s = s.Substring(0, s.Length - 1);
						}
					}
					string[] acc = s.Split(':');
					if (acc.Length == 2)
					{
						if (FullList.ContainsKey(acc[0]))
						{
							if (acc[1] != FullList[acc[0]])
							{
								DialogResult dr = MessageBox.Show("Duplicate account found\n" + "\nReplace the original:\n" + acc[0] + " : " + FullList[acc[0]] + "\nwith:\n" + acc[0] + " : " + acc[1] + "\n?", "Duplicate Account", MessageBoxButtons.YesNo);
								if (dr == DialogResult.Yes)
								{
									FullList[acc[0]] = acc[1];
								}
							}
						}
						else
						{
							FullList.Add(acc[0], acc[1]);
						}
					}
					/*else
					{
						if (false)
						{
							outputTextbox.AppendText("String did not contain email:password (" + s + ")\n");
						}
					}*/
				}
			}
			outputTextbox.AppendText("Read all accounts\n");
			cleanButton.Enabled = true;
		}

		private void cleanButton_Click(object sender, EventArgs e)
		{
			InvalidList.Clear();
			BannedList.Clear();
			MigrateList.Clear();
			ErrorList.Clear();
			MiscList.Clear();
			CleanList.Clear();
			Task.Run(() => { processNextAccount(); });
			cleanButton.Enabled = false;
		}

		private void processNextAccount()
		{
			updateControlText(progressLabel, accountCounter + "/" + FullList.Count);
			//progressLabel.Update();
			KeyValuePair<string, string> acc = new KeyValuePair<string, string>();
			try
			{
				acc = FullList.ElementAt(accountCounter);
			}
			catch
			{
				updateControlText(outputTextbox, "Finished\n", true);
				updateControlEnabled(cleanButton, true);
				updateControlEnabled(saveButton, true);
				accountCounter = 0;
				return;
			}
			WebClient wc = new WebClient();
			wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
			wc.DownloadStringAsync(new Uri(CHAR_LIST + acc.Key + "&password=" + acc.Value));
		}

		void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			string text = e.Result;
			var acc = FullList.ElementAt(accountCounter);
			if (text.StartsWith("<Error>"))
			{
				if (text.Contains("Account is under maintenance"))
				{
					updateControlText(outputTextbox, "Added banned account: " + acc.Key + ':' + acc.Value + '\n', true);
					BannedList.Add(acc.Key, acc.Value);
				}
				else if (text.Contains("Account credentials not valid"))
				{
					updateControlText(outputTextbox, "Added invalid credential account: " + acc.Key + ':' + acc.Value + '\n', true);
					InvalidList.Add(acc.Key, acc.Value);
				}
				else
				{
					updateControlText(outputTextbox, "Added unknown account error account: " + acc.Key + ':' + acc.Value + '\n', true);
					ErrorList.Add(acc.Key, acc.Value);
				}
			}
			else if (text.StartsWith("<Chars"))
			{
				updateControlText(outputTextbox, "Added clean account: " + acc.Key + ':' + acc.Value + '\n', true);
				CleanList.Add(acc.Key, acc.Value);
			}
			else if (text.StartsWith("<Migrate>"))
			{
				updateControlText(outputTextbox, "Added migrate account: " + acc.Key + ':' + acc.Value + '\n', true);
				MigrateList.Add(acc.Key, acc.Value);
			}
			else
			{
				updateControlText(outputTextbox, "Added unknown error account: " + acc.Key + ':' + acc.Value + '\n', true);
				MiscList.Add(acc.Key, acc.Value);
			}
			accountCounter++;
			processNextAccount();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			StringBuilder finalList = new StringBuilder();
			if (saveAsMuledumpFormatCheckbox.Checked)
			{
				finalList.Append("accounts = {\r\n");
			}
			if (CleanList.Count > 0)
			{
				finalList.Append("//Clean, unbanned accounts\r\n");
			}
			foreach (var acc in CleanList)
			{
				if (saveAsMuledumpFormatCheckbox.Checked)
				{
					finalList.Append("\'");
				}
				finalList.Append(acc.Key);
				if (saveAsMuledumpFormatCheckbox.Checked)
				{
					finalList.Append("\':\'");
				}
				else
				{
					finalList.Append(':');
				}
				finalList.Append(acc.Value);
				if (saveAsMuledumpFormatCheckbox.Checked)
				{
					finalList.Append("\',");
				}
				finalList.Append("\r\n");
			}
			if (outputBannedCheckbox.Checked)
			{
				if (BannedList.Count > 0)
				{
					finalList.Append("\n\n//Banned accounts\r\n");
				}
				foreach (var acc in BannedList)
				{
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\'");
					}
					finalList.Append(acc.Key);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\':\'");
					}
					else
					{
						finalList.Append(':');
					}
					finalList.Append(acc.Value);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\',");
					}
					finalList.Append("\r\n");
				}
			}
			if (outputErrorAccountsCheckbox.Checked)
			{
				if (ErrorList.Count > 0)
				{
					finalList.Append("\n\n//Errors - char/list result starts with <Error> but account is not banned\r\n");
				}
				foreach (var acc in ErrorList)
				{
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\'");
					}
					finalList.Append(acc.Key);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\':\'");
					}
					else
					{
						finalList.Append(':');
					}
					finalList.Append(acc.Value);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\',");
					}
					finalList.Append("\r\n");
				}
				if (InvalidList.Count > 0)
				{
					finalList.Append("\n\n//Invalid credential\r\n");
				}
				foreach (var acc in InvalidList)
				{
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\'");
					}
					finalList.Append(acc.Key);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\':\'");
					}
					else
					{
						finalList.Append(':');
					}
					finalList.Append(acc.Value);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\',");
					}
					finalList.Append("\r\n");
				}

				if (MigrateList.Count > 0)
				{
					finalList.Append("\n\n//Accounts that need(ed) migration\r\n");
				}
				foreach (var acc in MigrateList)
				{
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\'");
					}
					finalList.Append(acc.Key);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\':\'");
					}
					else
					{
						finalList.Append(':');
					}
					finalList.Append(acc.Value);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\',");
					}
					finalList.Append("\r\n");
				}
				if (MiscList.Count > 0)
				{
					finalList.Append("\n\n//Miscelaneous parse errors - char/list result does not start with <Error> or <Chars\r\n");
				}
				foreach (var acc in MiscList)
				{
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\'");
					}
					finalList.Append(acc.Key);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\':\'");
					}
					else
					{
						finalList.Append(':');
					}
					finalList.Append(acc.Value);
					if (saveAsMuledumpFormatCheckbox.Checked)
					{
						finalList.Append("\',");
					}
					finalList.Append("\r\n");
				}
			}
			if (saveAsMuledumpFormatCheckbox.Checked)
			{
				finalList.Append("}\r\n");
			}
			string finalString = finalList.ToString();
			saveFileDialog.InitialDirectory = Path.GetDirectoryName(file);
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				outputTextbox.AppendText("File saved as:" + saveFileDialog.FileName + '\n');
			}
			File.WriteAllText(saveFileDialog.FileName, finalString);
		}
	}
}
