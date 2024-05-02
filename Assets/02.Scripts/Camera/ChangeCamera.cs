using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    private CinemachineClearShot clearShot;
    private int nowCameraIndex;
    private float ChangeTime;
    private bool isChange;
    private bool LockChangeCamera;
    private void Start()
    {
        clearShot = GetComponent<CinemachineClearShot>();
        nowCameraIndex = 0;
        ChangeTime = clearShot.m_DefaultBlend.m_Time;
        isChange = false;
        LockChangeCamera = false;
    }
    public void LockCamera()
    {
        LockChangeCamera = true;
    }
    public void UnLockCamera()
    {
        LockChangeCamera = false;
    }

    public void ChangeMainScene()
    {
        ChangeCam(0);
    }
    public void ChangeGarretScene()
    {
        ChangeCam(1);
    }
    public void ChangeKitchenScene()
    {
        ChangeCam(2);
    }
    private void ChangeCam(int index)
    {
        if (LockChangeCamera)
            return;
        if (isChange)
            return;

        clearShot.ChildCameras[nowCameraIndex].GetComponent<CinemachineVirtualCamera>().Priority = 10;
        clearShot.ChildCameras[index].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        StartCoroutine(Change());
        nowCameraIndex = index;
    }

    IEnumerator Change()
    {
        isChange = true;
        yield return new WaitForSeconds(ChangeTime);
        isChange = false;
    }
}
