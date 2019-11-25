//------------------------------------------------------------
//
//@Author : Jrimmmmmrz
//
//@Verison : 
//
//@Description : 数据表编辑器配置
//
//------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameFramework.DataTableTools
{

    public class DataTableEditorConfig : ScriptableObject
    {

        [Header("Label")]
        public string WindowTitle = "Data Table Editor";
        public string MainTitle = "Data Table Editor";
        public string SubTitle = "GameFrameWork";
        public string New = "New";
        public string Load = "Load";
        public string Setting = "Setting";
        public string Back = "Back";
        public string Apply = "Apply";
        public string AddColumn = "AddColumn";
        public string RemoveColumn = "RemoveColumn";
        public string AddRow = "AddRow";
        public string RemoveRow = "RemoveRow";
        public string Generate = "Generate";
        public string NameSpace = "NameSpace";
        public string Verision = "1.1.0";

        public string IDNameRow = "ID Name Row";
        public string IDTypeRow = "ID Type Row";
        public string CommentRow = "Comment Row";
        public string ContentStartRow = "Content Start Row";
        public string IDColumn = "Id Column";
        public string Language = "Language";

        public string DataTablePath = "DataTable Path";
        public string CSharpCodePath = "CSharpCode Path";
        public string CSharpCodeTemplateFileName = "CSharpCode Path";

        [Header("Data")]
        public int Data_IDameRow = 1;
        public int Data_IDTypeRow = 2;
        public int Data_IDCommentRow = 3;
        public int Data_IDCommentStartRow = 4;
        public int Data_IDColumn = 1;
        public string Data_Path = "Assets/GameMain/DataTables";
        public string Data_CSharpCodePath = "Assets/GameMain/Scripts/DataTable";
        public string Data_CSharpCodeTemplateFileName = "Assets/GameMain/Configs/DataTableCodeTemplate.txt";
        public string Data_NameSpace = "Game";

        public const string Filter = "txt文件(*.txt)\0*.txt";

        private static DataTableEditorConfig config;
        public static int DefaultLanguage
        {
            get
            {
                return int.Parse(EditorUserSettings.GetConfigValue("DataTableEditor_Language"));
            }
            set
            {
                EditorUserSettings.SetConfigValue("DataTableEditor_Language", value.ToString());
            }
        }
        public static DataTableEditorConfig GetConfig()
        {
            config = Resources.Load<DataTableEditorConfig>(LanguageFlags[DefaultLanguage]);

            if (config == null)
            {
                throw new System.Exception("Config is missing , create a new one.");
            }
            return config;
        }

        public static string[] LanguageFlags = new string[]
        {
            "EN",
            "ZHC"
        };


        public List<DataTableGenerateWindow.DataTableName> m_dataTableNames = new List<DataTableGenerateWindow.DataTableName>();
        public List<DataTableGenerateWindow.DataTableName> DataTableNamesList
        {
            get
            {
                config = Resources.Load<DataTableEditorConfig>(LanguageFlags[0]);
                return config.m_dataTableNames;
            }
            set
            {
                config = Resources.Load<DataTableEditorConfig>(LanguageFlags[0]);
                config.m_dataTableNames = value;
            }
        }
    }

}
