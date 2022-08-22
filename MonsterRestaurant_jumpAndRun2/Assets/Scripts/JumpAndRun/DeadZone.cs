using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!JumpDataManager.Instance.PlayerDie)
        {
            if(collision.gameObject.tag.CompareTo("Player") == 0)
            {
                JumpDataManager.Instance.PlayerDie = true;
            }
        }
    }
}
