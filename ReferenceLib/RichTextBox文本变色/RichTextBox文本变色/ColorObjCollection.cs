using System;
using System.Drawing;
using System.Collections;

namespace RichTextBox�ı���ɫ
{
	/// <summary>
	/// ColorObjCollection ��ժҪ˵����
	/// </summary>
	public class ColorObjCollection
	{
		public ColorObjCollection()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public ColorObjCollection(Color color,Color color1,Color color2,Color color3,Color color4)
		{
			COLORLIST = new Color[]{color,color1,color2,color3,color4};
		}
		public Color[] COLORLIST;
	}
}
