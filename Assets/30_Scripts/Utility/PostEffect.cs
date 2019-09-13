using UnityEngine;

public class PostEffect : MonoBehaviour
{
	[SerializeField]
	private Material postprocessMaterial = null;

	private Camera cam;

	private void Start()
	{
		this.cam = GetComponent<Camera>();
		this.cam.depthTextureMode = this.cam.depthTextureMode | DepthTextureMode.DepthNormals;
	}

	private void OnRenderImage(RenderTexture _source, RenderTexture _destination)
	{
		Graphics.Blit(_source, _destination, this.postprocessMaterial);
	}
}
