# Game-engines-2019-20
 - Repository for holding my 2019/2020 Game Engines Unity Project.

# Project Proposal
 - An **interactive** Audio-Visualiser **game**
 - Players will take control of a **starship/turret** in the bottom centre of the screen 
   (somewhere between the * *Dead Space* * & * *Star Fox* * gameplay below)

   ![](dead-space-turret.gif)
   ![](Star-Fox.gif)

 - **Asteroids** will be **procedurally created** in the path of the player and they will need to destroy them to survive
 - The obstacles which arise will be **randomly generated** (i.e. things will not spawn in the same place/order on consecutive playthroughs)
 - Asteroids the player destroys and power-ups they collect will afford them **extra points**
 - Though there will be a score-system implemented, the **main goal** of this project will be **to display impressive visuals** to the accompanying music track
 - Whatever **audio** is being played in the background **will affect the visual space** on-screen
   (similar to the visualiser below)

   ![](Audio-Visualiser.gif)
 
# Features / Feature Implementation Checklist
 - [ ] Turrets follow mouse cursor/screen centre at delayed rate
	- Camera to world-point so turrets know what to aim towards – maybe do so by having a canvas out in front of the ship with a reticle on it which moves around via mouse-pointer/right controller-joystick
 - [ ] Both turrets fire in tandem and reload together
	- Either turrets fire together, or which turret that fires depends on which mouse button/controller-trigger is pressed
	- If so then each turret reloads when empty or maybe energy returns over time when not being fired – maybe even a mix of both
	- If turret is not being fired it regains charge, however if player presses reload the battery of both turrets gets changed – full ammo
	- If one turret runs out either both automatically get new batteries or maybe only the empty one will
 - [ ] Holographic display above turrets show ammo count/energy remaining
	- Place canvas in world-space above/beside each turret
	- Assign the TMP element as the ammo display – digital font
	- Colour to make seem like hologram
 - [ ] Spawn asteroids
	- Create range for where asteroids spawn from – large quad maybe
	- Choose random point from range and Spawn()
	- Asteroids have health elements – maybe bigger asteroids take more shots to destroy
 - [ ] Randomly generate asteroid shape
	- No idea how to do this – fingers crossed there’s a Brackeys tutorial lol
 - [ ] Asteroid flies towards ship
	- Start()/OnAwake() – add force between range to decide asteroid speed
	- Possibly give asteroid an angle variable so they don’t all fly straight
 - [ ] Asteroid damages ship hull integrity on collision
	- Asteroids explode either on contact with ship – causing damage to it (if various asteroid sizes, damage will depend on size)
	- Or asteroids explode when health reaches 0
 - [ ] Starry background moves to show player momentum
	- Skybox maybe just scrolls behind player if that’s possible – maybe alter speed when ship gains momentum or under other circumstances – perhaps as players survive the ship speeds up and score begins to increase exponentially
 - [ ] Player flies towards effect being made by sound input
	- Blackhole-like target in the centre of screen that player is constantly flying toward
	- Blackhole pulses/changes shape/colour based on music being input either via desktop (if possible) or simply through mic
 - [ ] Player can move up/down/left/right to avoid danger
	- Input axis determines ship moving in game world-space, this will need a maximum distance in any direction
 - [ ] Powerups – infinite ammo for short time, invincibility, regain health, bonus points
	- Powerups will need to be flown into or perhaps shot to collect them – some may take more shots than others depending on their value to gameplay
 - [ ] Controller support – stretch goal
	- Should be a simple matter of adding controller key-binds as the alt input of all other controls
