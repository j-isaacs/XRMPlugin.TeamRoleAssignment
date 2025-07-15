using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using ScintillaNET;
using System.Linq;

namespace XRMPlugin.TeamRoleAssignment
{
    public partial class FetchXMLDialog : Form
    {
        public string FetchXml { get; set; }

        public FetchXMLDialog()
        {
            InitializeComponent();
            InitScintilla(scintillaFetchXML);
        }

        public FetchXMLDialog(string fetchXml) : this()
        {
            FetchXml = FormatFetchXml(fetchXml);
            scintillaFetchXML.Text = FetchXml;

            var idealWidth = scintillaFetchXML.TextWidth(Style.Default, scintillaFetchXML.Lines.Aggregate((max, cur) => max.Length > cur.Length ? max : cur).Text) + 
                scintillaFetchXML.Margins.Sum(m => m.Width);
            if (idealWidth > scintillaFetchXML.Width)
            {
                Width += idealWidth - scintillaFetchXML.Width;
            }
        }

        private void ToolStripButtonSaveAndClose_Click(object sender, EventArgs e)
        {
            FetchXml = scintillaFetchXML.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ToolStripButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ToolStripButtonBuilder_Click(object sender, EventArgs e)
        {
            FetchXml = scintillaFetchXML.Text;
            DialogResult = DialogResult.Yes;
            Close();
        }

        private string FormatFetchXml(string fetchXml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(fetchXml);
            var strBuilder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(strBuilder, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true }))
            {
                xmlDoc.Save(xmlWriter);
            }

            return strBuilder.ToString();
        }

        private void InitScintilla(Scintilla scintilla)
        {
            // Set the XML Lexer
            scintilla.Lexer = Lexer.Xml;

            // Show line numbers
            scintilla.Margins[0].Width = 20;

            // Enable folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");
            scintilla.SetProperty("fold.html", "1");

            // Use Margin 2 for fold markers
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            // Set the Styles
            scintilla.StyleResetDefault();
            // I like fixed font for XML
            scintilla.Styles[Style.Default].Font = "Courier";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();
            scintilla.Styles[Style.Xml.Attribute].ForeColor = Color.Teal;
            scintilla.Styles[Style.Xml.Entity].ForeColor = Color.Teal;
            scintilla.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            scintilla.Styles[Style.Xml.Tag].ForeColor = Color.DarkBlue;
            scintilla.Styles[Style.Xml.TagEnd].ForeColor = Color.DarkBlue;
            scintilla.Styles[Style.Xml.DoubleString].ForeColor = Color.Purple;
            scintilla.Styles[Style.Xml.SingleString].ForeColor = Color.Purple;
        }
    }
}
