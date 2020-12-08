using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    void Pool();
    void Depool();
    GameObject GetBulletGameObject { get; }
    BulletType GetBulletType { get; }
}
