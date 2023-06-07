/// Author: Fernando Sebastian Lopez Ochoa
using System;

/// <summary>
/// Main class to verify the parser works correctly
/// Reads from the specified txt file all test cases. Each test case is composed
/// of two lines: one for the xml string and the second one for the truth value
/// of that xml string. True-false values are case sensitive, input them only
/// in lower case. Output of the evaluation is displayed in the terminal.
/// </summary>
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
                    else {
                        Console.WriteLine("Case " + count.ToString() + " passed");
                    }
                    stringLine = true;
                    count++;
                }
            }
        }
        Console.WriteLine("Finished evaluating all cases");
    }
}