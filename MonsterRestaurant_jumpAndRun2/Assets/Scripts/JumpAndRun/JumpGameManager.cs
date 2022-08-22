using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class JumpGameManager : MonoBehaviour
{
    public GameObject TimeBar;
    public GameObject EndPanel;
    public GameObject SuccessPanel;

    //private AudioManager theAudio;//����
    //public string hitSound;//���� �̸�
    //public string onfloorSound;

    private void Start()
    {
       // theAudio = FindObjectOfType<AudioManager>(); //����
    }
    private void Update()
    {       

        if (!JumpDataManager.Instance.PlayerDie)
        {
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1�ʿ� 1���� ����
        // �̴��÷��̾� �̵�
            TimeBar.transform.Translate(0.5f * Time.deltaTime/9f, 0, 0);

            // ��Ʈ ������ ����
            if (MovePlayer.count == 3/*JumpDataManager.Instance.playTimeCurrent < 0 && JumpDataManager.Instance.heart !=0*/)
            {
                JumpDataManager.Instance.PlayerDie = true;
                EndPanel.SetActive(true);
            }      
        }

        // ��Ʈ�� �ְ� �ð��� �� �ƴٸ� SuccessPanel �ѱ�
        if(MovePlayer.count <= 3 && JumpDataManager.Instance.playTimeCurrent < 0)
        {
            JumpDataManager.Instance.PlayerDie = true;
            SuccessPanel.SetActive(true);
        }

    }

    //�ٽ� ���� ��ư�� �Լ� �߰�
    public void Restart_Btn()
    {
        //JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        EndPanel.SetActive(false);

    }

    //Ŭ���� ��ư�� �Լ� �߰�
    public void Success_Btn()
    {
        JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        SuccessPanel.SetActive(false);

    }

}
