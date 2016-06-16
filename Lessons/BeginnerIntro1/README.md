#Beginner's Lesson 1 - Simple Platformer
In this lesson we make a simple platformer. First, we use our own very simple physics to move around a sprite, then we switch over to using Unity's physics.

Start with "SimpleMovement" and the "Movement.unity" scene.

Then, check out "PhysicsMovement" and the "PhysicsMovement.unity" scene.

Finally, have a look at "FullGame" and the "FullGame.unity", "WonGame.unity", and "GameOver".unity scenes.

##Steps
These are the files that each step has changes in or introduces.

* Step 1
    * Mover.cs
    * hero.png
    * Movement.unity
* Step 2
    * Mover.cs
* Step 3
    * Mover.cs
* Step 4
    * Mover.cs
* Step 5
    * Mover.cs
* Step 6
    * Mover.cs
    * Controller.cs
* Step 7
    * Mover.cs
    * Controller.cs
* Step 8
    * Mover.cs
    * Controller.cs
* Step 9
    * Controller.cs
* Step 10
    * Mover.cs
    * Controller.cs
* Step 11
    * PhysicsMover.cs
    * PhysicsController.cs
    * PhysicsMovement.unity
    * ground.png
* Step 12
    * PhysicsMover.cs
    * PhysicsController.cs
* Step 13
    * PhysicsMover.cs
* Step 14
    * Spike.cs
    * FullGame.unity
    * spikes.png
* Step 15
    * Spike.cs
* Step 16
    * Spike.cs
    * GameOver.unity
* Step 17
    * Goal.cs
    * gold.gif
    * WonGame.unity
    
##Loading other scenes
In order to load another scene (such as WonGame or GameOver) from code (SceneManager.LoadScene), it must exist within your Unity build settings. To add it there, go to File>Build Settings... (or press Shift-Command-B). Then, drag the unity scenes from the project view into the "Scenes In Build" area. Any scene you want to load MUST be in this area or you will get an error.