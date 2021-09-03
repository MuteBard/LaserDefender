## DEV-24 Explosion particle effects
#### Tags: [particles, material, texture sheet animation module]

### Create VFX folder

![](../images/DEV-24-A.png)

### Create a Material

Right click > Create > material
set Albedo to your picture
set the shader to particles standard surface
change Rendering mode to Cutout

![](../images/DEV-24-B.png)

### Create a Particle System

Create in the hierarchy
effects > Particle System

Changed the Emission rate, shape, color, speed, lifetime, 

![](../images/DEV-24-C.png)

### Update Enemy Script

![](../images/DEV-24-D.png)

![](../images/DEV-24-E.png)

### Issues
we did not use the Texture sheet animation module for this unfortunately