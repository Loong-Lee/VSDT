using System;
using System.Text;
using System.Collections;
using System.Drawing;

namespace RichTextBox�ı���ɫ
{
    /// <summary>
    /// ���ɲ��ظ��Ҳ����Ƶ����ɫ�ʵ���������
    /// </summary>
    public class DRandomColor
    {
        private Random random;

        /// <summary>
        /// ���캯����
        /// </summary>
        public DRandomColor()
        {
            random = new Random();
        }

        /// <summary>
        /// ���ö���
        /// </summary>
        public void Reset()
        {
            colors.Clear();
        }

        /// <summary>
        /// ���RGB���Ƿ��ڷ�Χ�С�
        /// </summary>
        /// <param name="value">������RGB�롣</param>
        /// <returns></returns>
        private int CheckRGB(int value)
        {
            if (value < 0)
                return 0;
            else if (value > 255)
                return 255;
            else
                return value;
        }

        /// <summary>
        /// ��ȡ�����ú�ɫֵ���ޡ�
        /// </summary>
        public int Red_Min
        {
            get
            {
                return this.R_min;
            }
            set
            {
                this.R_min = CheckRGB(value);
            }
        }

        /// <summary>
        /// ��ȡ�����ú�ɫֵ���ޡ�
        /// </summary>
        public int Red_Max
        {
            get
            {
                return this.R_max;
            }
            set
            {
                this.R_max = CheckRGB(value);
            }
        }

        /// <summary>
        /// ��ȡ��������ɫֵ���ޡ�
        /// </summary>
        public int Green_Min
        {
            get
            {
                return this.G_min;
            }
            set
            {
                this.G_min = CheckRGB(value);
            }
        }

        /// <summary>
        /// ��ȡ��������ɫֵ���ޡ�
        /// </summary>
        public int Green_Max
        {
            get
            {
                return this.G_max;
            }
            set
            {
                this.G_max = CheckRGB(value);
            }
        }

        /// <summary>
        /// ��ȡ��������ɫֵ���ޡ�
        /// </summary>
        public int Blue_Min
        {
            get
            {
                return this.B_min;
            }
            set
            {
                this.B_min = CheckRGB(value);
            }
        }
        /// <summary>
        /// ��ȡ��������ɫֵ���ޡ�
        /// </summary>
        public int Blue_Max
        {
            get
            {
                return this.B_max;
            }
            set
            {
                this.B_max = CheckRGB(value);
            }
        }

        /// <summary>
        /// ��ȡ��������������������ɫ�Ĳ��̶�ֵ����ϣ�����ɵ���ɫ����ȥ̫���ƣ�
        /// �Ͼ����۵�ʶ���������ޡ���ֵԽ�����������ɫ�������Խ�󡣸�ֵ���100,
        /// ������ʾ���������ظ�ɫ�ʡ�
        /// </summary>
        public int DifferenceGrade
        {
            get
            {
                return this.differenceGrade;
            }
            set
            {
                if (value > 100)
                    this.differenceGrade = 100;
                else if (value < 0)
                    this.differenceGrade = -1;
                else
                    this.differenceGrade = value;
            }
        }

        /// <summary>
        /// ��¼������ɵ�ɫ�ʣ����ڷ�ֹ�����ظ�ɫ��
        /// </summary>
        private ArrayList colors = new ArrayList();

        /// <summary>
        /// ��Ԫɫ��Χֵ����Ϊ��ɫֵԽС����ɫԽ�RGB����0�ɾ����һƬ����ʹ������0������������50���£�Ҳ�ῴ���������ϵ��֣���
        /// �������⣬�û���벻��ϲ��Rֵ���ͣ�ʹ������ƣ����������Ӿ�ϲ�ã������������ñ����Է����޸ĵ��ء�
        /// </summary>
        private int R_min = 75, R_max = 200, G_min = 75, G_max = 200, B_min = 75, B_max = 200;

        /// <summary>
        /// ��������������ɫ�Ĳ��̶ȡ���ϣ�����ɵ���ɫ����ȥ̫���ƣ�
        /// �Ͼ����۵�ʶ���������ޡ���ֵԽ�����������ɫ�������Խ��
        /// </summary>
        private int differenceGrade = 100;

        /// <summary>
        /// ��ȡ���ɫ����colors����һ��ʵ�����ظ����ɫ���ɡ�
        /// </summary>
        /// <returns></returns>
        public Color GetRandomColor()
        {
            Color result = Color.White;
            bool isRepeat = false;
            do
            {
                isRepeat = false;
                int r = random.Next(R_min, R_max);
                int g = random.Next(G_min, G_max);
                int b = random.Next(B_min, B_max);
                result = Color.FromArgb(r, g, b);
                foreach (object i in colors)
                {
                    Color c = (Color)i;
                    if ((System.Math.Abs(c.R - result.R) + System.Math.Abs(c.G - result.G) + System.Math.Abs(c.B - result.B)) < differenceGrade)
                    {
                        isRepeat = true;
                        break;
                    }
                }
            } while (isRepeat);
            colors.Add(result);
            return result;
        }

		public Color CustomColor(int r,int g,int b)
		{
			Color result = Color.White;
			result = Color.FromArgb(r, g, b);
			return result;
		}

    }
}
