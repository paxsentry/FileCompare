using NLog;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System;

namespace FileCompare.Helpers
{
    public class XMLLoader
    {
        private static XMLLoader _instance;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private XMLLoader() { }

        public static XMLLoader Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new XMLLoader();
                }
                return _instance;
            }
        }

        public XmlDocument XmlDocument { get; private set; }

        public string ConvertXmlToText(OpenFileDialog dialog)
        {
            string result = string.Empty;

            if (dialog != null)
            {
                var xmlDoc = XElement.Load(dialog.FileName);
                XmlNodeList xmlNodeList;
                
                result = xmlDoc.ToString();

                
                //xmlDoc.Load(dialog.FileName);
                //xmlNodeList = xmlDoc.("Person");

                //for (int i = 0; i < xmlNodeList.Count-1; i++)
                //{
                //    for (int j = 0; j < xmlNodeList[i].ChildNodes.Count-1; j++)
                //    {
                //        var temp = xmlNodeList[i].ChildNodes.Item(j).InnerText;
                //        temp.Trim();
                //        xmlText = xmlText + " " + temp;
                //    }
                //}
                //XmlDocument parsedStream = new XmlDocument();
                //parsedStream.Load(dialog.FileName);

                //XmlNodeList nodeList = parsedStream.GetElementsByTagName("Persons");

                //XDocument xmlDoc = XDocument.Load(dialog.FileName);

                //var persons = from person in xmlDoc.Descendants("Person")
                //              select new
                //              {
                //                  Name = person.Element("Name").Value,
                //                  City = person.Element("City").Value,
                //                  Age = person.Element("Age").Value
                //              };

                //this.Text = string.Empty;
                //foreach (var person in persons)
                //{
                //    this.Text = this.Text + "Name: " + person.Name + "\n";
                //    this.Text = this.Text + "City: " + person.City + "\n";
                //    this.Text = this.Text + "Age: " + person.Age + "\n\n";
                //}

                //this.richTBFileView.LoadFile(dialog.FileName);
                //this.Text = dialog.FileName;

            }
            else
            {
                logger.Debug("No file supplied for XmlLoader.");
            }

            return result;
        }

        public void ColoriseResult(string result)
        {
            //for (int i = 0; i < result.Length; i++)
            //{
            //    if(result[i] == '<')
            //    {
            //        result[i]
            //    }
            //}
        }
    }
}
