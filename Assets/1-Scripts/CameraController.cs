using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    public PostProcessVolume postProcess;
    private ColorGrading colorGrade;
    private ChromaticAberration chromaticAbb;


    public CinemachineVirtualCamera[] cams;

    public static CameraController Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        postProcess.profile.TryGetSettings(out colorGrade);
        postProcess.profile.TryGetSettings(out chromaticAbb);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchCameraTo(0);
        }
        if ( Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchCameraTo(1);
        }
    }

    public void SwitchCameraTo(int camIndex)
    {
        foreach(CinemachineVirtualCamera cam in cams)
        {
            cam.Priority = 0;
        }

        cams[camIndex].Priority = 1;
    }

    public void ActivateLaserCamera()
    {
        StartCoroutine(ActivateLaserCamCor());
    }

    public void DeactivateLaserCamera()
    {
        StartCoroutine(DeactivateLaserCamCor());
    }

    IEnumerator ActivateLaserCamCor()
    {
        DOTween.To(() => chromaticAbb.intensity.value, x => chromaticAbb.intensity.value = x, 1, 2f).OnComplete((() =>
        {
            DOTween.To(() => chromaticAbb.intensity.value, x => chromaticAbb.intensity.value = x, 0, 1.5f);
        }));

        DOTween.To(() => colorGrade.postExposure.value, x => colorGrade.postExposure.value = x, 6, 2f).OnComplete((() =>
        {
            DOTween.To(() => colorGrade.postExposure.value, x => colorGrade.postExposure.value = x, 0, 1.5f);
        }));

        yield return new WaitForSeconds(2f);

        SwitchCameraTo(2);

        yield break;
    }

    IEnumerator DeactivateLaserCamCor()
    {

        DOTween.To(() => chromaticAbb.intensity.value, x => chromaticAbb.intensity.value = x, 1, 2f).OnComplete((() =>
        {
            DOTween.To(() => chromaticAbb.intensity.value, x => chromaticAbb.intensity.value = x, 0, 1.5f);
        }));

        DOTween.To(() => colorGrade.postExposure.value, x => colorGrade.postExposure.value = x, 6, 2f).OnComplete((() =>
        {
            DOTween.To(() => colorGrade.postExposure.value, x => colorGrade.postExposure.value = x, 0, 1.5f);
        }));

        yield return new WaitForSeconds(2f);
        SwitchCameraTo(1);

        yield break;
    }
}
