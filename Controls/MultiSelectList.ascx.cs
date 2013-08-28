using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_MultiselectList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {       
      
    }
    /// <summary>
    /// To get and set textbox width
    /// </summary>
    public int txtWidth
    {
        set { txtMultiSelectlist.Width = value; }
        get { return (Int32)txtMultiSelectlist.Width.Value; }
    }
    /// <summary>
    /// To get and set popup panel width
    /// </summary>
    public int panWidth
    {
        set { pnlMultiSelectlist.Width = value; }
        get { return (Int32)pnlMultiSelectlist.Width.Value; }
    }

    /// <summary>
    /// To binf checkboxlist
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="value"></param>
    /// <param name="text"></param>

    public void ChkBind(DataTable DtBind,string value,string text)
    {
        if (DtBind.Rows.Count > 0)
        {
            cblMultiSelectlist.DataSource = DtBind;
            cblMultiSelectlist.DataTextField = text;
            cblMultiSelectlist.DataValueField = value;
            cblMultiSelectlist.DataBind();

        }
        else
        {
            cblMultiSelectlist.DataSource = DtBind;
            cblMultiSelectlist.DataTextField = "text";
            cblMultiSelectlist.DataValueField = "value";
            cblMultiSelectlist.DataBind();
        }
    }
    /// <summary>
    /// To set checkboxlist values to show when updating
    /// </summary>
    /// <param name="DtSelect"></param>
    public void SetValue(DataTable DtSelect)
    {
        string SetName = "";
        for (int j = 0; j < DtSelect.Rows.Count; j++)
        {
            string ChkVal = DtSelect.Rows[j][1].ToString();
            for (int i = 0; i < cblMultiSelectlist.Items.Count; i++)
            {
                if (cblMultiSelectlist.Items[i].Value.ToString() == ChkVal)
                {
                    cblMultiSelectlist.Items[i].Selected = true;
                    SetName += cblMultiSelectlist.Items[i].Text + ",";
                }

            }
        }
        txtMultiSelectlist.Text = SetName.TrimEnd(',');
    }
    /// <summary>
    /// To get checkboxlist values to write in xml
    /// </summary>
    /// <param name="Text"></param>
    /// <param name="Value"></param>
    /// <returns></returns>
    public DataTable GetTable(string Text, string Value)
    {
        DataTable DtTable = new DataTable();
        DataColumn DtText = new DataColumn("Text");
        DataColumn DtValue = new DataColumn("Value");
        DtTable.Columns.Add(DtText);
        DtTable.Columns.Add(DtValue);
        for (int i = 0; i < cblMultiSelectlist.Items.Count; i++)
        {
            if (cblMultiSelectlist.Items[i].Selected)
            {
                DataRow dr = DtTable.NewRow();
                dr["Text"] += cblMultiSelectlist.Items[i].Text;
                dr["Value"] = cblMultiSelectlist.Items[i].Value;
                DtTable.Rows.Add(dr);
            }
        }
        return DtTable;
    }  
    /// <summary>
    /// To show selected checkbox valu in textbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cblMultiSelectlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SelectedName = "";
        for (int i = 0; i < cblMultiSelectlist.Items.Count; i++)
        {
            if (cblMultiSelectlist.Items[i].Selected)
            {
                SelectedName += cblMultiSelectlist.Items[i].Text + ",";
            }
        }

        txtMultiSelectlist.Text = SelectedName.TrimEnd(',');

    }
}