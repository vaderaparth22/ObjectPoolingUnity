using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletManager
{
    #region Singleton
    private static BulletManager instance;

    public static BulletManager Instance
    {
        get
        {
            if (instance == null)
                instance = new BulletManager();

            return instance;
        }
    }
    #endregion

    public Transform bulletParent;

    Dictionary<BulletType, List<Bullet>> spawnedBullets = new Dictionary<BulletType, List<Bullet>>();

    private BulletManager() { }

    public void Initialize()
    {
        CreateBulletParent();
    }

    public void UpdateBulletManager()
    {
        foreach (KeyValuePair<BulletType, List<Bullet>> kv in spawnedBullets)
            foreach (Bullet bullet in kv.Value)
                bullet.Refresh();
    }

    void CreateBulletParent()
    {
        bulletParent = new GameObject().transform;
        bulletParent.name = "BulletParent";
    }

    public void CreateRandomBullet(Transform gunPoint)
    {
        Bullet bullet = BulletFactory.Instance.CreateRandomBullet(gunPoint.position);
        bullet.SetMoveDirection(gunPoint.up);

        BulletType type = bullet.GetBulletType;
        AddBulletInDictionary(type, bullet);
    }

    void AddBulletInDictionary(BulletType type, Bullet bullet)
    {
        if (!spawnedBullets.ContainsKey(type))       //if this bullet is not in the dictionary
        {
            spawnedBullets.Add(type, new List<Bullet>() { bullet });
        }
        else if (!spawnedBullets[type].Contains(bullet))        //if this bullet is in dictionary but not in the list (value of dictionary)
        {
            spawnedBullets[type].Add(bullet);
        }
    }
}
