using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using System.IO;

namespace EF
{
 
	public enum EFProdOpeationType
	{
		Plan,
		Command,
		Material
	}

	public class UniqueOpenedForms
	{
		private static Hashtable _forms = new Hashtable();
		public static bool Contains(string formName)
		{
			return _forms.ContainsKey(formName);
		}

		public static Form Get(string formName)
		{
			return (Form)_forms[formName];
		}

		public static void Add(string formName, Form form)
		{
			if(!_forms.ContainsKey(formName))
				_forms.Add(formName, form);			
		}

		public static void Remove(string formName)
		{
			if(_forms.ContainsKey(formName))
				_forms.Remove(formName);			
		}

	}

	/// <summary>
	/// 
	/// </summary>
	public class QueryConditionCollection : ArrayList
	{
		public int Add(string qc)
		{
			return this.Add((object)qc);
		}

		public string GetConditions(bool bWhere)
		{
			if(Count == 0)
				return string.Empty;
			
			string cond = string.Empty;
			if(bWhere)
				cond = " Where";
			else
				cond = " And";
			int i=0;
			foreach(string qc in this)
			{
				if(i++==0)
					cond += " "+qc;
				else
					cond += " AND "+qc;

			}
			return cond;

		}
	}

	/// <summary>
	/// 
	/// </summary>
	public struct QueryPagerInfo
	{
		public QueryPagerInfo(string _sql, int _start, int _count)
		{
			sql= _sql;
			start = _start;
			count = _count;
		}
		public string	sql;
		public int		start;
		public int		count;
	}
	/// <summary>
	/// Utility ��ժҪ˵����
	/// </summary>
	public class Utility
	{
 
 
		/// <summary>
		/// ��ȡָ���嵥��Դ�е�ָ������ֵ
		/// </summary>
		/// <param name="s_res_name">�嵥��Դ</param>
		/// <param name="s_key_name">����</param>
		/// <returns>��ֵ</returns>
		public static string ReadFromResource(System.Reflection.Assembly assemboy, string s_res_name , string s_key_name)
		{
			ResourceReader reader = new ResourceReader(assemboy.GetManifestResourceStream(s_res_name+".resources"));
			IDictionaryEnumerator en = reader.GetEnumerator();
			while(en.MoveNext())
			{
				if((string)en.Key == s_key_name)
				{
					return (string)en.Value;
				}
			}
			return string.Empty;
		}


		public static string ReadAndReplaceResource(System.Reflection.Assembly assemboy
			, string s_res_name
			, string s_key_name
			, string[] entries, bool ignoreCase)
		{
			string s = EF.Utility.ReadFromResource(assemboy, s_res_name, s_key_name);
			s = EF.Utility.BatchReplace(s, entries, ignoreCase);
			return s;
		}

		public static string BatchReplace(string s, string[] entries, bool ignoreCase)
		{
			if(entries.Length % 2 == 1)
				return s;

			int count = entries.Length / 2;
			System.Text.StringBuilder sb = null;
			if(ignoreCase)
			{
				sb = new System.Text.StringBuilder(s);
				for(int i=0; i<count; i++)
				{
					sb.Replace(entries[i*2], entries[i*2+1]);
				}
			}
			else
			{
				sb = new System.Text.StringBuilder(s);
				for(int i=0; i<count; i++)
				{
					sb.Replace(entries[i*2], entries[i*2+1]);
				}
			}
			return sb.ToString();
		}
  
		public static string GetQueryCountSql(string deatialSql)
		{
			int nBraces = 0;
			int nBrackets = 0;
			int nParentheses = 0;
			int nSingleQuotationMarks = 0;
			int nDoubleQuotationMarks = 0;

			string tmpDeatialSql = deatialSql.Trim().ToUpper();
			int nStartPos = 6;
			int nFromPos = 6;
			do
			{
				nFromPos = tmpDeatialSql.IndexOf("FROM", nStartPos);
				for(int i=nStartPos; i<nFromPos; i++)
				{
					switch(tmpDeatialSql[i])
					{
						case '{':
							nBraces++;
							break;
						case '}':
							nBraces--;
							break;
						case '[':
							nBrackets++;
							break;
						case ']':
							nBrackets--;
							break;
						case '(':
							nParentheses++;
							break;
						case ')':
							nParentheses--;
							break;
						case '\'':
							nSingleQuotationMarks = ~nSingleQuotationMarks;
							break;
						case '"':
							nDoubleQuotationMarks = ~nDoubleQuotationMarks;
							break;
					}					
				}
				if( nBraces*nBrackets*nParentheses*nSingleQuotationMarks*nDoubleQuotationMarks == 0)
				{
					return deatialSql.Substring(0, 7) + " COUNT(*) " + deatialSql.Substring(nFromPos);
				}
				nStartPos = nFromPos;
			}while(nFromPos>=0);
			
			return string.Empty;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public static string GetProdShiftNo(DateTime time)
		{
			if(time.Hour < 8)
				return "1";
			else if(time.Hour < 16)
				return "2";
			else 
				return "3";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public static string GetProdShiftGroup(DateTime time)
		{
			TimeSpan ts = new TimeSpan(0);
			string sShiftNo = GetProdShiftNo(time);
			//����2006-2-20 Ϊ���������ҹ�ඡ���еĵ�һ��
			if(sShiftNo == "1" || sShiftNo == "2")
			{
				ts = time-new DateTime(2006, 2, 20);
			}
			else if(sShiftNo =="3")
			{
				ts = time-new DateTime(2006, 2, 19);
			}

			int iShiftValue = (3-(int)Math.Floor((ts.TotalDays % 8)/2.0f)+(int)Math.Floor(time.Hour/8.0f))%4;
			char cShiftGroup = '1';
			cShiftGroup = (char)((int)cShiftGroup + iShiftValue); 

			return new string(cShiftGroup, 1);

		}
 
        /// <summary>
        /// ���ݵ�ǰiPlat4C.xml�е��ַ������ȡ�ַ�������
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        static public int GetByteLength(string strValue)
        {
            //��������:
            //Ĭ����gbk
            //����gbk    ʱ: ���ֶ�Ӧ2 λ,����Ϊ1λ
            //����unicodeʱ: ȫΪ2λ
            //����utf-8  ʱ: ����Ϊ3λ,����Ϊ1λ
            System.Text.Encoding encoding = System.Text.Encoding.Default;
            try
            {
                encoding = System.Text.Encoding.GetEncoding("EC.ProjectConfig.Instance.CurrentServers[0].CharSet");
            }
            catch { 
              encoding = System.Text.Encoding.Default;
            }
            return encoding.GetByteCount(strValue);
             
        }




	


		/// <summary>
		/// ��Grid��ȡֵ������Ӧ�Ŀؼ���
		/// </summary>


		static public bool ControlArrayContains(Control [] controlArray, Control controlMatch)
		{
			if (controlArray == null || controlArray.Length < 1)
				return false;

			for (int i=0; i< controlArray.Length; i++)
			{
				if (controlArray[i] == controlMatch)
					return true;
			}

			return false;
		}
 
 
		static public double CalcCoilMatOuterDia(double matWt, double matInnerDia, double matWidth)
		{
			matInnerDia = matInnerDia /1000;
			matWidth = matWidth / 1000;
			return 1000*2*Math.Sqrt((matWt/(Math.PI*matWidth*7.8)+ (matInnerDia/2)*(matInnerDia/2)));
		} 
  
        /// <summary>
        /// ����ָ����
        /// </summary>
        /// <param name="dtSoure"></param>
        /// <param name="drRow"></param>
        /// <returns></returns>
        public static DataRow AddCopyRow(DataTable dtSoure, DataRow drRow)
        {
            try
            {
                DataRow dr = dtSoure.NewRow();
                for (int nIndex = 0; nIndex < dtSoure.Columns.Count; nIndex++)
                {
                    dr[dtSoure.Columns[nIndex].ColumnName] = drRow[dtSoure.Columns[nIndex].ColumnName];
                }
                //���û������Լ��,������
                if (dtSoure.Constraints.Count < 1)
                {
                    dtSoure.Rows.Add(dr);
                }
                return dr;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static void CheckUnSavedChange(System.Windows.Forms.BindingSource tBindSource)
        {
            CheckUnSavedChange(true, tBindSource);
        }
        /// <summary>
        /// ��ѯ�Ƿ��и���
        /// </summary>
        /// <param name="isQuery">
        /// �Ƿ��ǲ�ѯ,true .�ǲ�ѯʱ,����Ƿ��и���,
        ///            false �����ǲ�ѯʱ,�������д���,����ʾ����</param>
        /// <param name="tBindSource"></param>
        public static void CheckUnSavedChange(bool isQuery, System.Windows.Forms.BindingSource tBindSource)
        {
            try
            {
                tBindSource.EndEdit();
                DataSet dsBindSet = new DataSet();
                if (tBindSource.DataSource is DataSet)
                {
                    dsBindSet = (DataSet)tBindSource.DataSource;
                }
                else if (tBindSource.DataSource is DataTable)
                {
                    DataTable dt = (DataTable)tBindSource.DataSource;
                    dsBindSet = dt.DataSet;
                }
                if (dsBindSet.HasChanges())
                {
                    throw new Exception("�����ѱ����ġ�");
                }
            }
            catch (Exception ex)
            {
                if (!isQuery)
                {
                    if (!ex.Message.Equals("�����ѱ����ġ�"))
                        throw new Exception(ex.Message);

                }
                DialogResult dr = EF.EFMessageBox.Show("��������ʧδ����ĸ��ģ��Ƿ������", "epEname", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    throw new Exception("�������.���������ĸ��ġ�");
                }
            }
        }
        /// <summary>
        /// LayoutControlHelper ��
        /// LayoutControl�ؼ��ĸ�����.
        /// ��������:layoutControl�ؼ�,configType��������,className������,moduleNameģ������
        /// </summary>
        public class LayoutControlHelper
        {
            /// <summary>
            /// �ؼ�LayoutControl
            /// </summary>
            public DevExpress.XtraLayout.LayoutControl layoutControl;
            /// <summary>
            /// ��������
            /// </summary>
            public ConfigEnum configType = ConfigEnum.Default;
            /// <summary>
            /// ������(��������Ϊ:: ������+form����+_layoutControl����.xml )
            /// </summary>
            public string className = "";
            /// <summary>
            /// ģ����,Ĭ��ȡ�������Ƶĵ�4��6λ
            /// </summary>
            public string moduleName = "";

            public LayoutControlHelper(DevExpress.XtraLayout.LayoutControl layoutControl)
            {
                this.layoutControl = layoutControl;
                layoutControl.OptionsCustomizationForm.ShowPropertyGrid = true;//��ʾ�������ÿ�
                //Ϊ���水ť�����¼�
                layoutControl.ShowCustomization += new System.EventHandler(this.layoutControl1_ShowCustomization);
            }

            private void layoutControl1_ShowCustomization(object sender, EventArgs e)
            {
                layoutControl = (DevExpress.XtraLayout.LayoutControl)sender;
                if (layoutControl != null)
                {
                    if (layoutControl.CustomizationForm != null)
                    {
                        (layoutControl.CustomizationForm as DevExpress.XtraLayout.Customization.CustomizationForm).buttonsPanel1.UnRegister();
                        //��ֹ�������¼�,���Ƴ�,�����
                        (layoutControl.CustomizationForm as DevExpress.XtraLayout.Customization.CustomizationForm).buttonsPanel1.SaveLayoutButton.Click -= new EventHandler(efBtnSaveLayout_Click);
                        (layoutControl.CustomizationForm as DevExpress.XtraLayout.Customization.CustomizationForm).buttonsPanel1.SaveLayoutButton.Click += new EventHandler(efBtnSaveLayout_Click);
                    }
                }
            }
            private void efBtnSaveLayout_Click(object sender, EventArgs e)
            {
                SaveLayout(layoutControl, this.configType, className, moduleName);
            }
            #region ����ͼ��ز���:���ֵ��ļ�����Ϊ (�����ClassName+����Form������+"_"+EFDevLayoutControl������)
            public enum ConfigEnum
            {
                UserConfig,
                EPConfig,
                Default //Ĭ���Ȳ����û�����,û���������Ŀ����
            }
            /******************************8
            /// <summary>
            /// �Դ���Form������+"_"+EFDevLayoutControl������,�Լ�Ĭ������ģʽ[�ݶ��û���]����grid����
            /// </summary>
            public void SaveLayout(DevExpress.XtraLayout.LayoutControl layoutControl)
            {
                SaveLayout(layoutControl, ConfigEnum.Default);
            }
            /// <summary>
            /// �Դ���Form������+"_"+gridView������,�Լ��ƶ�������ģʽ����grid����
            /// </summary>
            /// <param name="ConfigModule">�û�������Ŀ��</param>
            public void SaveLayout(DevExpress.XtraLayout.LayoutControl layoutControl, ConfigEnum ConfigModule)
            {
                this.SaveLayout(layoutControl, ConfigModule, string.Empty, string.Empty);
            }
            ******************************/
            /// <summary>
            ///  �ļ�Ŀ¼�������򴴽�,XML��������Ϊ: className +"��������_"+EFDevLayoutControl������.XML. 
            ///  ---2011-10-27 �� XML�������� ��Ϊ "��������_"+EFDevLayoutControl������+_className.XML
            /// </summary>  
            /// <param name="ConfigModule">����Ĭ��,�û�������Ŀ��</param>
            /// <param name="className">����,�����������û���ʱ,Ϊ�����ֲ�ͬ������������ </param>   
            /// <param name="moduleName">һ��ģ������(��DE,Ϊ��ʱȡ�������Ƶĵ�4��6λ)</param>
            public void SaveLayout(DevExpress.XtraLayout.LayoutControl layoutControl, ConfigEnum ConfigModule, string className, string moduleName)
            {
                //ģ������
                string formName = layoutControl.FindForm().Name;
                if (moduleName.Trim().Equals(""))
                {
                    moduleName = formName.Length > 6 ? formName.Substring(4, 2) : formName;
                }
                if (formName.StartsWith("Form"))
                {
                    formName = formName.Substring(4);
                }
                //XML·��
                string fileDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
                fileDirectory = Path.GetDirectoryName(fileDirectory);
                if (ConfigModule == ConfigEnum.UserConfig)
                {
                    //λ��UserConfig��,�û����ļ�����,һ��ģ����
                    fileDirectory = fileDirectory + "\\..\\UserConfig\\" + "EF.EF_Args.formUserId" + "\\" + moduleName + "\\";
                }
                else if (ConfigModule == ConfigEnum.EPConfig)
                {
                    //λ��һ��ģ����
                    fileDirectory = fileDirectory + "\\..\\" + moduleName + "\\";
                }
                else
                {
                    //λ��UserConfig��,�û����ļ�����,һ��ģ���� (Ĭ���û�����)
                    fileDirectory = fileDirectory + "\\..\\UserConfig\\" + "EF.EF_Args.formUserId" + "\\" + moduleName + "\\";
                }
                string fileDirectory2 = "";
                try
                {
                    fileDirectory2 = fileDirectory + "EC.UserConfig.Instance.Culture" + "\\";
                }
                catch { }
                //�ļ�Ŀ¼�������򴴽�[�߼���,������Ŀ����ʱ,ģ��Ŀ¼һ������,���򱨴�]
                if (!System.IO.Directory.Exists(fileDirectory))
                {
                    System.IO.Directory.CreateDirectory(fileDirectory);
                }
                if (fileDirectory2 != "" && !System.IO.Directory.Exists(fileDirectory2))
                {
                    System.IO.Directory.CreateDirectory(fileDirectory2);
                }
                //�����ļ���
                //string fileName = className.Trim() + formName + "_" + layoutControl.Name + ".xml";
                //  ---2011-10-27 �� XML�������� ��Ϊ "��������_"+EFDevLayoutControl������+_className.XML
                string fileName = formName + "_" + layoutControl.Name +(className.Trim().Equals("")?"":("_"+className.Trim()))+ ".xml";
                string filePath = fileDirectory + fileName;
                string filePath2 = fileDirectory2 + fileName;
                bool isFirstConfig = false;
                if (System.IO.File.Exists(filePath))
                {
                    if (System.IO.File.Exists(filePath2))
                    {
                        //�ļ��Ѵ���,����ʾ,�Ƿ񸲸�
                        if (EF.EFMessageBox.Show("�����ļ��Ѵ���,�Ƿ��滻��","��ʾ", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    isFirstConfig = false;
                }
                if (isFirstConfig)
                {
                    //��ʹ�ǵ�һ������Ҳ�����浽Ĭ��Ŀ¼��.ֻ�ŵ���Ӧ����Ŀ¼��
                   // layoutControl.SaveLayoutToXml(filePath);
                }
                layoutControl.SaveLayoutToXml(filePath2);
            }
            public void LoadLayout()
            {
                  LoadLayout(layoutControl, this.configType, className, moduleName);
            }
            /// <summary>
            /// Ѱ��(�Դ���Form������+"_"+EFDevLayoutControl������)�������ļ�.���ز���..�Ȳ����û�Ŀ¼,û���������Ŀ��Ŀ¼,û���򲻲���
            /// </summary>
            public void LoadLayout(DevExpress.XtraLayout.LayoutControl layoutControl)
            {
                  LoadLayout(layoutControl, this.configType, className, moduleName);
            }
            /// <summary>
            ///  Ѱ��(�Դ���Form������+"_"+EFDevLayoutControl������)�������ļ�.���ز���..���ݲ���(����ģʽ)ѡ���ӦĿ¼�µ������ļ�.
            /// </summary>
            /// <param name="ConfigModule"></param>
            public void LoadLayout(DevExpress.XtraLayout.LayoutControl layoutControl, ConfigEnum ConfigModule)
            {
                  LoadLayout(layoutControl, this.configType, className, moduleName);
            }
            /// <summary>
            ///  Ѱ��(��className+����Form������+"_"+EFDevLayoutControl������)�������ļ�.���ز���..���ݲ���(����ģʽ)ѡ���ӦĿ¼�µ������ļ�.
            /// </summary>
            /// <param name="ConfigModule">����ģʽ,Ĭ��ʱ�Ȳ����û�����,�ٲ�����Ŀ������..</param>
            /// <param name="className">������[����������_+EFDevLayoutControl���Ʋ�������Ψһxml�ļ�������ʱ,�ڿ�ͷ���������</param>
            /// <param name="moduleName">һ��ģ������.��DE,FI��</param>
            public void LoadLayout(DevExpress.XtraLayout.LayoutControl layoutControl, ConfigEnum ConfigModule, string className, string moduleName)
            {
                //ģ������
                string formName = layoutControl.FindForm().Name;
                if (moduleName.Trim().Equals(""))
                {
                    moduleName = formName.Length > 6 ? formName.Substring(4, 2) : formName;
                }
                if (formName.StartsWith("Form"))
                {
                    formName = formName.Substring(4);
                }
                //XML·��
                string fileDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
                fileDirectory = Path.GetDirectoryName(fileDirectory);
                string fileDirectoryUser = fileDirectory + "\\..\\UserConfig\\" + "EF.EF_Args.formUserId" + "\\" + moduleName + "\\";
                string fileDirectoryEP = fileDirectory + "\\..\\" + moduleName + "\\";

                //�Ȳ鿴�û�������,Ŀ¼�����ڶ�ȡ��Ŀ����
                //  ---2011-10-27 �� XML�������� ��Ϊ "��������_"+EFDevLayoutControl������+_className.XML
                string fileName = formName + "_" + layoutControl.Name + (className.Trim().Equals("") ? "" : ("_" + className.Trim())) + ".xml";
                //string fileName = className.Trim() + formName + "_" + layoutControl.Name + ".xml";
                string filePath = "";
                if (ConfigModule == ConfigEnum.EPConfig)
                {
                    filePath = fileDirectoryEP + fileName;
                }
                else if (ConfigModule == ConfigEnum.UserConfig)
                {
                    filePath = fileDirectoryUser + fileName;
                }
                else //Ĭ������.�ȶ�ȡ�û�������,���������ȡ��Ŀ������
                {
                    filePath = fileDirectoryUser + fileName;
                    if (!  IsFileExit(ref filePath))//������,���ȡ��Ŀ����
                    {
                        filePath = fileDirectoryEP + fileName;
                    }
                }

                if   (IsFileExit(ref filePath))    // (System.IO.File.Exists(filePath))  //����,���ȡ
                {

                    //string EPConfigXML = fileDirectoryEP + fileName; //��Ŀ������xml
                    //��Ŀ������xml ������ھ��鷳��---������,��ֱ�Ӷ�ȡ�����ļ�
                    //---�ȼ�����Ŀ������,�Ѳ��ɼ�����,����Ϊ��������
                    //---������û������� "�ټ����û�������",�����˳�
                    //---�ٰѲ�����������Ϊ���ɼ�
                    //if (System.IO.File.Exists(EPConfigXML))
                    //{
                    //    layoutControl.RestoreLayoutFromXml(EPConfigXML);
                    //    if (view is DevExpress.XtraGrid.Views.Grid.GridView)
                    //    {
                    //        foreach (DevExpress.XtraGrid.Columns.GridColumn gridCol in ((DevExpress.XtraGrid.Views.Grid.GridView)view).Columns)
                    //        {
                    //            gridCol.OptionsColumn.ShowInCustomizationForm = gridCol.Visible;
                    //        }
                    //    }
                    //    //Ȼ������û�������
                    //    if (filePath.Equals(EPConfigXML))
                    //    {
                    //        break;
                    //    }
                    //    view.RestoreLayoutFromXml(filePath);
                    //    //Ȼ���ٴμ��,����Ŀ�����ɼ���,Ҳ��Ϊ���ɼ�
                    //    if (view is DevExpress.XtraGrid.Views.Grid.GridView)
                    //    {
                    //        foreach (DevExpress.XtraGrid.Columns.GridColumn gridCol in ((DevExpress.XtraGrid.Views.Grid.GridView)view).Columns)
                    //        {
                    //            gridCol.Visible = gridCol.OptionsColumn.ShowInCustomizationForm;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    view.RestoreLayoutFromXml(filePath);
                    //}
                    layoutControl.RestoreLayoutFromXml(filePath);
                   // return true;
                }
                else
                {
                   // return false;
                }
            }

            private bool IsFileExit(ref string fileFullPath)
            {
                string filePath = fileFullPath;
                try
                {
                    string culture = "\\" + "EC.UserConfig.Instance.Culture";
                    int last = filePath.LastIndexOf("\\");
                    filePath = filePath.Insert(last, culture);
                    if (File.Exists(filePath))
                    {
                        fileFullPath = filePath;
                        return true;
                    }
                    return File.Exists(fileFullPath);
                }
                catch { }
                return File.Exists(fileFullPath);
            }
            #endregion

		}

		public static bool SetGridColumn(EF.EFDevGrid[] efGrid, string[] edFuncId)
		{
			int items = efGrid.Length < edFuncId.Length ? efGrid.Length : edFuncId.Length;
			if (items < 1)
			{
				return false;
			}

			try
			{
				string dll_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\EFX.dll";
				

				System.Reflection.Assembly assembly_EFX = System.Reflection.Assembly.LoadFrom(dll_path);

				Type myType = assembly_EFX.GetType("EFX.EFCGrid");

				System.Reflection.MethodInfo InitSingleGridColumn_MethodInfo
					= myType.GetMethod("InitMultiGridColumn", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

				if (InitSingleGridColumn_MethodInfo != null)
				{
					InitSingleGridColumn_MethodInfo.Invoke(null, new object[] { efGrid, edFuncId });
				}
			}
			catch (Exception e)
			{
				EF.EFMessageBox.Show(e.Message);
				return false;
			}

			return true;

/*
			EI.EIInfo inBlk = new EI.EIInfo();
			inBlk.SetColName(1, "func_id");
			int i = 0;
			for (i = 0; i < items; ++i)
			{
				inBlk.SetColVal(i + 1, "func_id", edFuncId[i]);
			}
			
			EI.EIInfo outBlk = EI.EITuxedo.CallService("eped54_inq_cfg1", inBlk);
			if (outBlk.GetSys().flag == 0)
			{
				try
				{
					string item_ename;
					string item_cname;
					string item_type;
					string item_len;
					string code_class;
					string form_edit_flag;
					string item_default_value;
					string item_hide_flag;

					DataSet DSsource = new DataSet();
					DataTable dtsource = null;
					outBlk.GetBlockVal(DSsource);
					DevExpress.XtraGrid.Columns.GridColumn gridcolumn = null;
					DevExpress.XtraGrid.Views.Grid.GridView gridview = null;
					for (i = 0; i < items; ++i)
					{
						DataTable dt = new DataTable();
						dt.TableName = edFuncId[i];
						dtsource = DSsource.Tables[edFuncId[i]];
						if (dtsource.Rows.Count < 1)
						{
							throw new Exception("Not found func_id :" + edFuncId[i]);
						}
						efGrid[i].BeginUpdate();
						if (efGrid[i].MainView is DevExpress.XtraGrid.Views.Grid.GridView)
						{
							gridview = efGrid[i].MainView as DevExpress.XtraGrid.Views.Grid.GridView;
							gridview.Columns.Clear();
						}
						else
						{
							efGrid[i].MainView.Dispose();
							gridview = new DevExpress.XtraGrid.Views.Grid.GridView(efGrid[i]);
							efGrid[i].MainView = gridview;
						}
						gridview.BeginUpdate();
						efGrid[i].Tag = dtsource;
						for (int row = 0; row < dtsource.Rows.Count; ++row)
						{
							item_hide_flag = dtsource.Rows[row]["item_hide_flag"].ToString().Trim();
							item_ename = dtsource.Rows[row]["item_ename"].ToString().Trim();
							item_cname = dtsource.Rows[row]["item_cname"].ToString().Trim();
							item_type = dtsource.Rows[row]["item_type"].ToString().Trim();
							item_len = dtsource.Rows[row]["item_len"].ToString().Trim();
							code_class = dtsource.Rows[row]["code_class"].ToString().Trim();
							form_edit_flag = dtsource.Rows[row]["form_edit_flag"].ToString().Trim();
							item_default_value = dtsource.Rows[row]["item_default_value"].ToString().Trim();

							gridcolumn = new DevExpress.XtraGrid.Columns.GridColumn();
							gridview.Columns.Add(gridcolumn);
							gridcolumn.Caption = item_cname;
							gridcolumn.Name = item_ename;
							gridcolumn.FieldName = item_ename;
							gridcolumn.Visible = !("1" == item_hide_flag || "2" == item_hide_flag);
							if (gridcolumn.Visible)
							{
								gridcolumn.VisibleIndex = gridview.Columns.Count;
							}
							gridcolumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
							gridcolumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

							DataColumn col = dt.Columns.Add(item_ename);
							col.Caption = item_cname;
							if (item_type == "N")
							{
								if (item_len.Contains(","))
								{
									col.DataType = typeof(double);
									if (item_default_value != string.Empty)
									{
										col.DefaultValue = double.Parse(item_default_value);
									}
								}
								else
								{
									col.DataType = typeof(int);
									if (item_default_value != string.Empty)
									{
										col.DefaultValue = int.Parse(item_default_value);
									}
								}
								if (item_default_value == string.Empty)
								{
									col.DefaultValue = 0;
								}
								gridcolumn.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
							}
							else if (item_type == "O" || item_type == "H")
							{
								DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupedit =
									new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
								gridcolumn.ColumnEdit = lookupedit;
								lookupedit.DataSource = DSsource.Tables["CODECLASS:" + code_class];
								lookupedit.AutoHeight = false;
								lookupedit.Name = "LookUpEdit_" + code_class;
								lookupedit.DisplayMember = lookupedit.ValueMember = "CODE";
								if ("H" == item_type)
								{
									lookupedit.DisplayMember = "CODE_DESC_1_CONTENT";
								}
								lookupedit.Properties.NullText = "";
								col.DefaultValue = item_default_value;
								lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "����"));
								if (dtsource.Rows[row]["CODE_BIND_ENAME1"].ToString().Trim() == string.Empty
									&& dtsource.Rows[row]["CODE_BIND_ENAME2"].ToString().Trim() == string.Empty
									&& dtsource.Rows[row]["CODE_BIND_ENAME3"].ToString().Trim() == string.Empty
									&& dtsource.Rows[row]["CODE_BIND_ENAME4"].ToString().Trim() == string.Empty
									&& dtsource.Rows[row]["CODE_BIND_ENAME5"].ToString().Trim() == string.Empty)
								{
									//lookupedit.DisplayMember = "CODE_DESC_1_CONTENT";
									lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE_DESC_1_CONTENT", "����"));
								}
								else
								{
									//lookupedit.DisplayMember = "CODE";
									if (dtsource.Rows[row]["CODE_BIND_ENAME1"].ToString().Trim() != string.Empty)
									{
										lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE_DESC_1_CONTENT", "����1"));
									}
									if (dtsource.Rows[row]["CODE_BIND_ENAME2"].ToString().Trim() != string.Empty)
									{
										lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE_DESC_2_CONTENT", "����2"));
									}
									if (dtsource.Rows[row]["CODE_BIND_ENAME3"].ToString().Trim() != string.Empty)
									{
										lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE_DESC_3_CONTENT", "����3"));
									}
									if (dtsource.Rows[row]["CODE_BIND_ENAME4"].ToString().Trim() != string.Empty)
									{
										lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE_DESC_4_CONTENT", "����4"));
									}
									if (dtsource.Rows[row]["CODE_BIND_ENAME5"].ToString().Trim() != string.Empty)
									{
										lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE_DESC_5_CONTENT", "����5"));
									}
									lookupedit.EditValueChanged += new EventHandler(EF.CustomCols.SetGridColumn_lookupedit_EditValueChanged);
								}
							}
							else if (item_type == "F")		// ��������
							{
								DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttedit =
									new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
								gridcolumn.ColumnEdit = buttedit;
								buttedit.Name = code_class;
								buttedit.Tag = code_class;
								col.DefaultValue = item_default_value;
								buttedit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(EF.CustomCols.SetGridColumn_buttedit_ButtonClick);
							}	
							else if ("D" == item_type)		// ʱ������
							{
								DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateEdit =
									new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
								gridcolumn.ColumnEdit = dateEdit;
								string strEditMask = dtsource.Rows[row]["editmask"].ToString().Trim();
								if (strEditMask == string.Empty)
								{
									strEditMask = "yyyyMMdd";
								}
								//dateEdit.EditMask = strEditMask;
								//dateEdit.Mask.UseMaskAsDisplayFormat = true;

								dateEdit.DisplayFormat.FormatString = strEditMask;
								dateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
								dateEdit.DisplayFormat.Format = new EF.CustomFormatter();

								dateEdit.EditFormat.FormatString = strEditMask;
								//dateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

								dateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
								dateEdit.EditFormat.Format = new EF.CustomFormatter1();

								dateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(dateEdit_ParseEditValue);
								//col.DataType = typeof(DateTime);
								//dateEdit.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(dateEdit_FormatEditValue);
							
								//col.DefaultValue = "";
							}
							else if ("B" == item_type)		// ����
							{
								col.DataType = typeof(Boolean);
								gridcolumn.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
								if ("1" == item_default_value || "true" == item_default_value.ToLower())
								{
									col.DefaultValue = true;
								}
								else
								{
									col.DefaultValue = false;
								}
							}
							else
							{
								col.DataType = typeof(string);
								gridcolumn.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
								col.DefaultValue = item_default_value;
							}

							gridcolumn.ColumnEdit.Leave += new EventHandler(EF.CustomCols.CustomGridColumnEdit_Leave);
							//gridcolumn.ColumnEdit.EditValueChanged += new EventHandler(EF.CustomCols.CustomGridColumnEdit_EditValueChanged);

							if (form_edit_flag == "0")
							{
								gridcolumn.ColumnEdit.ReadOnly = true;
							}
						}
						dt.Rows.Add();
                        efGrid[i].ShowSelectionColumn = efGrid[i].ShowSelectionColumn;
                        efGrid[i].ShowSelectedColumn = efGrid[i].ShowSelectedColumn;
						efGrid[i].DataSource = dt;
						gridview.BestFitColumns();
						gridview.EndUpdate();
						efGrid[i].EndUpdate();
					}
					return true;
				}
				catch (Exception e)
				{
					//MessageBox.Show(e.Message);
				}
			}
			return false;
 */
		}

		static void dateEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
		{
			if (e.Value is string)
			{
				string strTemp = e.Value.ToString();
				//e.Handled = true;
				try
				{
					DateTime dt = DateTime.Parse(strTemp);
					e.Value = DateTime.ParseExact(strTemp, "yyyyMMddHHmmss", null);
					e.Handled = true;
				}
				catch (Exception ex)
				{
					e.Value = strTemp;
				}
			}
		}
  
	}
}
