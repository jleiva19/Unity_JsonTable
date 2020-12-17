# Unity Json Table
------

## Summary

This project consists of a table on the main scene, this one gets filled with data retrieved from a JSON file located on the StreamingAssets folder. If you edit the file during runtime and press the reload button on the corner of the screen, the table will update.

**NOTE:** The table will update correctly as long as you only chance the value of Title, the amount and value of ColumnHeaders, plus the quantity of elements on Data along with their values as well. If you assign a new column header that the objects  do not possess it will certainly break the project, unlike the opposite situation, if you remove one of the column headers, regardless of the objects having it or not, it won't affect the runtime. 

### Details:

- The project uses Unity 2019.4.12f1
- For the serialization I use [JSON.NET](https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347) from the Asset Store.

------

## Stuff that I'm aware of

- ~~If the order of the column headers is changed it will probably mix the data (priority, fixing as soon as I can)~~. This has been disproven, they can be switched with no problem.

- Right now the file must be, and can only be on StreamingAssets under the name of `JsonChallenge.json`, it would be nice leaving a public field on the inspector or during runtime so the file can be changed during runtime, also allowing more than one file.

- There might be some repeated code, need to check that to make it more clean and human friendly.

  ------

  