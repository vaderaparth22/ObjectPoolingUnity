using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform[] gunPoints;

    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    public void Shoot()
    {
        Transform randomPoint = GetRandomGunPoint();
        BulletManager.Instance.CreateRandomBullet(randomPoint);
    }

    Transform GetRandomGunPoint()
    {
        return gunPoints[Random.Range(0, gunPoints.Length)];
    }
}
