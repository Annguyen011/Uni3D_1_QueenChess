using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region [Elements]

    public EGameState GameState;
    public EPlayer Player;

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
}
