﻿using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public void IvkShowGrandmaFaceUI()
    {
        imgUIBackGround.color = new Color(1, 1, 1, 1);
        Sprite GrandmaFaceSprite = Resources.Load<Sprite>("Sprites/GrandmaFace");
        imgUIBackGround.sprite = GrandmaFaceSprite;
        Invoke(nameof(IvkShowEndView), 5f);
    }

    public void IvkShowEndView()
    {
        imgUIBackGround.color = new Color(1, 1, 1, 1);
        Sprite EndViewSprite = Resources.Load<Sprite>("Sprites/EndView");
        imgUIBackGround.sprite = EndViewSprite;
        m_bReturnToBegin = true;
        playerCtrlr.m_bCanControl = true;
    }

    public void IvkShowDoorKey()
    {
        ShowHint(HintItemID.S1_Grandma_Room_Key);
    }

    public void IvkProcessGhostHandPushAnimator()
    {
        ProcessItemAnimator("Ghost_Hand", "Ghost_Hand_Push");
        Invoke(nameof(IvkProcessPlayerWakeUpSecondTime), 3.5f);

        ShowHint(HintItemID.S2_Room_Door);
        ShowHint(HintItemID.S2_Light_Switch);
    }

    public void IvkProcessPlayerWakeUpSecondTime()
    {
        Light playerFlashlight = playerCtrlr.tfPlayerCamera.GetComponent<Light>();
        playerFlashlight.enabled = false;
        audManager.Play(1, "Falling_To_Black_Screen_Sound_Part2", false);
        Animation am = playerCtrlr.GetComponent<Animation>();
        am.Stop();
        ProcessPlayerAnimator("Player_Wake_Up_SecondTime");
    }

    public void IvkShowS2DoorKey()
    {
        ShowHint(HintItemID.S2_Room_Key);
    }

    void IvkS1_SetGhostHandPosition()
    {
        // 鬼手出現
        GameObject GhostHandObj = GameObject.Find("Ghost_Hand");
        GhostHandObj.transform.position = new Vector3(-8.5f, 0, 6);
    }

    public void IvkS1_SetGrandmaGhostPosition()
    {
        S2_Grandma_Ghost_Obj.GetComponent<Animator>().applyRootMotion = true;
        S2_Grandma_Ghost_Obj.transform.localPosition = new Vector3(-8f, -2f, 2.35f);

        TempBoxCollider = GameObject.Find("Lv1_Filial_Piety_Curtain").GetComponent<BoxCollider>();
        TempBoxCollider.enabled = true;
    }

    public void IvkS2_Grandma_Pass_Door()
    {
        S2_Grandma_Ghost_Obj.GetComponent<Animator>().applyRootMotion = true;
        ShowHint(HintItemID.S2_Toilet_Door);
    }

    public void IvkS2_Shocked_By_Toilet()
    {
        S2_Toilet_Door_GhostHead_Obj.GetComponent<Animator>().SetTrigger("S2_Toilet_Door_GhostHead_Scared");
    }

    public void IvkS2_SlientAfterPhotoFrame()
    {
        // 紹威 (Word 檔 - 聲音大約出現 2-3 秒後安靜下來
        audManager.Play(1, "At_the_end_it_is_found_that_Acuan_has_mostly_disappeared_and_Acuan_has_climbed_up", false);

        // 加在這兩個註解中間
        ProcessPlayerAnimator("Player_S2_Shocked_After_PhotoFrame");

        Invoke(nameof(IvkS2_PlayGrandmaVideo), 15f);

        Invoke(nameof(IvkS2_SlientAfterPhotoFrameForRecord), 22f);
    }

    public void IvkS2_PlayGrandmaVideo()
    {
        videoPlayer.clip = GrandmaVP;
        videoPlayer.Play();
        // AUDManager.instance.BodyTwistingSound();
        Invoke(nameof(IvkS2_ShowVideoPlayerMesh), 1f);
    }

    public void IvkS2_ShowVideoPlayerMesh()
    {
        videoPlayer.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void IvkS2_SlientAfterPhotoFrameForRecord()
    {
        videoPlayer.gameObject.GetComponent<MeshRenderer>().enabled = false;
        FinalUI.SetActive(true);
        bIsGameEnd = true;
    }
}