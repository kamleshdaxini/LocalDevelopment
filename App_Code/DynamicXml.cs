using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;

/// <summary>
/// Summary description for DynamicXml
/// </summary>
public class DynamicXml
{
	public DynamicXml()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// To Create Xml file for every multiselect list to pass data of xml type in database
    /// </summary>
    /// <param name="DtXml"></param>
    /// <param name="Text"></param>
    /// <param name="Value"></param>
    /// <param name="XmlFileName"></param>
    /// <returns></returns>
    public string GetXml(DataTable DtXml, String Text, String Value,string XmlFileName)
    {       
        XmlDocument xmldoc = new XmlDocument();
        //To create Xml declarartion in xml file
        XmlDeclaration decl = xmldoc.CreateXmlDeclaration("1.0", "UTF-16", "");
        xmldoc.InsertBefore(decl, xmldoc.DocumentElement);
        XmlElement RootNode = xmldoc.CreateElement("Root");
        xmldoc.AppendChild(RootNode);
        for (int i = 0; i < DtXml.Rows.Count; i++)
        {
            XmlElement childNode = xmldoc.CreateElement("Row");
            childNode.SetAttribute(Value, DtXml.Rows[i][1].ToString());
            childNode.SetAttribute(Text, DtXml.Rows[i][0].ToString());
            RootNode.AppendChild(childNode);
        }

        //Check if directory already exist or not otherwise 
        //create directory
        if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("XML")))
            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("XML"));
        XmlFileName = "XML" + "\\" + XmlFileName;

        //To save xml file on respective path
        xmldoc.Save(System.Web.HttpContext.Current.Server.MapPath(XmlFileName));
        xmldoc.RemoveChild(xmldoc.FirstChild);      
        string RetXml = xmldoc.InnerXml;
        return RetXml;
    }
}