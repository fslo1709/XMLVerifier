using System;
using MyXMLParser;

class Program {
    static public void Main() {
        MyXMLParser myParser = new MyXMLParser();

        // Cases provided by the problem statement
        if (!myParser.DetermineXML("<Design><Code>hello world</Code></Design>")) {
            Console.WriteLine("Error in case 1");
        }
        if (myParser.DetermineXML("<Design><Code>hello world</Code></Design><People>")) {
            Console.WriteLine("Error in case 2");
        }
        if (myParser.DetermineXML("<People><Design><Code>hello world</People></Code></Design>")) {
            Console.WriteLine("Error in case 3");
        }
        if (myParser.DetermineXML("<People age=”1”>hello world</People>")) {
            Console.WriteLine("Error in case 1");
        }
    }
}