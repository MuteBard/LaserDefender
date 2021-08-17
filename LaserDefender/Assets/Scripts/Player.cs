using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Serialized Fields
    [Range(5f, 15f)] [SerializeField] float moveSpeed = 10;
    [SerializeField] float paddingRest = 1f;
    [SerializeField] float paddingTop = 10f;

    //Player constants
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    //Project Settings constants
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
    }

    private void Move(){
        var deltaX = Input.GetAxis(HORIZONTAL) * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis(VERTICAL) * Time.deltaTime * moveSpeed;

        var newXPos = clampMovement(transform.position.x, deltaX, xMin, xMax);
        var newYPos = clampMovement(transform.position.y, deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private float clampMovement(float position, float delta, float min, float max){
        return Mathf.Clamp(position + delta, min, max);
    }

    private void SetUpMoveBoundaries(){
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingRest;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingRest;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingRest;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingTop;
    }
}
