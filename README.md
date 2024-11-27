# Graphics: Course Project

##  Assignment 1 Report
The following are part of the report for assignment 1. We left this here as a refresher for marking, as well as, for referencing. ```For Course Project Report, go to [Course Project Report](#course-project-report).```

### Video Report
[Comp Graphics Assignment 1 Video Report](https://youtu.be/TryUkKaSO8k)
### Slides
[INFR 1350U - Intro to Computer Graphics: Assignment 1](https://docs.google.com/presentation/d/1tRHT3C_LpAaZC8hJ9qsogvOmAxXBVREYNdiiqRI-b2E/edit?usp=sharing)
 
## Assignement 1 Explanations
### Base Game
The game is a top-down, point-and-click style game that takes minor inspiration from pac-man. There are four enemies that the player must defeat to win, both enemies and the player can only defeat each other by obtaining powerups in the form of powerup crystals that will randomly spawn. Once these powerups are obtained, the player or enemies must hunt the other to defeat them, winning the game when the player dies or all the enemies die.

The screenshot below shows the gameplay mid-progress.
![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Assignment_1/Gameplay_Screenshot.jpg?raw=true)

#### Crystal Powerups
The crystal powerups are split into two parts, the spawning of them and the interaction of them. The spawner simply creates a new crystal witin a set bound (hard coded) at set intervals. After the crystals are spawned, the crystal will modify its transparency to make it seem to fade in and out. Additionally, when the player or enemy interacts with the crystal (collides with it), it will delete itself and set the player or enemy to dangerous.

#### Enemy AI & Player Character
Both the player character and the enemy use a NavMesh to move around; the enemy uses the NavMesh to track to the powerup crystals and track the player character while the player character uses the NavMesh to move to the where the player has clicked to with their cursor.

When both the player and the enemy AI must move to the crystal to gain a buff that allows them to kill each other. When either the player character or enemy collides with the crystal, it will set a boolean variable to true which adjusts their rim lighting to be more visible. For the player character, it will also change the animation to an attacking animation.

The gif below shows the player and enemy gaining the buff while also showing the player defeating the enemy before dying.

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Assignment_1/Player_VS_Enemy.gif?raw=true)

### Illumination
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

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Assignment_1/Rim_Lighting.gif?raw=true)

#### Tranparency
The crystal modified its own transpaency by setting the value of its shader variable to the C# variable call ```Opacity```. By modifying the shader variable directly, we can dynamically change the transparency of the crystal, which creates a fade-in-fade-out effect that makes the crystal a bit more noticable and also plays with the psychology of the player as we have been conditioned to understand that a blinking object is important, either as part of the game or as a visual indicator of the object potentially disappearing.

The gif below shows the crystal dynamically adjusting their tranparency of their material shader.
![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Assignment_1/Transparent_Crystal.gif?raw=true)

## Third-Party Resources and Credits - Assignment 1
The following third-party resources were used to save time on modelling and animations. These have no impact on the game aside from making the game look more pleasing than looking at primatives or looking at a flat color skybox.

- Tower and tree models by LowPolyBoy. [(FREE) Low Poly Game Assets](https://sketchfab.com/3d-models/free-low-poly-game-assets-bbbfbeccfc9047b8b3f15b1c90061cdf)
- Player model and animations by Dungeon Mason. [RPG Hero PBR HP Polyart](https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy/rpg-hero-pbr-hp-polyart-121480)
- Powerup gem model by AurnySky. [Simple Gems Ultimate Animated Customizable Pack](https://assetstore.unity.com/packages/3d/props/simple-gems-ultimate-animated-customizable-pack-73764)
- Skybox by rpgwhitelock. [AllSky Free - 10 Sky / Skybox Set](https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014)

## Course Project Report
The following is the report for the course project. If you need to refresh yourself about assignment 1 or want look through the assignment 1 report, go to [Assingnment 1 Report](#assignment-1-report).

### Video Presentation

### Slides
https://docs.google.com/presentation/d/18r-wigTjYK7FULCZWv_ocfFUd6Feu4yxFGk7QZALwwo/edit?usp=sharing

## Course Project Explanations
### Assignment 1 Improvements
#### Gameplay
In our previous build, the only way to exit the game was to close the build through ```ALT + F4``` or through the ```Task Manager```. Now we have a dedicated button to quit the game at any time, which is more convenient for the user. We also made the game pause when the player wins or dies, which gives the user a better idea of when the game is over especially when the player wins as in Assignment 1, the player will continue to over around which may be confusing. As part of testing our project, we added a button that will unpause the game if the user wants to see the effects on our player and a restart button for if the user wants to play again.

#### Enemy Models
We have changed the enemy models from the primiative capsules to [Dog Knights](https://assetstore.unity.com/packages/3d/characters/animals/dog-knight-pbr-polyart-135227) which allowed us to apply our shaders to the enemy and display the full effect of our shaders like our player character does. We also modified the animator so that the animations are similar to the ones used for our player character.

#### Power-up gem
The power-up gem was not very visable in our previous gem due to the opacity changes. We moved away from a fading gem to have a pulsing gem effect using extrusion to make the gem seem to grow and shrink, which was done by having 2 rendering of the gem; the center gem is of a solid color and is the "main body" for the gem while the extruded rendering has the extrusion value changed over time to make the gem seem to grow and shrink.

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Course_Project/Graphics_GemImprovementsAid.gif?raw=true)

### Texturing
Almost everything is now textured!
 - Textures have been added to:
 - Enemies
 - Props (Tower,Bush,Tree)
 - Ground
 - Waves

Textures are implemented alongside a 'bool' that enables or disabled use of textures. When not enabled, a flat color is applied to the albedo instead.
NOTE: Due to lack of relevance, no texture is applied to the gems.

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Course_Project/Graphics_TextureTogglesAid.gif?raw=true)

### Visual Effects
#### Particles
4 particles systems were combined together to create a simple death effect for both the player and enemies. First the sparks from the impact of the metal sword on metal armor was created following the tutorial [EASY EXPLOSIONS in Unity - Particle System vs VFX Graph](https://www.youtube.com/watch?v=adgeiUNlajY) along side the flash particle. After following the sparks and flash particles, the following was changed to create the death VFX:
 - The sparks were given random rotations so that spark generation are not always the same and added 3 sub emitters: metal shrapnel, flash, and bloodsplat.
 - A copy of sparks was modified to create metal shrapnel effect by creating a new particle material and changing the ```Render Mode``` from ```Stretech Billboard``` to ```Mesh```, as well as, changing the amount of particles and size (including disabling ```Size Over Lifetime```) to fit with the effect.
 - Bloodsplat is a also a copy of sparks with larger emitter radius and different particle material for the red colour and a sub emitter of Blood cloud.
 - Blood cloud was created the same way metal shrapnel was however it used more particles however it keeps the ```Size Over Lifetime``` proptery and the emitter radius is the same size of Bloodsplat. This creates a dense red cloud-like effect that dissipates.

This particle system enhanced our previous version by creating a clearer and more noticable feedback of defeating an enemy or dying. The sparks and flash is a logical VFX for the metal sword hitting metal armour, the metal shrapnel comes from the impact of the powered up character (enemy or player) attacking, and the bloodsplat and blood cloud shows the power the power-ups give to the character. 

#### Stencil
In our previous version, we experienced concerns that the powerup gems could spawn behind our props. To remedy this, we wanted to make a stencil modification that would allow you to see behind the props if you hovered over them. In the scene, a sphere with a Stencil front is rendered invisibly and its position is updated via raycast to the cursor position each frame-tick via script. Our props have a modified but similar shader to the ground, adding the Stencil back functionality.

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Course_Project/Graphics_StencilAid.gif?raw=true)

#### Wave
In our previous version, you could see the skybox from below due to the lack of screen coverage. We decided to recontextualize our scene to be a proper island, and so we implemented waves. Our islands is circular (vaguely), and we found the waves moving linearly to be insufficient, so the wave shader has been modified to define a point on itself, and the waves collapse inward onto that location. For example, inputting 0 and 0 causes the waves to radially crash inwards towards our island. Amplitude, frequency, and speed are calculated traditionally. (I made a plane with far more vertices in blender to improve wave smoothness)

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Course_Project/Graphics_WavesAid.gif?raw=true)

#### Scrolling texture
Scrolling textures was also added to the waves to further increase the realism of the waves, making the water seem to move around. Additionally, we added a sea foam texture that is layered ontop of the waves that scrolls at a different speed which further increases the realism of the water texture.

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Course_Project/Graphics_ScrollingAid.gif?raw=true)

#### Outline/Extrude
Our characters have a bit of a visibility Issue. We wanted to supplement this, and we felt given the artstyle an outline would work best. We also knew this would be a good chance to improve on our 'dangerous' versus 'not dangerous' states of the characters. Our outline draws a second pass with a color variable a set distance off the mesh. Using our previous scripts, we added a modification to additionally change the outline color when the character is 'dangerous', and return to white when the character is no longer 'dangerous'.

![alt text](https://github.com/JL-40/Graphics_Assignment_1/blob/main/ReportImages/Course_Project/Graphics_OutlineAid.png?raw=true)

## Third-Party Resources and Credits - Course Project
The following third-party resources were added after Assignment 1. The reasoning for the models is the same as assignment 1, we used these assets to save time on modelling and animations and have no impact on the game aside from making the game look more pleasing than looking at primatives. A tutorial was followed for the particle system up but was changed as described in [Particles](#particles) section.
- New enemy model and animations by Dungeon Mason. [Dog Knight PBR Polyart](https://assetstore.unity.com/packages/3d/characters/animals/dog-knight-pbr-polyart-135227)
- Particle system tutorial by [Gabriel Aguiar Prod.](https://www.youtube.com/@GabrielAguiarProd) was used to create the sparks of the particle system. Video found here: [EASY EXPLOSIONS in Unity - Particle System vs VFX Graph](https://www.youtube.com/watch?v=adgeiUNlajY)
