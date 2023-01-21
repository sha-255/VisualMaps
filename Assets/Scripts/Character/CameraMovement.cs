using UnityEngine.UI;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Slider zoomSlider;
    [SerializeField] private Slider rotateCameraSlider;
    [SerializeField] private GameObject cameraRig;
    void Start()
    {

    }

    void Update()
    {
        CameraZoom();
        CameraTrack();
        CameraRotate();
    }

    private void CameraZoom()
    {
        mainCamera.orthographicSize = (zoomSlider.value * 10) + 10;

        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw > 0.1)
        {
            mainCamera.orthographicSize -= 10;
        }
        if (mw < -0.1)
        {
            mainCamera.orthographicSize += 10;
        }
    }

    private void CameraTrack()
    {
        cameraRig.transform.position = this.transform.position;
    }

    private void CameraRotate()
    {
        cameraRig.transform.rotation = Quaternion.Euler(0, (rotateCameraSlider.value)*45, 0);
    }
}
