using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Terrain mTerrain;
    public GameObject mTank;

    private HQGrid<int> mGrid;
    private static GameManager mInstance;

    public static GameManager Instance
    {
        get
        {
            return mInstance;
        }
    }

    private void Awake()
    {
        if (mInstance != null && mInstance != this)
        {
            Destroy(this.gameObject);
        }else
        {
            mInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mGrid = new HQGrid<int>(mTerrain, 2f, true);
        mGrid.SetElement(11, 0, 0);
    }

    public HQGrid<int> GetGrid()
    {
        return mGrid;
    }


}
