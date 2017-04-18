using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using NLog;
using ScintillaNET;

namespace FileCompare
{
    public partial class UCFileView : UserControl
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

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML files|*.xml|Rich Text files|*.rtf|Simple Text files|*.txt";
            var result = dialog.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    if (Path.GetExtension(dialog.FileName) == ".rtf")
                    {
                        //this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);
                        //this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == ".txt")
                    {
                        //this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                        //this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == ".xml")
                    {
                        TextArea.Text = File.ReadAllText(dialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during loading file. {ex.Message}");
                throw;
            }
        }

        private void richTBFileView_TextChanged(object sender, EventArgs e)
        {
            //XMLLoader.Instance.ColoriseResult(this.richTBFileView.Text);
            //int index = richTBFileView.Text.IndexOf("<");
            //int length = 1;

            //richTBFileView.Select(index, length);
            //richTBFileView.SelectionColor = System.Drawing.Color.Blue;

            //this.CheckKeyword("<", Color.Blue, 0);
            //this.CheckKeyword(">", Color.Blue, 0);
            //this.CheckKeyword("/", Color.Blue, 0);

           // XMLSyntaxHighlight(this.richTBFileView);
        }

        private void XMLSyntaxHighlight(RichTextBox rtb)
        {
            string content = rtb.Text;

            int index = -1;
            int current = 0;
            int start, end;

            while (current < content.Length)
            {
                start = content.IndexOf('<', current);
                if (start < 0) { break; }

                if (index > 0)
                {
                    rtb.Select(index + 1, start - index - 1);
                    rtb.SelectionColor = HC_INNERTEXT;
                }

                end = content.IndexOf('>', start + 1);
                if (end < 0) { break; }

                current = end + 1;
                index = end;

                if (content[start + 1] == '!')
                {
                    rtb.Select(start + 1, end - start - 1);
                    rtb.SelectionColor = HC_COMMENT;
                    continue;
                }

                string nodeText = content.Substring(start + 1, end - start - 1);

                string caretStart = content.Substring(start, 1);
                if (!string.IsNullOrEmpty(caretStart))
                {
                    rtb.Select(start, 1);
                    rtb.SelectionColor = HC_STRING;
                }

                string caretEnd = content.Substring(end, 1);
                if (!string.IsNullOrEmpty(caretEnd))
                {
                    rtb.Select(end, 1);
                    rtb.SelectionColor = HC_STRING;
                }


                bool inString = false;

                int lastString = -1;
                int state = 0; // 0 before node name, 1 in node name, 2 after node name, 3 in attribute, 4 in string
                int startNodename = 0, startAttr = 0;
                for (int i = 0; i < nodeText.Length; ++i)
                {
                    if (nodeText[i] == '"') inString = !inString;
                    if (inString && nodeText[i] == '"')
                    {
                        lastString = i;
                    }
                    else if (nodeText[i] == '"')
                    {
                        rtb.Select(lastString + start + 2, i - lastString - 1);
                        rtb.SelectionColor = HC_STRING;
                    }

                    switch (state)
                    {
                        case 0:
                            if (!char.IsWhiteSpace(nodeText, i))
                            {
                                startNodename = i;
                                state = 1;
                            }
                            break;
                        case 1:
                            if (char.IsWhiteSpace(nodeText, i))
                            {
                                rtb.Select(startNodename + start, i - startNodename + 1);
                                rtb.SelectionColor = HC_NODE;
                                state = 2;
                            }
                            break;
                        case 2:
                            if (!char.IsWhiteSpace(nodeText, i))
                            {
                                startAttr = i;
                                state = 3;
                            }
                            break;
                        case 3:
                            if (char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
                            {
                                rtb.Select(startAttr + start, i - startAttr + 1);
                                rtb.SelectionColor = HC_ATTRIBUTE;
                                state = 4;
                            }
                            break;
                        case 4:
                            if (nodeText[i] == '"' && !inString)
                            {
                                state = 2;
                            }
                            break;
                        default:
                            break;
                    }
                }

                if (state == 1)
                {
                    rtb.Select(start + 1, nodeText.Length);
                    rtb.SelectionColor = HC_NODE;
                }
            }
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            //if (this.richTBFileView.Text.Contains(word))
            //{
            //    int index = -1;
            //    int selectStart = this.richTBFileView.SelectionStart;

            //    while ((index = this.richTBFileView.Text.IndexOf(word, (index + 1))) != -1)
            //    {
            //        this.richTBFileView.Select((index + startIndex), word.Length);
            //        this.richTBFileView.SelectionColor = color;
            //        this.richTBFileView.Select(selectStart, 0);
            //        this.richTBFileView.SelectionColor = Color.Black;
            //    }
            //}
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
            TextArea.StyleResetDefault();
            // I like fixed font for XML
            TextArea.Styles[Style.Default].Font = "Courier";
            TextArea.Styles[Style.Default].Size = 10;
            TextArea.StyleClearAll();
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