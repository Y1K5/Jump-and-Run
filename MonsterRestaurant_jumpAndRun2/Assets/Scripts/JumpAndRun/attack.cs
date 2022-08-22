using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    public GameObject attackCollider;
    public GameObject attackCanvas;



    // 바닥과 충돌 시 (점프 후 착지하면) 동작 & Block과 충돌 시 하트 -1 감소
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.CompareTo("Block") == 0)
        {
           if (Input.GetKey(KeyCode.Space) &&  collision.gameObject.layer == LayerMask.NameToLayer("Object"))
            {
                attackCanvas.SetActive(true);
                Invoke("Close", 0.5f);
                Debug.Log("몬스터랑 부딪힘" + collision.gameObject);
                collision.gameObject.SetActive(false);
                //theAudio.Play(hitSound);  // 합치고나서 주석처리 없애기
            }
        }
    }

    public void Close()
    {
        attackCanvas.SetActive(false);
    }
}

