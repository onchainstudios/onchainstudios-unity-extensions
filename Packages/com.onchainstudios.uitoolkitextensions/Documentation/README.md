# UI Toolkit Extensions (com.onchainstudios.uitoolkitextensions)

# Table of Contents
- [UI Toolkit Extensions (com.onchainstudios.uitoolkitextensions)](#ui-toolkit-extensions-comonchainstudiosuitoolkitextensions)
- [Table of Contents](#table-of-contents)
- [Overview](#overview)
- [Required Software](#required-software)
- [Installation](#installation)
- [Gradient View](#gradient-view)
  - [Example](#example)
  - [Using the `GradientView` Visual Element](#using-the-gradientview-visual-element)
- [List View Event Bus Bridge](#list-view-event-bus-bridge)
  - [Example](#example-1)
  - [Using the `ListViewEventBusBridge`](#using-the-listvieweventbusbridge)
    - [OnListViewBindItem](#onlistviewbinditem)
    - [OnListViewUnbindItem](#onlistviewunbinditem)
- [UI Document Event Bus Bridge](#ui-document-event-bus-bridge)
  - [Example](#example-2)
  - [Using the `UIDocumentEventBusBridge` Visual Element](#using-the-uidocumenteventbusbridge-visual-element)
    - [OnVisualElementChangeEvent](#onvisualelementchangeevent)
    - [OnVisualElementClickEvent](#onvisualelementclickevent)
- [Query Visual Element](#query-visual-element)
  - [Example](#example-3)
  - [Using the `QueryVisualElement`](#using-the-queryvisualelement)
- [Helper Methods](#helper-methods)
  - [Get Visual Element Background Color](#get-visual-element-background-color)
    - [Usage](#usage)
  - [Lerp Visual Element Background Color Alpha](#lerp-visual-element-background-color-alpha)
    - [Usage](#usage-1)
  - [Set Visual Element Background Color](#set-visual-element-background-color)
    - [Usage](#usage-2)
  - [Set Visual Element Background Color Alpha](#set-visual-element-background-color-alpha)
    - [Usage](#usage-3)
  - [Set Label By Name](#set-label-by-name)
    - [Usage](#usage-4)
  - [Set Label By Name And Args](#set-label-by-name-and-args)
    - [Usage](#usage-5)
  - [Set Nested Label By Name](#set-nested-label-by-name)
    - [Usage](#usage-6)
  - [Set Nested Label By Name And Args](#set-nested-label-by-name-and-args)
    - [Usage](#usage-7)
- [Radial Progress](#radial-progress)
   - [Example](#example-4)
   - [Using the `RadialProgress` VisualElemnt](#using-the-radialprogress-visual-element)

# Overview

UIToolkitExtensions is a Unity package that extends the functionality of the Unity UI Toolkit. It includes GradientView, UIDocumentEventBusBridge, and VisualScriptingNodes. These components add features that do not currently exist in Unity and make communication between UIDocuments and Visual Scripting more seamless.

# Required Software

Unity: Supported versions include 2022.3

# Installation

1. Add the package to your unity project using the Unity Package Manager

    ```html
    https://github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.uitoolkitextensions
    ```

2. To pull the versioned package based on a tag, append the tag to the end of the URL like this

    ```html
    https://github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.uitoolkitextensions#v0.7.0-preview.13
    ```

# Gradient View

The `GradientView` is a custom visual element that creates a gradient with up to five colors.

![GradientView](Images/GradientView.png)

## Example

An example for the `GradientView` can be found at **Examples**→**GradientView**→**Scene**.**GradientViewExample**

![GradientViewExample.png](Images/GradientViewExample.png)

There are several key components to the example.

**Scene.GradientViewExample:** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate a `GradientView`.

**UIDocument.GradientViewExample**: A `UIDocument` that demonstrates the `GradientView` custom `VisualElement`.

**Behaviour.GradientViewExample:** A behaviour `ScriptMachine` that demonstrates basic interactions with the `GradientView` within the `UIDocument`.

## Using the `GradientView` Visual Element

1. Create a `UIDocument`.

   ![UsingTheGradientViewVisualElement00](Images/UsingTheGradientViewVisualElement00.png)

2. Under **Library**, click the **Project** tab.

   ![UsingTheGradientViewVisualElement01](Images/UsingTheGradientViewVisualElement01.png)

   Now a section for **Custom Controls** will exist.

3. Navigate to **OnChainStudios****→****UIToolkitExtensions**→**GradientView**

   ![UsingTheGradientViewVisualElement02](Images/UsingTheGradientViewVisualElement02.png)

   The `GradientView` is the custom visual element and behaves like any other `VIsualElement`.

4. Drag the `GradientView` into the ********************UI Builder******************** ******************Hierarchy******************.

   ![UsingTheGradientViewVisualElement03](Images/UsingTheGradientViewVisualElement03.png)

5. Adjust the `GradientView` within the ******************Hierarchy****************** to the preferred size. In the example below, ******Grow****** is set to **1**, so that it takes the entire space.

   ![UsingTheGradientViewVisualElement04](Images/UsingTheGradientViewVisualElement04.png)

6. Understand the properties of the `GradientView` to perform simple gradients.

   ![UsingTheGradientViewVisualElement05a](Images/UsingTheGradientViewVisualElement05a.png)

   The `GradientView` has twelve properties.

   **Allow Updates In Editor**: The `GradientView` has a property called `Allow Updates In Editor`, which determines whether the gradient texture should be rebuilt while in-editor. When the `GradientView` creates a `Texture2D` and sets the color to be a gradient, this process consumes significant processing power, especially when actively making changes. Therefore, it is recommended to only enable this property when you are ready to regenerate the gradient. This information is relevant for developers using the `GradientView` in their code.

   **Angle:** The angle of the gradient. For example, 0 degrees means left to right, while 90 degrees means top to bottom.

   **Color [Number] & Color [Number] Position:** The `GradientView` allows for up to five color options, with the gradient transitioning to the indicated color at the `Color [Number] Position`, which can range from 0 to 1.

   For example, to create a red-green-blue gradient, set the following properties:

   ![UsingTheGradientViewVisualElement05b](Images/UsingTheGradientViewVisualElement05b.png)

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

The `ListViewEventBusBridge` is a component that listens to events on a specified `ListView` within a `UIDocument` and forwards them to the event bus. This allows for seamless integration between the `ListView` and `VisualScripting`. It serves as a bridge to provide communication between these two tools.

## Example

An example for the `ListViewEventBusBridge` can be found at **Examples**→**ListViewExample**→**Scene**.**ListViewExample**

![ListViewEventBusBridgeExample](Images/ListViewEventBusBridgeExample.png)

There are several key parts to the example.

******************Scene.ListViewExample:****************** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate the usage of the `ListViewEventBusBridge`.

**UIDocument.ListViewExample**: A `UIDocument` that contains a `ListView` for the `ListViewEventBusBridge` .

**UIDocument.ListViewExample.ListItem**: The `ListViewEventBusBridge` requires a template item for the `ListView` to function properly. This template item serves as a blueprint for each item in the list view.

**Behaviour.ListViewExample:** A behaviour `ScriptMachine` that example demonstrates how a `ScriptMachine` can receive events from a `ListView` via the `ListViewEventBusBridge`.

## Using the `ListViewEventBusBridge`

1. Create a `UIDocument` with a `ListView`. In the example, the ******UIDocument.ListViewExample****** has ******Grow****** set to **1**, so that it takes the entire space. Remember to also set the ******************************FixedItemHeight****************************** property to an appropriate value.

   ![UsingTheListViewEventBusBridge00](Images/UsingTheListViewEventBusBridge00.png)

2. Create a template item for a `ListView` .

   In the example, **UIDocument.ListViewExample.ListItem** serves as a blueprint for each item in the `ListView` within ******UIDocument.ListViewExample******.

   ![UsingTheListViewEventBusBridge01](Images/UsingTheListViewEventBusBridge01.png)

3. In a scene, create an empty game object with a `UIDocument` and `ListViewEventBusBridge` .

   ![UsingTheListViewEventBusBridge02](Images/UsingTheListViewEventBusBridge02.png)

4. Attach PanelSettings and the `UIDocument` with the `ListView`.

   ![UsingTheListViewEventBusBridge03](Images/UsingTheListViewEventBusBridge03.png)

5. Now that the `UIDocument` is setup. The `ListViewEventBusBridge` requires two properties, the **************************************Visual Element Name************************************** and the **********************************Visual Tree Asset**********************************.

   **************************************Visual Element Name************************************** is the element name of the `ListView` within the `UIDocument` .

   **********************************Visual Tree Asset********************************** is the template item for the `ListView` .

   ![UsingTheListViewEventBusBridge04](Images/UsingTheListViewEventBusBridge04.png)

   Great! This is everything you need to begin listening to events from the `ListView` within UVS (Unity Visual Scripting).

6. Create a `ScriptMachine` (or a `StateMachine`) and add it to a game object in the scene.

   ![UsingTheListViewEventBusBridge05](Images/UsingTheListViewEventBusBridge05.png)

7. Set the `ListView.itemsSource` on the specified `ListView` .

   In the example, an object variable called `UIDocument` was created and set to the `UIDocument` inside the `ListViewExampleUIDocument` game object. Then, a list of integers ranging from 0 to 100 was created and supplied to the `ListView`.

   ![UsingTheListViewEventBusBridge06](Images/UsingTheListViewEventBusBridge06.png)

8. Now that the `ListView` has been provided an item source, we can listen to two of the key events, `ListView.BindItem` and `ListView.UnbindItem`.

   ### OnListViewBindItem

   The `ListViewEventBusBridge` registers the `ListView.BindItem` event and forwards it through the `EventBus`. The `OnListViewBindItem` event node listens for the event on the `EventBus`.

   ![UsingTheListViewEventBusBridge08a](Images/UsingTheListViewEventBusBridge08a.png)

   ![UsingTheListViewEventBusBridge08b](Images/UsingTheListViewEventBusBridge08b.png)

   In order to determine whether the flow should execute for the `OnListViewBindItem` event node, it is necessary to evaluate whether the `ListView` name, class, and type properties match with the `MatchRule`. This event node can occur with all `ListView.BindItem` events that are registered through a `ListViewEventBusBridge`. The `MatchRule` is used to specify the criteria for determining whether the flow should execute.

   ![UsingTheListViewEventBusBridge08c](Images/UsingTheListViewEventBusBridge08c.png)

   In the example, the `OnListViewBindItem` event node will trigger if the ****************************List View Name**************************** matches the “exact” name of the `ListView` that triggered the event via the `ListViewEventBusBridge` .

   ![UsingTheListViewEventBusBridge08d](Images/UsingTheListViewEventBusBridge08d.png)

   If the flow is executed, the `OnListViewBindItem` event node will return three properties.

   ****************ListView****************: The `ListView` that triggered the event.

   **********Item**********: The item parameter that is provided by `ListView.BindItem` . This is the item that is being bound by the `ListView`.

   **********Index**********: The index parameter that is provided by `ListView.BindItem` . This is the index of the item that is being bound by the `ListView`.

   ![UsingTheListViewEventBusBridge08e](Images/UsingTheListViewEventBusBridge08e.png)

   ### OnListViewUnbindItem

   The `ListViewEventBusBridge` registers the `ListView.UnbindItem` event and forwards it through the `EventBus`. The `OnListViewUnbindItem` event node listens for the event on the `EventBus`.

   ![UsingTheListViewEventBusBridge08f](Images/UsingTheListViewEventBusBridge08f.png)

   ![UsingTheListViewEventBusBridge08g](Images/UsingTheListViewEventBusBridge08g.png)

   The `OnListViewUnbindItem` event node is triggered by all `ListView.UnbindItem` events registered through a `ListViewEventBusBridge`. This event node has the same input and output parameters as the `OnListViewBindItem` event node and evaluates whether the flow should execute using the same `MatchRule`.

   ![UsingTheListViewEventBusBridge08h](Images/UsingTheListViewEventBusBridge08h.png)

   If the flow is executed, the `OnListViewUnbindItem` event node will return three properties.

   ****************ListView****************: The `ListView` that triggered the event.

   **********Item**********: The item parameter that is provided by `ListView.UnbindItem` . This is the item that is being unbound by the `ListView`.

   **********Index**********: The index parameter that is provided by `ListView.UnbindItem` . This is the index of the item that is being unbound by the `ListView`.

   ![UsingTheListViewEventBusBridge08i](Images/UsingTheListViewEventBusBridge08i.png)


# UI Document Event Bus Bridge

The `UIDocumentEventBusBridge` is a tool that listens to events on a `UIDocument` and forwards them to the event bus. This allows for seamless integration between the `UIDocument` and `VisualScripting`. It serves as a bridge to close the gap between these two elements.

`UIDocumentEventBusBridge` is only limited to `ClickEvent` and `ChangeEvent` for `VisualElement`.

## Example

An example for the `UIDocumentEventBusBridge` can be found at **Examples**→**VisualScriptingExample**→**Scene**.**VisualScriptingExample**

![UIDocumentEventBusBridgeLocationExample](Images/UIDocumentEventBusBridgeExample.png)

There are several key components to the example.

******************Scene.VisualScriptingExample:****************** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate the usage of the `UIDocumentEventBusBridge`.

**UIDocument.VisualScriptingExample**: A `UIDocument` that that will be used by the `UIDocumentEventBusBridge` .

**Behaviour.VisualScriptingExample:** A behaviour `ScriptMachine` that example demonstrates how a `ScriptMachine` can receive events from a `UIDocument` via the `UIDocumentEventBusBridge`.

## Using the `UIDocumentEventBusBridge` Visual Element

1. Create a `UIDocument` with a `ListView`.

   In the given example, the `UIDocument.VisualScriptingExample` contains various UI elements such as sliders, buttons, text fields, and toggles, which demonstrate the versatility of events that can be triggered by a variety of controls.

   ![UsingTheUIDocumentEventBusBridgeVisualElement00](Images/UsingTheUIDocumentEventBusBridgeVisualElement00.png)

2. In a scene, create an empty game object with a `UIDocument` and `UIDocumentEventBusBridge` .

   ![UsingTheUIDocumentEventBusBridgeVisualElement01](Images/UsingTheUIDocumentEventBusBridgeVisualElement01.png)

3. Attach PanelSettings and the `UIDocument` .

   ![UsingTheUIDocumentEventBusBridgeVisualElement02](Images/UsingTheUIDocumentEventBusBridgeVisualElement02.png)

   Great! This is everything you need to begin listening to events from the `UIDocument` within UVS (Unity Visual Scripting).

4. Create a `ScriptMachine` (or a `StateMachine`) and add it to a game object in the scene.

   ![UsingTheUIDocumentEventBusBridgeVisualElement03](Images/UsingTheUIDocumentEventBusBridgeVisualElement03.png)

5. Now that we have a `ScriptMachine` , we can listen to two crucial events for a `VisualElement`, `ClickEvent` and `ChangeEvent` within UVS (Unity Visual Scripting).

   ### OnVisualElementChangeEvent<T>

   The `UIDocumentEventBusBridge` registers the `ChangeEvent` on a `VisualElement` and forwards it through the `EventBus`. The `OnVisualElementChangeEvent` event node listens for the event on the `EventBus`.

   There are four variations of the `OnVisualElementChangeEvent` event node to support a variety of different visual elements: `bool`, `int`, `float`, and `string`.

   ![UsingTheUIDocumentEventBusBridgeVisualElement04a](Images/UsingTheUIDocumentEventBusBridgeVisualElement04a.png)

   ![UsingTheUIDocumentEventBusBridgeVisualElement04b](Images/UsingTheUIDocumentEventBusBridgeVisualElement04b.png)

   For ease of understanding, only the `OnVisualElementChangeEventFloat` will be demonstrated in the examples. However, the usage is the same across all variations of the `OnVisualElementChangeEvent` event node.

   ![UsingTheUIDocumentEventBusBridgeVisualElement04c](Images/UsingTheUIDocumentEventBusBridgeVisualElement04c.png)

   In order to determine whether the flow should execute for the `OnVisualElementChangeEventFloat` event node, it is necessary to evaluate whether the `VisualElement` name, class, and type properties match with the `MatchRule`. This event node can occur with all `ChangeEvent` events that are registered through a `UIDocumentEventBusBridge`. The `MatchRule` is used to specify the criteria for determining whether the flow should execute.

   ![UsingTheUIDocumentEventBusBridgeVisualElement04d](Images/UsingTheUIDocumentEventBusBridgeVisualElement04d.png)

   In the example, the `OnVisualElementChangeEventFloat` event node will trigger if the ****************************Slider 1 Name**************************** matches the “exact” name of the `VisualElement` that triggered the event via the `UIDocumentEventBusBridge` .

   ![UsingTheUIDocumentEventBusBridgeVisualElement04e](Images/UsingTheUIDocumentEventBusBridgeVisualElement04e.png)

   If the flow is executed, the `UIDocumentEventBusBridge` event node will return three properties.

   ****************Visual Element****************: The `VisualElement` that triggered the event.

   **********Previous Value**********: The previous value of the `VisualElement` .

   **********New Value**********: The new value of the `VisualElement` .

   ![OnVisualElementChangeNodeOutputExample](Images/UsingTheUIDocumentEventBusBridgeVisualElement04f.png)

   ### OnVisualElementClickEvent

   The `UIDocumentEventBusBridge` registers the `ClickEvent` on a `VisualElement` and forwards it through the `EventBus`. The `OnVisualElementClickEvent` event node listens for the event on the `EventBus`.

   ![UsingTheUIDocumentEventBusBridgeVisualElement04g](Images/UsingTheUIDocumentEventBusBridgeVisualElement04g.png)

   ![UsingTheUIDocumentEventBusBridgeVisualElement04h](Images/UsingTheUIDocumentEventBusBridgeVisualElement04h.png)

   The `OnVisualElementClickEvent` event node functions similarly to the `OnVisualElementChangeEvent` node in terms of evaluating whether the flow should execute. It uses the `MatchRule` criteria and input to determine this.

   ![UsingTheUIDocumentEventBusBridgeVisualElement04i](Images/UsingTheUIDocumentEventBusBridgeVisualElement04i.png)

   In the example, the `OnVisualElementClickEvent` event node will trigger if the `VisualElement` that triggered the event via the `UIDocumentEventBusBridge` has the class provided by ************************Button Class************************.

   ![UsingTheUIDocumentEventBusBridgeVisualElement04j](Images/UsingTheUIDocumentEventBusBridgeVisualElement04j.png)

   If the flow is executed, the `UIDocumentEventBusBridge` event node will return the `VisualElement` that triggered the event

   ![UsingTheUIDocumentEventBusBridgeVisualElement04k](Images/UsingTheUIDocumentEventBusBridgeVisualElement04k.png)

# Query Visual Element 

The `QueryVisualElement` is a custom node that functions similar to [`UQueryExtensions.Query`](https://docs.unity3d.com/2020.1/Documentation/ScriptReference/UIElements.UQueryExtensions.Query.html), but returns a list of Visual Elements within Unity Visual Scripting.

## Example

An example for the `QueryVisualElement` can be found at **Examples**→**QueryExample**→**Scene**.**QueryExample**

![QueryVisualElementExample](Images/QueryVisualElementExample.png)

There are several key components to the example.

**Scene.QueryExample:** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate a `GradientView`.

**UIDocument.QueryExample:** A `UIDocument` that demonstrates the `QueryVisualElement` custom `VisualElement`.

**Behaviour.QueryExample:** A behaviour `ScriptMachine` that demonstrates basic interactions with the `QueryVisualElement` within the `UIDocument`.

## Using the `QueryVisualElement`

1. Create a `UIDocument` with a set visual elements that will be returned for the query. In the image below, we are have a parent container with three children elements. 
   Each of the children elements will have a class called **example-child** and a unique name. 

   ![UsingTheQueryVisualElement00a](Images/UsingTheQueryVisualElement00a.png)
   ![UsingTheQueryVisualElement00b](Images/UsingTheQueryVisualElement00b.png)

2. In a scene, create an empty game object with a `UIDocument`.
   
   ![UsingTheQueryVisualElement01](Images/UsingTheQueryVisualElement01.png)

3. Attach PanelSettings and the `UIDocument`.

   ![UsingTheQueryVisualElement02a](Images/UsingTheQueryVisualElement02a.png)
   ![UsingTheQueryVisualElement02b](Images/UsingTheQueryVisualElement02b.png)

4. Create a `ScriptMachine` (or a `StateMachine`) and add it to a game object in the scene.

   ![UsingTheQueryVisualElement03](Images/UsingTheQueryVisualElement03.png)

5. In the `ScriptMachine`, add a `QueryVisualElement` with the `VisualElement` to query and the `className` or `name` for the query parameters.
   The node will query for all children within the `VisualElement` provided and return a list of visual elements that match the `className` or `name`. 
   In the `UIDocument`, there was a parent container with three children visual elements. Those children had a unique name with a class `example-child`. 

   ![UsingTheQueryVisualElement04a](Images/UsingTheQueryVisualElement04a.png)

   The output for this node should be as shown.

   ![UsingTheQueryVisualElement04b](Images/UsingTheQueryVisualElement04b.png)

# Helper Methods

## Get Visual Element Background Color

`Method.GetVisualElementBackgroundColor` can used to get the background color of a visual element.

   ![GetVisualElementBackgroundColorLocation.png](Images/GetVisualElementBackgroundColorLocation.png)

### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Visual Element: The visual element you want to get the background color from.

**Data Outputs**

* Color: The background color of the visual element.

![GetVisualElementBackgroundColorExample.png](Images/GetVisualElementBackgroundColorExample.png)

## Lerp Visual Element Background Color Alpha

`Method.LerpVisualElementBackgroundColorAlpha` can be used to set the alpha of a visual element background over time using an `AnimationCurve`.

![LerpVisualElementBackgroundColorAlphaLocation.png](Images/LerpVisualElementBackgroundColorAlphaLocation.png)

### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Visual Element: The visual element you want to lerp the alpha on.
* Step Duration: The duration between steps while lerping the alpha. Use smaller values for smoother fades Use larger values for chunkier fades.
* Lerp Animation: The animation curve to use to lerp the value. x = time, y = alpha value.

**Trigger Outputs**

* Started: Trigger flow for when the lerp animation starts.
* Complete: Trigger flow for when the lerp animation completes.

![LerpVisualElementBackgroundColorAlphaExample.png](Images/LerpVisualElementBackgroundColorAlphaExample.png)

## Set Visual Element Background Color

`Method.SetVisualElementBackgroundColor` can used to set the background color of a visual element.

![SetVisualElementBackgroundColorLocation.png](Images/SetVisualElementBackgroundColorLocation.png)

### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Visual Element: The visual element you want to set the background color on.
* Color: The background color you want to set.

![SetVisualElementBackgroundColorExample.png](Images/SetVisualElementBackgroundColorExample.png)

## Set Visual Element Background Color Alpha

`Method.SetVisualElementBackgroundColorAlpha` can be used to set the background alpha of a visual element.

![SetVisualElementBackgroundColorAlphaLocation.png](Images/SetVisualElementBackgroundColorAlphaLocation.png)

### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Visual Element: The visual element you want to set the background color on.
* Alpha: The alpha value you want to set.

![SetVisualElementBackgroundColorAlphaExample.png](Images/SetVisualElementBackgroundColorAlphaExample.png)

## Set Label By Name

`Method.SetLabelByName` can be used to set the text of a `Label` `UIElement`.

![SetLabelByNameLocation.png](Images/SetLabelByNameLocation.png)

### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Root Visual Element: The `VisualElement` that contains the `Label`. 
* Label Name: The name of the `Label`.
* Text: The text value to set for the `Label`.
  
![SetLabelByNameExample.png](Images/SetLabelByNameExample.png)

## Set Label By Name And Args

`Method.SetLabelByNameAndArgs` can be used to set the text of a `Label` `UIElement` with arguments.

![SetLabelByNameAndArgsLocation.png](Images/SetLabelByNameAndArgsLocation.png)
### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Root Visual Element: The `VisualElement` that contains the `Label`. 
* Label Name: The name of the `Label`.
* Format: The format of the text value to set for the `Label`.
* Args: The list of arguments to be used by the **Format**.
  
![SetLabelByNameAndArgsExample.png](Images/SetLabelByNameAndArgsExample.png)

## Set Nested Label By Name

`Method.SetNestedLabelByName` can be used to set the text of a `Label` `UIElement`.

![SetNestedLabelByNameLocation.png](Images/SetNestedLabelByNameLocation.png)

### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Root Visual Element: The `VisualElement` that contains the `Label`. 
* Container Name: The name of the `VisualElement` within the **RootVisualElement** that contains the `Label`.
* Label Name: The name of the `Label`.
* Text: The text value to set for the `Label`.
  
![SetNestedLabelByNameExample.png](Images/SetNestedLabelByNameExample.png)

## Set Nested Label By Name And Args

`Method.SetNestedLabelByNameAndArgs` can be used to set the text of a `Label` `UIElement` with arguments.

![SetNestedLabelByNameAndArgsLocation.png](Images/SetNestedLabelByNameAndArgsLocation.png)
### Usage

An example can be found in the `Behaviour.VisualScriptingExample`.

**Data Inputs**

* Root Visual Element: The `VisualElement` that contains the `Label`. 
* Container Name: The name of the `VisualElement` within the **RootVisualElement** that contains the `Label`.
* Label Name: The name of the `Label`.
* Format: The format of the text value to set for the `Label`.
* Args: The list of arguments to be used by the **Format**.
  
![SetNestedLabelByNameAndArgsExample.png](Images/SetNestedLabelByNameAndArgsExample.png)

# Radial Progress

The `RadialProgress` is a custom visual element that create a radial progress bar.

![RadialProgress](Images/RadialProgress.png)

## Example

An example for the `RadialProgress` can be found at **Examples**→**RadialProgress**→**Scene**.**RadialProgressExample**

![RadialProgressExample.png](Images/RadialProgressExample.png)

There are several key components to the example.

**Scene.RadialProgressExample:** A scene that contains a `UIDocument` and `ScriptGraph` to demonstrate a `RadialProgress`.

**UIDocument.RadialProgressExample**: A `UIDocument` that demonstrates the `RadialProgress` custom `VisualElement`.

**Behaviour.RadialProgressExample:** A behaviour `ScriptMachine` that demonstrates basic interactions with the `RadialProgress` within the `UIDocument`.

## Using the `RadialProgress` Visual Element

1. Create a `UIDocument`.

   ![UsingTheRadialProgressVisualElement00](Images/UsingTheRadialProgressVisualElement00.png)

2. Under **Library**, click the **Project** tab.

   ![UsingTheRadialProgressVisualElement01](Images/UsingTheRadialProgressVisualElement01.png)

   Now a section for **Custom Controls** will exist.

3. Navigate to **OnChainStudios****→****UIToolkitExtensions**→**RadialProgress**

   ![UsingTheRadialProgressVisualElement02](Images/UsingTheRadialProgressVisualElement02.png)

   The `RadilProgress` is the custom visual element and behaves like any other `VIsualElement`.

4. Drag the `RadialProgress` into the ********************UI Builder******************** ******************Hierarchy******************.

   ![UsingTheRadialProgressVisualElement03](Images/UsingTheRadialProgressVisualElement03.png)

5. Adjust the `RadialProgress` within the ******************Hierarchy****************** to the preferred size. In the example below, ******Grow****** is set to **1**, so that it takes the entire space.

   ![UsingTheRadialProgressVisualElement04](Images/UsingTheRadialProgressVisualElement04.png)

6. Understand the properties of the `RadialProgress`.

   ![UsingTheRadialProgressVisualElement05](Images/UsingTheRadialProgressVisualElement05.png)

   The RadialProgress has four properties.

   **Progress:** the progress value for the RadialProgress element. The progress represents a value between 0 and 100, indicating the completion percentage. Use this property to dynamically update and visualize the progress within the radial element.

   **TrackColor:** the color of the track (unfilled portion) in the RadialProgress element. Customize this property to change the color of the unfilled portion of the radial progress element.

   **ProgressColor:** the color of the progress (filled portion) in the RadialProgress element. Customize this property to change the color of the filled portion of the radial progress element, indicating the completed progress.

   **LineWidth:** the line width used to draw the track and progress arcs within the RadialProgress element. Adjust this property to control the thickness of the lines representing the track and progress arcs.

   ![UsingTheRadialProgressVisualElement06](Images/UsingTheRadialProgressVisualElement06.png)
