using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float S = 10f;
    [SerializeField] float MaxRange = 10f;
    Vector3 StartPos;

    void Start()
    {
        StartPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.up * S * Time.deltaTime);
        DestroyBullet();

    }
    void DestroyBullet()
    {
        if (Vector3.Distance(StartPos, transform.position) > MaxRange)
        {
            Destroy(gameObject);
            Debug.Log("destroy");
        }

    }
}
