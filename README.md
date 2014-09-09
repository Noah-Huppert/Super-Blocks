#Goals
Currently the `GameController` `GuiController` scheme only supports one scene without completely duplicating those two major controllers for other scenes.  
<br>
**Solution to fix this:**  
Create a Singleton class called `EventController`. This event controller will have its own game object in every scene. In the `GameController` instead of accessing the `StageController` or `GuiController` directly it will fire a global method via a method similar to this pseudo implementation `EventController.controller.fire("update")`. Any class that wishes to receive events will implement a `EventInterface` which will have several relevant overridable methods. In each scene there will be a custom Singleton that can receive these events and react appropriately based on the role of the scene.  
<br>
A less safe way of doing this is only to have a `EventInterface`. This would simplify things. However it may allow for unsafe uses. Implementing it with just an Interface would completely remove the possibility for logic when making Event Calls.
