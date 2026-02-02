   # HW4
## Devlog
I used a locator for the player so that I can make its code decoupled from the other systems in this game. The Controller class and the Locator class defines the control side and the UI class and Audio Class defines the view side. The controller class controls the generation of the obstacles, and the UI and Audio classes are used when there are events (score, flap and collision). Events are sent to the objects that subscribe to it and the Locator, which is the singleton is used to track the character. The classes that send event or the static class (control) do not directly call any methods in the view side, so that I only need to modify the view side codes in order to change the view side effects with the control side classes unmodified. 

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites