# UI Toolkit Extensions (com.onchainstudios.uitoolkitextensions)

UI Toolkit Extensions extends the Unity UI Toolkit to add functionalities that currently do not exist in Unity.

GradientView is a UI Toolkit component that allows you to create responsive gradients inside of UI Toolkit.

UIDocumentEventBusBridge forwards events from a UIDocument to the event bus to allow easier use of events from UIToolkit.

VisualScriptingNodes gives a library of new nodes for visual scripting that listen in to the UIDocumentEventBusBridge to allow easy communications between UIDocuments and Visual Scripting.

# Required Software

Unity: Supported versions include 2022.3

# Gradient View

The `GradientView` is a custom visual element that creates a gradient with up to five colors.

![Untitled](README/Untitled.png)

## Example

An example for the `GradientView` can be found at **Examples**→**GradientView**→**Scene**.**GradientViewExample**

![Untitled](README/Untitled%201.png)

There are several key components to the example.

**Scene.GradientViewExample:** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate a `GradientView`.

**UIDocument.GradientViewExample**: A `UIDocument` that demonstrates the `GradientView` custom `VisualElement`.

**Behaviour.GradientViewExample:** A behaviour `ScriptMachine` that demonstrates basic interactions with the `GradientView` within the `UIDocument`.

## Using the `GradientView` Visual Element

1. Create a `UIDocument`.

   ![Untitled](README/Untitled%202.png)

2. Under **Library**, click the **************Project************** tab.

   ![Untitled](README/Untitled%203.png)

   Now a section for ******************************Custom Controls****************************** will exist.

3. Navigate to ****************************OnChainStudios****************************→**************************************UIToolkitExtensions**************************************→************************GradientView************************

   ![Untitled](README/Untitled%204.png)

   The `GradientView` is the custom visual element and behaves like any other `VIsualElement`.

4. Drag the `GradientView` into the ********************UI Builder******************** ******************Hierarchy******************.

   ![Untitled](README/Untitled%205.png)

5. Adjust the `GradientView` within the ******************Hierarchy****************** to the preferred size. In the example below, ******Grow****** is set to **1**, so that it takes the entire space.

   ![Untitled](README/Untitled%206.png)

6. Understand the properties of the `GradientView` to perform simple gradients.

   ![Untitled](README/Untitled%207.png)

   The `GradientView` has twelve properties.

   **********************************************Allow Updates In Editor**********************************************: The `GradientView` has a property called `Allow Updates In Editor`, which determines whether the gradient texture should be rebuilt while in-editor. When the `GradientView` creates a `Texture2D` and sets the color to be a gradient, this process consumes significant processing power, especially when actively making changes. Therefore, it is recommended to only enable this property when you are ready to regenerate the gradient. This information is relevant for developers using the `GradientView` in their code.

   **************Angle:************** The angle of the gradient. For example, 0 degrees means left to right, while 90 degrees means top to bottom.

   ******************Color [Number] & Color [Number] Position:****************** The `GradientView` allows for up to five color options, with the gradient transitioning to the indicated color at the `Color [Number] Position`, which can range from 0 to 1.

   For example, to create a red-green-blue gradient, set the following properties:

   ![Untitled](README/Untitled%208.png)

    ```
    Angle: 0
    Color 1: #FF0000FF (red)
    Color 1 Position: 0
    Color 2: #00FF00FF (green)
    Color 2 Position: 0.5
    Color 3: #0000FFFF (blue)
    Color 3 Position: 1
    ```

   Note that `Color [Number] Position` specifies the position of each color on the gradient, with `1` indicating the end of the gradient. This information is highly relevant to developers utilizing the `GradientView` in their code.


# List View Event Bus Bridge

The `ListViewEventBusBridge` is a tool that listens to events on a specified `ListView` within a `UIDocument` and forwards them to the event bus. This allows for seamless integration between the `ListView` and `VisualScripting`. It serves as a bridge to close the gap between these two elements.

## Example

An example for the `ListViewEventBusBridge` can be found at **Examples**→**ListViewExample**→**Scene**.**ListViewExample**

![Untitled](README/Untitled%209.png)

There are several key components to the example.

******************Scene.ListViewExample:****************** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate the usage of the `ListViewEventBusBridge`.

**UIDocument.ListViewExample**: A `UIDocument` that contains a `ListView` for the `ListViewEventBusBridge` .

**UIDocument.ListViewExample.ListItem**: The `ListViewEventBusBridge` requires a template item for the `ListView` to function properly. This template item serves as a blueprint for each item in the list view.

**Behaviour.ListViewExample:** A behaviour `ScriptMachine` that example demonstrates how a `ScriptMachine` can receive events from a `ListView` via the `ListViewEventBusBridge`.

## Using the `ListViewEventBusBridge` Visual Element

1. Create a `UIDocument` with a `ListView`. In the example, the ******UIDocument.ListViewExample****** has ******Grow****** set to **1**, so that it takes the entire space. Remember to also set the ******************************FixedItemHeight****************************** property to an appropriate value.

   ![Untitled](README/Untitled%2010.png)

2. Create a template item for a `ListView` .

   In the example, **UIDocument.ListViewExample.ListItem** serves as a blueprint for each item in the `ListView` within ******UIDocument.ListViewExample******.

   ![Untitled](README/Untitled%2011.png)

3. In a scene, create an empty game object with a `UIDocument` and `ListViewEventBusBridge` .

   ![Untitled](README/Untitled%2012.png)

4. Attach PanelSettings and the `UIDocument` with the `ListView`.

   ![Untitled](README/Untitled%2013.png)

5. Now that the `UIDocument` is setup. The `ListViewEventBusBridge` requires two properties, the **************************************Visual Element Name************************************** and the **********************************Visual Tree Asset**********************************.

   **************************************Visual Element Name************************************** is the element name of the `ListView` within the `UIDocument` .

   **********************************Visual Tree Asset********************************** is the template item for the `ListView` .

   ![Untitled](README/Untitled%2014.png)

   Great! This is everything you need to begin listening to events from the `ListView` within UVS (Unity Visual Scripting).

6. Create a `ScriptMachine` (or a `StateMachine`) and add it to a game object in the scene.

   ![Untitled](README/Untitled%2015.png)

7. Set the `ListView.itemsSource` on the specified `ListView` .

   In the example, an object variable called `UIDocument` was created and set to the `UIDocument` inside the `ListViewExampleUIDocument` game object. Then, a list of integers ranging from 0 to 100 was created and supplied to the `ListView`.

   ![Untitled](README/Untitled%2016.png)

8. Now that the `ListView` has been provided an item source, we can listen to two of the key events, `ListView.BindItem` and `ListView.UnbindItem`.

   ### OnListViewBindItem

   The `ListViewEventBusBridge` registers the `ListView.BindItem` event and forwards it through the `EventBus`. The `OnListViewBindItem` event node listens for the event on the `EventBus`.

   ![Untitled](README/Untitled%2017.png)

   ![Untitled](README/Untitled%2018.png)

   In order to determine whether the flow should execute for the `OnListViewBindItem` event node, it is necessary to evaluate whether the `ListView` name, class, and type properties match with the `MatchRule`. This event node can occur with all `ListView.BindItem` events that are registered through a `ListViewEventBusBridge`. The `MatchRule` is used to specify the criteria for determining whether the flow should execute.

   ![Untitled](README/Untitled%2019.png)

   In the example, the `OnListViewBindItem` event node will trigger if the ****************************List View Name**************************** matches the “exact” ************name of the `ListView` that triggered the event via the `ListViewEventBusBridge` .

   ![Untitled](README/Untitled%2020.png)

   If the flow is executed, the `OnListViewBindItem` event node will return three properties.

   ****************ListView****************: The `ListView` that triggered the event.

   **********Item**********: The item parameter that is provided by `ListView.BindItem` . This is the item that is being bound by the `ListView`.

   **********Index**********: The index parameter that is provided by `ListView.BindItem` . This is the index of the item that is being bound by the `ListView`.

   ![Untitled](README/Untitled%2021.png)

   ### OnListViewUnbindItem

   The `ListViewEventBusBridge` registers the `ListView.UnbindItem` event and forwards it through the `EventBus`. The `OnListViewUnbindItem` event node listens for the event on the `EventBus`.

   ![Untitled](README/Untitled%2022.png)

   ![Untitled](README/Untitled%2023.png)

   The `OnListViewUnbindItem` event node is triggered by all `ListView.UnbindItem` events registered through a `ListViewEventBusBridge`. This event node has the same input and output parameters as the `OnListViewBindItem` event node and evaluates whether the flow should execute using the same `MatchRule`.

   ![Untitled](README/Untitled%2024.png)

   If the flow is executed, the `OnListViewUnbindItem` event node will return three properties.

   ****************ListView****************: The `ListView` that triggered the event.

   **********Item**********: The item parameter that is provided by `ListView.UnbindItem` . This is the item that is being unbound by the `ListView`.

   **********Index**********: The index parameter that is provided by `ListView.UnbindItem` . This is the index of the item that is being unbound by the `ListView`.

   ![Untitled](README/Untitled%2025.png)


# UI Document Event Bus Bridge

The `UIDocumentEventBusBridge` is a tool that listens to events on a `UIDocument` and forwards them to the event bus. This allows for seamless integration between the `UIDocument` and `VisualScripting`. It serves as a bridge to close the gap between these two elements.

`UIDocumentEventBusBridge` is only limited to `ClickEvent` and `ChangeEvent` for `VisualElement`.

## Example

An example for the `UIDocumentEventBusBridge` can be found at **Examples**→**VisualScriptingExample**→**Scene**.**VisualScriptingExample**

![Untitled](README/Untitled%2026.png)

There are several key components to the example.

******************Scene.VisualScriptingExample:****************** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate the usage of the `UIDocumentEventBusBridge`.

**UIDocument.VisualScriptingExample**: A `UIDocument` that that will be used by the `UIDocumentEventBusBridge` .

**Behaviour.VisualScriptingExample:** A behaviour `ScriptMachine` that example demonstrates how a `ScriptMachine` can receive events from a `UIDocument` via the `UIDocumentEventBusBridge`.

## Using the `UIDocumentEventBusBridge` Visual Element

1. Create a `UIDocument` with a `ListView`.

   In the given example, the `UIDocument.VisualScriptingExample` contains various UI elements such as sliders, buttons, text fields, and toggles, which demonstrate the versatility of events that can be triggered by a variety of controls.

   ![Untitled](README/Untitled%2027.png)

2. In a scene, create an empty game object with a `UIDocument` and `UIDocumentEventBusBridge` .

   ![Untitled](README/Untitled%2028.png)

3. Attach PanelSettings and the `UIDocument` .

   ![Untitled](README/Untitled%2029.png)

   Great! This is everything you need to begin listening to events from the `UIDocument` within UVS (Unity Visual Scripting).

4. Create a `ScriptMachine` (or a `StateMachine`) and add it to a game object in the scene.

   ![Untitled](README/Untitled%2030.png)

5. Now that we have a `ScriptMachine` , we can listen to two crucial events for a `VisualElement`, `ClickEvent` and `ChangeEvent` within UVS (Unity Visual Scripting).

   ### OnVisualElementChangeEvent<T>

   The `UIDocumentEventBusBridge` registers the `ChangeEvent` on a `VisualElement` and forwards it through the `EventBus`. The `OnVisualElementChangeEvent` event node listens for the event on the `EventBus`.

   There are four variations of the `OnVisualElementChangeEvent` event node to support a variety of different visual elements: `bool`, `int`, `float`, and `string`.

   ![Untitled](README/Untitled%2031.png)

   ![Untitled](README/Untitled%2032.png)

   For ease of understanding, only the `OnVisualElementChangeEventFloat` will be demonstrated in the examples. However, the usage is the same across all variations of the `OnVisualElementChangeEvent` event node.

   ![Untitled](README/Untitled%2033.png)

   In order to determine whether the flow should execute for the `OnVisualElementChangeEventFloat` event node, it is necessary to evaluate whether the `VisualElement` name, class, and type properties match with the `MatchRule`. This event node can occur with all `ChangeEvent` events that are registered through a `UIDocumentEventBusBridge`. The `MatchRule` is used to specify the criteria for determining whether the flow should execute.

   ![Untitled](README/Untitled%2034.png)

   In the example, the `OnVisualElementChangeEventFloat` event node will trigger if the ****************************Slider 1 Name**************************** matches the “exact” name of the `VisualElement` that triggered the event via the `UIDocumentEventBusBridge` .

   ![Untitled](README/Untitled%2035.png)

   If the flow is executed, the `UIDocumentEventBusBridge` event node will return three properties.

   ****************Visual Element****************: The `VisualElement` that triggered the event.

   **********Previous Value**********: The previous value of the `VisualElement` .

   **********New Value**********: The new value of the `VisualElement` .

   ![Untitled](README/Untitled%2036.png)

   ### OnVisualElementClickEvent

   The `UIDocumentEventBusBridge` registers the `ClickEvent` on a `VisualElement` and forwards it through the `EventBus`. The `OnVisualElementClickEvent` event node listens for the event on the `EventBus`.

   ![Untitled](README/Untitled%2037.png)

   ![Untitled](README/Untitled%2038.png)

   The `OnVisualElementClickEvent` event node functions similarly to the `OnVisualElementChangeEvent` node in terms of evaluating whether the flow should execute. It uses the `MatchRule` criteria and input to determine this.

   ![Untitled](README/Untitled%2039.png)

   In the example, the `OnVisualElementClickEvent` event node will trigger if the `VisualElement` that triggered the event via the `UIDocumentEventBusBridge` has the class provided by ************************Button Class************************.

   ![Untitled](README/Untitled%2040.png)

   If the flow is executed, the `UIDocumentEventBusBridge` event node will return the `VisualElement` that triggered the event

   ![Untitled](README/Untitled%2041.png)