# Physics Based Car Controller

## What this is: 
This is a car controller I made that does NOT uses Unity's built in wheel colliders or any other tool that one would use to make a car,
rather everything is raycast based, using actual physics formulas to calculate car behaviour. 
## Breakdown: 
The car consists of four parts: 
- Suspensions
- Grip
- Engine
- Steering

To simulate the suspensions one has to first get a spring in all 4 of the tires, with the formula Force = k*x where k is the spring constant and x is its dislacement from its rest position.
But having just a spring will make the car go boing boing or in other words it will keep oscillating forever, To counter this in real life suspensions always come with damper, 
they absorb a part of the oscillation energy in every cycle making the rocking slow down eventually. 
The dampers are simulated by them being proportional to a tyre's velocity , coz a slow moving tyre requires less damping and a fast moving one requires more. 

For lateral Grip, each tyre is always calculating the amount of lateral velocity it has, tyres love to roll in the direction they are made to but dont like it when they are slid side to side. Thus an opposing force proportional to the lateral velocity of the tyre will act upon it and over time cancel out the lateral velocity. 

For Engine, i made the decision to have a rear wheel drive car for this project, so according to the throttle, an acceleration is induced upon the car divided between the last two tyres. 
But as happens in real life, a car does not accelerate indefinitely. as the car approaches its top speed the acceleration produced by the rear tyres drop down exponentially, thus the car cannot accelerate beyond its top speed on its own. 

For the steering, i just had to rotate the front tyres at a turn angle and the lateral grip they had caused the tyre to rotate. Also i got to know that as a car speeds up it becomes less responsive to steering due to rotational inertia, to implement that i added a dropoff similar to that of engine acceleration but to the turn angle this time. Thus as the car accelerates the turn angle becomes lesser and lesser so to turn properly one would have to slow down first.

## How to use it: 
- Just put your car model as a child of the "Car" gameobject.
- adjust "resting height" and "spring force" to match the cars height above ground/
- move tyre gameobjects to the tyre of your car models ( FL, FR, BL and BR)
- Play with the values to then make different type of cars!!!

## Tips:
- To make a drifty car, lower the friction coeffecients, that much is obvious but to make a car REALLY drift then remember to have the rear friction coeffecient slightly less than the front one. 
- The camera's FOV also changes with cars speed for immersion so there's taht to play around with aswell.

## Credits: 
- Skybox: by rpgwhitelock
- Music: by Rosa Walton and Hallie Coggins
- Terrain Textures: by A god's life software

