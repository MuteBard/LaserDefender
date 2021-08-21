using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //Config Fields
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    [Range(1f, 10f)] [SerializeField] float moveSpeed;
    int waypointIndex = 0;

    void Start(){
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }
    void Update(){
        Move();
    }

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
}

