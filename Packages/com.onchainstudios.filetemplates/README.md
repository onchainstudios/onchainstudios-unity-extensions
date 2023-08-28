# File Templates (com.onchainstudios.filetemplates)

# Overview

File templates is a project to allow the user to rapidly generate highly readable c# and visual scripting code within a given set of coding standards.

# Installation

1. Add the package to your unity project using the Unity Package Manager
    
    ```html
    git+ssh://git@github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.filetemplates
    ```
    
2. To pull the versioned package based on a tag, append the tag to the end of the URL like this
    
    ```html
    git+ssh://git@github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.filetemplates#v0.7.0-preview.5
    ```
    

# How to Use C# Templates

1. Set the Company Name in the player settings
    
    ![Untitled](README/Untitled.png)
    
2. Navigate to the preferences and set your Author and Namespace
    
    ![Untitled](README/Untitled%201.png)
    
3. Right click a folder and navigate to the C# script you would like to create.
    
    ![Untitled](README/Untitled%202.png)
    
4. The new C# script will be created with the company name, author and namespace you have set above.
    
    ![Untitled](README/Untitled%203.png)
    

# How to Use Visual Scripting Templates

## Main Visual Scripting Folder

### Create the Main Visual Scripting Folder

Create a main folder for all your visual scripting assets called VisualScripting

![Untitled](README/Untitled%204.png)

## Finite State Machine

### State Machines

State machines are the main flow of your program.

1. Create a game object in your scene and attach the State Machine component to it.
    
    ![Untitled](README/Untitled%205.png)
    
2. Create a [GameObjectName] folder in your VisualScripting folder with the same name as the game object.
    
    ![Untitled](README/Untitled%206.png)
    
3. Right click the folder and navigate to the StateMachine template to create.
    
    ![Untitled](README/Untitled%207.png)
    
4. The new asset with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→StateMachine→
    StateMachine.[GameObjectName]
    
    ![Untitled](README/Untitled%208.png)
    
5. Attach the StateMachine state graph to the game object.
    
    ![Untitled](README/Untitled%209.png)
    

### States

States are the individual parts of the state machine handling method calls and waiting to execute transitions.

1. Right click the [GameObjectFolder] or super state folder and navigate to the State template to create.
    
    ![Untitled](README/Untitled%2010.png)
    
2. The new state script graph asset with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→States→
    State.[GameObjectName].New
Name the state Appropriately.
    
    ![Untitled](README/Untitled%2011.png)
    
3. Drag the state into the state machine.
    
    ![Untitled](README/Untitled%2012.png)
    
4. Toggle start state if this is the state you want to start in when the game object loads in.
    
    ![Untitled](README/Untitled%2013.png)
    

### Transitions

Transitions are comprised of 3 parts. A listener, a trigger and a state. They are used to move from one state to another.

1. Right click the [GameObjectName] and navigate to the Transition templates to create all 3 of the transition templates EventName, State and Trigger.
    
    ![Untitled](README/Untitled%2014.png)
    
2. The new transition script graph assets with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→Transitions→[TransitionType]
    Transition.[TransitionType].[GameObjectName].New
Name the files appropriately.
    
    ![Untitled](README/Untitled%2015.png)
    
3. Select the state and the trigger and hook up the event name.
    
    ![Untitled](README/Untitled%2016.png)
    
    ![Untitled](README/Untitled%2017.png)
    
4. Right click the state you are transitioning from and make a transition to the state you are moving to.
    
    ![Untitled](README/Untitled%2018.png)
    
5. Switch the graph to use Graph.
    
    ![Untitled](README/Untitled%2019.png)
    
6. Click switch to finalize the switch.
    
    ![Untitled](README/Untitled%2020.png)
    
7. Select the transition state graph you created.
    
    ![Untitled](README/Untitled%2021.png)
    
8. Hook the Transition.Trigger up to the event you would like to trigger the event with.
    
    ![Untitled](README/Untitled%2022.png)
    

### Super States

Super states are state machines within state machines that can transition to other states in the main state machine they live in from any state within them.

1. Create a super states folder inside of the VisualScripting→[GameObjectName]→FiniteStateMachine folder.
    
    ![Untitled](README/Untitled%2023.png)
    
2. Create a [SuperStateName] folder inside of the VisualScripting→[GameObjectName]→FiniteStateMachine→SuperStates folder.
    - NOTE: When making states or transitions within the super state, use the [SuperStateName] Folder instead of the [GameObjectName] folder when creating from the template files.
    
    ![Untitled](README/Untitled%2024.png)
    
3. Right click the [SuperStateName] folder and navigate to the SuperState template to create.
    
    ![Untitled](README/Untitled%2025.png)
    
4. The new asset with the correct name will show up in the VisualScripting→[GameObjectName]→FiniteStateMachine→SuperStates→
    [SuperStateName]→FiniteStateMachine→StateMachine→
    SuperState.[GameObjectName].[SuperStateName]
    
    ![Untitled](README/Untitled%2026.png)
    
5. Drag the SuperState into the State Machine.
    
    ![Untitled](README/Untitled%2027.png)
    

## Behaviours

### Behaviours

Behaviours are visual scripting asset representing a monobehavior.

1. Create a Game object in your scene and attach the Script Machine component.
    
    ![Untitled](README/Untitled%2028.png)
    
2. Create a [GameObjectName] folder in your VisualScripting folder with the same name as the game object.
    
    ![Untitled](README/Untitled%2029.png)
    
3. Right click the [GameObjectName] folder and navigate to the Behaviour template to create.
    
    ![Untitled](README/Untitled%2030.png)
    
4. The new behaviour script graph asset with the correct name will show up in the VisualScripting→[GameObjectName]→Behaviour→Behaviour.[GameObjectName]
    
    ![Untitled](README/Untitled%2031.png)
    
5. Attach the behaviour script graph to the game object.
    
    ![Untitled](README/Untitled%2032.png)
    

## Methods

### Methods

Methods are visual scripting asset representing a method you might make in c#. They can have inputs and outputs just like a method in c# can have parameters and return values.

1. Right click the folder and navigate to the Method template to create.
    
    ![Untitled](README/Untitled%2033.png)
    
2. The new method script graph asset with the correct name will show up in the VisualScripting→[GameObjectName]→Methods→Method.[GameObjectName].New
Name the method appropriately.
    
    ![Untitled](README/Untitled%2034.png)
    
3. Fill out the Method
    
    ![Untitled](README/Untitled%2035.png)
    
4. Drag the method into a state to use it.
    
    ![Untitled](README/Untitled%2036.png)
    

## Variables

### Constants

Constants are representations of c# const values that are not used by the designer or influence mechanics. We put values in constants instead of directly into the inputs of method graphs to keep the data in a singular place and allow for greater flexibility and maintainability so that if values change, the main state doesn’t need to be modified in case people are working on the state when you may need to update these values.

1. Right click the folder and navigate to the Constants template to create.
    
    ![Untitled](README/Untitled%2037.png)
    
2. The new constant script graph asset with the name will show up in the VisualScripting→[GameObjectName]→Variables→Constants→[ConstantType]→
    [ConstantType].[GameObjectName].New
Name the file and set the output value appropriately
    
    ![Untitled](README/Untitled%2038.png)
    
3. Drag the constant into the script graph that is using it and hook it up.
    
    ![Untitled](README/Untitled%2039.png)
    

### Configurations

Configurations are script graphs you store data in that may change throughout the development of the app. For example, the speed of a game or anything a game designer might need to modify for tuning the game.

1. Right click the folder and navigate to the Configurations template to create.
    
    ![Untitled](README/Untitled%2040.png)
    
2. The new configuration script graph asset with the name will show up in the VisualScripting→[GameObjectName]→Variables→Configurations→
    Configuration.[GameObjectName].New
Name the file appropriately.
    
    ![Untitled](README/Untitled%2041.png)
    
3. Add the output values you need.
    
    ![Untitled](README/Untitled%2042.png)
    
4. Drag the configuration into a script graph that is using it and hook it up.
    
    ![Untitled](README/Untitled%2043.png)
    

### Saved Variables

1. Select one of your script machines and navigate to the Saved tab on the Blackboard. Add the saved variable to the initial tab.
    
    ![Untitled](README/Untitled%2044.png)
    
2. Right click on the main VisualScripting folder and navigate to the Saved Variables template. Create the VariableName and the necessary Get/Has/Set [GraphType]’s as needed.
    
    ![Untitled](README/Untitled%2045.png)
    
3. The new Application Variable script graph assets with their names will show up as VisualScripting→Variables→Saved→[GraphType]→
    Saved.[GraphType].New
Name the files appropriately
    
    ![Untitled](README/Untitled%2046.png)
    
4. Set the output value of the VariableName subgraph to the name of the variable.
    
    ![Untitled](README/Untitled%2047.png)
    
5. Hook up the variable name to the Get/Set/Has graphs.
    
    ![Untitled](README/Untitled%2048.png)
    
    ![Untitled](README/Untitled%2049.png)
    
    ![Untitled](README/Untitled%2050.png)
    
6. Update the Get Data Output and the Set Data Input to the correct type if needed.
    
    ![Untitled](README/Untitled%2051.png)
    
    ![Untitled](README/Untitled%2052.png)
    
7. Use the Get/Set/Has as needed within your project.
    
    ![Untitled](README/Untitled%2053.png)
    
    ![Untitled](README/Untitled%2054.png)
    

### Application Variables

1. Select the application variables asset and add the variable to the application variables.
    
    ![Untitled](README/Untitled%2055.png)
    
2. Right click on the main VisualScripting folder and navigate to the Application Variables template. Create the VariableName and the necessary Get/Has/Set [GraphType]’s as needed.
    
    ![Untitled](README/Untitled%2056.png)
    
3. The new Application Variable script graph assets with their names will show up as VisualScripting→Variables→Application→[GraphType]→
    Application.[GraphType].New
Name the files appropriately
    
    ![Untitled](README/Untitled%2057.png)
    
4. Set the output value of the VariableName subgraph to the name of the variable.
    
    ![Untitled](README/Untitled%2058.png)
    
5. Hook up the variable name to the Get/Set/Has graphs.
    
    ![Untitled](README/Untitled%2059.png)
    
    ![Untitled](README/Untitled%2060.png)
    
    ![Untitled](README/Untitled%2061.png)
    
6. Update the Get Data Output and the Set Data Input to the correct type if needed.
    
    ![Untitled](README/Untitled%2062.png)
    
    ![Untitled](README/Untitled%2063.png)
    
7. Use the Get/Set/Has as needed within your project.
    
    ![Untitled](README/Untitled%2064.png)
    

### Scene Variables

1. Add a new variable to the VisualScripting SceneVariables game object.
    
    ![Untitled](README/Untitled%2065.png)
    
2. Create a folder under the VisualScripting folder named the same as your scene.
    
    ![Untitled](README/Untitled%2066.png)
    
3. Right click the folder and navigate to the Scene Variables template. Create the VariableName and the necessary Get/Has/Set [GraphType]’s as needed.
    
    ![Untitled](README/Untitled%2067.png)
    
4. The new Scene Variable script graph assets with their names will show up as VisualScripting→[SceneName]→Variables→Scene→[GraphType]→
    Scene.[GraphType].[SceneName].New
Name the files appropriately
    
    ![Untitled](README/Untitled%2068.png)
    
5. Set the output value of the VariableName subgraph to the name of the variable.
    
    ![Untitled](README/Untitled%2069.png)
    
6. Hook up the variable name to the Get/Set/Has graphs.
    
    ![Untitled](README/Untitled%2070.png)
    
    ![Untitled](README/Untitled%2071.png)
    
    ![Untitled](README/Untitled%2072.png)
    
7. Update the Get Data Output and the Set Data Input to the correct type if needed.
    
    ![Untitled](README/Untitled%2073.png)
    
    ![Untitled](README/Untitled%2074.png)
    
8. Use the Get/Set/Has as needed within your project.
    
    ![Untitled](README/Untitled%2075.png)
    

### Object Variables

1. Navigate to the GameObject you want to place an object variable on and add the object variable to the variables component on the object.
    
    ![Untitled](README/Untitled%2076.png)
    
2. Right click the folder and navigate to the Object Variables template and create the VariableName and the necessary Get/Has/Set script graphs as needed.
    
    ![Untitled](README/Untitled%2067.png)
    
3. The new Object variable script graph assets with their names will show up as VisualScripting→[GameObjectName]→Variables→Object→[GraphType]→
    Object.[GraphType].[GameObjectName].New
Name the files appropriately
    
    ![Untitled](README/Untitled%2077.png)
    
4. Set the output value of the VariableName subgraph to the name of the variable.
    
    ![Untitled](README/Untitled%2078.png)
    
5. Drag the variable name into the get/set/has methods and hook it up.
    
    ![Untitled](README/Untitled%2079.png)
    
    ![Untitled](README/Untitled%2080.png)
    
    ![Untitled](README/Untitled%2081.png)
    
6. Update the Get Data Output and the Set Data Input to the correct type if needed.
    
    ![Untitled](README/Untitled%2082.png)
    
    ![Untitled](README/Untitled%2083.png)
    
7. Setup a Scene Variable to hold the handle of the GameObject you are grabbing from even if it is instantiated dynamically. Hook up the scene variable get to the get/set/has object input.
    
    ![Untitled](README/Untitled%2084.png)
    
    ![Untitled](README/Untitled%2085.png)
    
    ![Untitled](README/Untitled%2086.png)
    
8. Use the get/has/set script graphs as you need to use them.
    
    ![Untitled](README/Untitled%2087.png)
    
    ![Untitled](README/Untitled%2088.png)
    

### Renaming Object/Scene/Application/Saved Variables.

1. Rename the variable.
    
    ![Untitled](README/Untitled%2089.png)
    
2. Rename The Get/Has/Set/VariableName script graph assets.
    
    ![Untitled](README/Untitled%2090.png)
    
3. Set the return value in the VariableName subgraph to the variable name.
    
    ![Untitled](README/Untitled%2091.png)
    
4. Realign the VariableName subgraph in the get/has/set graphs.
    
    ![Untitled](README/Untitled%2092.png)
    
    ![Untitled](README/Untitled%2093.png)
    
    ![Untitled](README/Untitled%2094.png)
    

## Events

### Events

Events are used to communicate from StateMachines or Behaviours to Behaviors.

1. Right click the [GameObjectName] folder who will listen to the event. Navigate to the event templates to create all 3 of the event templates Name, Listener and Trigger.
    
    ![Untitled](README/Untitled%2095.png)
    
2. The new event script graph assets with the correct name will show up in the VisualScripting→[GameObjectName]→Events→[EventType]→
    Event.[EventType].[GameObjectName].New
Name the files appropriately.
    
    ![Untitled](README/Untitled%2096.png)
    
3. Drag the name script graph into the trigger and listener script graphs and hook it up.
    
    ![Untitled](README/Untitled%2097.png)
    
    ![Untitled](README/Untitled%2098.png)
    
4. If the game object is not dynamically instantiated, you can remove the GameObject input date and hook up a scene variable getter in the trigger.
    
    ![Untitled](README/Untitled%2099.png)
    
5. Add the listener to the behavior.
    
    ![Untitled](README/Untitled%20100.png)
    
6. Post the event trigger inside another behaviour or state machine.
    
    ![Untitled](README/Untitled%20101.png)