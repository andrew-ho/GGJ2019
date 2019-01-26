using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using EZObjectPools;

public class Gun : MonoBehaviour {

	public GameObject bulletPrefab;
    public float shotDelay = 0.3f;

    private EZObjectPool bulletPool;
    private float time = 99f;

	void Awake () {
		//Object pool parameters: (object, name of pool, starting pool size, auto resize (should be true), instantiate immediate (should be true), shared pools)
		bulletPool = EZObjectPool.CreateObjectPool(bulletPrefab, "Bullets", 30, true, true, true);
	}

	void Start () {
		
	}
	
	void Update () {
		//can fire every [shotDelay] seconds while right click is held
		if (Input.GetButton("Fire2") && time > shotDelay) {
            Shoot();
            time = 0;
        }

        time += Time.deltaTime;
	}

	void Shoot() {
		bulletPool.TryGetNextObject(transform.position+(3.0f*transform.forward), transform.rotation);
    }
}