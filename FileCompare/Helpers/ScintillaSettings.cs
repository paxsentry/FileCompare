using System.Drawing;
using ScintillaNET;

namespace FileCompare.Helpers
{
    public static class ScintillaSettings
    {
        private static Scintilla _area;
        private static int _maxLineNumberCharLength;

        public static void SetupScintilla(Scintilla area)
        {
            _area = area;
            SetupBasics();
            SetupSelectionBackColor();
            SetupLineNumbering();
            SetupXmlSyntaxColoring();
        }

        public static void SetupXML(Scintilla area)
        {
            _area = area;
            SetupXmlSyntaxColoring();
            SetupLineNumbering();
        }

        private static void SetupBasics()
        {
            _area.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private static void SetupSelectionBackColor()
        {
            _area.SetSelectionBackColor(true, IntToColor(0x114D9C));
        }

        private static void SetupLineNumbering()
        {
            var maxLineNumberCharLength = _area.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == _maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number and include some padding for good measure.
            const int padding = 1;
            _area.Margins[0].Width = _area.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            _maxLineNumberCharLength = maxLineNumberCharLength;
        }

        private static void SetupXmlSyntaxColoring()
        {
            // Reset the styles
            _area.StyleResetDefault();
            _area.Styles[Style.Default].Font = "Consolas";
            _area.Styles[Style.Default].Size = 10;
            _area.Styles[Style.Default].BackColor = Color.DarkGray;
            _area.Styles[Style.Default].ForeColor = Color.DarkBlue;
            _area.StyleClearAll();

            // Set the XML Lexer
            _area.Lexer = Lexer.Xml;

            // Enable folding
            _area.SetProperty("fold", "1");
            _area.SetProperty("fold.compact", "1");
            _area.SetProperty("fold.html", "1");

            // Use Margin 2 for fold markers
            _area.Margins[2].Type = MarginType.Symbol;
            _area.Margins[2].Mask = Marker.MaskFolders;
            _area.Margins[2].Sensitive = true;
            _area.Margins[2].Width = 20;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                _area.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                _area.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            _area.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            _area.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            _area.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            _area.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            _area.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            _area.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            _area.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            _area.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            _area.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            _area.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            // Set the Styles
            //_area.StyleResetDefault();
            //// I like fixed font for XML
            //_area.Styles[Style.Default].Font = "Courier";
            //_area.Styles[Style.Default].Size = 10;
            //_area.StyleClearAll();
            _area.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
            _area.Styles[Style.Xml.Entity].ForeColor = Color.Red;
            _area.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            _area.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
            _area.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
            _area.Styles[Style.Xml.DoubleString].ForeColor = Color.DeepPink;
            _area.Styles[Style.Xml.SingleString].ForeColor = Color.DeepPink;
        }

        private static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}