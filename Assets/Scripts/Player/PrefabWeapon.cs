using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public Animator animator;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			animator.SetTrigger("Throw");
			SoundManager.instance.PlayShootClip();
			//Shoot();
		}
		if (Input.GetButtonDown("Fire2"))
		{
			animator.SetTrigger("IsAttacking");
			SoundManager.instance.PlaySwingAxeClip();
			//Shoot();
		}
	}

	void Shoot ()
	{
		//animator.ResetTrigger("Throw");
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
