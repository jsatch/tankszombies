using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float mSpeed;
    public float mRotationSpeed;
    public float mDistanceRadiusStart;
    public float mDistanceRadiusStop;
    public Transform mTank;

    private bool isChasing = false;

    private void Update()
    {
        if (Vector3.Distance(mTank.position, transform.position) < mDistanceRadiusStart)
        {
            isChasing = true;
        }

        if (Vector3.Distance(mTank.position, transform.position) > mDistanceRadiusStop)
        {
            isChasing = false;
        }

        if (isChasing) Chase();
    }

    private void Chase()
    {
        //transform.LookAt(mTank);

        // direction angle
        Quaternion lookAtTank = Quaternion.LookRotation(mTank.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtTank, Time.deltaTime * mRotationSpeed);

        transform.Translate(0f, 0f, mSpeed * Time.deltaTime);
    }
}
