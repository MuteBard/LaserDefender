using System.Transactions;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Config Fields
    [Header("Movement")]
    WaveConfig waveConfig;
    List<Transform> waypoints;
    float moveSpeed;
    int waypointIndex = 0;

    [Header("HP")]
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;

    [Header("Firing")]
    [SerializeField] float minTimeBetweenShots = .2f;
    [SerializeField] float maxTimeBetweenShots = 1f;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] GameObject enemyFrontLaser;
    
    [Header("Visual Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    [Header("Sound Effects")]
    [SerializeField] AudioClip laserSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float laserSFXVolume = 0.5f;
    [SerializeField] [Range(0,1)] float deathSFXVolume = 1f;

    void Start(){
        waypoints = waveConfig.GetWaypoints();
        moveSpeed = waveConfig.GetMoveSpeed();
        transform.position = waypoints[waypointIndex].transform.position;
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    void Update(){
        Move();
        CountDownAndShoot();
    }

    private void CountDownAndShoot(){
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0){
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire(){
        GameObject newEnemyLaser = Instantiate(enemyFrontLaser, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserSFXVolume);
        newEnemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed * 5);
    }

    public void SetWaveConfig(WaveConfig waveConfig){ this.waveConfig = waveConfig; }

    private void Move(){
        if(waypointIndex <= waypoints.Count - 1){
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition){
                waypointIndex++;
            }
        }else{
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(damageDealer){
            ReceiveDamage(damageDealer);
        }
    }

    private void ReceiveDamage(DamageDealer damageDealer)
    {
        
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
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }
}

