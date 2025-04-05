using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Transform orientation;
    [SerializeField]
    float sensX;
    [SerializeField]
    float sensY;
    [SerializeField]
    [Range(-90f, 0f)]
    float minXRotation;
    [SerializeField]
    [Range(0f, 90f)]
    float maxXRotation;

    const float MULTIPLIER = 0.01f;
    
    void Start()
    {
        DisableCursor();
    }
    
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        float yRotation = mouseX * sensX * MULTIPLIER;
        float xRotation = mouseY * sensY * MULTIPLIER;
        xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
