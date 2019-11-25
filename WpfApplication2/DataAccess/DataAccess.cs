using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class DataAccess
{

    public static SQLiteConnection SqlConnection()
    {
        Console.WriteLine("XqlPassing " + XqlPassing());
        string connStr = @"Data Source=C:\Users\jongyoung\Documents\Visual Studio 2015\Projects\WpfApplication2\sqlite\sqlite;Pooling=true;FailIfMissing=false";
        SQLiteConnection sqliteConnection = new SQLiteConnection(connStr);
   
        sqliteConnection.Open();

        return sqliteConnection;
    }


    private static String XqlPassing()
    {
        string returnXml = "";
        XmlDocument xml = new XmlDocument();
        xml.Load(@"Setting\ConnectionString.xml"); //"D:\\test\\config.xml" == @"D:\test\config.xml" 
        XmlNodeList xmlList = xml.SelectNodes("/CONNECTION");
        foreach (XmlNode xnl in xmlList)
        {
            returnXml = xnl["STRING"].InnerText;

        }



        return returnXml;

    }

     
}
