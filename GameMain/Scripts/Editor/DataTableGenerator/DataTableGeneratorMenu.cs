//------------------------------------------------------------
//
//@Author : Jrimmmmmrz
//
//@Verison : 
//
//@Description : 数据表生成
//
//------------------------------------------------------------

using GameFramework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor.DataTableTools;

namespace GameFramework.DataTableTools
{
    public class DataTableGeneratorMenu
    {
        public static void GenerateDataTables(List<GameFramework.DataTableTools.DataTableGenerateWindow.DataTableName> dataTableNames)
        {
            foreach (var dataTable in dataTableNames)
            {
                if (!dataTable.IsOn)
                    continue;

                DataTableProcessor dataTableProcessor = DataTableGenerator.CreateDataTableProcessor(dataTable.Name);
                if (!DataTableGenerator.CheckRawData(dataTableProcessor, dataTable.Name))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTable.Name));
                    break;
                }

                DataTableGenerator.GenerateDataFile(dataTableProcessor, dataTable.Name);
                DataTableGenerator.GenerateCodeFile(dataTableProcessor, dataTable.Name);
            }

            AssetDatabase.Refresh();
        }
    }
}
