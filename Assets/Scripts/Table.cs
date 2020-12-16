using System;
using System.Collections.Generic;
[Serializable]
public class Table
{
    public string title;
    public string[] columnHeaders;
    public Dictionary<string, dynamic>[] data;
}
