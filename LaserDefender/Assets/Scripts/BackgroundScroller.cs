using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offSet;

    void Start(){
        //Renderer is Mesh Renderer and we are a accessing the material
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update(){
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }

}
