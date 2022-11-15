using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(_Fire());
    }

    IEnumerator _Fire()
    {
        if (isFiring) yield break;
        isFiring = true;
        Player player = Player.instance;
        while (player.isAlive)
        {
            var bullet = ObjectPool.instance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.LookAt(player.transform);
            bullet.gameObject.SetActive(true);
            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        }
        isFiring = false;
    }

    public float spawnRateMin;
    public float spawnRateMax;

    public bool isFiring;
}
