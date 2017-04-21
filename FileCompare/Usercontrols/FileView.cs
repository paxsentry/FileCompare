using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FileCompare.Interfaces;
using NLog;
using ScintillaNET;

namespace FileCompare
{
    public partial class UCFileView : UserControl, IFileView
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        Scintilla TextArea;

        public static Color HC_NODE = Color.Firebrick;
        public static Color HC_STRING = Color.Blue;
        public static Color HC_ATTRIBUTE = Color.Red;
        public static Color HC_COMMENT = Color.GreenYellow;
        public static Color HC_INNERTEXT = Color.Black;

        public UCFileView()
        {
            InitializeComponent();
        }

        public void SetFilePathAndName(string filePathAndName)
        {
            lblFilePathAndName.Text = filePathAndName;
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            //   dialog.Filter = "XML files|*.xml|Rich Text files|*.rtf|Simple Text files|*.txt";
            var result = dialog.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    TextArea.Text = File.ReadAllText(dialog.FileName);
                    SetFilePathAndName(dialog.FileName);
                    // TODO check file type and modify scintilla settings.
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during loading file. {ex.Message}");
                throw;
            }
        }

        private void UCFileView_Load(object sender, EventArgs e)
        {
            TextArea = new Scintilla();
            TextPanel.Controls.Add(TextArea);

            // BASIC CONFIG
            TextArea.Dock = DockStyle.Fill;

            // INITIAL VIEW CONFIG
            TextArea.WrapMode = WrapMode.None;
            TextArea.IndentationGuides = IndentView.LookBoth;

            // STYLING
            InitColors();
            InitSyntaxColoring();
        }

        private void InitColors()
        {
            TextArea.SetSelectionBackColor(true, IntToColor(0x114D9C));
        }

        private void InitSyntaxColoring()
        {
            // Reset the styles
            TextArea.StyleResetDefault();
            TextArea.Styles[Style.Default].Font = "Consolas";
            TextArea.Styles[Style.Default].Size = 10;
            TextArea.Styles[Style.Default].BackColor = Color.DarkGray;
            TextArea.Styles[Style.Default].ForeColor = Color.DarkBlue;
            TextArea.StyleClearAll();

            // Set the XML Lexer
            TextArea.Lexer = Lexer.Xml;

            // Show line numbers
            TextArea.Margins[0].Width = 20;

            // Enable folding
            TextArea.SetProperty("fold", "1");
            TextArea.SetProperty("fold.compact", "1");
            TextArea.SetProperty("fold.html", "1");

            // Use Margin 2 for fold markers
            TextArea.Margins[2].Type = MarginType.Symbol;
            TextArea.Margins[2].Mask = Marker.MaskFolders;
            TextArea.Margins[2].Sensitive = true;
            TextArea.Margins[2].Width = 20;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                TextArea.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                TextArea.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            TextArea.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            TextArea.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            TextArea.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            TextArea.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            TextArea.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            TextArea.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            TextArea.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            TextArea.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            TextArea.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            TextArea.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            // Set the Styles
            //TextArea.StyleResetDefault();
            //// I like fixed font for XML
            //TextArea.Styles[Style.Default].Font = "Courier";
            //TextArea.Styles[Style.Default].Size = 10;
            //TextArea.StyleClearAll();
            TextArea.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
            TextArea.Styles[Style.Xml.Entity].ForeColor = Color.Red;
            TextArea.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            TextArea.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
            TextArea.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
            TextArea.Styles[Style.Xml.DoubleString].ForeColor = Color.DeepPink;
            TextArea.Styles[Style.Xml.SingleString].ForeColor = Color.DeepPink;
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

    }
}