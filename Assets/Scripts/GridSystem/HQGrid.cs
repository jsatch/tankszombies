using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQGridCell<T> 
{
    private int mPosWidth;
    private int mPosHeight;

    public T Element { get; set; }
    public int PosWidth { get; set; }
    public int PosHeight { get; set; }

    public Vector3 Center { get; set; }
    private Vector3 mOrigin;

    public HQGridCell()
    {
    }

    public void SetOrigin(Vector3 origin)
    {
        mOrigin = origin;
    }
    public Vector3 GetOrigin()
    {
        return mOrigin;
    }

}

public class HQGrid<Q>
{ 
    public int Width { private set; get; }
    public int Height { private set; get; }
    public bool DebugMode { set; get; }

    private Terrain mTerrain;
    private float mCellSize;
    private HQGridCell<Q>[,] mGridArray;
    private TextMesh[,] mGridDebugText;

    private Vector3 mOrigin = new Vector3(0f, 0f, 0f);


    public HQGrid(Terrain terrain, float cellSize, bool debugMode)
    {
        DebugMode = debugMode;
        Vector3 size = terrain.terrainData.size;
        mCellSize = cellSize;
        Width = (int)(size.x / mCellSize);
        Height = (int)(size.z / mCellSize);

        mGridArray = new HQGridCell<Q>[Width, Height];
        if (DebugMode) mGridDebugText = new TextMesh[Width, Height];


        for (int j=0; j < Height; j++)
        {
            for (int i = 0; i < Width; i++)
            {
                HQGridCell<Q> cell = new HQGridCell<Q>
                {
                    PosWidth = i,
                    PosHeight = j,
                    Center = new Vector3(i * mCellSize + (mCellSize / 2f), 0f, j * mCellSize + (mCellSize / 2f))
                };
                cell.SetOrigin(new Vector3(i * mCellSize, 0f, j * mCellSize));
                cell.Element = default(Q);

                Debug.DrawLine(cell.GetOrigin() ,
                    cell.GetOrigin() + (Vector3.forward * mCellSize), Color.white, 100f);
                Debug.DrawLine(cell.GetOrigin(),
                    cell.GetOrigin() + (Vector3.right * mCellSize), Color.white, 100f);

                if (DebugMode)
                {
                    mGridDebugText[i, j] = Utils.CreateWorldText(null, cell.Element.ToString(), cell.Center, 10, Color.white);
                }

                mGridArray[i, j] = cell;
            }
        }
    }

    public void SetElement(Q element, int posW, int posH)
    {
        mGridArray[posW, posH].Element = element;
        if (DebugMode) mGridDebugText[posW, posH].text = element.ToString();
    }

    public void SetElement(Q element, float worldW, float worldH)
    {
        int posW = (int)(worldW / mCellSize);
        int posH = (int)(worldH/ mCellSize);

        mGridArray[posW, posH].Element = element;
        if (DebugMode) mGridDebugText[posW, posH].text = element.ToString();
    }

    public void RemoveElement( int posW, int posH)
    {
        mGridArray[posW, posH].Element = default(Q);
    }

    public void RemoveElement(float worldW, float worldH)
    {
        int posW = (int)(worldW / mCellSize);
        int posH = (int)(worldH / mCellSize);

        mGridArray[posW, posH].Element = default(Q);
    }

    public Q GetElement(int posW, int posH)
    {
        return mGridArray[posW, posH].Element;
    }

}
