using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 pos = collision.contacts[0].point;
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, collision.contacts[0].normal);
        Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        collision.gameObject.transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
    }
}
