using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace FinalProject.FileHendlers
{
class XLSdataTableHandlers
{
            public void createXslFromDataset(DataSet ds, String path)
            {
                XmlDataDocument xmlDataDoc = new XmlDataDocument(ds);
                XslTransform xt = new XslTransform();
                StreamReader reader =new StreamReader(typeof (XLSdataTableHandlers).Assembly.GetManifestResourceStream(typeof (XLSdataTableHandlers), "Excel.xsl"));
                XmlTextReader xRdr = new XmlTextReader(reader);
                xt.Load(xRdr, null, null);
                StringWriter sw = new StringWriter();
                xt.Transform(xmlDataDoc, null, sw, null);
                StreamWriter myWriter = new StreamWriter(path + "\\Report.xls");
                myWriter.Write (sw.ToString());
                myWriter.Close ();
            }
}
}
