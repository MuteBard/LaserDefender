
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Imported Game Objects 
    [Header("Player")]
    [Range(5f, 15f)] [SerializeField] float moveSpeed = 10;
    [SerializeField] float paddingTop = 10f;
    [SerializeField] float paddingRest = 1f;
    [SerializeField] int health = 200;

    [Header("Firing")]
    [SerializeField] GameObject frontLaser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    Coroutine firingCoroutine;

    [Header("Sound Effects")]
    [SerializeField] AudioClip laserSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float laserSFXVolume = 0.5f;
    [SerializeField] [Range(0,1)] float deathSFXVolume = 1f;

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
        Fire();
    }

    void OnTriggerEnter2D(Collider2D other){
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!!damageDealer){
            ReceiveDamage(damageDealer);
        } 
    }

    private void ReceiveDamage(DamageDealer damageDealer){
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health < 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        Destroy(gameObject);
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

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")){
            firingCoroutine = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1")){
            StopCoroutine(firingCoroutine);
        }
    }
    private IEnumerator FireContinously(){
        while(true){
            AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserSFXVolume);
            GameObject newFrontLaser = Instantiate(frontLaser, transform.position, Quaternion.identity) as GameObject;
            newFrontLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
