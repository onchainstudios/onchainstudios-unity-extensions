# Changelog (com.onchainstudios.uitoolkitextensions)

All notable changes to this project will be documented in this file.

## [Unreleased]

## [2.6.0] - 2023-09-21

* Fixed a critical event leak in the `VisualElementCallbackManager` by using a callback methods, instead of a lambda.
* The callback manager now passes the `ClickEvent` and `ChangeEvent<T>` to the event nodes. 

## [2.5.2] - 2023-09-20

### Fixed

- Fixed urls for installation instructions now that the repo is public.

## [2.5.1] - 2023-09-12

### Added
* Added a `VisualElementCallbackManager` that registers callbacks for the children of a `VisualElement`, this functionality was originally within the `UIDocumentEventBusBridge`.
* The `UIDocumentEventBusBridge` utilizes the `VisualElementCallbackManager` to register and unregister callbacks for the `UIDocument`.
* The `ListViewEventBus` registers and unregister callbacks on all items via the `VisualElementCallbackManager` during bind and unbind. 

## [2.5.0] - 2023-09-07

### Fixes
* Fixed issue with serialization of match rules in event nodes.
* Removed duplicate script machine in visual scripting example scene.
* Fixed style sheet attached to example panel settings to reference style sheets in the examples.

### Added
* Method visual script for lerping the alpha of a Visual Element Background.
* Method visual script for getting the background color of a visual element.
* Method visual script for setting the background color of a visual element.
* Method visual script for setting the background color alpha of a visual element.
* Examples for the new methods.

## [2.4.0] - 2023-09-05

### Fixes
* Fixed coding standard violation for visual scripts for the **GradietViewExample**.
* Removed the duplicate output **ListView** from the `OnListViewItemBind` and `OnListViewItemUnbind` node. The nodes already return the output **VisualElement** which is the `ListView`.

## [2.3.1] - 2023-09-05

* Renamed `QueryNode` to `QueryVisualElement`. 

## [2.3.0] - 2023-09-05

### Added
* A custom Visual Script node, `QueryNode`, to query a visual element and return a list of visual elements that match a criteria. Functions similarly to [UQueryExtensions](https://docs.unity3d.com/2020.1/Documentation/ScriptReference/UIElements.UQueryExtensions.Query.html).

## [2.2.2] - 2023-08-31

This is the first release of the OnChain Studios UI Toolkit Extension 

