using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    public float speed;

    protected Vector3 moveDirection;
    protected float magnitude;
    protected BulletType type;

    public GameObject GetBulletGameObject => gameObject;

    public BulletType GetBulletType => type;

    public virtual void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }

    public virtual void SetType(BulletType type)
    {
        this.type = type;
    }

    public virtual void Refresh()
    {
        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
            magnitude = transform.position.sqrMagnitude;

            if (magnitude > 20)
                ObjectPool.Instance.Add(type, this);
        }
    }

    public void Pool()
    {
        gameObject.SetActive(false);
    }

    public void Depool()
    {
        gameObject.SetActive(true);
    }
}
