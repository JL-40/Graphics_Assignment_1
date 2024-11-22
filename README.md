# Graphics: Course Project

##  Assignment 1 Report
The following are part of the report for assignment 1. We left this here as a refresher for marking, as well as, for referencing. For Course Project Report, go to [Course Project Rport](#course-project-report).

### Video Report
[Comp Graphics Assignment 1 Video Report](https://youtu.be/TryUkKaSO8k)
### Slides
[INFR 1350U - Intro to Computer Graphics: Assignment 1](https://docs.google.com/presentation/d/1tRHT3C_LpAaZC8hJ9qsogvOmAxXBVREYNdiiqRI-b2E/edit?usp=sharing)
 
## Explanations
### Base Game
The game is a top-down, point-and-click style game that takes minor inspiration from pac-man. There are four enemies that the player must defeat to win, both enemies and the player can only defeat each other by obtaining powerups in the form of powerup crystals that will randomly spawn. Once these powerups are obtained, the player or enemies must hunt the other to defeat them, winning the game when the player dies or all the enemies die.

The screenshot below shows the gameplay mid-progress.
![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Gameplay_Screenshot.jpg?raw=true)

#### Crystal Powerups
The crystal powerups are split into two parts, the spawning of them and the interaction of them. The spawner simply creates a new crystal witin a set bound (hard coded) at set intervals. After the crystals are spawned, the crystal will modify its transparency to make it seem to fade in and out. Additionally, when the player or enemy interacts with the crystal (collides with it), it will delete itself and set the player or enemy to dangerous.

#### Enemy AI & Player Character
Both the player character and the enemy use a NavMesh to move around; the enemy uses the NavMesh to track to the powerup crystals and track the player character while the player character uses the NavMesh to move to the where the player has clicked to with their cursor.

When both the player and the enemy AI must move to the crystal to gain a buff that allows them to kill each other. When either the player character or enemy collides with the crystal, it will set a boolean variable to true which adjusts their rim lighting to be more visible. For the player character, it will also change the animation to an attacking animation.

The gif below shows the player and enemy gaining the buff while also showing the player defeating the enemy before dying.

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Player_VS_Enemy.gif?raw=true)

### Illuminatioin
#### Diffuse Lighting, Diffuse Lighting with Ambient, and Simple Specular
I have combined these three together since they are part of a single shaderlab script. The overall code has not changed from the slide code when seperated from each other, however, we had to add some modifications to get these three implementations to work together and work with the following deliverable, toggling. First of all we added toggled for both ambient and specular so that we can isolate each for the toggling portion, as well as, code to handle rendering for having both, one or the other, or neither ambient or specular enabled and we used Diffuse lighting to combine them all together. During this process we also merged the shaders together for this function to work.

#### Ambient/Specular Toggle
The toggling for each setting; No Lighting, Ambient Only, Specular Only, Ambient + Specular, and Ambinent + Specular + Custom Effect/Shader, are implemented using a C# script to change the values of shaderlab variables and/or materal the object will use. Each object that is affected will have a C# script that allows for an "Illumination Manager" to tell every object to what toggle should happen when a key is pressed. This is the simplests way we can implement it, however, it is by far not the best or most elegant, it just works and works well enough.

#### Toon Ramp
There are no changes to the toom ramp shaderlab script itself at this time, taken from the class slides, but has been implemented alongside the above togglable Illumination Manager Functionality.

### Color Grading
#### Night time LUT
The LUT for night time was simply blue shifted so that it creates a blue-ish hue that is "projected" onto the camera. The game will dynamically change to this LUT when the directional light turns 180 degrees, simulating the sun's light as it moves across Earth's sky. This dynamic change brings realism into our game as the sun's light still affects our sky during the night by bouncing it off the moon, which does become a more blue-ish color.

#### Death LUT
The LUT of dying is a greyscaled version of the neutral LUT, which is also dynamically changed when the player dies. The gives a visual indicator that the player has died and is seen in many games such as GTA.

### Shaders and Effects
#### Rim Lighting
The rim lighting, as mentioned in the [Base Game](#Base-Game) section, the rim lighting is used to show if the player or enemy has obtained the powerup crystal and is able to kill. The rim lighting was modified by adding the ability to change and apply colors and textures respectively. This allows us to have fully textured objects such as the player and give it rim lighting which the class code did not have, which makes the object affected give a visual indicator.

The screenshot below shows the rim lighting with the texture applied to the player character from [RPG Hero PBR HP Polyart](#Third-Party-Resources-and-Credits).

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Rim_Lighting.gif?raw=true)

#### Tranparency
The crystal modified its own transpaency by setting the value of its shader variable to the C# variable call ```Opacity```. By modifying the shader variable directly, we can dynamically change the transparency of the crystal, which creates a fade-in-fade-out effect that makes the crystal a bit more noticable and also plays with the psychology of the player as we have been conditioned to understand that a blinking object is important, either as part of the game or as a visual indicator of the object potentially disappearing.

The gif below shows the crystal dynamically adjusting their tranparency of their material shader.
![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Transparent_Crystal.gif?raw=true)

## Third-Party Resources and Credits - Assignment 1
The following third-party resources were used to save time on modelling and animations. These have no impact on the game aside from making the game look more pleasing than looking at primatives or looking at a flat color skybox.

- Tower and tree models by LowPolyBoy. [(FREE) Low Poly Game Assets](https://sketchfab.com/3d-models/free-low-poly-game-assets-bbbfbeccfc9047b8b3f15b1c90061cdf)
- Player model and animations by Dungeon Mason. [RPG Hero PBR HP Polyart](https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy/rpg-hero-pbr-hp-polyart-121480)
- Powerup gem model by AurnySky. [Simple Gems Ultimate Animated Customizable Pack](https://assetstore.unity.com/packages/3d/props/simple-gems-ultimate-animated-customizable-pack-73764)
- Skybox by rpgwhitelock. [AllSky Free - 10 Sky / Skybox Set](https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014)

## Course Project Report
The following is the report for the course project. If you need to refresh yourself about assignmnet 1 or want look through the assignment 1 report, go to [Assingnment 1 Report](#assignment-1-report)

## Third-Party Resources and Credits - Course Project
The following third-party resources were added after Assignment 1. The reasoning is the same as assignment 1, we used these assets to save time on modelling and animations. These have no impact on the game aside from making the game look more pleasing than looking at primatives.
- New enemy model and animations by Pxltiger. [Zombie](https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232)
