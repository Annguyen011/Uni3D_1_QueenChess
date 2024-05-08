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
    [SerializeField] private List<BasePiece> pieces;

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
        // Tao object cha chua cac piece
        Transform parentOfPiece = MakeObjectHolder("Pieces").transform;

        for (var i = 0; i < 8; i++)
        {
            // Vòng lặp thứ hai để tạo quân cờ trên mỗi ô
            for (var j = 0; j < 8; j++)
            {
                if (i == 0)
                {
                    // Kiểm tra vị trí của ô để gán quân tương ứng
                    switch (j)
                    {
                        case 0:
                        case 7:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.RookDark); // Thêm quân xe (rook)
                            break;
                        case 1:
                        case 6:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.KnightDark); // Thêm quân xe (rook)
                            break;
                        case 2:
                        case 5:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.BishopDark); // Thêm quân tượng (bishop)
                            break;
                        case 3:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.QueenDark); // Thêm quân hậu (queen)
                            break;
                        case 4:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.KingDark); // Thêm quân vua (king)
                            break;
                    }
                }
                // Kiểm tra nếu ô đang ở hàng 1 hoặc 6, đó là hàng các quân bộ tốt (piece)
                else if (i == 1)
                {
                    SetupPieceOnCell(parentOfPiece, j, i, EPieceName.PawnDark);
                }
                else if (i == 6)
                {
                    SetupPieceOnCell(parentOfPiece, j, i, EPieceName.PawnLight);
                }
                // Kiểm tra nếu ô đang ở hàng 0 hoặc 7, đó là hàng các quân đặc biệt (rook, knight, bishop, queen, king)

                else if (i == 7)
                {
                    // Kiểm tra vị trí của ô để gán quân tương ứng
                    switch (j)
                    {
                        case 0:
                        case 7:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.RookLight); // Thêm quân xe (rook)
                            break;
                        case 1:
                        case 6:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.KnightLight); // Thêm quân xe (rook)
                            break;
                        case 2:
                        case 5:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.BishopLight); // Thêm quân tượng (bishop)
                            break;
                        case 3:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.QueenLight); // Thêm quân hậu (queen)
                            break;
                        case 4:
                            SetupPieceOnCell(parentOfPiece, j, i, EPieceName.KingLight); // Thêm quân vua (king)
                            break;
                    }
                }
            }
        }
    }
    /// <summary>
    /// Tao va gan cho cell tuong ung
    /// </summary>
    /// <param name="parentOfPiece"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="namePiecePrefab"></param>
    private void SetupPieceOnCell(Transform parentOfPiece, int i, int j, EPieceName namePiecePrefab)
    {
        GameObject piece = Instantiate(piecePrefabs.Find(x => x.name == namePiecePrefab.ToString()).gameObject, parentOfPiece);
        piece.transform.position = cells[i][j].transform.position;
        piece.name = piece.name + " " + i + " X " + j;

        switch (namePiecePrefab)
        {
            case EPieceName.BishopDark:
            case EPieceName.BishopLight:
                PBishop pbishop1 = piece.GetComponent<PBishop>();
                pbishop1.SetPieceInfo(new PieceInfo
                {
                    x = i,
                    y = j,
                });

                cells[i][j].SetPiece(pbishop1);
                AddToPiece(pbishop1);
                return;
            case EPieceName.KingDark:
            case EPieceName.KingLight:
                PKing king = piece.GetComponent<PKing>();
                king.SetPieceInfo(new PieceInfo
                {
                    x = i,
                    y = j,
                });
                cells[i][j].SetPiece(king);
                AddToPiece(king);
                return;
            case EPieceName.KnightDark:
            case EPieceName.KnightLight:
                PKnight knight = piece.GetComponent<PKnight>();
                knight.SetPieceInfo(new PieceInfo
                {
                    x = i,
                    y = j,
                });
                cells[i][j].SetPiece(knight);
                AddToPiece(knight);
                return;

            case EPieceName.PawnLight:
            case EPieceName.PawnDark:
                PPawn pawn = piece.GetComponent<PPawn>();
                pawn.SetPieceInfo(new PieceInfo
                {
                    x = i,
                    y = j,
                });
                cells[i][j].SetPiece(pawn);
                AddToPiece(pawn);
                return;
            case EPieceName.QueenDark:
            case EPieceName.QueenLight:
                PQueen queen = piece.GetComponent<PQueen>();
                queen.SetPieceInfo(new PieceInfo
                {
                    x = i,
                    y = j,
                });
                cells[i][j].SetPiece(queen);
                AddToPiece(queen);
                return;
            case EPieceName.RookDark:
            case EPieceName.RookLight:
                PRook rook = piece.GetComponent<PRook>();
                rook.SetPieceInfo(new PieceInfo
                {
                    x = i,
                    y = j,
                });
                cells[i][j].SetPiece(rook);
                AddToPiece(rook);
                return;
        }
    }

    /// <summary>
    /// Them vao list piece
    /// </summary>
    /// <param name="classPiece"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void AddToPiece(BasePiece classPiece)
    {
        pieces.Add(classPiece);
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
    #endregion

    #region [INPUT]
    /// <summary>
    /// Kiem tra input cua chuot
    /// </summary>
    /// 
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

    #endregion
}
