using System;
using System.IO;

class MyXMLParser {
    private static string getNextTagOf(string target) {
        if (target.IndexOf('<') < 0 || target.IndexOf('>') < 0) {
            return null;
        }
        else {
            return target.Split('<', '>')[1];
        }
    }
    public static bool DetermineXML(string xml) {
        string tempXML = xml;
        while (true) {
            string tag = getNextTagOf(tempXML);
            if (tag == null) {
                break;
            }
            else {
                Console.WriteLine(tag);
            }
            tempXML = tempXML.Substring(tempXML.IndexOf('>') + 1);
        }
        return true;
    }
}