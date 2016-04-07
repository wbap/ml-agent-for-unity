using UnityEngine;

public class RenderDepth : MonoBehaviour
{
	[Range(0f, 3f)]
	public float depthLevel = 0.5f;
	
	private Shader _shader;
	private Shader shader
	{
		get { return _shader != null ? _shader : (_shader = Shader.Find("Custom/RenderDepth")); }
	}
//	
	public Material _material;
	public Material material
	{
		get
		{
			if (_material == null)
			{
				_material = new Material(shader);
				_material.hideFlags = HideFlags.HideAndDontSave;
			}
			return _material;
		}
	}
	
	private RenderTexture m_colorTex;
	private RenderTexture m_depthTex;
	public Material m_postRenderMat;
	void Start ()
	{
		Camera cam = GetComponent<Camera>();
		cam.depthTextureMode = DepthTextureMode.Depth;
		
		// カラーバッファ用 RenderTexture
		m_colorTex = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);
		m_colorTex.Create();
		
		// デプスバッファ用 RenderTexture
		m_depthTex = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.Depth);
		m_depthTex.Create();
		
		// cameraにカラーバッファとデプスバッファをセットする
		cam.SetTargetBuffers(m_colorTex.colorBuffer, m_depthTex.depthBuffer);

		if (!SystemInfo.supportsImageEffects)
		{
			print("System doesn't support image effects");
			enabled = false;
			return;
		}
		if (shader == null || !shader.isSupported)
		{
			enabled = false;
			print("Shader " + shader.name + " is not supported");
			return;
		}
		
		// turn on depth rendering for the camera so that the shader can access it via _CameraDepthTexture
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;

	}
//	
	private void OnDisable()
	{
		if (_material != null)
			DestroyImmediate(_material);
	}
	
	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
//		if (shader != null)
//		{
//			material.SetFloat("_DepthLevel", depthLevel);
//			Graphics.Blit(src, dest, material);
//		}
//		else
//		{
//			Graphics.Blit(src, dest);
//		}
	}
//
	void OnPostRender()
	{
		// RenderTarget無し：画面に出力される
		//Graphics.SetRenderTarget(null);
		
		// デプスバッファを描画する(m_postRenderMatはテクスチャ画像をそのまま描画するマテリアル)
		//Graphics.Blit(m_depthTex, material);
	}
}