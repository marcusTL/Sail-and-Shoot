using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sail_n__Shoot___Obl_Opg._aswc.XMLConfig
{
    public class XmlConfig
    {
        public XmlConfig()
        {
        }

        public int UseConfigFile(string tag)
        {
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load("Config.xml");
            XmlNode xNode = configDoc.DocumentElement.SelectSingleNode(tag);
            //C:\Users\mtlau\source\repos\4th semester\Sail n' Shoot - Obl Opg. aswc\GameTest\bin\Debug\net5.0

            if (xNode != null)
            {
                string xmlStr = xNode.InnerText.Trim();
                int xmlval = Convert.ToInt32(xmlStr);

                return xmlval;
            }

            return 0;
        }

        public void UpdateValues()
        {

        }

        
    }
}
