using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

    public partial class RoleDetails : System.Web.UI.Page
    {
        // Initialization of Public Variables
        public  string UserName;// For loged in username
        public  int LoginUser;// For loged in user Id
        public  string Ret;// For return message
        int GroupRoleId,GroupId,RoleId;// For GroupRoleId ,Group Id, Role Id

        /// <summary>
        /// Page Load Method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // To set Selected accordion open 
            Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
            int GroupRoleInd = MasterAcc.SelectedIndex;
            int GroupRoleIndex = Convert.ToInt16(Session["SrNo"]);
            MasterAcc.SelectedIndex = GroupRoleIndex - 1;
            // To select loginuser id and login username
            Login objGroupRole = new Login();
            objGroupRole.Start();
            UserName = objGroupRole.LogedInUser;
            LoginUser = objGroupRole.LoginUser;
            Ret = objGroupRole.Ret;
            if (!Page.IsPostBack)
            {         
                BindRoleddl();
                BindGroupddl();
                if (Session["GroupRoleId"] != null)
                {
                    CheckGroupRoleId();
                    GroupRoleId = Convert.ToInt32(Session["GroupRoleId"].ToString());
                }
            }
            else
            {
                if (Session["GroupRoleId"] != null)
                {
                    GroupRoleId = Convert.ToInt32(Session["GroupRoleId"].ToString());
                }

            }                               
        }

        /// <summary>
        /// CheckGroupRoleId is a function which is used for Edit functionality
        /// </summary>
        protected void CheckGroupRoleId()
        {
            GroupRoleId = Convert.ToInt32(Session["GroupRoleId"].ToString());
            DataTable DtSelectId = GetGroupRoleDetails(GroupRoleId);
            if (btnSave.Text == "Save")
            {
                if (DtSelectId.Rows.Count > 0)
                {
                    ddlGroupName.SelectedValue = DtSelectId.Rows[0][1].ToString();
                    ddlRoleName.SelectedValue = DtSelectId.Rows[0][3].ToString();
                    string Status = DtSelectId.Rows[0][5].ToString();
                    if (Status == "False")
                    {
                        ddlGroupRoleStatus.SelectedIndex = 1;
                    }
                    else if (Status == "True")
                    {
                        ddlGroupRoleStatus.SelectedIndex = 2;
                    }
                    btnSave.Text = "Update";
                }
            }
        }

        /// <summary>
        /// To get Role Details from database
        /// </summary>
        /// <returns></returns>
        private DataTable GetRoleDetails()
        {
            RoleBAL RoleBAL = new RoleBAL();
            DataTable DtRoleDe = new DataTable();
            try
            {
                DtRoleDe = RoleBAL.LoadAllRole(LoginUser, Ret);
            }
            catch
            {

            }
            finally
            {
                RoleBAL = null;
            }

            return DtRoleDe;
        }

        /// <summary>
        /// To get Group Details from database
        /// </summary>
        /// <returns></returns>
        private DataTable GetGroupDetails()
        {
            GroupBAL GroupBAL = new GroupBAL();
            DataTable DtGrpDe = new DataTable();
            try
            {
                DtGrpDe = GroupBAL.LoadAllGroup(LoginUser, Ret);
            }
            catch
            {

            }
            finally
            {
                GroupBAL = null;
            }

            return DtGrpDe;
        }

        /// <summary>
        /// To get Group Role Details from database
        /// </summary>
        /// <param name="GroupRoleId"></param>
        /// <returns></returns>
        private DataTable GetGroupRoleDetails(int GroupRoleId)
        {
            GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();
            DataTable DtGrpRolDe = new DataTable();
            try
            {
                DtGrpRolDe = GroupRoleBAL.SelectGroupRoleID(GroupRoleId, LoginUser, Ret);
            }
            catch
            {

            }
            finally
            {
                GroupRoleBAL = null;
            }

            return DtGrpRolDe;
        }

        /// <summary>
        /// To bind Role dropdown list
        /// </summary>
        private void BindRoleddl()
        {
            DataTable DtRole = GetRoleDetails();
            if (DtRole.Rows.Count > 0 || DtRole != null)
            {
                ddlRoleName.DataSource = DtRole;
                ddlRoleName.DataTextField = "RoleName";
                ddlRoleName.DataValueField = "RoleId";
                ddlRoleName.DataBind();
                ddlRoleName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            }
            else
            {
                ddlGroupName.DataSource = null;
                ddlRoleName.DataTextField = "RoleName";
                ddlRoleName.DataValueField = "RoleId";
                ddlGroupName.DataBind();
                ddlGroupName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            }
        }

        /// <summary>
        /// To bind Group dropdown list
        /// </summary>
        private void BindGroupddl()
        {
            DataTable DtGroup = GetGroupDetails();
            if (DtGroup.Rows.Count > 0 || DtGroup != null)
            {
                ddlGroupName.DataSource = GetGroupDetails();
                ddlGroupName.DataTextField = "GroupName";
                ddlGroupName.DataValueField = "GroupId";
                ddlGroupName.DataBind();
                ddlGroupName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                ddlGroupName.SelectedIndex = 0;
            }
            else
            {
                ddlGroupName.DataSource = null;
                ddlGroupName.DataTextField = "GroupName";
                ddlGroupName.DataValueField = "GroupId";
                ddlGroupName.DataBind();
                ddlGroupName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                ddlGroupName.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// To save and update Group Role Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Status = ddlGroupRoleStatus.SelectedItem.Text;
            GroupId = Convert.ToInt16(ddlGroupName.SelectedValue);
            RoleId = Convert.ToInt16(ddlRoleName.SelectedValue);
            if (Session["GroupRoleId"] != null)
            {
                GroupRoleId = Convert.ToInt32(Session["GroupRoleId"].ToString());
            }
            bool GroupRolestatus = false;
            if (ddlGroupRoleStatus.SelectedItem.Text != "Select")
            {
                if (Status == "Active")
                {
                    GroupRolestatus = true;
                }
                else if (Status == "InActive")
                {
                    GroupRolestatus = false;
                }
                if (btnSave.Text == "Save")
                {
                    int IntResult = 0;
                    GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();
                    try
                    {
                        // 'InsertGroupRole' is GroupRole business Access Layer function called
                        // to insert GroupRole details
                        IntResult = GroupRoleBAL.InsertGroupRole(GroupId, RoleId, GroupRolestatus, LoginUser, Ret);
                        ClearGroupRole();
                        msgGroupRole.Msg = "Group Role details submitted successfully";
                        msgGroupRole.showmsg();
                    }
                    catch (Exception ee)
                    {
                        // Duplicate Entry is catched when inserting GroupRole       
                        if (ee.Message == "Duplicate Entry")
                        {
                            msgGroupRole.Msg = "Duplicate Entry!";
                            msgGroupRole.showmsg();
                            ClearGroupRole();
                        }
                    }
                    finally
                    {
                        GroupRoleBAL = null;
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    int IntResult = 0;
                    GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();
                    try
                    {
                        // 'UpdateGroupRole' is GroupRole business Access Layer function called
                        // to update GroupRole details
                        IntResult = GroupRoleBAL.UpdateGroupRole(GroupRoleId, GroupRolestatus, LoginUser, Ret);
                        ClearGroupRole();
                        Session["GroupId"] = null;
                        btnSave.Text = "Save";
                        msgGroupRole.Msg = "Group Role updated successfully";
                        msgGroupRole.showmsg();
                        //Response.Redirect("GroupRoleList.aspx",false);                                                                          
                    }
                    catch (Exception ee)
                    {
                        // Duplicate Entry is catched when updating GroupRole
                        if (ee.Message == "Duplicate Entry")
                        {
                            msgGroupRole.Msg = "Duplicate Entry!";
                            msgGroupRole.showmsg();
                        }
                    }
                    finally
                    {
                        GroupRoleBAL = null;
                    }
                }
            }
        }

        /// <summary>
        /// Clear data
        /// </summary>
        private void ClearGroupRole()
        {
            ddlRoleName.SelectedIndex = 0;
            ddlGroupName.SelectedIndex = 0;
            ddlGroupRoleStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// To cancel current operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearGroupRole();
            Response.Redirect("GroupRoleList.aspx", false);
        }
}
