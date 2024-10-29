# Graphics_Assignment_1
 
## Explanations
### Base Game
The game is a top-down, point-and-click style game that takes minor inspiration from pac-man. There are four enemies that the player must defeat to win, both enemies and the player can only defeat each other by obtaining powerups in the form of powerup crystals that will randomly spawn. Once these powerups are obtained, the player or enemies must hunt the other to defeat them, winning the game when the player dies or all the enemies die.

The screenshot below shows the gameplay mid-progress.
![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Gameplay_Screenshot.jpg?raw=true)

#### Enemy AI
The enemy AI uses a NavMesh to move around obstacles such as trees and towers. While using the NavMesh, the enemy is also able to track the crystals and after colliding with it they will start to glow from the rim lighting and track the player

#### Crystal Powerups
The crystal powerups are split into two parts, the spawning of them and the interaction of them. The spawner simply creates a new crystal witin a set bound (hard coded) at set intervals. After the crystals are spawned, the crystal will modify its transparency to make it seem to fade in and out. Additionally, when the player or enemy interacts with the crystal (collides with it), it will delete itself and set the player or enemy to dangerous.

#### Player Character
The player character moves around by navigating to the point the player clicked on using a NavMesh. After interacting the with crystal, the player will play an attacking animation and start to glow from the rim lighting, inwhich the player must then move towards the enemy and collide with it which will defeat the enemy. Alternatively, if enemy is glowing, the player must move away from it until they can get a powerup crystal to defeat the enemy.

### Illuminatioin
#### Diffuse Lighting, Diffuse Lighting with Ambient, and Simple Specular
I have combined these three together since they are part of a single shaderlab script. The overall code has not changed from the slide code when seperated from each other, however, we had to add some modifications to get these three implementations to work together and work with the following deliverable, toggling. First of all we added toggled for both ambient and specular so that we can isolate each for the toggling portion, as well as, code to handle rendering for having both, one or the other, or neither ambient or specular enabled and we used Diffuse lighting to combine them all together. During this process we also merged the shaders together for this function to work.

#### Ambient/Specular Toggle
The toggling for each setting; No Lighting, Ambient Only, Specular Only, Ambient + Specular, and Ambinent + Specular + Custom Effect/Shader, are implemented using a C# script to change the values of shaderlab variables and/or materal the object will use. Each object that is affected will have a C# script that allows for an "Illumination Manager" to tell every object to what toggle should happen when a key is pressed. This is the simplests way we can implement it, however, it is by far not the best or most elegant, it just works and works well enough.

#### Toon Ramp
There are no changes to the toom ramp shaderlab script. It is taken from the class slides.

### Color Grading
#### Night time LUT
The LUT for night time was simply blue shifted so that it creates a blue-ish hue that is "projected" onto the camera. The game will dynamically change to this LUT when the directional light turns 180 degrees, simulating the sun's light as it moves across Earth's sky. This dynamic change brings realism into our game as the sun's light still affects our sky during the night by bouncing it off the moon, which does become a more blue-ish color.

#### Death LUT
The LUT of dying is a greyscaled version of the neutral LUT, which is also dynamically changed when the player dies. The gives a visual indicator that the player has died and is seen in many games such as GTA.

### Shaders and Effects
#### Rim Lighting
The rim lighting, as mentioned in the [Base Game](#Base-Game) section, the rim lighting is used to show if the player or enemy has obtained the powerup crystal and is able to kill.

The rim lighting was modified by adding the ability to change and apply colors and textures respectively. This allows us to have fully textured objects such as the player and give it rim lighting which the class code did not have, which makes the object affected give a visual indicator.

#### Tranparency
The crystal modified its own transpaency by setting the value of its shader variable to the C# variable call ```Opacity```. By modifying the shader variable directly, we can dynamically change the transparency of the crystal, which creates a fade-in-fade-out effect that makes the crystal a bit more noticable and also plays with the psychology of the player as we have been conditioned to understand that a blinking object is important, either as part of the game or as a visual indicator of the object potentially disappearing.

## Third-Party Resources and Credits
- Tower and tree models by LowPolyBoy. [(FREE) Low Poly Game Assets](https://sketchfab.com/3d-models/free-low-poly-game-assets-bbbfbeccfc9047b8b3f15b1c90061cdf)
- Player model and animations by Dungeon Mason. [RPG Hero PBR HP Polyart](https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy/rpg-hero-pbr-hp-polyart-121480)
- Powerup gem model by AurnySky. [Simple Gems Ultimate Animated Customizable Pack](https://assetstore.unity.com/packages/3d/props/simple-gems-ultimate-animated-customizable-pack-73764)
- Skybox by rpgwhitelock. [AllSky Free - 10 Sky / Skybox Set](https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014)
