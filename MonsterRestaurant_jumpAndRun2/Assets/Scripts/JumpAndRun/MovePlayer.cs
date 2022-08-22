using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jump = 12f;
    public float jump2 = 15f;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;


    int jumpCount = 0;
    static public int count = 0;


    private void Update()
    {

        if (!JumpDataManager.Instance.PlayerDie)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (jumpCount == 0) // 점프를 한 번도 안 함
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                    jumpCount += 1; // 점프 횟수 추가
                }
                else if (jumpCount == 1)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                }
            }
        }
    }

    public void Jump_press()
    {
        if (!JumpDataManager.Instance.PlayerDie)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (jumpCount == 0) // 점프를 한 번도 안 함
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                    jumpCount += 1; // 점프 횟수 추가
                }
                else if(jumpCount == 1)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                }
            }
        }
    }

    // 바닥과 충돌 시 (점프 후 착지하면) 동작 & Block과 충돌 시 하트 -1 감소
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject scanObject;

        if (collision.gameObject.tag.CompareTo("Land") == 0)
        {
            jumpCount = 0;
            //theAudio.Play(onfloorSound);
        }

        if (collision.gameObject.tag.CompareTo("Block") == 0)
        {
            scanObject = collision.gameObject;

                JumpDataManager.Instance.heart -= 1;
                // Debug.Log("부딪힘");
                Debug.Log(scanObject);

                count++;
        }


        if(collision.gameObject.tag.CompareTo("Heart") == 0)
        {
            count--;
        }

        if (count == 0)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        else if(count == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        else if(count == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
        else if(count == 3)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
    }

    
}
