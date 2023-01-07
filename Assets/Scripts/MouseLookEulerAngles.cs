using UnityEngine;

public class MouseLookEulerAngles : MonoBehaviour
{
    [SerializeField] private float HorizontalSens = 9.0f;
    [SerializeField] private float minimunVert = -45.0f;                
    [SerializeField] private float maximumVert = 45.0f; 
    private float _rotationY;
    void Update()
    {
        _rotationY -= Input.GetAxis("Mouse Y") * HorizontalSens;
        _rotationY = Mathf.Clamp(_rotationY, minimunVert, maximumVert);

        transform.eulerAngles = new Vector3(_rotationY, 0, 0);
        print("transform.eulerAngles= " + transform.eulerAngles.x);
    }
}