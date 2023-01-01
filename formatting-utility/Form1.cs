using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Formatter
{
    public partial class Form1 : Form
    {
        private ResourceManager rm;

        private ToolStripStatusLabel label;

        private string decimalSeparator;
        private string amDesignator, pmDesignator, aDesignator, pDesignator;
        private string pattern;

        // Flags to indicate presence of error information in status bar
        bool valueInfo;
        bool formatInfo;

        private readonly string[] numberFormats = { "C", "D", "E", "e", "F", "G", "N", "P", "R", "X", "x" };
        private const int DEFAULTSELECTION = 5;
        private readonly string[] dateFormats = { "g", "d", "D", "f", "F", "g", "G", "M", "O", "R", "s",
                                       "t", "T", "u", "U", "Y" };

        public Form1()
        {
            InitializeComponent();
            rm = new ResourceManager("Formatter.Resources", GetType().Assembly);

            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            ValueTextBox.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            DateBox.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Disable OK button.
            OKButton.Enabled = false;

            // Add label to status bar.
            label = new ToolStripStatusLabel();
            ToolStripItem[] items = { label };
            StatusBar.Items.AddRange(items);

            // Get localized strings for user interface.
            Text = rm.GetString("WindowCaption");
            ValueLabel.Text = rm.GetString("ValueLabel");
            FormatLabel.Text = rm.GetString("FormatLabel");
            ResultLabel.Text = rm.GetString("ResultLabel");
            CulturesLabel.Text = rm.GetString("CultureLabel");
            NumberBox.Text = rm.GetString("NumberBoxText");
            DateBox.Text = rm.GetString("DateBoxText");
            OKButton.Text = rm.GetString("OKButtonText");

            // Populate CultureNames list box with culture names
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            // Define a string list so that we can sort and modify the names.
            var names = new List<string>();
            var currentIndex = 0;                    // Index of the current culture.

            foreach (var culture in cultures)
            {
                names.Add(culture.Name);
            }

            names.Sort();
            // Change the name of the invariant culture so it is human readable.
            names[0] = rm.GetString("InvariantCultureName");
            // Add the culture names to the list box.
            CultureNames.Items.AddRange(names.ToArray());

            // Make the current culture the selected culture.
            for (int ctr = 0; ctr < names.Count; ctr++)
            {
                if (names[ctr] == CultureInfo.CurrentCulture.Name)
                {
                    currentIndex = ctr;
                    break;
                }
            }
            CultureNames.SelectedIndex = currentIndex;

            // Get decimal separator.
            decimalSeparator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            // Get am, pm designators.
            amDesignator = DateTimeFormatInfo.CurrentInfo.AMDesignator;
            if (amDesignator.Length >= 1)
                aDesignator = amDesignator.Substring(0, 1);
            else
                aDesignator = string.Empty;

            pmDesignator = DateTimeFormatInfo.CurrentInfo.PMDesignator;
            if (pmDesignator.Length >= 1)
                pDesignator = pmDesignator.Substring(0, 1);
            else
                pDesignator = string.Empty;

            // For regex pattern for date and time components.
            pattern = @$"^\s*\S+\s+\S+\s+\S+(\s+\S+)?(?<!{amDesignator}|{aDesignator}|{pmDesignator}|{pDesignator})\s*$";

            // Select NumberBox for numeric string and populate combo box.
            NumberBox.Checked = true;
        }

        private void NumberBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NumberBox.Checked)
            {
                Result.Text = String.Empty;

                FormatStrings.Items.Clear();
                FormatStrings.Items.AddRange(numberFormats);
                FormatStrings.SelectedIndex = DEFAULTSELECTION;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

            label.Text = "";
            Result.Text = string.Empty;

            // Get name of the current culture.
            CultureInfo culture = null;
            string cultureName = (string)CultureNames.Items[CultureNames.SelectedIndex];
            // If the selected culture is the invariant culture, change its name.
            if (cultureName == rm.GetString("InvariantCultureName"))
                cultureName = String.Empty;
            culture = CultureInfo.CreateSpecificCulture(cultureName);

            // Parse string as date.
            if (DateBox.Checked)
            {
                DateTime dat = DateTime.MinValue;
                DateTimeOffset dto = DateTimeOffset.MinValue;
                long ticks;
                bool hasOffset = false;

                // Is the date a number expressed in ticks?
                if (Int64.TryParse(ValueTextBox.Text, out ticks))
                {
                    dat = new DateTime(ticks);
                }
                else
                {
                    // Does the date have three components (date, time offset), or fewer than 3?
                    if (Regex.IsMatch(ValueTextBox.Text, pattern, RegexOptions.IgnoreCase))
                    {
                        if (DateTimeOffset.TryParse(ValueTextBox.Text, out dto))
                        {
                            hasOffset = true;
                        }
                        else
                        {
                            label.Text = rm.GetString("MSG_InvalidDTO");
                            valueInfo = true;
                            return;
                        }
                    }
                    else
                    {
                        // The string is to be interpeted as a DateTime, not a DateTimeOffset.
                        if (DateTime.TryParse(ValueTextBox.Text, out dat))
                        {
                            hasOffset = false;
                        }
                        else
                        {
                            label.Text = rm.GetString("MSG_InvalidDate");
                            valueInfo = true;
                            return;
                        }
                    }
                }
                // Format date value.
                Result.Text = (hasOffset ? dto : dat).ToString(FormatStrings.Text, culture);
            }
            else
            {
                // Handle formatting of a number.
                long intToFormat;
                BigInteger bigintToFormat = BigInteger.Zero;
                double floatToFormat;

                // Format a floating point value.
                if (ValueTextBox.Text.Contains(decimalSeparator) || ValueTextBox.Text.ToUpper(CultureInfo.InvariantCulture).Contains("E"))
                {
                    try
                    {
                        if (!Double.TryParse(ValueTextBox.Text, out floatToFormat))
                            label.Text = rm.GetString("MSG_InvalidFloat");
                        else
                            Result.Text = floatToFormat.ToString(FormatStrings.Text, culture);
                    }
                    catch (FormatException)
                    {
                        label.Text = rm.GetString("MSG_InvalidFormat");
                        formatInfo = true;
                    }
                }
                else
                {
                    // Handle formatting an integer.
                    //
                    // Determine whether value is out of range of an Int64
                    if (!BigInteger.TryParse(ValueTextBox.Text, out bigintToFormat))
                    {
                        label.Text = rm.GetString("MSG_InvalidInteger");
                    }
                    else
                    {
                        // Format an Int64
                        if (bigintToFormat >= long.MinValue && bigintToFormat <= Int64.MaxValue)
                        {
                            intToFormat = (long)bigintToFormat;
                            try
                            {
                                Result.Text = intToFormat.ToString(FormatStrings.Text, culture);
                            }
                            catch (FormatException)
                            {
                                label.Text = rm.GetString("MSG_InvalidFormat");
                                formatInfo = true;
                            }
                        }
                        else
                        {
                            // Format a BigInteger
                            try
                            {
                                Result.Text = bigintToFormat.ToString(FormatStrings.Text, culture);
                            }
                            catch (FormatException)
                            {
                                label.Text = rm.GetString("MSG_InvalidFormat");
                                formatInfo = true;
                            }
                        }
                    }
                }
            }
        }

        private void DateBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DateBox.Checked)
            {
                Result.Text = string.Empty;

                FormatStrings.Items.Clear();
                FormatStrings.Items.AddRange(dateFormats);
                FormatStrings.SelectedIndex = DEFAULTSELECTION;
            }
        }

        private void Value_TextChanged(object sender, EventArgs e)
        {
            Result.Text = string.Empty;

            if (valueInfo)
            {
                label.Text = string.Empty;
                valueInfo = false;
            }
            OKButton.Enabled = !string.IsNullOrEmpty(ValueTextBox.Text);
        }

        private void FormatStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result.Text = string.Empty;
            if (formatInfo)
            {
                label.Text = string.Empty;
                formatInfo = false;
            }
        }

        private void CultureNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result.Text = string.Empty;
        }
    }
}
