using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    #region Bullet
    public Bullet GetBullet()
    {
        if (bulletQ.Count == 0)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            return bullet;
        }
        return bulletQ.Dequeue();
    }

    public void ReturnBullet(Bullet bullet)
    {
        if (bullet == null) return;
        bullet.gameObject.SetActive(false);
        bulletQ.Enqueue(bullet);
    }
    #endregion

    public static ObjectPool instance = null;

    public Bullet bulletPrefab;

    Queue<Bullet> bulletQ = new Queue<Bullet>();
}
