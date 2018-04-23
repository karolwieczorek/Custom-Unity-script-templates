# Custom Unity script templates
Some more extensive script templates for C# development.

## Usage
1. Place the script templates (the .cs.txt files) into the script template folder:

  **PC:** "C:\Program Files\Unity\Editor\Data\Resources\ScriptTemplates" (or similar)
  
  **MAC:** /Applications/Unity/Unity.app/Contents/Resources/ScriptTemplates/ (or similar)

  **Linux:** /opt/Unity/Editor/Data/Resources/ScriptTemplates
  
  *Note: do not change the ".cs.txt" extension.* 
  
2. Restart Unity if it was open when you added the files to the script template folder.
3. Right-click in the *Project* window and choose *"Create >"*.
4. Pick a script template of your choice.
  
## Templates

### 1-My__Plain C# Class-NewCSScript.cs.txt
An empty class in Game namespace. Useful for objects that do not directly interact with the Unity libraries.

### 2-My__MonoBehaviour-NewBehaviourScript.cs.txt
The standard MonoBehaviour subclass with a few added **magical** Unity *event functions*:
-  **Start():** Called right before the first Update() after #SCRIPTNAME# is enabled.
-  **Update():** Called every frame.

### 3-My__CustomEditor-NewCustomEditorScript.cs.txt
A subclass of the UnityEditor. Editor class that is used for making custom inspectors for classes.

### 4-My__ScriptableObject-NewScriptableObjectScript.cs.txt
A subclass of *ScriptableObject*. Useful for scripts that do not need to attach to specific *GameObjects*.

### 5-My__Plain C# Interface-INewCSInterfaceScript.cs.txt
An empty interface in Game namespace. Useful for quickly creating a very simple interface file.


## Templates file name format
[source](https://answers.unity.com/questions/635684/add-additional-script-templates.html)

The format is:

**{SortingIndex}**-**{MenuItemName}**-**{FileName}**.txt

**{SortingIndex}** is some number used to order the items in the "Create New" context menu, duplicates are allowed.

**{MenuItemName}** is a string that defines the name of the item. It can be a nested item, use double underscores "__" to indicate going into a folder, sorta like with the [CreateAssetMenu] attribute, except in that one they use forward slash "/" instead. A bit confusing.

**{FileName}** is the default suggested filename that Unity has highlighted, when the user clicks the menu item to create the file. There seems to be some additional magic string searches going on for the filename. If the string "Test" appears in the filename (case insensitive), Unity will automatically create and move the new file to an Editor folder, in the current directory.


## Special tags:

### "#SCRIPTNAME#" - Unity asset preprocessor just replaces them with the script filename (without extention) so that’s a nice touch there too. 

### "#NOTRIM#" - To explain why they are there, in Unity 5.5, tabs were added to some empty lines in the templates for better indentation. The #NOTRIM# text is a special marker used by the template file system to mark lines that end in whitespace, like tabs. They prevent that whitespace from being stripped by our source code tools. The Unity Editor then strips all the markers when the template is used.