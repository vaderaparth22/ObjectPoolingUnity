using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    #region Singleton
    private static ObjectPool instance;

    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObjectPool();
            }
            return instance;
        }
    }
    #endregion

    Dictionary<BulletType, Stack<IPoolable>> bulletPool = new Dictionary<BulletType, Stack<IPoolable>>();

    public Transform objectPoolParent;

    private ObjectPool()
    {
        objectPoolParent = new GameObject().transform;
        objectPoolParent.name = this.ToString();
    }

    public void Add(BulletType bulletType, IPoolable poolable)
    {
        if (!bulletPool.ContainsKey(bulletType))
            bulletPool.Add(bulletType, new Stack<IPoolable>());

        bulletPool[bulletType].Push(poolable);
        poolable.GetBulletGameObject.transform.SetParent(objectPoolParent);
        poolable.GetBulletGameObject.SetActive(false);
        poolable.Pool();
    }

    public IPoolable Retrieve(BulletType bulletType)
    {
        if (bulletPool.ContainsKey(bulletType) && bulletPool[bulletType].Count > 0)
        {
            IPoolable bulletToRet = bulletPool[bulletType].Pop();
            bulletToRet.GetBulletGameObject.SetActive(true);
            bulletToRet.Depool();
            return bulletToRet;
        }

        return null;
    }
}
