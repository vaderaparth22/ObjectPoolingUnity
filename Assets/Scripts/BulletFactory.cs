using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BulletType
{
    Diamond,
    Polygon,
    Hexagone
}

public class BulletFactory
{
    #region Singleton
    private static BulletFactory instance;

    public static BulletFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BulletFactory();
            }
            return instance;
        }
    }
    #endregion

    
    BulletType bulletType;
    Dictionary<BulletType, Bullet> loadedBullets = new Dictionary<BulletType, Bullet>();

    private BulletFactory() { }

    public void Initialize()
    {
        LoadBulletsInDictionary();
    }

    void LoadBulletsInDictionary()
    {
        loadedBullets.Add(BulletType.Diamond, Resources.Load<Diamond>("Bullets/diamond"));
        loadedBullets.Add(BulletType.Polygon, Resources.Load<Polygon>("Bullets/polygon"));
        loadedBullets.Add(BulletType.Hexagone, Resources.Load<Hexagone>("Bullets/hexagone"));
    }

    public BulletType GetRandomBulletType()
    {
        int randomNumber = UnityEngine.Random.Range(0, Enum.GetValues(typeof(BulletType)).Length);
        return (BulletType)randomNumber;
    }

    public Bullet CreateBulletDefault(BulletType type, Vector3 pos)
    {
        Bullet newBullet = GameObject.Instantiate(loadedBullets[type], pos, Quaternion.identity);
        newBullet.transform.SetParent(BulletManager.Instance.bulletParent);
        newBullet.SetType(type);

        return newBullet;
        
    }

    public Bullet CreateRandomBullet(Vector3 pos)
    {
        BulletType type = GetRandomBulletType();
        Bullet newBullet = null;

        IPoolable bulletStack = ObjectPool.Instance.Retrieve(type);

        if (bulletStack != null)
        {
            newBullet = bulletStack.GetBulletGameObject.GetComponent<Bullet>();
            newBullet.SetType(bulletStack.GetBulletType);
            newBullet.transform.position = pos;
        }
        else
            newBullet = CreateBulletDefault(type, pos);

        return newBullet;
    }
}
