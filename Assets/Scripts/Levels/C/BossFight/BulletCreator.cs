using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCreator : MonoBehaviour
{
    //private List<GameObject> bullets;

    private Slider _slider;
    private BoxCollider2D _bossBoxCollider;
    private GameObject _boss;    
   
    public Font font;
    

    void Start()
    {
        _boss = GameObject.Find("NullTerminator");
        _bossBoxCollider = _boss.GetComponent<BoxCollider2D>();
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    void Update()
    {
        foreach (var bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            if(bullet.GetComponent<BoxCollider2D>())
            if (_bossBoxCollider.IsTouching(bullet.GetComponent<BoxCollider2D>()))
            {
                _slider.value--;
                Destroy(bullet);
                _boss.GetComponent<Rigidbody2D>().AddForce(new Vector2(10,5));
                return;
            }
        }
    }

    public void SetBullet(Vector2 playerPosition, BoxCollider2D playerBoxCollider)
    {
        var bulletObject = new GameObject("bulletObject") {tag = "Bullet"};
        bulletObject.transform.localScale = new Vector2(0.5f, 0.5f);
        bulletObject.transform.position = playerPosition;
        
        
        var rigidBody = bulletObject.AddComponent<Rigidbody2D>();
        rigidBody.position = playerPosition;
        rigidBody.velocity = new Vector2(10, 0) * (Math.Sign(playerBoxCollider.offset.x));
        rigidBody.gravityScale = 0;

        bulletObject.AddComponent<BoxCollider2D>();
        bulletObject.AddComponent<MeshRenderer>();

        var text = bulletObject.AddComponent<TextMesh>();
        text.font = GetComponent<Font>();
        text.color = Color.grey;
        text.text = ((char)Math.Round(UnityEngine.Random.Range(33.0f, 125.0f))).ToString();
        
        Destroy(bulletObject, 0.4f);
    }
}