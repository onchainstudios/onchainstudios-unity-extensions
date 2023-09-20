# File Templates (com.onchainstudios.filetemplates)

# Table Of Contents

- [Overview](#overview)
- [Required Software](#required-software)
- [Installation](#installation)
- [How to Use C# Templates](#how-to-use-c-templates)
- [How to Use Visual Scripting Templates](#how-to-use-visual-scripting-templates)
  - [Create the Main Visual Scripting Folder](#create-the-main-visual-scripting-folder)
  - [Finite State Machine](#finite-state-machine)
    - [State Machines](#state-machines)
    - [States](#states)
    - [Transitions](#transitions)
    - [Super States](#super-states)
  - [Behaviours](#behaviours)
  - [Methods](#methods)
  - [Variables](#variables)
    - [Constants](#constants)
    - [Configurations](#configurations)
    - [Saved Variables](#saved-variables)
    - [Application Variables](#application-variables)
    - [Scene Variables](#scene-variables)
    - [Object Variables](#object-variables)
    - [Renaming Variables](#renaming-variables)
  - [Events](#events)

# Overview

File templates is a project to allow the user to rapidly generate highly readable c# and visual scripting code within a given set of coding standards.

# Required Software

Unity 2022.3 or greater.

# Installation

1. Add the package to your unity project using the Unity Package Manager

    ```html
    https://github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.filetemplates
    ```
2. To pull the versioned package based on a tag, append the tag to the end of the URL like this

    ```html
    https://github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.filetemplates#v0.7.0-preview.14
    ```

# How to Use C# Templates

1. Set the Company Name in the player settings.

    ![HowtoUseCSharpTemplates01](Images/HowtoUseCSharpTemplates01.png)

2. Navigate to the preferences and set your Author and Namespace

    ![HowtoUseCSharpTemplates02](Images/HowtoUseCSharpTemplates02.png)

3. Right click a folder and navigate to the C# script you would like to create.

    ![HowtoUseCSharpTemplates03](Images/HowtoUseCSharpTemplates03.png)

4. The new C# script will be created with the company name, author and namespace you have set above.

    ![HowtoUseCSharpTemplates04](Images/HowtoUseCSharpTemplates04.png)

# How to Use Visual Scripting Templates

## Create the Main Visual Scripting Folder

1. Create a main folder for all your visual scripting assets called VisualScripting

    ![CreateTheMainVisualScriptingFolder01](Images/CreateTheMainVisualScriptingFolder01.png)

## Finite State Machine

### State Machines

State machines are the main flow of your program.

1. Create a game object in your scene and attach the State Machine component to it.

    ![StateMachines01](Images/StateMachines01.png)

2. Create a [GameObjectName] folder in your VisualScripting folder with the same name as the game object.

    ![StateMachines02](Images/StateMachines02.png)

3. Right click the folder and navigate to the StateMachine template to create.

    ![StateMachines03](Images/StateMachines03.png)

4. The new asset with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→StateMachine→StateMachine.[GameObjectName]

    ![StateMachines04](Images/StateMachines04.png)

5. Attach the StateMachine state graph to the game object.

    ![StateMachines05](Images/StateMachines05.png)

### States

States are the individual parts of the state machine handling method calls and waiting to execute transitions.

1. Right click the [GameObjectFolder] or super state folder and navigate to the State template to create.

    ![States01](Images/States01.png)

2. The new state script graph asset with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→States→State.[GameObjectName].New

    Name the state Appropriately.

    ![States02](Images/States02.png)

3. Drag the state into the state machine.

    ![States03](Images/States03.png)

4. Toggle start state if this is the state you want to start in when the game object loads in.

    ![States04](Images/States04.png)

### Transitions

Transitions are comprised of 3 parts. A listener, a trigger and a state. They are used to move from one state to another.

1. Right click the [GameObjectName] and navigate to the Transition templates to create all 3 of the transition templates EventName, State and Trigger.

    ![Transitions01](Images/Transitions01.png)

2. The new transition script graph assets with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→Transitions→[TransitionType]Transition.[TransitionType].[GameObjectName].New

    Name the files appropriately.

    ![Transitions02](Images/Transitions02.png)

3. Select the state and the trigger and hook up the event name.

    ![Transitions03a](Images/Transitions03a.png)

    ![Transitions03b](Images/Transitions03b.png)

4. Right click the state you are transitioning from and make a transition to the state you are moving to.

    ![Transitions04](Images/Transitions04.png)

5. Switch the graph to use Graph.

    ![Transitions05](Images/Transitions05.png)

6. Click switch to finalize the switch.

    ![Transitions06](Images/Transitions06.png)

7. Select the transition state graph you created.

    ![Transitions07](Images/Transitions07.png)

8. Hook the Transition.Trigger up to the event you would like to trigger the event with.

    ![Transitions08](Images/Transitions08.png)

### Super States

Super states are state machines within state machines. The Superstate can transition inside itself along it's state flow and also exit from the entire flow by using transitions in the state machine above it.

1. Create a super states folder inside of the VisualScripting→[GameObjectName]→FiniteStateMachine folder.

    ![SuperStates01](Images/SuperStates01.png)

2. Create a [SuperStateName] folder inside of the VisualScripting→[GameObjectName]→FiniteStateMachine→SuperStates folder.

    [NOTE]: When making states or transitions within the super state, use the [SuperStateName] Folder instead of the [GameObjectName] folder when creating from the template files.

    ![SuperStates02](Images/SuperStates02.png)

3. Right click the [SuperStateName] folder and navigate to the SuperState template to create.

    ![SuperStates03](Images/SuperStates03.png)

4. The new asset with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→SuperStates→[SuperStateName]→FiniteStateMachine→StateMachine→SuperState.[GameObjectName].[SuperStateName]

    ![SuperStates04](Images/SuperStates04.png)

5. Drag the SuperState into the State Machine.

    ![SuperStates05](Images/SuperStates05.png)

## Behaviours

Behaviours are visual scripting asset representing a Monobehavior.

1. Create a Game object in your scene and attach the Script Machine component.

    ![Behaviours01](Images/Behaviours01.png)

2. Create a [GameObjectName] folder in your VisualScripting folder with the same name as the game object.

    ![Behaviours02](Images/Behaviours02.png)

3. Right click the [GameObjectName] folder and navigate to the Behaviour template to create.

    ![Behaviours03](Images/Behaviours03.png)

4. The new behaviour script graph asset with the correct name will show up in the VisualScripting→[GameObjectName]→Behaviour→Behaviour.[GameObjectName]

    ![Behaviours04](Images/Behaviours04.png)

5. Attach the behaviour script graph to the game object.

    ![Behaviours05](Images/Behaviours05.png)

## Methods

Methods are visual scripting asset representing a method you might make in c#. They can have inputs and outputs just like a method in c# can have parameters and return values.

1. Right click the folder and navigate to the Method template to create.

    ![Methods01](Images/Methods01.png)

2. The new method script graph asset with the correct name will show up in the VisualScripting→[GameObjectName]→Methods→Method.[GameObjectName].New

    Name the method appropriately.

    ![Methods02](Images/Methods02.png)

3. Fill out the Method

    ![Methods03](Images/Methods03.png)

4. Drag the method into a state to use it.

    ![Methods04](Images/Methods04.png)

## Variables

### Constants

Constants are representations of c# const values that are not used by the designer or influence mechanics. We put values in constants instead of directly into the inputs of method graphs to keep the data in a singular place and allow for greater flexibility and maintainability so that if values change, the main state doesn’t need to be modified in case people are working on the state when you may need to update these values.

1. Right click the folder and navigate to the Constants template to create.

    ![Constants01](Images/Constants01.png)

2. The new constant script graph asset with the name will show up in the VisualScripting→[GameObjectName]→Variables→Constants→[ConstantType]→[ConstantType].[GameObjectName].New

    Name the file and set the output value appropriately

    ![Constants02](Images/Constants02.png)

3. Drag the constant into the script graph that is using it and hook it up.

    ![Constants03](Images/Constants03.png)

### Configurations

Configurations are script graphs you store data in that may change throughout the development of the app. For example, the speed of a game or anything a game designer might need to modify for tuning the game.

1. Right click the folder and navigate to the Configurations template to create.

    ![Configurations01](Images/Configurations01.png)

2. The new configuration script graph asset with the name will show up in the VisualScripting→[GameObjectName]→Variables→Configurations→Configuration.[GameObjectName].New

    Name the file appropriately.

    ![Configurations02](Images/Configurations02.png)

3. Add the output values you need.

    ![Configurations03](Images/Configurations03.png)

4. Drag the configuration into a script graph that is using it and hook it up.

    ![Configurations04](Images/Configurations04.png)

### Saved Variables

1. Select one of your script machines and navigate to the Saved tab on the Blackboard. Add the saved variable to the initial tab.

    ![SavedVariables01](Images/SavedVariables01.png)

2. Right click on the main VisualScripting folder and navigate to the Saved Variables template. Create the VariableName and the necessary Get/Has/Set [GraphType]’s as needed.

    ![SavedVariables02](Images/SavedVariables02.png)

3. The new Application Variable script graph assets with their names will show up as VisualScripting→Variables→Saved→[GraphType]→Saved.[GraphType].New

    Name the files appropriately

    ![SavedVariables03](Images/SavedVariables03.png)

4. Set the output value of the VariableName subgraph to the name of the variable.

    ![SavedVariables04](Images/SavedVariables04.png)

5. Hook up the variable name to the Get/Set/Has graphs.

    ![SavedVariables05a](Images/SavedVariables05a.png)

    ![SavedVariables05b](Images/SavedVariables05b.png)

    ![SavedVariables05c](Images/SavedVariables05c.png)

6. Update the Get Data Output and the Set Data Input to the correct type if needed.

    ![SavedVariables06a](Images/SavedVariables06a.png)

    ![SavedVariables06b](Images/SavedVariables06b.png)

7. Use the Get/Set/Has as needed within your project.

    ![SavedVariables07a](Images/SavedVariables07a.png)

    ![SavedVariables07b](Images/SavedVariables07b.png)

### Application Variables

1. Select the application variables asset and add the variable to the application variables.

    ![ApplicationVariables01](Images/ApplicationVariables01.png)

2. Right click on the main VisualScripting folder and navigate to the Application Variables template. Create the VariableName and the necessary Get/Has/Set [GraphType]’s as needed.

    ![ApplicationVariables02](Images/ApplicationVariables02.png)

3. The new Application Variable script graph assets with their names will show up as VisualScripting→Variables→Application→[GraphType]→Application.[GraphType].New

    Name the files appropriately

    ![ApplicationVariables03](Images/ApplicationVariables03.png)

4. Set the output value of the VariableName subgraph to the name of the variable.

    ![ApplicationVariables04](Images/ApplicationVariables04.png)

5. Hook up the variable name to the Get/Set/Has graphs.

    ![ApplicationVariables05a](Images/ApplicationVariables05a.png)

    ![ApplicationVariables05b](Images/ApplicationVariables05b.png)

    ![ApplicationVariables05c](Images/ApplicationVariables05c.png)

6. Update the Get Data Output and the Set Data Input to the correct type if needed.

    ![ApplicationVariables06a](Images/ApplicationVariables06a.png)

    ![ApplicationVariables06b](Images/ApplicationVariables06b.png)

7. Use the Get/Set/Has as needed within your project.

    ![ApplicationVariables07](Images/ApplicationVariables07.png)

### Scene Variables

1. Add a new variable to the VisualScripting SceneVariables game object.

    ![SceneVariables01](Images/SceneVariables01.png)

2. Create a folder under the VisualScripting folder named the same as your scene.

    ![SceneVariables02](Images/SceneVariables02.png)

3. Right click the folder and navigate to the Scene Variables template. Create the VariableName and the necessary Get/Has/Set [GraphType]’s as needed.

    ![SceneVariables03](Images/SceneVariables03.png)

4. The new Scene Variable script graph assets with their names will show up as VisualScripting→[SceneName]→Variables→Scene→[GraphType]→Scene.[GraphType].[SceneName].New

    Name the files appropriately.

    ![SceneVariables04](Images/SceneVariables04.png)

5. Set the output value of the VariableName subgraph to the name of the variable.

    ![SceneVariables05](Images/SceneVariables05.png)

6. Hook up the variable name to the Get/Set/Has graphs.

    ![SceneVariables06a](Images/SceneVariables06a.png)

    ![SceneVariables06b](Images/SceneVariables06b.png)

    ![SceneVariables06c](Images/SceneVariables06c.png)

7. Update the Get Data Output and the Set Data Input to the correct type if needed.

    ![SceneVariables07a](Images/SceneVariables07a.png)

    ![SceneVariables07b](Images/SceneVariables07b.png)

8. Use the Get/Set/Has as needed within your project.

    ![SceneVariables08](Images/SceneVariables08.png)

### Object Variables

1. Navigate to the GameObject you want to place an object variable on and add the object variable to the variables component on the object.

    ![ObjectVariables01](Images/ObjectVariables01.png)

2. Right click the folder and navigate to the Object Variables template and create the VariableName and the necessary Get/Has/Set script graphs as needed.

    ![ObjectVariables02](Images/ObjectVariables02.png)

3. The new Object variable script graph assets with their names will show up as VisualScripting→[GameObjectName]→Variables→Object→[GraphType]→Object.[GraphType].[GameObjectName].New

    Name the files appropriately.

    ![ObjectVariables03](Images/ObjectVariables03.png)

4. Set the output value of the VariableName subgraph to the name of the variable.

    ![ObjectVariables04](Images/ObjectVariables04.png)

5. Drag the variable name into the get/set/has methods and hook it up.

    ![ObjectVariables05a](Images/ObjectVariables05a.png)

    ![ObjectVariables05b](Images/ObjectVariables05b.png)

    ![ObjectVariables05c](Images/ObjectVariables05c.png)

6. Update the Get Data Output and the Set Data Input to the correct type if needed.

    ![ObjectVariables06a](Images/ObjectVariables06a.png)

    ![ObjectVariables06b](Images/ObjectVariables06b.png)

7. Setup a Scene Variable to hold the handle of the GameObject you are grabbing from even if it is instantiated dynamically. Hook up the scene variable get to the get/set/has object input.

    ![ObjectVariables07a](Images/ObjectVariables07a.png)

    ![ObjectVariables07b](Images/ObjectVariables07b.png)

    ![ObjectVariables07c](Images/ObjectVariables07c.png)

8. Use the get/has/set script graphs as you need to use them.

    ![ObjectVariables08a](Images/ObjectVariables08a.png)

    ![ObjectVariables08b](Images/ObjectVariables08b.png)

### Renaming Variables

1. Rename the variable.

    ![RenamingVariables01](Images/RenamingVariables01.png)

2. Rename The Get/Has/Set/VariableName script graph assets.

    ![RenamingVariables02](Images/RenamingVariables02.png)

3. Set the return value in the VariableName subgraph to the variable name.

    ![RenamingVariables03](Images/RenamingVariables03.png)

4. Realign the VariableName subgraph in the get/has/set graphs.

    ![RenamingVariables04a](Images/RenamingVariables04a.png)

    ![RenamingVariables04b](Images/RenamingVariables04b.png)

    ![RenamingVariables04c](Images/RenamingVariables04c.png)

## Events

Events are used to communicate from StateMachines or Behaviours to Behaviors.

1. Right click the [GameObjectName] folder who will listen to the event. Navigate to the event templates to create all 3 of the event templates Name, Listener and Trigger.

    ![Events01](Images/Events01.png)

2. The new event script graph assets with the correct name will show up in the VisualScripting→[GameObjectName]→Events→[EventType]→Event.[EventType].[GameObjectName].New

    Name the files appropriately.

    ![Events02](Images/Events02.png)

3. Drag the name script graph into the trigger and listener script graphs and hook it up.

    ![Events03a](Images/Events03a.png)

    ![Events03b](Images/Events03b.png)

4. If the game object is not dynamically instantiated, you can remove the GameObject input date and hook up a scene variable getter in the trigger.

    ![Events04](Images/Events04.png)

5. Add the listener to the behavior.

    ![Events05](Images/Events05.png)

6. Post the event trigger inside another behaviour or state machine.

    ![Events06](Images/Events06.png)