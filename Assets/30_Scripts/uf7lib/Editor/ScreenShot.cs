using System;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace uf7lib
{
	public static class ScreenShot
	{
		[MenuItem("uf7lib/ScreenShot _F12")]
		private static void Capture()
		{
			var se = Resources.Load("uf7lib/screenshot") as AudioClip;
			PlayClip(se);
			ScreenCapture.CaptureScreenshot(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
		}

		public static void PlayClip(AudioClip clip)
		{
			var unityEditorAssembly = typeof(AudioImporter).Assembly;
			var audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");

			var method = audioUtilClass.GetMethod
			(
				"PlayClip",
				BindingFlags.Static | BindingFlags.Public,
				null,
				new Type[] { typeof(AudioClip) },
				null
			);

			method.Invoke(null, new object[] { clip });
		}
	}
}