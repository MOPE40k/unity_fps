using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _crosshair;
    //[SerializeField] private GameObject _gameOverPanel;
    //[SerializeField] private PlayerCharacter _playerCharacter;

    private GameObject _crosshair;
    private GameObject _gameOverPanel;
    private PlayerCharacter _playerCharacter;
    void Start()
    {
        _crosshair = GameObject.Find("Crosshair");
        _gameOverPanel = GameObject.Find("GameOverPanel");
        //_playerCharacter = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        _playerCharacter = GameObject.FindObjectOfType<PlayerCharacter>();
        
        CursorState(false);
        _crosshair.SetActive(true);
        _gameOverPanel.SetActive(false);
    }
    void Update()
    {
        //if ((_playerCharacter.playerHealthGet() <= 0) || Input.GetKey("escape"))
        if ((_playerCharacter.PlayerHealthGet() <= 0))
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        CursorState(true);
        _crosshair.SetActive(false);
        _gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
        print("EXIT");
    }
    void CursorState(bool state)
    {
        if (state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
