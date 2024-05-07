using System;
using UnityEngine;


public class ChessBoard : MonoBehaviour
{
    #region [Elements]
    [Header("# Cell info")]
    [SerializeField] private Vector3 basePos;
    [SerializeField] private float paddingX = 1f;
    [SerializeField] private float paddingZ = 1f;
    [SerializeField] private Transform cellPrefab;
    [SerializeField] private Cell[][] cells;
    public Cell[][] Cells => cells;


    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]

    private void Start()
    {
        InitChessBoard();
    }

    #endregion

    #region [Override]



    #endregion

    /// <summary>
    /// Khoi tao ban co
    /// </summary>
    public void InitChessBoard()
    {
        cells = new Cell[8][];

        for (int i = 0; i < 8; i++)
        {
            cells[i] = new Cell[8];
            for (int j = 0; j < 8; j++)
            {
                GameObject newCell = Instantiate(cellPrefab, transform).gameObject;

                newCell.transform.SetLocalPositionAndRotation(Vector3.zero,
                    Quaternion.identity);
                newCell.transform.SetPositionAndRotation(CaculatePosition(i, j),
                    Quaternion.identity);

                if ((i + j) % 2 == 0)
                {
                    newCell.GetComponent<Cell>().SetColor(ECellColor.WHITE);
                }
                else
                {
                    newCell.GetComponent<Cell>().SetColor(ECellColor.BLACK);
                }

                cells[i][j] = newCell.GetComponent<Cell>();
            }
        }
    }
    /// <summary>
    /// Tinh vi tri cua cell 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    private Vector3 CaculatePosition(int i, int j)
    {
        return basePos + new Vector3(i * paddingX, 0, j * paddingZ);
    }
}
