using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class LaserEndScript : MonoBehaviour
{
    public int PortToOpen;

    private bool animPlayed;

    public void PlayLaserEndAnim()
    {
        if(!animPlayed)
        {
            animPlayed = true;
            Vector3 initScale = gameObject.transform.localScale;
            Sequence seq = DOTween.Sequence();
            seq.Append(gameObject.transform.DOScale(initScale * 1.3f, 0.2f));
            seq.Append(gameObject.transform.DOScale(initScale, 0.2f).OnComplete(EndLevel));
        }
    }

    private void EndLevel()
    {
        CameraController.Instance.DeactivateLaserCamera();
            ConsoleController.Instance.OpenPort(PortToOpen);
    }
}
