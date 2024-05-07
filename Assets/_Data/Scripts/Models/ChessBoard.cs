using System;
using System.Collections.Generic;
using UnityEngine;


public class ChessBoard : MonoBehaviour
{
    #region [Elements]
    [Header("# Cell info")]
    [SerializeField] private LayerMask cellLayer;
    [SerializeField] private Vector3 basePos;
    [SerializeField] private float paddingOfCellX = 1f;
    [SerializeField] private float paddingOfCellZ = 1f;
    [SerializeField] private Transform cellPrefab;
    [SerializeField] private Cell[][] cells;
    [SerializeField] private Cell curHolderCell;
    [SerializeField] private Cell curSelectedCell;

    [Header("# Piece infos")]
    [SerializeField] private List<Transform> piecePrefabs;

    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]

    private void Start()
    {
        InitChessBoard();
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == EGameState.PLAYING)
        {
            CheclUserInput();
        }
    }

    #endregion

    #region [CREATE CELLS]
    /// <summary>
    /// Khoi tao ban co
    /// </summary>
    private void InitChessBoard()
    {
        MakeCells();
        MakePieces();
    }

    /// <summary>
    /// Tao ra quan co va set vi tri cho no
    /// </summary>
    private void MakePieces()
    {
            
    }

    /// <summary>
    /// Tao ra ban co
    /// </summary>
    private void MakeCells()
    {
        cells = new Cell[8][];

        GameObject parentOfCell = MakeObjectHolder("Cells");

        for (int i = 0; i < 8; i++)
        {
            cells[i] = new Cell[8];
            for (int j = 0; j < 8; j++)
            {

                GameObject newCell = Instantiate(cellPrefab, parentOfCell.transform).gameObject;

                newCell.transform.SetLocalPositionAndRotation(Vector3.zero,
                    Quaternion.identity);
                newCell.transform.SetPositionAndRotation(CaculatePosition(i, j),
                    Quaternion.identity);
                newCell.name = i + " x " + j;

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
    /// Tao ra cha cho cac object 
    /// </summary>
    /// <returns></returns>
    private GameObject MakeObjectHolder(string name)
    {
        GameObject parentOfCell = new GameObject(name);

        parentOfCell.transform.SetLocalPositionAndRotation(Vector3.zero,
            Quaternion.identity);
        parentOfCell.transform.SetPositionAndRotation(transform.position,
            Quaternion.identity);
        parentOfCell.transform.SetParent(transform);
        return parentOfCell;
    }

    /// <summary>
    /// Tinh vi tri cua cell 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    private Vector3 CaculatePosition(int i, int j)
    {
        return basePos + new Vector3(i * paddingOfCellX, 0, j * paddingOfCellZ);
    }
    /// <summary>
    /// Kiem tra input cua chuot
    /// </summary>
    /// 
    #endregion

    private void CheclUserInput()
    {
        // Tao mot ray tu cam toi chuot
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Neu tiep xuc voi cell
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, cellLayer))
        {
            // Get cell tu diem tiep xuc
            Cell cell = hit.collider.GetComponent<Cell>();

            // Neu cell khac cell hien co
            if (cell != curHolderCell)
            {
                // Cho cell hien co ve trang thai binh thuong
                // neu cell hien co khac null
                if (curHolderCell)
                {
                    curHolderCell.SetCellState(ECellState.NORMAL);
                }

                // Set lai cell hien co
                curHolderCell = cell;
                curHolderCell.SetCellState(ECellState.HOLDER);
            }
        }
        else
        {
            // Neu khong target duoc cell thi chuyen cell hien
            // co thanh binh thuong va tra lai null
            if (!curHolderCell)
            {
                return;
            }

            curHolderCell.SetCellState(ECellState.NORMAL);
            curHolderCell = null;
        }

        MouseDownHandler();
    }
    /// <summary>
    /// Xu ly su kien click chuot
    /// </summary>
    private void MouseDownHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!curHolderCell)
            {
                return;
            }

            if (curSelectedCell != null)
            {
                curSelectedCell.SetCellState(ECellState.UNSELECT);
            }

            curSelectedCell = curHolderCell;
            curSelectedCell.SetCellState(ECellState.SELECT);
        }

    }
}
