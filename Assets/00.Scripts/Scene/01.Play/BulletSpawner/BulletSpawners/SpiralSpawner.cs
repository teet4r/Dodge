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
    [Tooltip("�� ���� �Ѿ��� ��� �߻�ǰ� ���� �߻������ ����")]
    public float spawnRate;
    [Tooltip("���� ������ �Ѿ��� �߻�Ǳ������ ����")]
    public float spawnInterval;
}
