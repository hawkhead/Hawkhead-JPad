using System;
using System.Windows.Forms;

namespace JPad
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //TODO ==================================
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Add File Checking on Exit & Add Closing method to stop window from 
        //closing and exiting without checking for saving data.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //File Checking TODO
            Application.Exit();
        }
        //End TODO ==============================




        //Done
        private void SaveFile(object sender, EventArgs e)
        {
            if (jRichTextBox1.GetTextBox().TextLength > 0)
            {
                (sender.GetType().GetProperty("Enabled")).Equals(false);  
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    jRichTextBox1.GetTextBox().SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    (sender.GetType().GetProperty("Enabled")).Equals(true); 
                }
            }
        }

        //Done
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (jRichTextBox1.GetTextBox().SelectedText.Length > 0)
            {
                Clipboard.SetText(jRichTextBox1.GetTextBox().SelectedText);
                jRichTextBox1.GetTextBox().SelectedText = "";
            }
        }

        //Done
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if(jRichTextBox1.GetTextBox().SelectedText.Length > 0)
                Clipboard.SetText(jRichTextBox1.GetTextBox().SelectedText);
        }

        //Done
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            jRichTextBox1.GetTextBox().SelectedText = Clipboard.GetText();
        }

        //Done
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
            /*if (aboutBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }*/
        }

        //Done
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jRichTextBox1.GetTextBox().Undo();
        }

        //Done
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jRichTextBox1.GetTextBox().Redo();
        }

        //Done
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jRichTextBox1.GetTextBox().SelectAll();
        }

    }
}
