using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Camera _camera;
    private PlayerCharacter _playerCharacter;
    //[SerializeField] private string _crosshair = ".";
    //[SerializeField] private int _crosshairSize;
    void Start()
    {
        _playerCharacter = GetComponentInParent<PlayerCharacter>();
        _camera = GetComponent<Camera>();

        //CursorOff();
    }
    void Update()
    {
        if (_playerCharacter.PlayerHealthGet() > 0)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenCentre = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(screenCentre);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                EnemyAI target = hitObject.GetComponent<EnemyAI>();

                if (target != null)
                {
                    hitObject.GetComponent<EnemyReact>().ReactToHit();                   
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1.0f);

        Destroy(sphere);
    }
    /*void OnGUI()
    {
        float posX = _camera.pixelWidth / 2;
        float posY = _camera.pixelHeight / 2;
        GUI.Label(new Rect(posX, posY, _crosshairSize, _crosshairSize), _crosshair);
    }*/
    //void CursorOff()
    //{
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    //}
}