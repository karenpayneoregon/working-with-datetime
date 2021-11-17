namespace Formatter
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
            this.OKButton = new System.Windows.Forms.Button();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TextBox();
            this.FormatStrings = new System.Windows.Forms.ComboBox();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.DateBox = new System.Windows.Forms.RadioButton();
            this.NumberBox = new System.Windows.Forms.RadioButton();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.CultureNames = new System.Windows.Forms.ComboBox();
            this.CulturesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(328, 225);
            this.OKButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(88, 27);
            this.OKButton.TabIndex = 17;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(16, 207);
            this.ResultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(80, 15);
            this.ResultLabel.TabIndex = 16;
            this.ResultLabel.Text = "ResultTextBox";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(33, 228);
            this.Result.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Size = new System.Drawing.Size(223, 23);
            this.Result.TabIndex = 15;
            // 
            // FormatStrings
            // 
            this.FormatStrings.FormattingEnabled = true;
            this.FormatStrings.Location = new System.Drawing.Point(33, 104);
            this.FormatStrings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FormatStrings.Name = "FormatStrings";
            this.FormatStrings.Size = new System.Drawing.Size(223, 23);
            this.FormatStrings.TabIndex = 14;
            this.FormatStrings.SelectedIndexChanged += new System.EventHandler(this.FormatStrings_SelectedIndexChanged);
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.Location = new System.Drawing.Point(13, 85);
            this.FormatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(105, 15);
            this.FormatLabel.TabIndex = 13;
            this.FormatLabel.Text = "FormatComboBox";
            // 
            // DateBox
            // 
            this.DateBox.AutoSize = true;
            this.DateBox.Location = new System.Drawing.Point(328, 48);
            this.DateBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DateBox.Name = "DateBox";
            this.DateBox.Size = new System.Drawing.Size(97, 19);
            this.DateBox.TabIndex = 12;
            this.DateBox.TabStop = true;
            this.DateBox.Text = "RadioButton2";
            this.DateBox.UseVisualStyleBackColor = true;
            this.DateBox.CheckedChanged += new System.EventHandler(this.DateBox_CheckedChanged);
            // 
            // NumberBox
            // 
            this.NumberBox.AutoSize = true;
            this.NumberBox.Location = new System.Drawing.Point(328, 21);
            this.NumberBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NumberBox.Name = "NumberBox";
            this.NumberBox.Size = new System.Drawing.Size(97, 19);
            this.NumberBox.TabIndex = 11;
            this.NumberBox.TabStop = true;
            this.NumberBox.Text = "RadioButton1";
            this.NumberBox.UseVisualStyleBackColor = true;
            this.NumberBox.CheckedChanged += new System.EventHandler(this.NumberBox_CheckedChanged);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(33, 39);
            this.ValueTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(216, 23);
            this.ValueTextBox.TabIndex = 10;
            this.ValueTextBox.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(9, 21);
            this.ValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(76, 15);
            this.ValueLabel.TabIndex = 9;
            this.ValueLabel.Text = "ValueTextBox";
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 280);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(502, 22);
            this.StatusBar.TabIndex = 18;
            this.StatusBar.Text = "StatusStrip1";
            // 
            // CultureNames
            // 
            this.CultureNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CultureNames.FormattingEnabled = true;
            this.CultureNames.Location = new System.Drawing.Point(33, 162);
            this.CultureNames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CultureNames.Name = "CultureNames";
            this.CultureNames.Size = new System.Drawing.Size(223, 23);
            this.CultureNames.TabIndex = 20;
            this.CultureNames.SelectedIndexChanged += new System.EventHandler(this.CultureNames_SelectedIndexChanged);
            // 
            // CulturesLabel
            // 
            this.CulturesLabel.AutoSize = true;
            this.CulturesLabel.Location = new System.Drawing.Point(13, 143);
            this.CulturesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CulturesLabel.Name = "CulturesLabel";
            this.CulturesLabel.Size = new System.Drawing.Size(106, 15);
            this.CulturesLabel.TabIndex = 19;
            this.CulturesLabel.Text = "CultureComboBox";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 302);
            this.Controls.Add(this.CultureNames);
            this.Controls.Add(this.CulturesLabel);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.FormatStrings);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.DateBox);
            this.Controls.Add(this.NumberBox);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      internal System.Windows.Forms.Button OKButton;
      internal System.Windows.Forms.Label ResultLabel;
      internal System.Windows.Forms.TextBox Result;
      internal System.Windows.Forms.ComboBox FormatStrings;
      internal System.Windows.Forms.Label FormatLabel;
      internal System.Windows.Forms.RadioButton DateBox;
      internal System.Windows.Forms.RadioButton NumberBox;
      internal System.Windows.Forms.TextBox ValueTextBox;
      internal System.Windows.Forms.Label ValueLabel;
      internal System.Windows.Forms.StatusStrip StatusBar;
      internal System.Windows.Forms.ComboBox CultureNames;
      internal System.Windows.Forms.Label CulturesLabel;
   }
}

