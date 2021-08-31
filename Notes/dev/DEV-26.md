## DEV-26 Start Menu
#### Tags: [scenes, buttons, BreakPrefab Instance, fonts, textmeshpro]

### Create a level script

![](../images/DEV-26-A.png)

### Create a start scene

![](../images/DEV-26-B.png)

`right click on instance > prefab > unpack prefab`

to create a original copy ofd a prefab for the canvas

### Creating fonts

We will also import som text mesh pro fonts

![](../images/DEV-26-C.png)

We will ned to convert our batman forever fonts into text mes pro fonts

`Window > TextMeshPro > Font Asset Creator > Drag Drop font > Generate Font Atlas > Save As`

In heading text, replace `Font Asset` with the newly created font assets

![](../images/DEV-26-D.png)

![](../images/DEV-26-E.png)

Add in some color

![](../images/DEV-26-F.png)

Apply the second font

![](../images/DEV-26-G.png)

### Creating Buttons

Add a button component to a new texMeshPro text

![](../images/DEV-26-H.png)

drag the level game object into it
Be sure to select load game

![](../images/DEV-26-I.png)

Do the same for Quit functionality

For buttons to work, be sure that there is an eevent system in the hierarchy