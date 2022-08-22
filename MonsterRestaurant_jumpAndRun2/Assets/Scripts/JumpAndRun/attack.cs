using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    public GameObject attackCollider;
    public GameObject attackCanvas;



    // �ٴڰ� �浹 �� (���� �� �����ϸ�) ���� & Block�� �浹 �� ��Ʈ -1 ����
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.CompareTo("Block") == 0)
        {
           if (Input.GetKey(KeyCode.Space) &&  collision.gameObject.layer == LayerMask.NameToLayer("Object"))
            {
                attackCanvas.SetActive(true);
                Invoke("Close", 0.5f);
                Debug.Log("���Ͷ� �ε���" + collision.gameObject);
                collision.gameObject.SetActive(false);
                //theAudio.Play(hitSound);  // ��ġ���� �ּ�ó�� ���ֱ�
            }
        }
    }

    public void Close()
    {
        attackCanvas.SetActive(false);
    }
}

