using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace uf7lib
{
	/// <summary>
	/// uf7lib をインポートしたときに便利な初期化関数群 by flanny
	/// </summary>
	public class Initializer
	{
		[MenuItem("uf7lib/Initializer/All")]
		private static void All()
		{
			var title = "uf7lib Initializer";

			var isExec = EditorUtility.DisplayDialog(title, "Trash empty.cs の実行",
				"emptyを削除する", "スキップ");
			if (isExec) { TrashEmptyCS(); }

			isExec = EditorUtility.DisplayDialog(title, "Create .gitignore の実行",
				".gitignoreを生成する", "スキップ");
			if (isExec) { CreateGitIgnore(); }

			isExec = EditorUtility.DisplayDialog(title, "Create .editorconfig の実行",
				".editorconfigを生成する", "スキップ");
			if (isExec) { CreateEditorConfig(); }

			EditorUtility.DisplayDialog(title, "完了しました。", "OK");
		}

		/// <summary>
		/// empty.cs と そのmetaファイルを削除する関数 by flanny7
		/// </summary>
		[MenuItem("uf7lib/Initializer/Trash empty.cs")]
		private static void TrashEmptyCS()
		{
			var success = true;
			var guids = AssetDatabase.FindAssets("t:Script empty", null);
			for (var i = 0; i < guids.Length; ++i)
			{
				var guid = guids[i];
				var path = AssetDatabase.GUIDToAssetPath(guid);
				if (!AssetDatabase.MoveAssetToTrash(path))
				{
					Debug.LogWarning("削除に失敗しました：" + path);
					success = false;
				}

				Debug.Log("削除しました：" + path);
			}

			var resultText = string.Empty;
			if (success) { resultText = "すべての empty.cs を削除しました。"; }
			else { resultText = "削除に失敗したファイルがあります。"; }

			Debug.Log(resultText);
			EditorUtility.DisplayDialog("Trash empty.cs", resultText, "OK");

			AssetDatabase.Refresh();
		}

		/// <summary>
		/// .gitignoreを生成する by flanny7
		/// </summary>
		[MenuItem("uf7lib/Initializer/Create .gitignore")]
		private static void CreateGitIgnore()
		{
			// 書き出し先のPathを取得
			var projectFolder = Directory.GetParent(Application.dataPath).FullName;
			var outputPath = Path.Combine(projectFolder, ".gitignore");

			// .gitignoreを取得
			var guids = AssetDatabase.FindAssets("gitignore", null);
			var inputPath = AssetDatabase.GUIDToAssetPath(guids[0]);

			if (File.Exists(outputPath))
			{
				var isOverride = EditorUtility.DisplayDialog("Create .gitignore",
					"既に .gitignore があります。", "上書きする", "キャンセルする");
				if (!isOverride)
				{
					EditorUtility.DisplayDialog("Create .gitignore", "生成をキャンセルしました。", "OK");
					AssetDatabase.Refresh();
					return;
				}

				// 上書き用に削除
				File.Delete(outputPath);
			}

			// ファイルのコピー
			File.Copy(inputPath, outputPath);
			EditorUtility.DisplayDialog("Create .gitignore", "完了しました。", "OK");

			AssetDatabase.Refresh();
		}

		/// <summary>
		/// .editorconfigを生成する by flanny7
		/// </summary>
		[MenuItem("uf7lib/Initializer/Create .editorconfig")]
		private static void CreateEditorConfig()
		{
			// 書き出し先のPathを取得
			var projectFolder = Directory.GetParent(Application.dataPath).FullName;
			var outputPath = Path.Combine(projectFolder, ".editorconfig");

			// .editorconfigを取得
			var guids = AssetDatabase.FindAssets("editorconfig", null);
			var inputPath = AssetDatabase.GUIDToAssetPath(guids[0]);

			if (File.Exists(outputPath))
			{
				var isOverride = EditorUtility.DisplayDialog("Create .editorconfig",
					"既に .editorconfig があります。", "上書きする", "キャンセルする");
				if (!isOverride)
				{
					EditorUtility.DisplayDialog("Create .editorconfig", "生成をキャンセルしました。", "OK");
					AssetDatabase.Refresh();
					return;
				}

				// 上書き用に削除
				File.Delete(outputPath);
			}

			// ファイルのコピー
			File.Copy(inputPath, outputPath);
			EditorUtility.DisplayDialog("Create .editorconfig", "完了しました。", "OK");

			AssetDatabase.Refresh();
		}

		/// <summary>
		/// ファイル検索してパスを返してくれる関数 直書きの方がたぶん軽くて早い by flanny7
		/// </summary>
		/// <param name="_filter"></param>
		/// <param name="_searchInFolders"></param>
		/// <returns></returns>
		private static string[] FindAssetsPath(string _filter, string[] _searchInFolders)
		{
			var paths = new List<string>();
			var guids = AssetDatabase.FindAssets(_filter, _searchInFolders);
			for (var i = 0; i < guids.Length; ++i)
			{
				var guid = guids[i];
				var path = AssetDatabase.GUIDToAssetPath(guid);
				paths.Add(path);
			}

			return paths.ToArray();
		}
	}
}