using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlow : MonoBehaviour
{
    void Start()
    {
        BulletManager.Instance.Initialize();
        BulletFactory.Instance.Initialize();
    }

    
    void Update()
    {
        BulletManager.Instance.UpdateBulletManager();
    }
}
