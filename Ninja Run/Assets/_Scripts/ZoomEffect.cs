using UnityEngine;
using Cinemachine;

public class ZoomEffect : MonoBehaviour         //regelt den Zoom Effekt der Kamera
{
    public float originalSize;
    private float zoomSpeed = 3f;
    private float zoomFactor = 5.45f;

    public CinemachineVirtualCamera virtualCamera;

    private void Start() {
        originalSize = virtualCamera.m_Lens.OrthographicSize;
    }

    public void ZoomScreen() {
        float orthographicSize = virtualCamera.m_Lens.OrthographicSize;
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(orthographicSize, zoomFactor, zoomSpeed * Time.deltaTime);
    }

    public void ZoomOut()
    {
        float orthographicSize = virtualCamera.m_Lens.OrthographicSize;
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(orthographicSize, originalSize, zoomSpeed * Time.deltaTime);
    }
}
