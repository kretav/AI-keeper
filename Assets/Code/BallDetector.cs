using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 1. checking goal
        if (other.CompareTag("GoalTrigger"))
        {
            Debug.Log("[GOAL] Keeper missed the ball!");
            KeeperLearning keeper = GameObject.Find("KeeperAgent").GetComponent<KeeperLearning>();
            keeper.SetReward(-1.0f);
            keeper.EndEpisode();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 2. checking save
        if (collision.gameObject.CompareTag("KeeperAgent"))
        {
            Debug.Log("[SAVE] Great defense!");
            KeeperLearning keeper = collision.gameObject.GetComponent<KeeperLearning>();
            keeper.SetReward(1.0f);
            keeper.EndEpisode();
            Destroy(gameObject);
        }
    }
}
