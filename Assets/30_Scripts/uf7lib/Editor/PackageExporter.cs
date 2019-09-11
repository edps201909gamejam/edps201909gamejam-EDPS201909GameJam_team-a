using System.IO;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

namespace uf7lib
{
	public static class PackageExporter
	{
		private struct ExportData
		{
			public string FolderName;
			public string InputFilePath;
			public string OutputFilePath;
		}

		[MenuItem("uf7lib/Export package for @Folder", false, 2)]
		static public void ExportIgnoreFolders()
		{
			// 書き出し先のPathを取得（およびフォルダの生成）
			var projectFolder = Directory.GetParent(Application.dataPath).FullName;
			var outPutRootPath = Path.Combine(projectFolder, "IgnorePackages");
			SafeCreateDirectory(outPutRootPath);

			// 対象フォルダの検索とPathの取得
			var exportDatas = new List<ExportData>();
			var guids = AssetDatabase.FindAssets("t:folder @", null);
			for (var i = 0; i < guids.Length; ++i)
			{
				var guid = guids[i];
				var path = AssetDatabase.GUIDToAssetPath(guid);
				var folderName = Path.GetFileName(path) + ".unitypackage";
				exportDatas.Add(new ExportData
				{
					FolderName = folderName,
					InputFilePath = path,
					OutputFilePath = Path.Combine(outPutRootPath, folderName),
				});
			}

			// unitypackageの作成
			for (var i = 0; i < exportDatas.Count; ++i)
			{
				var data = exportDatas[i];
				EditorUtility.DisplayProgressBar("Export Unitypackages", data.FolderName, i / exportDatas.Count);
				AssetDatabase.ExportPackage(data.InputFilePath, data.OutputFilePath, ExportPackageOptions.Recurse);
			}

			EditorUtility.ClearProgressBar();
			EditorUtility.DisplayDialog("Export Unitypackages", "完了しました。", "OK");

			// 保存先フォルダを開く
			System.Diagnostics.Process.Start(outPutRootPath);

			AssetDatabase.Refresh();
		}

		/// <summary>
		/// フォルダが存在しない場合のみフォルダを生成する by flanny7
		/// </summary>
		/// <param name="_path">生成したいフォルダのPath</param>
		/// <returns>CreateDirectoryを実行したか</returns>
		public static bool SafeCreateDirectory(string _path)
		{
			var exist = Directory.Exists(_path);
			if (!exist)
			{
				Directory.CreateDirectory(_path);
			}

			return exist;
		}
	}
}