using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region [Elements]

    public EGameState GameState;
    public EPlayer Player;
    public TextMeshProUGUI text;
    public GameObject uiInGame;

    #endregion


    #region [Components]

    public static GameManager Instance;

    #endregion

    #region [Unity Methods]

    private void Awake()
    {
        Instance = this;
        Player = EPlayer.BLACK;
    }

    private void Start()
    {
        GameState = EGameState.PLAYING;
        uiInGame.SetActive(false);
    }

    #endregion

    public void SwitchTurn()
    {
        switch (Player)
        {
            case EPlayer.WHITE:
                Player = EPlayer.BLACK;
                break;
            case EPlayer.BLACK:
                Player = EPlayer.WHITE;
                break;
        }
    }
    public void GameOver()
    {
        uiInGame.SetActive(true);

        text.text = GameManager.Instance.Player.ToString() + " - Victory";
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
