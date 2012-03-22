using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JPad
{
    class JPadTextBox : RichTextBox
    {

        private bool textHasChanged = false;
        private int tabLength;
        private string tabString;

        public int TabLength
        {
            get { return tabLength; }
            set 
            {
                tabLength = value;
                this.tabString = "";
                for (int i = 0; i < value; i++)
                {
                    this.tabString += " ";
                }
            }
        }

        public bool TextHasChanged
        {
            get { return textHasChanged; }
            set 
            {
                textHasChanged = value;
            }
        }

        public JPadTextBox()
            : base()
        {
            this.AcceptsTab = true;
            this.TabLength = 5;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            textHasChanged = true;
            
            base.OnTextChanged(e);
        }

        //Handling our keypress events =================================
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = true;
                this.SelectedText += this.tabString;
            }

            base.OnKeyPress(e);

        }
        //================================================================

        public void DataSaved()
        {
            this.textHasChanged = false;
        }

    }

    class JRichTextBox : Panel
    {

        private JPadTextBox jTextBox = new JPadTextBox();

        public JPadTextBox GetTextBox()
        {
            return this.jTextBox;
        }

        public JRichTextBox()
        {
            jTextBox = new JPadTextBox();

            jTextBox.Width = this.Width - 2;
            jTextBox.Height = this.Height - 2;

            jTextBox.Left = 1;
            jTextBox.Top = 1;

            jTextBox.Dock = DockStyle.Fill;
            jTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;

            jTextBox.Font = new Font("Courier New", 10, FontStyle.Regular);

            this.BackColor = Color.Gray;
            this.Padding = new Padding(40, 1, 0, 0);

            this.Controls.Add(jTextBox);
        }

    }

}
