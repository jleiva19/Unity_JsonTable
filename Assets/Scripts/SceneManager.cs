using UnityEngine;
using System.IO;
public class SceneManager : MonoBehaviour
{
    // the Table instance with the data for UI
    Table myTable;
    // path to the .json that fills myTable
    string filePath = Path.Combine(Application.streamingAssetsPath, "JsonChallenge.json");
    // utility class to retrieve our table from a .json
    JSONReader jsonReader = new JSONReader();
    // utility class to take care of everything related to UI
    UIManager uiManager;

    private void Awake()
    {
        if (uiManager == null) uiManager = this.gameObject.GetComponent<UIManager>();
    }

    private void Start()
    {
        SetTable();
    }

    private void SetTable()
    {
        // get the contents of a json file
        string tableData = File.ReadAllText(filePath);
        // return the contents deserialized to set our table
        myTable = jsonReader.getTable(tableData);

        // set the title first
        uiManager.setTitle(myTable.title);

        int headersLenght = myTable.columnHeaders.Length;
        string[] headers = myTable.columnHeaders;

        // followed by instantiating headers and assigning their name
        for (int i = 0; i < headersLenght; i++)
        {
            uiManager.InsertHeader(headers[i]);
        }

        int dataLenght = myTable.data.Length;
        string[] data = new string[headersLenght];

        // finally instantiate a row for every data element and set the details of each one
        for (int i = 0; i < dataLenght; i++)
        {
            for (int x = 0; x < headersLenght; x++)
            {
                data[x] = myTable.data[i][headers[x]].ToString();
            }
            uiManager.InsertData(data);
        }
    }

    public void ReloadTable()
    {
        uiManager.RemoveAllData();
        uiManager.RemoveAllHeaders();
        SetTable();
    }
}
