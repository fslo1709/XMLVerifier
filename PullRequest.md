# Pull Request

### **Please check if the PR fulfills these requirements**
- [ x ] The commit message follows our guidelines
- [ x ] Tests for the changes have been added (for bug fixes/features)
- [ x ] Docs have been added / updated (for bug fixes / features)

### **What kind of change does this PR introduce?** 

This Pull Request introduces a new static function for the class MyXMLParser. 

The function is called DetermineXML; receives a string as an input, outputs a boolean value: if a string is a correct XML or not.

### **What is the current behavior?** 

No function currently exists for this feature.

### **What is the new behavior (if this is a feature change)?**

The static function can be called from other files in order to determine the XML validity of a string after importing the MyXMLParser class.

### **Does this PR introduce a breaking change?** 

None.


### **Other information**:

Test cases for this function can be added in the file "testcases.txt"

Format of adding: one line with the xml string, next line with a ```true``` or ```false``` value

Examples of valid and invalid XML values:

#### Given test cases

- Example 1:

    Input: ```<Design><Code>hello world</Code></Design>```

    Output: true

- Example 2:

    Input: ```<Design><Code>hello world</Code></Design><People>```

    Output: false

- Example 3:

    Input: ```<People><Design><Code>hello world</People></Code></Design>```

    Output: false

- Example 4:

    Input: ```<People age="1">hello world</People>```

    Output: false

#### My test cases

- Example 5: No closing tags

    Input: ```<People><Design>hello world```

    Output: false

- Example 6: The code considers all text between the angled brackets as the string of the tag, so the first tag would be read as "```<Design```"

    Input: ```<<Design><Code>hello world</Code></Design>```

    Output: false

- Example 7: Empty tags are invalid

    Input: ```<></Code>```

    Output: false

- Example 8: To verify an unopened angle bracket doesn't break the code. Logically, this means that it belongs to the string.

    Input: ```<Design>>hello world</Design>```

    Output: true