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

    //private AudioManager theAudio;//사운드
    //public string hitSound;//사운드 이름
    //public string onfloorSound;

    private void Start()
    {
       // theAudio = FindObjectOfType<AudioManager>(); //사운드
    }
    private void Update()
    {       

        if (!JumpDataManager.Instance.PlayerDie)
        {
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1초에 1씩만 빼기
        // 미니플레이어 이동
            TimeBar.transform.Translate(0.5f * Time.deltaTime/9f, 0, 0);

            // 하트 없으면 죽음
            if (MovePlayer.count == 3/*JumpDataManager.Instance.playTimeCurrent < 0 && JumpDataManager.Instance.heart !=0*/)
            {
                JumpDataManager.Instance.PlayerDie = true;
                EndPanel.SetActive(true);
            }      
        }

        // 하트가 있고 시간이 다 됐다면 SuccessPanel 켜기
        if(MovePlayer.count <= 3 && JumpDataManager.Instance.playTimeCurrent < 0)
        {
            JumpDataManager.Instance.PlayerDie = true;
            SuccessPanel.SetActive(true);
        }

    }

    //다시 시작 버튼용 함수 추가
    public void Restart_Btn()
    {
        //JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        EndPanel.SetActive(false);

    }

    //클리어 버튼용 함수 추가
    public void Success_Btn()
    {
        JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        SuccessPanel.SetActive(false);

    }

}
