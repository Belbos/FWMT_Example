using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class DataAccess
{

    public static SQLiteConnection SqlConnection()
    {
         Console.WriteLine("XqlPassing " + ReadConnectionStringXml());
        WriteConnectionStringXml();
        string connStr = "Data Source=" + ReadConnectionStringXml() + ";Pooling=true;FailIfMissing=false";
        SQLiteConnection sqliteConnection = new SQLiteConnection(connStr);
   
        sqliteConnection.Open();

        return sqliteConnection;
    }

    #region xml읽어서 ConnectionString 가져옴
    private static String ReadConnectionStringXml()
    {
        string returnXml = "";
        XmlDocument xml = new XmlDocument();
        string path = AppDomain.CurrentDomain.BaseDirectory + @"\Setting";
       

        xml.Load(path  + @"\ConnectionString.xml"); //"D:\\test\\config.xml" == @"D:\test\config.xml" 
        XmlNodeList xmlList = xml.SelectNodes("/CONNECTION");
        foreach (XmlNode xnl in xmlList)
        {
            returnXml = xnl["STRING"].InnerText;
     
        }
        return returnXml;
    }
    #endregion

    #region xml 파일이 없으면 Desktop 문서에 저장
    private static String WriteConnectionStringXml()
    {
        XmlDocument xml = new XmlDocument();
        // xml 자동생성 경로
        String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\FireWillManagementTool\Setting";

        // 메인 XMl root
        XmlNode root = xml.CreateElement("MAIN");
        XmlNode CONNECTION = xml.CreateElement("CONNECTION");
        XmlNode STRING = xml.CreateElement("STRING");

        // Value 값 입력
        STRING.InnerText = path;

        CONNECTION.AppendChild(STRING);
        root.AppendChild(CONNECTION);
        xml.AppendChild(root);

        // 폴더에 경로 존재여부 (없으면 폴더 생성)
        if ( !( Directory.Exists(path) ) )
        {
            Directory.CreateDirectory(path);
        }
        xml.Save(path + @"\ConnectionString.xml");

        //DirectoryInfo dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ @"\Setting");

        return path;

    }
    #endregion


}
