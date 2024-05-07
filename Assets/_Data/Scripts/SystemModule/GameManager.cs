using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region [Elements]

	public EGameState GameState;

	#endregion


	#region [Components]

	public static GameManager Instance;

    #endregion

    #region [Unity Methods]

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameState = EGameState.PLAYING;
    }

    #endregion

    #region [Override]



    #endregion

}
