using System;

class Program {
    static public void Main() {
        string textfile = "./testcases.txt";

        if (File.Exists(textfile)) {
            bool stringLine = true;
            string nextLine = "";
            int count = 1;
            string[] lines = File.ReadAllLines(textfile);
            foreach(string line in lines) {
                if (stringLine) {
                    nextLine = line;
                    stringLine = false;
                }
                else {
                    bool truthValue;
                    if (line.Equals("true")) {
                        truthValue = true;
                    }
                    else if (line.Equals("false")) {
                        truthValue = false;
                    }
                    else {
                        Console.WriteLine("Unexpected value at case " + count.ToString());
                        return;
                    }
                    if (MyXMLParser.DetermineXML(nextLine) != truthValue) {
                        Console.WriteLine("Error in case " + count.ToString());
                    }
                    stringLine = true;
                    count++;
                }
            }
        }
        Console.WriteLine("Finished evaluating all cases");
    }
}