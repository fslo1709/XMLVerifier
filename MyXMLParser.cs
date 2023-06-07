using System;
using System.IO;

/// <summary>
/// Class <c>MyXMLParser</c> includes an entry point, <c>DetermineXML(string xml)</c>
/// that returns a boolean value. This value indicates if the given string is a
/// valid xml string or not.
/// </summary>
class MyXMLParser {
    /// <summary>
    /// <c>getNextTagOf (string target)</c> is an auxiliary function to extract tags out of a string
    /// It returns two values, first the string contained between the next two angled brackets, 
    /// null if there's no other pair of angled brackets or it further evaluates if the opening
    /// angled bracket it found is after the closing angled bracket.
    /// The second value is the substring that remains after parsing the last closing
    /// angled bracket.
    /// </summary>
    private static Tuple<string, string> getNextTagOf(string target) {
        int firstIndex = target.IndexOf('<');
        int secondIndex = target.IndexOf('>');

        /// If there are no more pairs of angled brackets left, return null to break the parsing here
        if (firstIndex < 0 || secondIndex < 0) {
            Tuple<string, string> response = new Tuple<string, string>(null, null);
            return response;
        }
        /// In case of an empty tag, returns an empty string
        else if (firstIndex == secondIndex - 1) {
            Tuple<string, string> response = new Tuple<string, string>("", null);
            return response;
        }
        /// '>' could be part of another string, this parses it again starting from the 
        /// first opening angled bracket
        else if (firstIndex > secondIndex) {
            return getNextTagOf(target.Substring(firstIndex));
        }
        // No errors, return the string contained between the angled brackets
        else {
            return target.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
        }
    }
    public static bool DetermineXML(string xml) {
        string tempXML = xml;
        Stack<string> angleBracketsStack = new Stack<string>();

        while (true) {
            string tag = getNextTagOf(tempXML);
            if (tag == null) {
                break;
            }
            else {
                if (tag.Empty()) {
                    return false;
                }
                if (tag[0] == '/') {
                    if (angleBracketsStack.Count == 0) {
                        return false;
                    }
                    string lastElement = angleBracketsStack.Pop();
                    if (!lastElement.Equals(tag.Substring(1))) {
                        return false;
                    }
                }
                else {
                    angleBracketsStack.Push(tag);
                }
            }
            tempXML = tempXML.Substring(tempXML.IndexOf('>') + 1);
        }

        if (angleBracketsStack.Count != 0) {
            return false;
        }
        return true;
    }
}