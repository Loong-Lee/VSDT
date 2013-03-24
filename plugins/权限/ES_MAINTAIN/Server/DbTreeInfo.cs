﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EP
{
    public partial class DbTreeInfo
    {
        static string strSQL =
 " WITH all_tree_name_up (name, fname) "
+ "         AS (SELECT   name, fname "
+ "               FROM   testreeinfo "
+ "              WHERE   fname <> @favorite AND appname = @appname "
+ "             UNION ALL "
+ "             SELECT   testreeinfo.name, testreeinfo.fname "
+ "               FROM   testreeinfo, all_tree_name_up "
+ "              WHERE   all_tree_name_up.fname = testreeinfo.name), "
+ "      all_tree_name_down ( "
+ "         name, "
+ "         fname, "
+ "         description, "
+ "         aclid, "
+ "         resname, "
+ "         treeseq, "
+ "         levell) "
+ "      AS "
+ "         (SELECT   testreeinfo.name, "
+ "                   testreeinfo.fname, "
+ "                   testreeinfo_res.description, "
+ "                   testreeinfo.aclid, "
+ "                   testreeinfo.resname, "
+ "                   testreeinfo.treeseq, "
+ "                   1 "
+ "            FROM   testreeinfo, testreeinfo_res "
+ "           WHERE       testreeinfo.aclid = testreeinfo_res.aclid "
+ "                   AND testreeinfo_res.culture = @culture "
+ "                   AND fname = @root "
+ "                   AND appname = @appname "
+ "          UNION ALL "
+ "          SELECT   testreeinfo.name, "
+ "                   testreeinfo.fname, "
+ "                   testreeinfo_res.description, "
+ "                   testreeinfo.aclid, "
+ "                   testreeinfo.resname, "
+ "                   testreeinfo.treeseq, "
+ "                   all_tree_name_down.levell + 1 "
+ "            FROM   testreeinfo, all_tree_name_down, testreeinfo_res "
+ "           WHERE       testreeinfo.fname = all_tree_name_down.name "
+ "                   AND testreeinfo_res.aclid = testreeinfo.aclid "
+ "                   AND testreeinfo_res.culture = @culture "
+ "                   AND testreeinfo.fname <> @favorite ), "
+ "      available_tree (name, "
+ "                      fname, "
+ "                      description, "
+ "                      aclid, "
+ "                      resname, "
+ "                      levell, "
+ "                      treeseq) "
+ "      AS "
+ "         (SELECT   DISTINCT all_tree_name_down.name, "
+ "                            all_tree_name_down.fname, "
+ "                            all_tree_name_down.description, "
+ "                            all_tree_name_down.aclid, "
+ "                            all_tree_name_down.resname, "
+ "                            all_tree_name_down.levell, "
+ "                            all_tree_name_down.treeseq "
+ "            FROM   all_tree_name_down, all_tree_name_up "
+ "           WHERE   all_tree_name_down.name = all_tree_name_up.name) "
+ "   SELECT   * "
+ "     FROM   available_tree "
+ " ORDER BY   levell, treeseq ";

        public static DataSet f_epestree_inqa(DataSet bcls_rec, string conn)
        {
            //程序用变量
            string strUserid = "";
            string strCompanycode = "";
            string strRoot = "root";
            string strFavorite = "MYFAVORITE";
            string strAppname = "";

            try
            {
                strUserid = "admin";
                strCompanycode = bcls_rec.Tables[0].Rows[0]["COMPANYCODE"].ToString();
                strRoot = bcls_rec.Tables[0].Rows[0]["ROOT"].ToString();
                strFavorite = bcls_rec.Tables[0].Rows[0]["FAVORITE"].ToString();
                strAppname = bcls_rec.Tables[0].Rows[0]["APPNAME"].ToString();

                CDbCommand tree_inqa = new CDbCommand(conn);

                tree_inqa.SetCommandText(strSQL);

                tree_inqa.Parameters.Set("appname", strAppname);
                tree_inqa.Parameters.Set("userid", strUserid);
                tree_inqa.Parameters.Set("root", strRoot);
                tree_inqa.Parameters.Set("favorite", strFavorite);
                tree_inqa.Parameters.Set("culture", "chs");
                tree_inqa.Parameters.Set("companycode", strCompanycode);

                DataTable dt = new DataTable();
                tree_inqa.ExecuteQuery(ref dt);

                DataSet bcls_ret = new DataSet();
                bcls_ret.Tables.Add("MENUTREE");
                bcls_ret.Tables[0].Merge(dt);
                return bcls_ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
