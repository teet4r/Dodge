using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : BulletSpawner
{
    protected override IEnumerator _Fire()
    {
        if (isFiring) yield break;
        isFiring = true;
        var wfsSpawnRate = new WaitForSeconds(targetSpawnerData.spawnRate);
        var wfsCfFireRate = new WaitForSeconds(targetSpawnerData.cfFireRate);
        while (Player.instance.isAlive)
        {
            yield return wfsSpawnRate;
            for (int i = 0; i < targetSpawnerData.cfFireCount; i++)
            {
                var bullet = ObjectPool.instance.GetBullet();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.transform.LookAt(Player.instance.transform);
                bullet.gameObject.SetActive(true);
                yield return wfsCfFireRate;
            }
        }
        isFiring = false;
    }

    public TargetSpawnerData targetSpawnerData;
}
