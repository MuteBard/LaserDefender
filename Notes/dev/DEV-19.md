## DEV-19 Make the enemy shoot
#### Tags: [projectiles, collision, avoiding selfdamage]


We want the enemy to be able to shoot
We want the shots to be random
We want the enemy to shoot its own prefab of lasers
We will create a duplicate of the green laser prefab and make a red one

So that the enemy can shoot, we created an interval of time min to max of thew space of time it will take for an enemy to shoot.
when the counter time is decided and counted down to zero, then the enemy will shoot
Wanted the enemy to avoid killing itself with its own bullets so we created names for the lasers so that it will only get hurt by green lasers

![](../images/DEV-19-A.jpg)


![](../images/DEV-19-B.jpg)


We also made sure that the red lasers were a kinematic body opposed to the Dynamic body of the green laser

![](../images/DEV-19-C.jpg)
