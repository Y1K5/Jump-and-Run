using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    Vector2 _position;
    Rigidbody2D rigid;
    Vector3 dirVec;
    GameObject scanObject;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Direction
            dirVec = Vector3.right;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Scan Object
    //    if (Input.GetKey(KeyCode.A) && collision.gameObject.layer.CompareTo("Object") == 0)
    //    {
    //        scanObject.SetActive(false);
    //    }

    //}

    private void FixedUpdate()
    {
        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, dirVec, 5.0f, LayerMask.GetMask("Object"));

        if (rayhit.collider != null)
        {
            scanObject = rayhit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
