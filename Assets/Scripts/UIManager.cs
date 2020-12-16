using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    #region Title
    [Header("Table Title")]
    // title on top of the table
    public Text title;
    #endregion
    #region ColumnHeader
    [Header("Column Headers")]
    // parent for the headers of the table
    public RectTransform columnHeadersContainer;
    // template to be set as a header
    public GameObject columnHeaderPrefab;
    #endregion
    #region Data
    [Header("Data")]
    // parent for the data of the table
    public RectTransform dataContainer;
    // template to contain data columns
    public GameObject dataRowPrefab;
    // template to contain part of the data of one element
    public GameObject dataColumnPrefab;

    #endregion

    private List<GameObject> headersPool = new List<GameObject>();
    private List<GameObject> rowsPool = new List<GameObject>();
    private List<GameObject> columnsPool = new List<GameObject>();

    /// <summary>
    /// Receives and sets a name for the table
    /// </summary>
    /// <param name="title"></param>
    public void setTitle(string title) {
        this.title.text = title;
    }

    /// <summary>
    /// Inserts a new header from a pool and assigns the title for it,
    /// if there are no objects on the pool it creates a new header
    /// </summary>
    /// <param name="title"></param>
    public void InsertHeader(string title)
    {
        GameObject header;

        if (headersPool.Count == 0)
        {
            header = Instantiate(columnHeaderPrefab, columnHeadersContainer);
        }
        else
        {
            header = headersPool[0];
            headersPool.RemoveAt(0);
            header.transform.SetAsLastSibling();
            header.SetActive(true);
        }
        
        header.GetComponentInChildren<Text>().text = title;
    }

    /// <summary>
    /// Inserts a new column for data from a pool, creates a new one if the pool is empty,
    /// followed by the columns filled with data, also from a pool that can increase in number
    /// </summary>
    /// <param name="data"></param>
    public void InsertData(string[] data)
    {
        GameObject row;

        if(rowsPool.Count == 0)
        {
            row = Instantiate(dataRowPrefab, dataContainer);
        }
        else 
        {
            row = rowsPool[0];
            rowsPool.RemoveAt(0);
            row.transform.SetAsLastSibling();
            row.SetActive(true);
        }
        
        int dataLenght = data.Length;

        for (int i = 0; i < dataLenght; i++)
        {
            GameObject dataColumn;

            if (columnsPool.Count == 0)
            {
                dataColumn = Instantiate(dataColumnPrefab, row.transform);
            }
            else
            {
                dataColumn = columnsPool[0];
                columnsPool.RemoveAt(0);
                dataColumn.transform.SetParent(row.transform);
                dataColumn.transform.SetAsLastSibling();
                dataColumn.SetActive(true);
            }
            
            dataColumn.GetComponentInChildren<Text>().text = data[i];
        }
    }

    /// <summary>
    /// Goes through every row disabling the columns and then the row itself for future use
    /// </summary>
    public void RemoveAllData()
    {
        int dataLenght = dataContainer.childCount;
        
        for (int i = 0; i < dataLenght; i++)
        {
            GameObject row = dataContainer.GetChild(i).gameObject;

            int columnsLenght = row.transform.childCount;

            for (int x = 0; x < columnsLenght; x++)
            {
                GameObject column = row.transform.GetChild(x).gameObject;
                if(column.activeInHierarchy)
                { 
                column.SetActive(false);
                columnsPool.Add(column);
                }
            }
            if(row.activeInHierarchy)
            { 
            row.SetActive(false);
            rowsPool.Add(row);
            }
        }
    }

    /// <summary>
    /// Disables every header and adds it to a pool in case they are required again
    /// </summary>
    public void RemoveAllHeaders()
    {
        int columnHeadersLenght = columnHeadersContainer.childCount;

        for (int i = 0; i < columnHeadersLenght; i++)
        {
            GameObject header = columnHeadersContainer.GetChild(i).gameObject;
            if(header.activeInHierarchy)
            {
            header.SetActive(false);
            headersPool.Add(header);
            }
        }
    }
}
