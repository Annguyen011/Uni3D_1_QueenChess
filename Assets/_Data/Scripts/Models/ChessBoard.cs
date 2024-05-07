using UnityEngine;


public class ChessBoard : MonoBehaviour
{
	#region [Elements]
	[Header("# Cell info")]
	[SerializeField] private Cell cellPrefab;
	[SerializeField] private Cell[][] cells;
	public Cell[][] Cells => cells;
	

	#endregion


	#region [Components]



	#endregion

	#region [Unity Methods]



	#endregion

	#region [Override]



	#endregion

	/// <summary>
	/// Khoi tao ban co
	/// </summary>
	public void InitChessBoard()
	{

	}
}
