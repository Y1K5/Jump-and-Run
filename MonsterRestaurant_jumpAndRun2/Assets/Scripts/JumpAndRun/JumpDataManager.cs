using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDataManager : MonoBehaviour
{
    // ���ο� ���� ���� ��� 
    static JumpDataManager instance;
    // ��� �Ǵ�
    public bool PlayerDie = false;
    // ���� ��Ʈ ������ �� 
    public int heart = 2;

    // ���� �÷��� Ÿ��
    public float playTimeCurrent = 90f;
    public float playTimeMax = 90f;
    public static JumpDataManager Instance
    {
        get
        {
            return instance;
        }

    }
    private void Awake()
    {
        //if(heart == 0)
        //{
        //    PlayerDie = true;
        //}

        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }


}
