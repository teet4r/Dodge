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
    public void ReturnBullet(Bullet bullet, float returnTime = 0f)
    {
        if (bullet == null) return;
        if (returnTime < 0f) returnTime = 0f;
        StartCoroutine(_ReturnBullet(bullet, returnTime));
    }
    IEnumerator _ReturnBullet(Bullet bullet, float returnTime)
    {
        yield return new WaitForSeconds(returnTime);
        bullet.gameObject.SetActive(false);
        bulletQ.Enqueue(bullet);
    }
    #endregion

    public static ObjectPool instance = null;

    public Bullet bulletPrefab;

    Queue<Bullet> bulletQ = new Queue<Bullet>();
}
