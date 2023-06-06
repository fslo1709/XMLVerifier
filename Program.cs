using System;

class Program {
    static public void Main() {
        // Cases provided by the problem statement
        if (!MyXMLParser.DetermineXML("<Design><Code>hello world</Code></Design>")) {
            Console.WriteLine("Error in case 1");
        }
        if (MyXMLParser.DetermineXML("<Design><Code>hello world</Code></Design><People>")) {
            Console.WriteLine("Error in case 2");
        }
        if (MyXMLParser.DetermineXML("<People><Design><Code>hello world</People></Code></Design>")) {
            Console.WriteLine("Error in case 3");
        }
        if (MyXMLParser.DetermineXML("<People age=”1”>hello world</People>")) {
            Console.WriteLine("Error in case 4");
        }
    }
}