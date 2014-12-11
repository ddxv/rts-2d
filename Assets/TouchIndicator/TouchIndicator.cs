using UnityEngine;
using System.Collections;

public class TouchIndicator : MonoBehaviour
{
	float animationDuration;
	
	GUITexture thisImage;
	
	float startColorAlpha;

	Vector2 startPosition;
	float endSize;
	
	float animStartTime;
	float animDeltaTime;

	public void MakeIndicator (int size, float animDuration, Color color, float startAlpha, Vector2 startPos)
	{
//		Get references to components
		thisImage = gameObject.GetComponent<GUITexture> ();
		animationDuration = animDuration;

		endSize = size;
		startPosition = startPos;

		thisImage.color = new Color (color.r, color.g, color.b, startAlpha);

		startColorAlpha = startAlpha;

		animStartTime = Time.realtimeSinceStartup;
	}
	
	void Update ()
	{
		animDeltaTime = Time.realtimeSinceStartup - animStartTime;
		
		if (animDeltaTime <= animationDuration)
		{
			Rect tempRect = thisImage.pixelInset;
			tempRect.width = EaseOutQuintAnim (0f, endSize, animDeltaTime, animationDuration);
			tempRect.height = tempRect.width;
			tempRect.x = startPosition.x - tempRect.width / 2;
			tempRect.y = startPosition.y - tempRect.width / 2;
			thisImage.pixelInset = tempRect;

			Color tempColor = thisImage.color;
			tempColor.a = EaseOutQuintAnim (startColorAlpha, 0f, animDeltaTime, animationDuration);
			thisImage.color = tempColor;
		}
		else
		{
			Destroy (gameObject);
		}
	}

	float EaseOutQuintAnim (float startValue, float endValue, float time, float duration)
	{
		float differenceValue = endValue - startValue;
		time = Mathf.Clamp (time, 0f, duration);
		time /= duration;
		time--;
		return differenceValue * (time * time * time * time * time + 1) + startValue;
	}
}
