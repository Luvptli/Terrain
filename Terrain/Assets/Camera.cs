using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        // Desactiva todas las cámaras excepto la primera
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }

    void Update()
    {
        // Cambio con teclas numéricas
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCamera(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCamera(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCamera(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SwitchCamera(3);

        // Cambio con flechas
        if (Input.GetKeyDown(KeyCode.LeftArrow)) SwitchCamera((currentCameraIndex - 1 + cameras.Length) % cameras.Length);
        if (Input.GetKeyDown(KeyCode.RightArrow)) SwitchCamera((currentCameraIndex + 1) % cameras.Length);
    }

    void SwitchCamera(int index)
    {
        if (index >= 0 && index < cameras.Length)
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);
            cameras[index].gameObject.SetActive(true);
            currentCameraIndex = index;
        }
    }
}
