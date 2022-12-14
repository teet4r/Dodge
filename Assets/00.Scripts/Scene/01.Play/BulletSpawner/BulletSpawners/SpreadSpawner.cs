using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadSpawner : BulletSpawner
{
    protected override IEnumerator _Fire()
    {
        if (isFiring) yield break;
        isFiring = true;
        WaitForSeconds wfs = new WaitForSeconds(spreadSpawnerData.spawnRate);
        while (Player.instance.isAlive)
        {
            yield return wfs;

            float angle = 360f / spreadSpawnerData.bulletCountPerShot;
            for (int i = 0; i < spreadSpawnerData.bulletCountPerShot; i++)
            {
                var bullet = ObjectPool.instance.GetBullet();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(0f, i * angle, 0f);
                bullet.gameObject.SetActive(true);
            }
        }
        isFiring = false;
    }

    public SpreadSpawnerData spreadSpawnerData;
}
