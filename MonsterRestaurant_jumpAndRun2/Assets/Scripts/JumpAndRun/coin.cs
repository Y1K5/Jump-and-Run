using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Player") == 0)
        {
            JumpDataManager.Instance.heart += 1;
            // �� �ڽ��� ȭ�鿡�� ��
            gameObject.SetActive(false);
        }
    }
}
