using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : BulletSpawner
{
    protected override IEnumerator _Fire()
    {
        if (isFiring) yield break;
        isFiring = true;
        while (Player.instance.isAlive)
        {
            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));

            var bullet = ObjectPool.instance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.LookAt(Player.instance.transform);
            bullet.gameObject.SetActive(true);
        }
        isFiring = false;
    }

    public float spawnRateMin;
    public float spawnRateMax;
}
