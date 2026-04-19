using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bullerPrefab;
    public Transform bulletSpawm;
    public float bulletVelocity = 30;
    public float bulletLifeTime = 3f;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            FireWeapon();
        }
		
	}

    private void FireWeapon() {
        GameObject bullet = Instantiate(bullerPrefab, bulletSpawm.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawm.forward.normalized * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}