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

Testing can be done by running the command ```dotnet test```

Examples of valid and invalid XML values:

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