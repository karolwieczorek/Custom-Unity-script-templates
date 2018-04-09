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
### 81-MonoBehaviour-NewBehaviourScript.cs.txt
The standard MonoBehaviour subclass with a few added **magical** Unity *event functions*:
-  **Awake():** Called when #SCRIPTNAME# is loaded, even if the behaviour is disabled but not if the GameObject it is attached to is inactive.
-  **Start():** Called right before the first Update() after #SCRIPTNAME# is enabled.
-  **OnEnable():** Called when #SCRIPTNAME# is enabled, before *Start()*.
-  **OnDisable():** Called when #SCRIPTNAME# is disabled, either specifically or right before the GameObject is destroyed.
-  **OnDrawGizmosSelected():** Draw gizmos when GameObject that #SCRIPTNAME# is attached to is selected.
-  **OnDrawGizmos():** Draw gizmos of the GameObject that #SCRIPTNAME# is attached to.
-  **OnValidate():** Called when the script is loaded or a value is changed in the inspector (Called in the editor only).


### 82-SerializableObject-NewBehaviourScript.cs.txt
A subclass of *ScriptableObject*. Useful for scripts that do not need to attach to specific *GameObjects*.
    Contains the following **magical** Unity *event functions*:
- **OnEnable():** Called when #SCRIPTNAME# is enabled.
- **OnDisable():** Called when #SCRIPTNAME# is disabled.
- **OnDestroy():** Called when #SCRIPTNAME# is destroyed.
 

### 83-Plain C# Class-NewBehaviourScript.cs.txt
An empty class in global namespace. Useful for objects that do not directly interact with the Unity libraries.

### 84-Empty C# file-NewBehaviourScript.cs.txt
A completely empty .cs file. Useful for quickly creating a very custom code file.

### 85-CustomEditor-NewBehaviourScript.cs.txt
A subclass of the UnityEditor.Editor class that is used for making custom inspectors for classes.

## Templates name format
[source](https://answers.unity.com/questions/635684/add-additional-script-templates.html)
The format is:

**{SortingIndex}**-**{MenuItemName}**-**{FileName}**.txt

**{SortingIndex}** is some number used to order the items in the "Create New" context menu, duplicates are allowed.

**{MenuItemName}** is a string that defines the name of the item. It can be a nested item, use double underscores "__" to indicate going into a folder, sorta like with the [CreateAssetMenu] attribute, except in that one they use forward slash "/" instead. A bit confusing.

**{FileName}** is the default suggested filename that Unity has highlighted, when the user clicks the menu item to create the file. There seems to be some additional magic string searches going on for the filename. If the string "Test" appears in the filename (case insensitive), Unity will automatically create and move the new file to an Editor folder, in the current directory.
