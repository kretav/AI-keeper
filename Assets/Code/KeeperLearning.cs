using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class KeeperLearning : Agent
{
    public Rigidbody rb;
    public Transform ballTransform;
    public float moveSpeed = 15f;



    public override void OnEpisodeBegin()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = new Vector3(-9.76f, 1f, 26.55f); 
    }


    public override void CollectObservations(VectorSensor sensor)
    {
        // giving 3 parameters to the ai
        sensor.AddObservation(transform.position.x);
        sensor.AddObservation(ballTransform.position.x);
        sensor.AddObservation(ballTransform.position.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {    
        // read every command
        float moveSignal = actions.ContinuousActions[0];
        rb.velocity = new Vector3(moveSignal * moveSpeed, rb.velocity.y, rb.velocity.z);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // keyboard input
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxisRaw("Horizontal");
    }
    

}


