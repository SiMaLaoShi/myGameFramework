/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/05/13 16:04:39
** desc:  导表生成c#;
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Framework
{
    public static class TableExportCs
    {
        public static Dictionary<TableFiledType, string> _tableTypeDict = new Dictionary<TableFiledType, string>()
        {
            {TableFiledType.INT,"int"},
            {TableFiledType.FLOAT,"float"},
            {TableFiledType.STRING,"string"},
            {TableFiledType.BOOL,"bool"},
        };

        public static Dictionary<TableFiledType, string> _tableReadDict = new Dictionary<TableFiledType, string>()
        {
            {TableFiledType.INT,"        ReadInt32(ref byteArr,ref bytePos,out {0});"},
            {TableFiledType.FLOAT,"        ReadFloat(ref byteArr,ref bytePos,out {0});"},
            {TableFiledType.STRING,"        ReadString(ref byteArr,ref bytePos,out {0});"},
            {TableFiledType.BOOL,"        ReadBoolean(ref byteArr,ref bytePos,out {0});"}
        };

        private static Dictionary<int, List<string>> infoDict = new Dictionary<int, List<string>>();

        private static string targetPath = Application.dataPath.ToLower() + "/Scripts/Common/Table/";

        private static string fileName = string.Empty;

        private static string code = string.Empty;

        public static void ExportCs(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            infoDict.Clear();
            fileName = string.Empty;
            code = string.Empty;

            infoDict = TableReader.ReadCsvFile(path);
            code = template;
            if (infoDict.ContainsKey(1))
            {
                fileName = Path.GetFileNameWithoutExtension(path);
                targetPath = targetPath + fileName + ".cs";
                code = code.Replace("#fileName#", fileName);

                string fields = string.Empty;
                string mainKey = string.Empty;
                string funcs = string.Empty;

                List<string> line = infoDict[1];
                for (int i = 0; i < line.Count; i++)
                {
                    string target = line[i];
                    string[] temp = target.Split(":".ToArray());
                    TableFiledType type = TableFiledType.STRING;
                    if (temp.Length < 2)
                    {
                        LogUtil.LogUtility.PrintWarning(string.Format("#配表未指定类型{0}行,{1}列,请先初始化#path:" + path, 2.ToString(), i.ToString()));
                        return;
                    }
                    else
                    {
                        type = TableReader.GetTableFiledType(temp[1]);
                    }
                    fields = fields + "\r\n " + "    public " + _tableTypeDict[type].ToString() + " " + temp[0] + ";";
                    if (i == 0)
                        mainKey = temp[0];
                    funcs = funcs + "\r\n " + string.Format(_tableReadDict[type], temp[0]);
                }
                code = code.Replace("#fields#", fields);
                code = code.Replace("#mainKey#", mainKey);
                code = code.Replace("#function#", funcs);
                File.WriteAllText(targetPath, code);
                AssetDatabase.Refresh();
                EditorUtility.DisplayDialog("提示", "cs 导出成功，等待编译通过！", "确认");
            }
        }

        public static string template =
            "//------------------------------------------------------------------------------\r\n" +
            "// <auto-generated>\r\n" +
            "//     This code was generated by a tool.\r\n" +
            "//\r\n" +
            "//     Changes to this file may cause incorrect behavior and will be lost if\r\n" +
            "//     the code is regenerated.\r\n" +
            "// </auto-generated>\r\n" +
            "//------------------------------------------------------------------------------\r\n" +
            " \r\n" +
            "using Framework; \r\n" +
            "using System.Collections; \r\n" +
            "using System.Collections.Generic; \r\n" +
            "using UnityEngine; \r\n" +
            " \r\n" +
            "public class #fileName#DB : TableMgr<#fileName#>\r\n" +
            "{\r\n" +
            "    public static readonly #fileName#DB instance=new #fileName#DB();\r\n" +
            "}\r\n" +
            " \r\n" +
            "// Generated from: #fileName#.csv\r\n" +
            "public class #fileName# : TableData\r\n" +
            "{\r\n" +
            "#fields#\r\n" +
            " \r\n" +
            "    public override int Key\r\n" +
            "    {\r\n" +
            "        get\r\n" +
            "        {\r\n" +
            "            return #mainKey#; \r\n" +
            "        }\r\n" +
            "    }\r\n" +
            " \r\n" +
            "    public override void Decode(byte[] byteArr, ref int bytePos)\r\n" +
            "    {\r\n" +
            "#function#\r\n" +
            " \r\n" +
            "    }\r\n" +
            " \r\n" +
            "}\r\n";
    }
}