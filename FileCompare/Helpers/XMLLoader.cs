using System.Xml;

namespace FileCompare.Helpers
{
    public class XMLLoader
    {
        private static XMLLoader _instance;
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

        private XmlDocument CreateEmptyXmlDocument()
        {
            // Return an empty XML if the the file open window was closed
            XmlDocument empty = new XmlDocument();
            return empty;
        }

    }
}
