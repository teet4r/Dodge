using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpiralSpawner : BulletSpawner
{
    protected override IEnumerator _Fire()
    {
        if (isFiring) yield break;
        isFiring = true;
        WaitForSeconds spawnRateWfs = new WaitForSeconds(spiralSpawnerData.spawnRate);
        WaitForSeconds spawnIntervalWfs = new WaitForSeconds(spiralSpawnerData.spawnInterval);
        while (Player.instance.isAlive)
        {
            yield return spawnRateWfs;

            for (int i = 0; i < spiralSpawnerData.spawnCount; i++)
            {
                var bullet = ObjectPool.instance.GetBullet();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(0f, i * spiralSpawnerData.angle, 0f);
                bullet.gameObject.SetActive(true);
                yield return spawnIntervalWfs;
            }
        }
        isFiring = false;
    }

    public SpiralSpawnerData spiralSpawnerData;
}
