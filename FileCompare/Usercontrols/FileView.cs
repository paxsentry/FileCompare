using NLog;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FileCompare
{
    public partial class UCFileView : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
                        this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);
                        this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == ".txt")
                    {
                        this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                        this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == ".xml")
                    {
                        XmlDocument parsedStream = new XmlDocument();
                        parsedStream.Load(dialog.FileName);
                        
                        XmlNodeList nodeList = parsedStream.GetElementsByTagName("Persons");

                        XDocument xmlDoc = XDocument.Load(dialog.FileName);

                        var persons = from person in xmlDoc.Descendants("Person")
                                      select new
                                      {
                                          Name = person.Element("Name").Value,
                                          City = person.Element("City").Value,
                                          Age = person.Element("Age").Value
                                      };

                        this.Text = string.Empty;
                        foreach (var person in persons)
                        {
                            this.Text = this.Text + "Name: " + person.Name + "\n";
                            this.Text = this.Text + "City: " + person.City + "\n";
                            this.Text = this.Text + "Age: " + person.Age + "\n\n";
                        }

                        //this.richTBFileView.LoadFile(dialog.FileName);
                        //this.Text = dialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during loading file. {ex.Message}");
                throw;
            }
        }
    }
}