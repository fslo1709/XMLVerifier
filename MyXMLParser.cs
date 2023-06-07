/// Author: Fernando Sebastian Lopez Ochoa
using System;
using System.IO;

/// <summary>
/// Class <c>MyXMLParser</c> includes an entry point, <c>DetermineXML(string xml)</c>
/// that returns a boolean value. This value indicates if the given string is a
/// valid xml string or not.
/// </summary>
class MyXMLParser {
    /// <summary>
    /// <c>GetNextTagOf (string target)</c> is an auxiliary function to extract tags out of a string
    /// It returns two values, first the string contained between the next two angled brackets, 
    /// blank if there's no other pair of angled brackets or it further evaluates if the opening
    /// angled bracket it found is after the closing angled bracket.
    /// The second value is the substring that remains after parsing the last closing
    /// angled bracket.
    /// </summary>
    private static Tuple<string, string> GetNextTagOf(string target) {
        int firstIndex = target.IndexOf('<');
        int secondIndex = target.IndexOf('>');

        /// If there are no more pairs of angled brackets left, return null to break the parsing here
        if (firstIndex < 0 || secondIndex < 0) {
            Tuple<string, string> response = new Tuple<string, string>("", target);
            return response;
        }
        /// In case of an empty tag, returns an empty string
        else if (firstIndex == secondIndex - 1) {
            Tuple<string, string> response = new Tuple<string, string>("", "");
            return response;
        }
        /// '>' could be part of another string, this parses it again starting from the 
        /// first opening angled bracket
        else if (firstIndex > secondIndex) {
            return GetNextTagOf(target.Substring(firstIndex));
        }
        /// No errors, return the string contained between the angled brackets 
        /// and the following substring
        else {
            string extractedTag = target.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
            string newSubstring = target.Substring(secondIndex + 1);
            Tuple<string, string> response = new Tuple<string, string>(extractedTag, newSubstring);
            return response;
        }
    }

    /// <summary>
    /// <c>DetermineXML(string xml)</c> receives a string as an input. It extracts
    /// the tags contained in the string using the auxiliary function <c>GetNextTagOf(string target)</c>.
    /// It returns a truth value, if the string is a valid xml or not.
    /// To evaluate the correctness of the bracket order, it utilizes a stack.
    /// If it's an opening bracket, it pushes it into the stack. When it finds a closing
    /// bracket, it pops the first element out of the stack. If they don't match, or if
    /// the stack is empty, then the string is invalid. If there are elements left after
    /// the entire parse, it is also considered an invalid string. 
    /// Detailed explanations of the valid cases can be found in the document "PullRequest.md"
    /// </summary>
    public static bool DetermineXML(string xml) {
        string tempXML = xml;
        Stack<string> angleBracketsStack = new Stack<string>();

        /// Loop is broken until there are no more tags, or a false conclusion can be reached.
        while (true) {
            Tuple<string, string> tagResponse = GetNextTagOf(tempXML);
            string tag = tagResponse.Item1;

            /// It ends parsing if there are no more tags to extract (the tag is empty
            /// and the tempXML element is intact). Else, it encountered a false case
            if (String.IsNullOrEmpty(tag)) {
                if (tag.Equals("") && tempXML.Equals(tagResponse.Item2)) {
                    break;
                }
                else {
                    return false;
                }
            }
            /// Simple logic to determine a closing tag: if its first character is a slash.
            if (tag[0] == '/') {
                /// Check for empty stack, otherwise pop throws an error
                if (angleBracketsStack.Count == 0) {
                    return false;
                }
                string lastElement = angleBracketsStack.Pop();

                /// If they're not equal, it's not a valid xml nesting structure
                if (!lastElement.Equals(tag.Substring(1))) {
                    return false;
                }
            }
            /// If it's an opening tag, just push it into the stack
            else {
                angleBracketsStack.Push(tag);
            }
            /// For the next iteration, done until here to assert the unchanged string in line 71
            tempXML = tagResponse.Item2;
        }

        /// Stack not empty at the end, excess of closing tags
        if (angleBracketsStack.Count != 0) {
            return false;
        }

        return true;
    }
}