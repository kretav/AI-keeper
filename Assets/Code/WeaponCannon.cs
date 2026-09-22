using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCannon : MonoBehaviour
{

    // 1. public variables
    public GameObject ballPrefab;
    public float forwardForce = 15f;
    public Transform targetKeeper;

    // 2. strting timer in Start()
    void Start()
    {
        InvokeRepeating("ShootBall", 1f, 3f);
    }

    // 3. Logic of method ShootBall()
    void ShootBall()
    {
        // A: Ball spawn. Creating prefab copy in cannon
        GameObject crystalBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // B: physic searching. fingштп Rigidbody from ball
        Rigidbody ballRb = crystalBall.GetComponent<Rigidbody>();

        // C: Random power vector
        Vector3 pushDirection = new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 5f), forwardForce);

        // D: Phusic impulse. Pushing ball
        ballRb.AddForce(pushDirection, ForceMode.Impulse);
    }
}

