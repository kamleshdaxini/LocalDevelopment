using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

    public partial class GroupDetails : System.Web.UI.Page
    {
        // Initialization of Public Variables
        int GroupId;// For Group Id 
        public string UserName;// For Loged in username
        public int LoginUser;// For Loged in userId
        public string Ret;// For return message
       
        /// <summary>
        ///  Page Load Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // To set Selected accordion open 
            Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
            int GroupInd = MasterAcc.SelectedIndex;
            int GroupIndex = Convert.ToInt16(Session["SrNo"]);
            MasterAcc.SelectedIndex = GroupIndex - 1;
            // To select loginuser id and login username
            Login objGroup = new Login();
            objGroup.Start();
            UserName = objGroup.LogedInUser;
            LoginUser = objGroup.LoginUser;
            Ret = objGroup.Ret;
            if (!IsPostBack)
            {
                if (Session["GroupId"] != null)
                {
                    CheckGroupId();
                    GroupId = Convert.ToInt32(Session["GroupId"].ToString());
                }
            }
            else
            {
                if (Session["GroupId"] != null)
                {
                    GroupId = Convert.ToInt32(Session["GroupId"].ToString());
                }

            }
        }
                                         
        /// <summary>
        /// CheckGroupId is a function which is used for Edit functionality
        /// </summary>
        protected void CheckGroupId()
        {
            GroupId = Convert.ToInt32(Session["GroupId"].ToString());
            DataTable DtSelectId = GetGroupDetails(GroupId);
            if (btnSave.Text == "Save")
            {
                if (DtSelectId.Rows.Count > 0)
                {
                    txtGroupName.Text = DtSelectId.Rows[0][1].ToString();
                    txtGroupDesc.Text = DtSelectId.Rows[0][2].ToString();
                    string Status = DtSelectId.Rows[0][3].ToString();
                    if (Status == "True")
                    {
                        ddlGroupStatus.SelectedIndex = 2;
                    }
                    else
                    {
                        ddlGroupStatus.SelectedIndex = 1;
                    }
                    btnSave.Text = "Update";

                }
            }
        }

       /// <summary>
        /// To get details of particular Group ID
       /// </summary>
       /// <param name="GroupId"></param>
       /// <returns></returns>
        private DataTable GetGroupDetails(int GroupId)
        {
            GroupBAL GroupBAL = new GroupBAL();
            DataTable DtGrpDet = new DataTable();
            try
            {
                DtGrpDet = GroupBAL.SelectGroupID(GroupId, LoginUser, Ret);
            }
            catch
            {

            }
            finally
            {
                GroupBAL = null;
            }

            return DtGrpDet;
        }

        /// <summary>
        /// To save and update group details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Status = ddlGroupStatus.SelectedItem.Text;
            bool GroupStatus;
            if (ddlGroupStatus.SelectedItem.Text != "Select")
            {
                if (Status == "Active")
                {
                    GroupStatus = true;
                }
                else
                {
                    GroupStatus = false;
                }
                if (btnSave.Text == "Save")
                {                    
                    if (!Page.IsValid)
                    return;
                    int IntResult = 0;
                    GroupBAL GroupBAL = new GroupBAL();                 
                    string GroupName = txtGroupName.Text;
                    string GroupDesc = txtGroupDesc.Text;
                    if (txtGroupName.Text.Trim() != "")
                    {
                        try
                        {
                            // 'InsertGroup' is Group business Access Layer function called
                            // to insert Group details
                            IntResult = GroupBAL.InsertGroup(GroupName, GroupDesc, GroupStatus, LoginUser, Ret);                           
                            ClearGroupDetails();                           
                            Response.Redirect("GroupList.aspx", false);
                            msgGroup.Msg = "Group submited successfully";
                            msgGroup.showmsg();
                        }
                        catch (Exception ee)
                        {
                            // Duplicate Entry is catched when inserting Group
                            if (ee.Message == "Duplicate Entry")
                            {
                                msgGroup.Msg = "Duplicate Entry!";
                                msgGroup.showmsg();
                                ClearGroupDetails();

                            }
                        }
                        finally
                        {
                            GroupBAL = null;
                        }
                    }

                }
                else if (btnSave.Text == "Update")
                {            
                    int IntResult = 0;
                    GroupBAL GroupBAL = new GroupBAL();                  
                    string GroupName = txtGroupName.Text;
                    string GroupDesc = txtGroupDesc.Text;
                    if (txtGroupName.Text.Trim() != "")
                    {
                        try
                        {
                            // 'UpdateGroup' is Group business Access Layer function called
                            // to update Group details
                            IntResult = GroupBAL.UpdateGroup(GroupId, GroupDesc, GroupStatus, txtGroupName.Text, LoginUser, Ret);
                            ClearGroupDetails();                           
                            Response.Redirect("GroupList.aspx", false);
                            msgGroup.Msg = "Group updated successfully";
                            msgGroup.showmsg();   
                            Session["GroupId"] = null;
                            btnSave.Text = "Save";
                        }
                        catch(Exception ee)
                        {
                            // Duplicate Entry is catched when updating Group
                            if (ee.Message == "Duplicate Entry")
                            {
                                msgGroup.Msg = "Duplicate Entry!";
                                msgGroup.showmsg();                                
                            }
                        }
                        finally
                        {
                            GroupBAL = null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// To Clear data
        /// </summary>
        private void ClearGroupDetails()
        {
            txtGroupName.Text = "";
            txtGroupDesc.Text = "";
            ddlGroupStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// To cancel current operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearGroupDetails();
            Response.Redirect("GroupList.aspx", false);
        }
}
