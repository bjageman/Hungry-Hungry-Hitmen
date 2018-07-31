using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankUI : MonoBehaviour {

	[SerializeField] RectTransform panel;
	[SerializeField] Text tankName;
	[SerializeField] Text currentHealth;
	[SerializeField] GridLayoutGroup bullets; 

	public RectTransform Panel { 
		get { return panel;}
		set { panel = value;}
	}

	public Text TankName { 
		get { return tankName;}
		set { tankName = value;}
	}

	public Text CurrentHealth { 
		get { return currentHealth;}
		set { currentHealth = value;}
	}

	public void AddBulletToUI(Bullet bullet)
    {
        GameObject bulletUIObject = new GameObject();
        Image bulletImage = bulletUIObject.AddComponent<Image>(); 
        bulletImage.sprite = bullet.GetComponent<SpriteRenderer>().sprite;
		bulletImage.transform.SetParent(bullets.transform);
    }

	public void RemoveBulletFromUI(Bullet bullet)
    {
        Image[] bulletImages = bullets.GetComponentsInChildren<Image>();
		Destroy(bulletImages[0].gameObject);
    }

}
