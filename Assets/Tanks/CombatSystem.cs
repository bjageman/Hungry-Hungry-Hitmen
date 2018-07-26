using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSystem : MonoBehaviour {

	[SerializeField] GameObject bulletSpawn;
	[SerializeField] float bulletSpeed = 300f;
	[SerializeField] float bulletLifeSpan = 5f;
	[SerializeField] float fireRate = .5f;
	[SerializeField] int maxBullets = 10;

	[SerializeField] GridLayoutGroup bulletUI; 

	List<Bullet> bullets;

	float timeSinceLastShot;

	void Start(){
		bullets = new List<Bullet>();
		timeSinceLastShot = Time.time;
	}

	public void Shoot(){
		if (Time.time - timeSinceLastShot > fireRate)
        {
            timeSinceLastShot = Time.time;
			if (bullets.Count > 0){
				Bullet bullet = bullets[0];
				bullets.RemoveAt(0);
				SpawnBullet(bullet);
				RemoveBulletFromUI(bullet);
			}
        }
    }

    private void SpawnBullet(Bullet bullet)
    {
        GameObject bulletObject = Instantiate(bullet.gameObject, bulletSpawn.transform.position, transform.rotation);
        bulletObject.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
        Destroy(bulletObject, bulletLifeSpan);
    }

    public bool LoadBullet(Bullet bullet){
		if (bullet == null || bullets.Count >= maxBullets){ return false; }
		bullets.Add(bullet);
		AddBulletToUI(bullet);
		if (CheckForBulletCombo())
        {
            CreateSuperBullet();
        }
        return true;
	}

    private static void CreateSuperBullet()
    {
        print("CREATE SUPER BULLET (TBD)");
    }

    private bool CheckForBulletCombo()
    {
		Bullet previousBullet = null;
        for (int i = 0; i < bullets.Count && i <= 2; i++){
			Bullet currentBullet = bullets[bullets.Count - 1 - i];
			if (previousBullet){
				print(currentBullet.gameObject.name + " VS " + previousBullet.gameObject.name);
				}
			if (previousBullet != null && currentBullet != previousBullet ){
				return false;
			} else if (i == 2){ return true; }
			previousBullet = currentBullet;
		}
		return false;
    }

    private void AddBulletToUI(Bullet bullet)
    {
        GameObject bulletUIObject = new GameObject();
        Image bulletImage = bulletUIObject.AddComponent<Image>(); 
        bulletImage.sprite = bullet.GetComponent<SpriteRenderer>().sprite;
		bulletImage.transform.SetParent(bulletUI.transform);
    }

	private void RemoveBulletFromUI(Bullet bullet)
    {
        Image[] bulletImages = bulletUI.GetComponentsInChildren<Image>();
		Destroy(bulletImages[bulletImages.Length - 1].gameObject);
    }
}
