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
        WaitForSeconds spawnRateWfs = new WaitForSeconds(spawnRate);
        WaitForSeconds spawnIntervalWfs = new WaitForSeconds(spawnInterval);
        while (Player.instance.isAlive)
        {
            yield return spawnRateWfs;

            for (int i = 0; i < spawnCount; i++)
            {
                var bullet = ObjectPool.instance.GetBullet();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(0f, i * angle, 0f);
                bullet.gameObject.SetActive(true);
                yield return spawnIntervalWfs;
            }
        }
        isFiring = false;
    }

    public float angle;
    public int spawnCount;
    [Tooltip("한 차례 총알이 모두 발사되고 다음 발사까지의 간격")]
    public float spawnRate;
    [Tooltip("다음 각도의 총알이 발사되기까지의 간격")]
    public float spawnInterval;
}
