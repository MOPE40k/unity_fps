using UnityEngine;

public class MouseLookRotate : MonoBehaviour
{
    [SerializeField] private float HorizontalSens = 9.0f;
    [SerializeField] private float minimunVert = -45.0f;                
    [SerializeField] private float maximumVert = 45.0f; 
    private float _rotationY;
    void Update()
    {
        _rotationY = Input.GetAxis("Mouse Y") * HorizontalSens;
        _rotationY = Mathf.Clamp(_rotationY, minimunVert, maximumVert);

        transform.Rotate(-_rotationY, 0, 0);
        print("transform.Rotate= " + Input.GetAxis("Mouse Y"));
    }
}